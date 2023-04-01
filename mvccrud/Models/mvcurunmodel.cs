using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvccrud.Models
{
    public class mvcurunmodel
    {
        public int UrunNo { get; set; }
        public string UrunAdi { get; set; }
        public string Marka { get; set; }
        public decimal Fiyat { get; set; }
    }
}