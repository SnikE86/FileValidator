using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            FileValidator fileValidator = new FileValidator();

            foreach (var file in Directory.EnumerateFiles("C:\\TestDirectory", "*.txt*"))
            {
                fileValidator.ValidateFile(file);
            }
        }
    }
}
