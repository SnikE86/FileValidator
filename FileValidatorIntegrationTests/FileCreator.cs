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
        System.IO.StreamWriter file;
        string _filename;

        public void SetupFile(string filename)
        {
            _filename = filename;
            //if (File.Exists(filePath))
            //{
            //    File.Delete(filePath);
            //}

            //File.Create(filePath);
            //File.
            ////config must contain all validators
            //file = new System.IO.StreamWriter(filePath);
        }

        public void AddLine(string line)
        {
            using (StreamWriter sw = File.AppendText(_filename))
            {
                sw.WriteLine(line);
            }
        }

        public void CloseFile()
        {
            //file.Close();
        }
    }
}
