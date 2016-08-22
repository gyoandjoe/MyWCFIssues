using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace MyWCFIssues.Web
{
    public class Utilidades
    {
        public static T ConsumirRESTFullService<T>(string url, dynamic parametros, string metodo = "POST")
        {
            WebRequest request = WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = metodo;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(parametros
                //new {
                //    noPagina = 2,
                //    tamanoPagina = 2
                //}
                );
                streamWriter.Write(json);
            }


            HttpWebResponse resp = request.GetResponse() as HttpWebResponse;
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    var jsonResponse = reader.ReadToEnd();
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    var result = jss.Deserialize<T>(jsonResponse);
                    return result;
                }
            }
            throw new Exception("Error HttpStatusCode: " + resp.StatusCode);
        }
    }
}