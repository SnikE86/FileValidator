using System;
using System.Collections.Generic;
using System.IO;
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
            MoveFile(fileName, SuccessDirectory);
        }

        public void MoveFileToFailureDirectory(string fileName)
        {
            MoveFile(fileName, FailureDirectory);
        }

        private void MoveFile(string srcFileName, string dstPath)
        {
            if (!System.IO.Directory.Exists(dstPath))
            {
                System.IO.Directory.CreateDirectory(dstPath);
            }

            System.IO.File.Move(srcFileName, Path.Combine(dstPath, Path.GetFileName(srcFileName)));
        }
    }
}
