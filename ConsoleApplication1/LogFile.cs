using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileValidator
{
    class LogFile
    {
        private string fileLocation;

        public LogFile(string afileLocation)
        {
            fileLocation = afileLocation;
        }

        public void WriteLine(string text)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(fileLocation);
            file.WriteLine(text);

            file.Close();
        }
    }
}
