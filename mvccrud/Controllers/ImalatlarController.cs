using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using mvccrud.Models;

namespace mvccrud.Controllers
{
    public class ImalatlarController : Controller
    {
        // GET: Imalatlar
        public ActionResult Index()
        {
            IEnumerable<mvcimalatmodel> callist;
            HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Imalatlars").Result;
            callist = response.Content.ReadAsAsync<IEnumerable<mvcimalatmodel>>().Result;
            return View(callist);
        }
        public ActionResult EY(int id =0)
        {
            if(id == 0)
            {
                return View(new mvcimalatmodel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.GetAsync("Imalatlars/" + id. ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcimalatmodel>().Result);
            }
        }
        [HttpPost]
        public ActionResult EY(mvcimalatmodel imalat)
        {
            if(imalat.ImalatNo==0)
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PostAsJsonAsync("Imalatlars/", imalat).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.webapiclient.PutAsJsonAsync("Imalatlars/" + imalat.ImalatNo, imalat).Result;
                
            }
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GlobalVariables.webapiclient.DeleteAsync("Imalatlars/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}