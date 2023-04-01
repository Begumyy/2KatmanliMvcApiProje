using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using mvccrud.Models;

namespace mvccrud.Controllers
{
    public class SubelerController : Controller
    {
        // GET: Subeler
        public ActionResult Index()
        {
            IEnumerable<mvcsubemodel> callist;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Subelers").Result;
            callist = response.Content.ReadAsAsync<IEnumerable<mvcsubemodel>>().Result;
            return View(callist);
        }

        public ActionResult EY(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcsubemodel());
            }
            else
            {
                //Api/Urunlers/1
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Subelers/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcsubemodel>().Result);
            }
        }
        [HttpPost]
        public ActionResult EY(mvcsubemodel sube)
        {
            if (sube.SubeNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Subelers", sube).Result;
            }
            else
            {
                //Api/Urunlers/1
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Subelers/" + sube.SubeNo, sube).Result;

            }
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        { 
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Subelers/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}