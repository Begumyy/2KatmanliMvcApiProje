using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using mvccrud.Models;

namespace mvccrud.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        public ActionResult Index()
        {
            IEnumerable<mvcurunmodel> callist;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Urunlers").Result;
            callist = response.Content.ReadAsAsync<IEnumerable<mvcurunmodel>>().Result;
            return View(callist);
        }
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcurunmodel());
            }
            else
            {
                //Api/Urunlers/1
                HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Urunlers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcurunmodel>().Result);
            }
        }

        [HttpPost]
        public ActionResult EY(mvcurunmodel urun)
        {
            if (urun.UrunNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Urunlers", urun).Result;
            }
            else
            {
                //Api/Urunlers/1
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Urunlers/" + urun.UrunNo, urun).Result;
            
            }  
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Urunlers/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }


    }
}