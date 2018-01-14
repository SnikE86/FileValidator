using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace FileValidator
{
    class ServerVersionProvider : IVersionProvider
    {
        public string GetVersion()
        {
            HttpWebRequest request = WebRequest.Create("http://michaelekins.co.uk/ApplicationVersions/FileValidatorVersion.php") as HttpWebRequest;

            request.Method = "GET";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            StreamReader reader = new StreamReader(response.GetResponseStream());

            return reader.ReadToEnd();
        }
    }
}
