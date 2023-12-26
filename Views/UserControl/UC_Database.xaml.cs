using OCR_Camera_Printer.Controller;
using System;
using System.Windows;
using System.Windows.Controls;

namespace OCR_Camera_Printer.Views
{
    public partial class UC_Database : UserControl
    {
        public UC_Database()
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

        private void BrowseClick(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm=>vm.GetFilePath());  
        }

        private void ApplyClick(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.AutoAddSuffixes());
            System.Windows.MessageBox.Show("Done set database action!", "Notify", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
