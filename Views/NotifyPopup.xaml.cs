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
using System.Windows.Shapes;

namespace OCR_Camera_Printer.Views
{
    /// <summary>
    /// Interaction logic for NotifyPopup.xaml
    /// </summary>
    public partial class NotifyPopup : Window
    {
        public NotifyPopup(string tt, string ct)
        {
            InitializeComponent();
            MessTitle.Text = tt;
            MessContent.Text = ct ;

        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
