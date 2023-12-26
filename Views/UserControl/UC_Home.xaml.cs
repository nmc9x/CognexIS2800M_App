using Cognex.InSight.Web.Controls;
using OCR_Camera_Printer.Controller;
using System;
using System.Windows;
using System.Windows.Controls;

namespace OCR_Camera_Printer.Views
{
    /// <summary>
    /// Interaction logic for UC_Home.xaml
    /// </summary>
    public partial class UC_Home : UserControl
    {
        private CvsDisplay _cvsControl = new CvsDisplay();
        public UC_Home()
        {
            InitializeComponent();
           
            CvsDisplayForm.Child = _cvsControl;
          
            BtnStart.Click += BtnStart_Click;
            BtnStop.Click += BtnStop_Click;
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.StopProccess());
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.ConnectFirst(_cvsControl));
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
      
        
        private void HomeClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CallbackCommand(vm => vm.TabIndex = 0);
        }

        private void ConfigClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CallbackCommand(vm => vm.TabIndex = 1);
        }

        private void DBClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CallbackCommand(vm => vm.TabIndex = 2);
        }

        private void AbClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string message = "Software: RCVM\n" +
                      "Version: 1.0.0.0\n" +
                      "Company: MyLanGroup\n" +
                      "Address: Long Duc Industrial Park, Tra Vinh, VietNam";
            string caption = "Software Information";
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ExitAppClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
           // NotifyPopup np = new NotifyPopup()
            var ex = MessageBox.Show("Exit Applacation ? ","Exit",MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if(ex.Equals(MessageBoxResult.OK))
            {
                Application.Current.Shutdown();
            }
        }
    }
}
