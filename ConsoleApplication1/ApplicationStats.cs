using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FileValidator
{
    class ApplicationStats
    {
        public void ApplicationLaunched()
        {
            string utcNow = DateTime.UtcNow.ToString("dd'/'MM'/'yyyy HH:mm:ss");      

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://michaelekins.co.uk/ApplicationStats/AddApplicationStat.php");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    appName = "FileValidator",
                    dateTime = utcNow,
                    user = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                });

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
    }
}
