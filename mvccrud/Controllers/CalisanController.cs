using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using mvccrud.Models;

namespace mvccrud.Controllers
{
    public class CalisanController : Controller
    {
        // GET: Calisan
        public ActionResult Index()
        {
            IEnumerable<mvccalisanmodel> callist;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Calisanlars").Result;
            callist = response.Content.ReadAsAsync<IEnumerable<mvccalisanmodel>>().Result;
            return View(callist);
        }
        public ActionResult EY(int id = 0)//sayfaya veri gelir id 
        {
            if (id == 0)
            {
                return View(new mvccalisanmodel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Calisanlars/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvccalisanmodel>().Result);
            }
        }

        [HttpPost]
        public ActionResult EY(mvccalisanmodel calisan)
        {
            if (calisan.CalisanID == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Calisanlars", calisan).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Calisanlars/" + calisan.CalisanID, calisan).Result;
                return View(response.Content.ReadAsAsync<mvccalisanmodel>().Result);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {

            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Calisanlars/" + id.ToString()).Result;
            return RedirectToAction("Index");

        }
    }
}