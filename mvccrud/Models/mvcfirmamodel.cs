using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvccrud.Models
{
    public class mvcfirmamodel
    {
        public int FirmaNo { get; set; }
        public string FirmaAd { get; set; }
        public decimal Bakiye { get; set; }
        public string Sektor { get; set; }
    }
}