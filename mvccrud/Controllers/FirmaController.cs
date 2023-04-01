using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using mvccrud.Models;

namespace mvccrud.Controllers
{
    public class FirmalarController : Controller
    {
        // GET: Firmalar
        public ActionResult Index()
        {
            IEnumerable<mvcfirmamodel> callist;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Firmalars").Result;
            callist = response.Content.ReadAsAsync<IEnumerable<mvcfirmamodel>>().Result;
            return View(callist);
        }
        public ActionResult EY(int id = 0)//sayfaya veri gelir id 
        {
            if (id == 0)
            {
                return View(new mvcfirmamodel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Firmalars/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcfirmamodel>().Result);
            }
        }
        [HttpPost]
        public ActionResult EY(mvcfirmamodel firma)
        {
            if (firma.FirmaNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Firmalars", firma).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Firmalars/" + firma.FirmaNo, firma).Result;
                
            }
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Firmalars/" + id.ToString()).Result;
            return RedirectToAction("Index");

        }
    }
}
