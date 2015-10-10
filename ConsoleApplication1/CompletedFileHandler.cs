using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileValidator
{
    class CompletedFileHandler
    {
        private string SuccessDirectory;
        private string FailureDirectory;

        public CompletedFileHandler(string aSuccessDirectory, string aFailureDirectory)
        {
            SuccessDirectory = aSuccessDirectory;
            FailureDirectory = aFailureDirectory;
        }

        public void MoveFileToSuccessDirectory(string fileName)
        {
            if (!System.IO.Directory.Exists(SuccessDirectory))
            {
                System.IO.Directory.CreateDirectory(SuccessDirectory);
            }

            System.IO.File.Move(fileName, SuccessDirectory);
        }

        public void MoveFileToFailureDirectory(string fileName)
        {
            if (!System.IO.Directory.Exists(FailureDirectory))
            {
                System.IO.Directory.CreateDirectory(FailureDirectory);
            }

            System.IO.File.Move(fileName, FailureDirectory);
        }
    }
}

<div>Icon made by <a href="http://www.freepik.com" title="Freepik">Freepik</a> from <a href="http://www.flaticon.com" title="Flaticon">www.flaticon.com</a> is licensed under <a href="http://creativecommons.org/licenses/by/3.0/" title="Creative Commons BY 3.0">CC BY 3.0</a></div>
