using Cognex.InSight.Remoting.Serialization;
using Cognex.InSight.Web;
using Cognex.InSight.Web.Controls;
using Cognex.SimpleCogSocket;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OCR_Camera_Printer.Models;
using OCR_Camera_Printer.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace OCR_Camera_Printer.Controller
{
    public partial class MainViewModel
    {
        private CvsInSight _inSight;
        private bool _camConnectionStatus;
        private CvsDisplay _cvsDisplay;
        readonly string notFoundStr = "Not Found";
        readonly string duplicateStr = "Duplicate";
        readonly string goodStr = "Good";
        public MainViewModel()
        {

            _inSight = new CvsInSight();
            RegEventCam();
            _ = CheckStatusAsync();
        }
        internal void FirstLoadFrm()
        {
            var oldObj = LoadObjectFromFile();
            if (oldObj != null)
            {
                IPAddressWithPort = oldObj.IPAddressWithPort;
                DBFilePath = oldObj.DBFilePath;
                ObjectName1 = oldObj.ObjectName1;
                FirstLoadDB();
            }

            InitChart();

        }
        internal void RegEventCam()
        {
            _inSight.ResultsChanged += _inSight_ResultsChanged;
        }
        private async Task CheckStatusAsync()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            AsyncTimer timer = new AsyncTimer(
                async () =>
                {
                    await Task.Run(() =>
                    {
                        if (_inSight != null && _inSight.Connected)
                        {
                            CameraConnStat = _inSight.Connected == true ? 1 : 0;
                            SoftOnline = _inSight.SoftOnline ? 1 : 0;
                        }
                        else
                        {
                            CameraConnStat = 0;
                        }
                        ConditionCheck();
                    });
                },
                1000,
                cts.Token);

            await timer.StartAsync();
        }

        private void ConditionCheck()
        {
            int idO1 = EnO1 ? 1 : 0;
            int idO2 = EnO2 ? 1 : 0;
            int idO3 = EnO3 ? 1 : 0;
            int idO4 = EnO4 ? 1 : 0;
            int idO5 = EnO5 ? 1 : 0;
            int tt = idO1 + idO2 + idO3 + idO4 + idO5;
            bool haveDB = File.Exists(DBFilePath);
            bool isConnected = CameraConnStat == 1;
            if (haveDB && !isConnected && tt > 0)
            {
                StartEnable = true;
            }
            else
            {
                StartEnable = false;
            }
            if (isConnected)
            {
                StartEnable = false;
                StopEnable = true;
            }
            if (!isConnected && !StartEnable)
            {
                StopEnable = true;
            }
        }
        private void GetCompareList()
        {
            int idO1 = EnO1 ? 1 : 0;
            int idO2 = EnO2 ? 1 : 0;
            int idO3 = EnO3 ? 1 : 0;
            int idO4 = EnO4 ? 1 : 0;
            int idO5 = EnO5 ? 1 : 0;
            int tt = idO1 + idO2 + idO3 + idO4 + idO5;

            if (tt > 0)
            {
                listcmp = new ObjectCompare[tt];
                for (int i = 0; i < tt; i++)
                {
                    try
                    {
                        listcmp[i] = new ObjectCompare
                        {
                            ObjectData = desireDataList[i].ToString(),
                            IndexColumn = SelectedColumn[i]
                        };
                    }
                    catch (Exception)
                    {

                        listcmp[i] = new ObjectCompare
                        {
                            ObjectData = "",
                            IndexColumn = 0
                        };
                    }

                }
            }
        }

        internal void UpdateCompareList()
        {
            ListCompare.Clear();
            for (int j = 0; j < desireDataList.Count; j++)
            {
                if (!ListCompare.Contains(listcmp[j]))
                {
                    ListCompare.Add(listcmp[j]);
                }
            }
        }

        internal async void StopProccess()
        {
            if (_inSight.Connected)
            {
                //GoOfflineCam();
                //SoftOnline = 0;
                await _inSight.Disconnect();
            }
        }
        internal async void ConnectFirst(CvsDisplay cvsDisplay)
        {
            _cvsDisplay= cvsDisplay;
            try
            {
                cvsDisplay.SetInSight(_inSight);
                var sessionInfo = new HmiSessionInfo
                {
                    SheetName = "Inspection",
                    CellNames = new string[1] { "A0:Z599" },
                    EnableQueuedResults = true, 
                    IncludeCustomView = true
                };
                await _inSight.Connect(IPAddressWithPort, Username, Password, sessionInfo);
                await cvsDisplay.OnConnected();
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check IP !", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #region InsightEvent

        private async void _inSight_ResultsChanged(object sender, EventArgs e)
        {
            int state = 0;
            try
            {
                if (!isManual)
                {
                    isManual = true;
                }
                else
                {
                    //Convert Json => Object
                    JToken results = _inSight.Results;
                    JObject myObject = results.ToObject<JObject>();
                    JToken d = myObject["cells"];
                    string jsonString = d.ToString();

                    if (myObject != null && jsonString != "")
                    {
                        resultList = JsonConvert.DeserializeObject<List<HSR>>(jsonString);
                        desireDataList = GetDesireData().ToList();
                        desireDataList.Sort();
                        GetCompareList();
                        UpdateCompareList();
                        state = CompareColumnWithObject(ListCompare);
                        isManual = state == 1;

                        // Show string data in main page
                        if (desireDataList != null)
                        {
                            CameraData = "";
                            int i = 0;
                            foreach (var item in desireDataList)
                            {
                                if (i < desireDataList.Count)
                                    CameraData += item.Item2.ToString() + ";";
                                if (i == desireDataList.Count - 1)
                                {
                                    CameraData = CameraData.Substring(0, CameraData.Length - 1);
                                    // Add to data raw list
                                    await Task.Run(() => // Update difference Ui Thread
                                     {
                                         DataList tempDate = new DataList
                                         {
                                             StrData = CameraData,
                                             ReadDateTime = DateTime.Now
                                         };
                                         Application.Current.Dispatcher.Invoke(() =>
                                         {
                                             RawDataList.Add(tempDate);
                                         });
                                     });
                                    TotalCount = RawDataList.Count;
                                }
                                i++;
                            }
                        }
                    }
                }
                await _cvsDisplay.UpdateResults();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
            finally
            {
                await Task.Run(() =>
                 {
                     if (state != 1)
                     {
                         ErrorTriggerManual();
                     }
                 });
            }
        }

        private List<(int, string)> GetDesireData()
        {
            try
            {
                // Find Data by Pattern Name (on camera)
                List<(int, string)> listData = new List<(int, string)>();
                List<HSR> desireList = new List<HSR>();
                if (EnO1)
                {
                    HSR objectData1 = resultList.FirstOrDefault(x => x.Name != null && x.Name.Contains(ObjectName1_Temp));
                    if (objectData1 != null)
                    {
                        desireList.Add(objectData1);
                        listData.Add((1, objectData1.Data.ToString()));
                    }
                }
                if (EnO2)
                {
                    HSR objectData2 = resultList.FirstOrDefault(x => x.Name != null && x.Name.Contains(ObjectName2_Temp));
                    if (objectData2 != null)
                    {
                        desireList.Add(objectData2);
                        listData.Add((2, objectData2.Data.ToString()));
                    }
                }

                if (EnO3)
                {
                    HSR objectData3 = resultList.FirstOrDefault(x => x.Name != null && x.Name.Contains(ObjectName3_Temp));
                    if (objectData3 != null)
                    {
                        desireList.Add(objectData3);
                        listData.Add((3, objectData3.Data.ToString()));
                    }
                }

                if (EnO4)
                {
                    HSR objectData4 = resultList.FirstOrDefault(x => x.Name != null && x.Name.Contains(ObjectName4_Temp));
                    if (objectData4 != null)
                    {
                        desireList.Add(objectData4);
                        listData.Add((4, objectData4.Data.ToString()));
                    }

                }

                if (EnO5)
                {
                    HSR objectData5 = resultList.FirstOrDefault(x => x.Name != null && x.Name.Contains(ObjectName5_Temp));
                    if (objectData5 != null)
                    {
                        desireList.Add(objectData5);
                        listData.Add((5, objectData5.Data.ToString()));
                    }
                }

                return listData;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void _inSight_PreviewMessage(object sender, MessagePayloadPreviewEventArgs e)
        {
        }
        #endregion

        #region Get_Column_Database

        internal List<string> GetCsvHeaders(string csvFilePath)
        {
            try
            {
                var headers = new List<string>();
                using (var reader = new StreamReader(csvFilePath))
                {
                    string firstLine = reader.ReadLine();
                    if (!string.IsNullOrEmpty(firstLine))
                    {
                        headers.AddRange(firstLine.Split(',', ';'));
                    }
                }
                ColumnCount = headers.Count;
                return headers;
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal void ExportToCsv(List<DataVerified> data)
        {
            try
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string newFolderPath = Path.Combine(documentsPath, "LogDataRCVM", "ExportData");
                if (!Directory.Exists(newFolderPath))
                {
                    Directory.CreateDirectory(newFolderPath);
                }
                var filename = "backupdata" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
                string filePath = newFolderPath + @"\" + filename;

                var sb = new StringBuilder();
                var propertyInfos = typeof(DataVerified).GetProperties();
                sb.AppendLine(string.Join(",", propertyInfos.Select(p => p.Name)));

                foreach (var item in data)
                {
                    var values = propertyInfos.Select(p => p.GetValue(item, null)?.ToString());
                    sb.AppendLine(string.Join(",", values));
                }
                File.WriteAllText(filePath, sb.ToString());
            }
            catch (Exception)
            {
            }
        }
        private void SaveObjectToFile()
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(MainWindow.MainViewModelIns, Formatting.Indented);
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string newFolderPath = Path.Combine(documentsPath, "LogDataRCVM", "Config");
                if (!Directory.Exists(newFolderPath))
                {
                    Directory.CreateDirectory(newFolderPath);
                }
                var filename = "configfile.json";
                string filePath = newFolderPath + @"\" + filename;

                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception)
            {
            }

        }
        internal MainViewModel LoadObjectFromFile()
        {
            try
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string newFolderPath = Path.Combine(documentsPath, "LogDataRCVM", "Config");
                if (!Directory.Exists(newFolderPath))
                {
                    Directory.CreateDirectory(newFolderPath);
                }
                var filename = "configfile.json";
                string filePath = newFolderPath + @"\" + filename;

                string jsonString = File.ReadAllText(filePath);

                return JsonConvert.DeserializeObject<MainViewModel>(jsonString);
            }
            catch (Exception)
            {
                return null;
            }

        }
        internal async void GetFilePath()
        {
            var openFileDialog = new System.Windows.Forms.OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                RestoreDirectory = true
            };
            openFileDialog.ShowDialog();
            if (File.Exists(openFileDialog.FileName))
            {
                CollectionHeaderCsv = new ObservableCollection<string>(GetCsvHeaders(openFileDialog.FileName));
                DBFilePath = openFileDialog.FileName;
                DbName = Path.GetFileName(DBFilePath);
                await LoadCsvIntoDataGrid(DBFilePath);
            }
        }
        private async void FirstLoadDB()
        {
            if (File.Exists(DBFilePath))
            {
                CollectionHeaderCsv = new ObservableCollection<string>(GetCsvHeaders(DBFilePath));
                DbName = Path.GetFileName(DBFilePath);
                await LoadCsvIntoDataGrid(DBFilePath);
            }
        }

        private async Task LoadCsvIntoDataGrid(string csvFilePath)
        {
            try
            {

                var dataTab = await Task.Run(() =>
                {
                    var dataTable = new DataTable();
                    using (var parser = new TextFieldParser(csvFilePath))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.SetDelimiters(",");
                        if (!parser.EndOfData)
                        {
                            string[] fields = parser.ReadFields();
                            foreach (string field in fields)
                            {
                                dataTable.Columns.Add(field);
                            }
                        }
                        while (!parser.EndOfData)
                        {
                            string[] values = parser.ReadFields();
                            dataTable.Rows.Add(values);
                        }
                    }
                    return dataTable;
                });
                Dispatcher.CurrentDispatcher.Invoke(() =>
                {
                    DBDataView = dataTab.DefaultView;
                    TotalRecordDb = DBDataView.Count;
                });
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Database Not Found", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public class ObjectCompare
        {
            public int ObjectIndex { get; set; }
            public string ObjectData { get; set; }
            public int IndexColumn { get; set; }
        }
        private string GetValueData(string input)
        {

            string[] parts = input.Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
            return parts[1].Trim();
        }
        internal int CompareColumnWithObject(List<ObjectCompare> objectNameList)
        {
            VerifiedStatus VerifyStatus = VerifiedStatus.NotFound;
            string stringResData = "";
            string[] lines = File.ReadAllLines(DBFilePath).Skip(1).ToArray();
            bool stateChecked = false;
            int countTrue = 0;
            ObjectCompare curObjectCmp;
            foreach (string line in lines)
            {
                stringResData = ""; // reset

                string[] columns = line.Split(',', ';');
                if (columns != null && columns.Length > 0)
                {
                    foreach (var obj in objectNameList)
                    {
                        for (int i = 0; i < objectNameList.Count; i++)
                        {
                            stringResData += GetValueData(objectNameList[i].ObjectData) + ";"; // save string data
                            if (i == objectNameList.Count - 1)
                            {
                                stringResData = stringResData.Substring(0, stringResData.Length - 1);
                            }
                        }

                        if (GetValueData(obj.ObjectData) == columns[obj.IndexColumn])
                        {
                            stateChecked = true;
                            curObjectCmp = obj;
                        }
                        else
                        {
                            stateChecked = false;
                            curObjectCmp = null;
                            break;
                        }
                    }
                    if (stateChecked)
                    {
                        if (savedListRead != null && !savedListRead.Contains(stringResData))
                        {
                            countTrue++;
                            savedListRead.Add(stringResData);
                        }
                        else
                        {
                            countTrue = -1;
                        }
                    }
                }
            }
            if (countTrue == 0)
            {
                NotFoundCount++;
                FailCount = NotFoundCount + DupCount;
                VerifyStatus = VerifiedStatus.NotFound;
                ClassificationList(VerifyStatus, stringResData);
                WriteLog(stringResData + "-" + notFoundStr);
                return 0; //not found

            }
            if (countTrue > 1)
            {
                return 2;// duplicate in list
            }
            if (countTrue == -1)
            {
                DupCount++;
                FailCount = NotFoundCount + DupCount;
                VerifyStatus = VerifiedStatus.Duplicate;
                ClassificationList(VerifyStatus, stringResData);
                WriteLog(stringResData + "-" + duplicateStr);
                return -1; // duplicates the previous list
            }
            if (countTrue == 1)
            {
                GoodCount++;
                VerifyStatus = VerifiedStatus.Good;
                ClassificationList(VerifyStatus, stringResData);
                WriteLog(stringResData + "-" + goodStr);
                return 1; // satisfy the condition
            }

            return 0;

        }

        enum VerifiedStatus
        {
            NotFound,
            Duplicate,
            Good
        }

        private void ClassificationList(VerifiedStatus sts, string data)
        {
            string stsTxt = "";
            if (sts == VerifiedStatus.NotFound)
            {
                stsTxt = notFoundStr;
            }
            if (sts == VerifiedStatus.Duplicate)
            {
                stsTxt = duplicateStr;
            }
            if (sts == VerifiedStatus.Good)
            {
                stsTxt = goodStr;
            }

            ListVerified.Add(new DataVerified
            {
                StrData = data,
                VerifiedStatus = stsTxt,
                ReadDateTime = DateTime.Now
            });
            IEnumerable<DataVerified> tempGoodList = ListVerified.Where(x => x.VerifiedStatus == goodStr);
            IEnumerable<DataVerified> tempFailList = ListVerified.Where(y => y.VerifiedStatus == notFoundStr || y.VerifiedStatus == duplicateStr);
            GoodList = new ObservableCollection<DataVerified>(tempGoodList);
            FailList = new ObservableCollection<DataVerified>(tempFailList);
        }

        internal async void IsPortOpen()
        {
            await Task.Run(() =>
             {
                 try
                 {
                     var myPing = new Ping();
                     var reply = myPing.Send(IPAddressWithPort.Split(':')[0]);
                     if (reply != null)
                     {
                         if (reply.Status == IPStatus.Success)
                         {
                             System.Windows.MessageBox.Show("Ping IP and Port successfully !", "Connection Check", MessageBoxButton.OK, MessageBoxImage.Information);

                         }
                         else
                         {
                             System.Windows.MessageBox.Show("Fail IP and Port", "Connection Check", MessageBoxButton.OK, MessageBoxImage.Error);
                         }
                     }
                 }
                 catch
                 {
                     System.Windows.MessageBox.Show("Fail IP and Port", "Connection Check", MessageBoxButton.OK, MessageBoxImage.Error);
                 }
             });

        }

        internal void AutoAddSuffixes()
        {
            try
            {
                SaveObjectToFile();
                string suf_code = ".Result00.String";
                string suf_text = ".ReadText";

                ObjectName1_Temp = ObjectName1.Replace(suf_code, "");
                ObjectName1_Temp = ObjectName1.Replace(suf_text, "");

                ObjectName2_Temp = ObjectName2.Replace(suf_code, "");
                ObjectName2_Temp = ObjectName2.Replace(suf_text, "");

                ObjectName3_Temp = ObjectName3.Replace(suf_code, "");
                ObjectName3_Temp = ObjectName3.Replace(suf_text, "");

                ObjectName4_Temp = ObjectName4.Replace(suf_code, "");
                ObjectName4_Temp = ObjectName4.Replace(suf_text, "");

                ObjectName5_Temp = ObjectName5.Replace(suf_code, "");
                ObjectName5_Temp = ObjectName5.Replace(suf_text, "");

                if (ObjectName1_Temp != null)
                {
                    if (IsCode1)
                    {
                        if (ObjectName1_Temp.EndsWith(suf_code))
                        {
                            // If already exists, update only the non-suffix part
                            int suffixPosition = ObjectName1_Temp.LastIndexOf(suf_code);
                            ObjectName1_Temp = ObjectName1_Temp.Substring(0, suffixPosition);
                        }
                        ObjectName1_Temp += suf_code;
                    }
                    else
                    {
                        if (ObjectName1_Temp.EndsWith(suf_text))
                        {
                            // If already exists, update only the non-suffix part
                            int suffixPosition = ObjectName1_Temp.LastIndexOf(suf_text);
                            ObjectName1_Temp = ObjectName1_Temp.Substring(0, suffixPosition);
                        }
                        ObjectName1_Temp += suf_text;

                    }
                }
                if (ObjectName2_Temp != null)
                {
                    if (IsCode2)
                    {
                        if (ObjectName2_Temp.EndsWith(suf_code))
                        {
                            // If already exists, update only the non-suffix part
                            int suffixPosition = ObjectName2_Temp.LastIndexOf(suf_code);
                            ObjectName2_Temp = ObjectName2_Temp.Substring(0, suffixPosition);
                        }
                        ObjectName2_Temp += suf_code;
                    }
                    else
                    {
                        if (ObjectName2_Temp.EndsWith(suf_text))
                        {
                            // If already exists, update only the non-suffix part
                            int suffixPosition = ObjectName2_Temp.LastIndexOf(suf_text);
                            ObjectName2_Temp = ObjectName2_Temp.Substring(0, suffixPosition);
                        }
                        ObjectName2_Temp += suf_text;
                    }
                }

                if (ObjectName3_Temp != null)
                {
                    if (IsCode3)
                    {
                        if (ObjectName3_Temp.EndsWith(suf_code))
                        {
                            // If already exists, update only the non-suffix part
                            int suffixPosition = ObjectName3_Temp.LastIndexOf(suf_code);
                            ObjectName3_Temp = ObjectName3_Temp.Substring(0, suffixPosition);
                        }
                        ObjectName3_Temp += suf_code;
                    }
                    else
                    {
                        if (ObjectName3_Temp.EndsWith(suf_text))
                        {
                            // If already exists, update only the non-suffix part
                            int suffixPosition = ObjectName3_Temp.LastIndexOf(suf_text);
                            ObjectName3_Temp = ObjectName3_Temp.Substring(0, suffixPosition);
                        }
                        ObjectName3_Temp += suf_text;
                    }
                }

                if (ObjectName4_Temp != null)
                {
                    if (IsCode4)
                    {
                        if (ObjectName4_Temp.EndsWith(suf_code))
                        {
                            // If already exists, update only the non-suffix part
                            int suffixPosition = ObjectName4_Temp.LastIndexOf(suf_code);
                            ObjectName4_Temp = ObjectName4_Temp.Substring(0, suffixPosition);
                        }
                        ObjectName4_Temp += suf_code;
                    }
                    else
                    {
                        if (ObjectName4_Temp.EndsWith(suf_text))
                        {
                            // If already exists, update only the non-suffix part
                            int suffixPosition = ObjectName4_Temp.LastIndexOf(suf_text);
                            ObjectName4_Temp = ObjectName4_Temp.Substring(0, suffixPosition);
                        }
                        ObjectName4_Temp += suf_text;
                    }
                }

                if (ObjectName5_Temp != null)
                {
                    if (IsCode5)
                    {
                        if (ObjectName5_Temp.EndsWith(suf_code))
                        {
                            // If already exists, update only the non-suffix part
                            int suffixPosition = ObjectName5_Temp.LastIndexOf(suf_code);
                            ObjectName5_Temp = ObjectName5_Temp.Substring(0, suffixPosition);
                        }
                        ObjectName5_Temp += suf_code;
                    }
                    else
                    {
                        if (ObjectName5_Temp.EndsWith(suf_text))
                        {
                            // If already exists, update only the non-suffix part
                            int suffixPosition = ObjectName5_Temp.LastIndexOf(suf_text);
                            ObjectName5_Temp = ObjectName5_Temp.Substring(0, suffixPosition);
                        }
                        ObjectName5_Temp += suf_text;
                    }
                }
            }
            catch (Exception)
            {
            }
        }


        private void WriteLog(string message)
        {
            try
            {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string newFolderPath = Path.Combine(documentsPath, "LogDataRCVM");
                if (!Directory.Exists(newFolderPath))
                {
                    Directory.CreateDirectory(newFolderPath);
                }
                var filename = "logfile" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                string filePath = newFolderPath + @"\" + filename;
                File.AppendAllText(filePath, $"{DateTime.Now}: {message}\n");

            }
            catch (Exception)
            {
            }

        }

        internal async void GoOnlineCam()
        {
            if (_inSight.Connected && !_inSight.SoftOnline)
            {
                try
                {
                    await _inSight.SetSoftOnlineAsync(true);


                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("Error setting soft online. Verify that ISE is not connected.");
                }
            }
        }

        internal async void GoOfflineCam()
        {
            if (_inSight.Connected && _inSight.SoftOnline)
            {
                try
                {
                    await _inSight.SetSoftOnlineAsync(!_inSight.SoftOnline);

                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("Error setting soft online. Verify that ISE is not connected.");
                }
            }
        }

        public bool isManual { get; set; } = true;
        internal async void ErrorTriggerManual()
        {

            if (_inSight.Connected && !isManual)
            {
                try
                {
                    await _inSight.ManualAcquire();
                    await Task.Delay(Debounce);
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("Error sending manual trigger");
                }
            }

        }

        #endregion
    }
}
