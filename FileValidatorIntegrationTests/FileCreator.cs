using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileValidatorIntegrationTests
{
    class FileCreator
    {
       string _filename;

        public void SetupFile(string filename)
        {
            _filename = filename;
        }

        public void AddLine(string line)
        {
            using (StreamWriter sw = File.AppendText(_filename))
            {
                sw.WriteLine(line);
            }
        }
    }
}
