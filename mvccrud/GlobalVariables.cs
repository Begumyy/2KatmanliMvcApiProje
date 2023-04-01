using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;//api katmanındaki calısır haldeki url'sini alıp baglanması icin.

namespace mvccrud
{
    public static class GlobalVariables //static nesne olusturmadan direkt baglanması icin
    {
        public static HttpClient webapiclient = new HttpClient();


        static GlobalVariables()
        {
            webapiclient.BaseAddress = new Uri("https://localhost:44363/api/");
            webapiclient.DefaultRequestHeaders.Clear();
            webapiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}