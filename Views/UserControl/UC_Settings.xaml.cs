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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OCR_Camera_Printer.Views
{
    /// <summary>
    /// Interaction logic for UC_Settings.xaml
    /// </summary>
    public partial class UC_Settings : UserControl
    {
        public UC_Settings()
        {
            InitializeComponent();
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
        private void PingTestClick(object sender, RoutedEventArgs e)
        {

            CallbackCommand(vm => vm.IsPortOpen());
                
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.AutoAddSuffixes());
            NotifyPopup np = new NotifyPopup("Notify","Done set pattern action!");
            np.Show();
            //MessageBox.Show("Done set pattern action!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
