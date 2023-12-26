using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using OCR_Camera_Printer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Threading;

namespace OCR_Camera_Printer.Controller
{
    public partial class MainViewModel : ViewModelBase
    {

        [JsonIgnore]
        private ObservableCollection<string> _CollectionHeaderCsv;
        public ObservableCollection<string> CollectionHeaderCsv
        {
            get { return _CollectionHeaderCsv; }
            set { _CollectionHeaderCsv = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        private int[] _SelectedColumn = new int[] { 0, 0, 0, 0, 0 };
        public int[] SelectedColumn
        {
            get { return _SelectedColumn; }
            set { _SelectedColumn = value; OnPropertyChanged(); }
        }

        private string _DBFilePath;
        public string DBFilePath
        {
            get { return _DBFilePath; }
            set { _DBFilePath = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        private DataView _DBDataView;
        [JsonIgnore]
        public DataView DBDataView
        {
            get { return _DBDataView; }
            set { _DBDataView = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        private int _TotalRecordDb;
        public int TotalRecordDb
        {
            get { return _TotalRecordDb; }
            set { _TotalRecordDb = value; OnPropertyChanged(); }
        }
        #region Camera

        private string _IPAddressWithPort = "192.168.1.42:80";
        public string IPAddressWithPort
        {
            get { return _IPAddressWithPort; }
            set { _IPAddressWithPort = value; OnPropertyChanged(); }
        }

        private string _username = "admin";
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        private int _tabIndex;

        public int TabIndex
        {
            get { return _tabIndex; }
            set { _tabIndex = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        List<HSR> resultList = new List<HSR>();

        public string ObjectName1_Temp { get; set; }
        public string ObjectName2_Temp { get; set; }
        public string ObjectName3_Temp { get; set; }
        public string ObjectName4_Temp { get; set; }
        public string ObjectName5_Temp { get; set; }

        private string _objectName1 = "Object1";
        public string ObjectName1
        {
            get { return _objectName1; }
            set { _objectName1 = value; OnPropertyChanged(); }
        }
        private string _objectName2 = "Object2";
        public string ObjectName2
        {
            get { return _objectName2; }
            set { _objectName2 = value; OnPropertyChanged(); }
        }
        private string _objectName3 = "Object3";
        public string ObjectName3
        {
            get { return _objectName3; }
            set { _objectName3 = value; OnPropertyChanged(); }
        }
        private string _objectName4 = "Object4";
        public string ObjectName4
        {
            get { return _objectName4; }
            set { _objectName4 = value; OnPropertyChanged(); }
        }
        private string _objectName5 = "Object5";
        public string ObjectName5
        {
            get { return _objectName5; }
            set { _objectName5 = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        public List<string> savedListRead = new List<string>();

        [JsonIgnore]
        private string _CameraData;
        public string CameraData
        {
            get { return _CameraData; }
            set { _CameraData = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        private ObservableCollection<DataList> _rawDataList = new ObservableCollection<DataList>();
        public ObservableCollection<DataList> RawDataList
        {
            get { return _rawDataList; }
            set { _rawDataList = value; OnPropertyChanged(); }
        }

        private string _MessTitle;
        public string MessTitle
        {
            get { return _MessTitle; }
            set { _MessTitle = value; OnPropertyChanged(); }
        }


        private string _MessContent;
        public string MessContent
        {
            get { return _MessContent; }
            set { _MessContent = value; OnPropertyChanged(); }
        }

        // total raw data
        [JsonIgnore]
        private int _TotalCount;
        public int TotalCount
        {
            get { return _TotalCount; }
            set { _TotalCount = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        private int _GoodCount;
        public int GoodCount
        {
            get { return _GoodCount; }
            set { _GoodCount = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        private int _NotFoundCount;
        public int NotFoundCount
        {
            get { return _NotFoundCount; }
            set { _NotFoundCount = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        private int _DupCount;
        public int DupCount
        {
            get { return _DupCount; }
            set { _DupCount = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        private int _FailCount;
        public int FailCount
        {
            get { return _FailCount; }
            set { _FailCount = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        private int _CameraConnStat;
        public int CameraConnStat
        {
            get { return _CameraConnStat; }
            set { _CameraConnStat = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        private List<ObjectCompare> _ListCompare = new List<ObjectCompare>();

        [JsonIgnore]
        public List<ObjectCompare> ListCompare
        {
            get { return _ListCompare; }
            set { _ListCompare = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        List<(int, string)> desireDataList = new List<(int, string)>();

        [JsonIgnore]
        ObjectCompare[] listcmp;

        [JsonIgnore]
        private ObservableCollection<DataVerified> _ListVerified = new ObservableCollection<DataVerified>();
        [JsonIgnore]
        public ObservableCollection<DataVerified> ListVerified
        {
            get { return _ListVerified; }
            set { _ListVerified = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        private ObservableCollection<DataVerified> _GoodList = new ObservableCollection<DataVerified>();
        public ObservableCollection<DataVerified> GoodList
        {
            get => _GoodList;
            set { _GoodList = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        private ObservableCollection<DataVerified> _FailList = new ObservableCollection<DataVerified>();
        public ObservableCollection<DataVerified> FailList
        {
            get => _FailList;
            set { _FailList = value; OnPropertyChanged(); }
        }

        private bool _EnO1;
        public bool EnO1
        {
            get { return _EnO1; }
            set { _EnO1 = value; OnPropertyChanged(); }
        }

        private bool _EnO2;
        public bool EnO2
        {
            get { return _EnO2; }
            set { _EnO2 = value; OnPropertyChanged(); }
        }

        private bool _EnO3;
        public bool EnO3
        {
            get { return _EnO3; }
            set { _EnO3 = value; OnPropertyChanged(); }
        }

        private bool _EnO4;
        public bool EnO4
        {
            get { return _EnO4; }
            set { _EnO4 = value; OnPropertyChanged(); }
        }

        private bool _EnO5;
        public bool EnO5
        {
            get { return _EnO5; }
            set { _EnO5 = value; OnPropertyChanged(); }
        }
        private bool _StartEnable;

        public bool StartEnable
        {
            get { return _StartEnable; }
            set { _StartEnable = value; OnPropertyChanged(); }

        }

        private bool _StopEnable = true;

        public bool StopEnable
        {
            get { return _StopEnable; }
            set { _StopEnable = value; OnPropertyChanged(); }
        }

        private bool _IsCode1;

        public bool IsCode1
        {
            get { return _IsCode1; }
            set { _IsCode1 = value; OnPropertyChanged(); }
        }
        private bool _IsCode2;

        public bool IsCode2
        {
            get { return _IsCode2; }
            set { _IsCode2 = value; OnPropertyChanged(); }
        }
        private bool _IsCode3;

        public bool IsCode3
        {
            get { return _IsCode3; }
            set { _IsCode3 = value; OnPropertyChanged(); }
        }
        private bool _IsCode4;

        public bool IsCode4
        {
            get { return _IsCode4; }
            set { _IsCode4 = value; OnPropertyChanged(); }
        }
        private bool _IsCode5;

        public bool IsCode5
        {
            get { return _IsCode5; }
            set { _IsCode5 = value; OnPropertyChanged(); }
        }

        private int _ColumnCount;

        public int ColumnCount
        {
            get { return _ColumnCount; }
            set { _ColumnCount = value; OnPropertyChanged(); }
        }

        private string _DbName;

        public string DbName
        {
            get { return _DbName; }
            set { _DbName = value; OnPropertyChanged(); }
        }


        private int _SoftOnline;

        public int SoftOnline
        {
            get { return _SoftOnline; }
            set { _SoftOnline = value; OnPropertyChanged(); }
        }

        private string _TextSensorSts;

        public string TextSensorSts
        {
            get { return _TextSensorSts; }
            set { _TextSensorSts = value; OnPropertyChanged(); }
        }


        [JsonIgnore]
        public static Func<ChartPoint, string> PointLabel { get; set; }

        [JsonIgnore]
        private SeriesCollection _SeriesCollection;
        [JsonIgnore]
        public SeriesCollection SeriesCollection
        {
            get { return _SeriesCollection; }
            set { _SeriesCollection = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        public double GoodPercent { get; set; }
        [JsonIgnore]
        public double FailPercent { get; set; }

        private int _Debounce;

        public int Debounce
        {
            get { return _Debounce; }
            set { _Debounce = value; OnPropertyChanged(); }
        }


        internal void InitChart()
        {
            PointLabel = chartPoint => string.Format("{1:P}", chartPoint.Y, chartPoint.Participation);
            InitializeChartData();
            // Update Chart
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void InitializeChartData()
        {
            SeriesCollection = new SeriesCollection
        {
            new PieSeries
            {
                Title = "Good",
                Values = new ChartValues<double> { 0 },
                DataLabels = true,
                LabelPoint = PointLabel

            },
            new PieSeries
            {
                Title = "Fail",
                Values = new ChartValues<double> { 0 },
                DataLabels = true,
                LabelPoint = PointLabel
            },

        };
        }
        public void UpdateChartValues(double goodPercent, double failPercent)
        {
            SeriesCollection[0].Values[0] = goodPercent;
            SeriesCollection[1].Values[0] = failPercent;
        }
        private void CalcPercent()
        {
            Application.Current.Dispatcher?.Invoke(() =>
            {
                double total = FailCount + GoodCount;

                GoodPercent = double.Parse(GoodCount.ToString()) / total;
                FailPercent = double.Parse(FailCount.ToString()) / total;
                if (total == 0)
                {
                    GoodPercent = 1;
                    FailPercent = 0;
                }

            });
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            CalcPercent();
            UpdateChartValues(GoodPercent, FailPercent);
        }

       
        #endregion
    }
}
