using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvccrud.Models
{
    public class mvcsatilanmodel
    {
        public int SatilanNo { get; set; }
        
        public string SatilanUrunAdi { get; set; }
        public int BirimFiyat { get; set; }
        public int Maliyet { get; set; }
    }
}