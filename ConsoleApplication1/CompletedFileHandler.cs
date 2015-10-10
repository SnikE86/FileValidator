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
