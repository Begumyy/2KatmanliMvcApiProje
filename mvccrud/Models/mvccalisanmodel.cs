using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvccrud.Models
{
    public class mvccalisanmodel
    {
        public int CalisanID { get; set; }
        [Required(ErrorMessage ="adsoyad girilmesi zorunludur!!!")]//adsoyad'ın ustunde olmalı!!!
        public string AdSoyad { get; set; }
        public string Pozisyon { get; set; }
        public int Yas { get; set; }
        public int Maas { get; set; }
    }
}