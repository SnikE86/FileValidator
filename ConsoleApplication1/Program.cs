﻿using System;
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
            string input_folder = ConfigurationManager.AppSettings["input_folder"];
            string file_mask = ConfigurationManager.AppSettings["file_mask"];
            string errors_file = ConfigurationManager.AppSettings["errors_file"];
            string delimiter = ConfigurationManager.AppSettings["delimiter"];

            ValidatorsProvider validatorsProvider = new ValidatorsProvider();

            LogFile logFile = new LogFile(errors_file);

            if (delimiter.Length == 1)
            {
                if (System.IO.Directory.Exists(input_folder))
                {
                    if (System.IO.Directory.Exists(Path.GetDirectoryName(errors_file)))
                    {
                        if (file_mask.Length > 0)
                        {
                            FileValidator fileValidator = new FileValidator(validatorsProvider.GetValidators(), delimiter, logFile);

                            foreach (var file in Directory.EnumerateFiles(input_folder, file_mask))
                            {
                                fileValidator.ValidateFile(file);
                            }
                        }
                        else
                        {
                            logFile.WriteLine("file_mask not provided. Check the appconfig is configured correctly.");
                        }
                    }
                    else
                    {
                        logFile.WriteLine("errors_file folder path does not exist. Check the appconfig is configured correctly.");
                    }
                }
                else
                {
                    logFile.WriteLine("input_folder does not exist. Check the appconfig is configured correctly.");
                }
            }
            else
            {
                logFile.WriteLine("Delimiter can only be one character. Check the appconfig is configured correctly.");
            }
        }
    }
}