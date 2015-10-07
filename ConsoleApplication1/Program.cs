using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FileValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "";

            string input_folder = ConfigurationManager.AppSettings["input_folder"];
            string file_mask = ConfigurationManager.AppSettings["file_mask"];
            string errors_file = ConfigurationManager.AppSettings["errors_file"];

            ValidatorsProvider validatorsProvider = new ValidatorsProvider();

            FileValidator fileValidator = new FileValidator(validatorsProvider.GetValidators(), errors_file);

            foreach (var file in Directory.EnumerateFiles(input_folder, file_mask))
            {
                fileValidator.ValidateFile(file);
            }
        }
    }
}
