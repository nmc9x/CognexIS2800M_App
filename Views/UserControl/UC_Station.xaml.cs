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
using System.Windows.Threading;

namespace OCR_Camera_Printer.Views
{
    /// <summary>
    /// Interaction logic for UC_Station.xaml
    /// </summary>
    public partial class UC_Station : UserControl
    {
        private WindowDetailList detailTt;
        private WindowDetailList detailG;
        private WindowDetailList detailF;
        public UC_Station()
        {
            InitializeComponent();
            this.BtnDetailGood.Click += BtnDetailGood_Click;
            this.BtnDetailFail.Click += BtnDetailFail_Click;
            this.BtnDetailTotal.Click += BtnDetailTotal_Click;
        }
        private void BtnDetailTotal_Click(object sender, RoutedEventArgs e)
        {
            detailTt = new WindowDetailList(Datatype.CommonDatatype.DataGridResItemSrcId.Total);
            detailTt.ShowDialog();
        }
        private void BtnDetailGood_Click(object sender, RoutedEventArgs e)
        {
            detailG = new WindowDetailList(Datatype.CommonDatatype.DataGridResItemSrcId.Good);
            detailG.ShowDialog();
        }
        private void BtnDetailFail_Click(object sender, RoutedEventArgs e)
        {
            detailF = new WindowDetailList(Datatype.CommonDatatype.DataGridResItemSrcId.Fail);
            detailF.ShowDialog();
        }

    }
}
