using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using mvccrud.Models;

namespace mvccrud.Controllers
{
    public class SatilanlarController : Controller
    {
        // GET: Satilanlar
        public ActionResult Index()
        {
            IEnumerable<mvcsatilanmodel> callist;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync ("Satilanlars/").Result;
            callist = response.Content.ReadAsAsync<IEnumerable<mvcsatilanmodel>>().Result;
            return View(callist);
        }
        public ActionResult EY(int id =0)
        {
            if (id==0)
            {
                return View(new mvcsatilanmodel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Satilanlars/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcsatilanmodel>().Result);
            }
        }
        [HttpPost]
        public ActionResult EY(mvcsatilanmodel satilan)
        {
            if (satilan.SatilanNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Satilanlars", satilan).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Satilanlars/" + satilan.SatilanNo, satilan).Result;
               
            }
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Satilanlars/" + id.ToString()).Result;
            return RedirectToAction("Index");

        }
    }
}