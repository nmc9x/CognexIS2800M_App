using OCR_Camera_Printer.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR_Camera_Printer.Models
{
    public class DataList : ViewModelBase
    {
       // public string StrData { get; set; }
        private string _StrData;

        public string StrData
        {
            get { return _StrData; }
            set { _StrData = value; OnPropertyChanged(); }
        }

        public DateTime ReadDateTime { get; set; }  

    }
}
