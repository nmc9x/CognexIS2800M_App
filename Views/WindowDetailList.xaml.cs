using OCR_Camera_Printer.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OCR_Camera_Printer.Datatype;
using System.Reflection;
using System.Web.UI;

namespace OCR_Camera_Printer.Views
{
    /// <summary>
    /// Interaction logic for WindowDetailList.xaml
    /// </summary>
    public partial class WindowDetailList : Window
    {
        private CommonDatatype.DataGridResItemSrcId _id;
        public WindowDetailList(CommonDatatype.DataGridResItemSrcId id)
        {
            InitializeComponent();
            DataContext = MainWindow.MainViewModelIns;
            _id = id;
            switch (id)
            {
                case CommonDatatype.DataGridResItemSrcId.Total:
                    DataGrid1.ItemsSource = MainWindow.MainViewModelIns.RawDataList;
                    
                    LabelTitle.Content = "Total List";
                    BtnExp.Visibility = Visibility.Visible;
                    break;
                case CommonDatatype.DataGridResItemSrcId.Good:
                    DataGrid1.ItemsSource = MainWindow.MainViewModelIns.GoodList;
                    LabelTitle.Content = "Good List";
                    BtnExp.Visibility = Visibility.Collapsed;
                    break;
                case CommonDatatype.DataGridResItemSrcId.Fail:
                    DataGrid1.ItemsSource = MainWindow.MainViewModelIns.FailList;
                    LabelTitle.Content = "Fail List";
                    BtnExp.Visibility = Visibility.Collapsed;

                    break;
                default:
                    DataGrid1.ItemsSource = null;
                    BtnExp.Visibility = Visibility.Collapsed;
                    break;
            }
            
        }

        public void CallbackCommand(Action<MainViewModel> execute)
        {
            try
            {
                if (DataContext is MainViewModel model)
                {
                    execute?.Invoke(model);
                }
                else
                {
                    return;
                }
            }
            catch (Exception)
            {
                return;
            }
        }


        private void DataGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.Items.Count > 0)
            {
                var border = VisualTreeHelper.GetChild(DataGrid1, 0) as Decorator;
                if (border != null)
                {
                    var scroll = border.Child as ScrollViewer;
                    if (scroll != null) scroll.ScrollToEnd();
                }
            }
        }

        private void DataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void ControlDataGridButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (System.Windows.Controls.Button)sender;
            switch (button.Name)
            {
                case "FirstButton":
                    DataGrid1.SelectedIndex = 0;
                    DataGrid1.ScrollIntoView(DataGrid1.SelectedItem);
                    break;
                case "BackButton":
                    if (DataGrid1.SelectedIndex > 0)
                    {
                        DataGrid1.SelectedIndex -= 1;
                        DataGrid1.ScrollIntoView(DataGrid1.SelectedItem);
                    }
                    break;
                case "NextButton":
                    if (DataGrid1.SelectedIndex < DataGrid1.Items.Count - 1)
                    {
                        DataGrid1.SelectedIndex += 1;
                        DataGrid1.ScrollIntoView(DataGrid1.SelectedItem);
                    }
                    break;
                case "LastButton":
                    DataGrid1.SelectedIndex = DataGrid1.Items.Count - 1;
                    DataGrid1.ScrollIntoView(DataGrid1.SelectedItem);
                    break;
                default: break;
            }
        }


        private void ClearDataGrid_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                var vm = MainWindow.MainViewModelIns;
                switch (_id)
                {
                    case CommonDatatype.DataGridResItemSrcId.Total:
                        MainWindow.MainViewModelIns.RawDataList.Clear();
                        MainWindow.MainViewModelIns.TotalCount = 0;
                        MainWindow.MainViewModelIns.ListCompare.Clear();
                        MainWindow.MainViewModelIns.savedListRead.Clear();

                        break;
                    case CommonDatatype.DataGridResItemSrcId.Good:
                        MainWindow.MainViewModelIns.GoodList.Clear();
                        MainWindow.MainViewModelIns.GoodCount = 0;
                       
                        break;
                    case CommonDatatype.DataGridResItemSrcId.Fail:
                        MainWindow.MainViewModelIns.FailList.Clear();
                        MainWindow.MainViewModelIns.FailCount = 0;
                        MainWindow.MainViewModelIns.DupCount = 0;
                        MainWindow.MainViewModelIns.NotFoundCount = 0;
                       
                        break;
                    default:
                        DataGrid1.ItemsSource = null;
                        break;
                }
            });

        }

        private void ExportClick(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.ExportToCsv(MainWindow.MainViewModelIns.ListVerified.ToList()));
            System.Windows.MessageBox.Show("Done export action!","Notify",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}
