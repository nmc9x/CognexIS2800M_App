using OCR_Camera_Printer.Controller;
using System.Collections.ObjectModel;
using System;
using System.Windows;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using Cognex.InSight.Web.Controls;

namespace OCR_Camera_Printer.Views
{
    public partial class MainWindow : Window
    {
        private CvsDisplay _CvsDisplay = new CvsDisplay();
        public static MainViewModel MainViewModelIns;
        public MainWindow()
        {
            InitializeComponent();
            MainViewModelIns = new MainViewModel();
            DataContext = MainViewModelIns;
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CallbackCommand(vm => vm.FirstLoadFrm());
        }
    }
}
