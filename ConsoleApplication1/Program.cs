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
            string input_folder = ConfigurationManager.AppSettings["input_folder"];
            string file_mask = ConfigurationManager.AppSettings["file_mask"];
            string errors_file = ConfigurationManager.AppSettings["errors_file"];
            string delimiter = ConfigurationManager.AppSettings["delimiter"];
            string successDirectory = ConfigurationManager.AppSettings["successDirectory"];
            string failureDirectory = ConfigurationManager.AppSettings["failureDirectory"];

            IVersionProvider currentVersionProvider = new CurrentVersionProvider();
            IVersionProvider serverVersionProvider = new ServerVersionProvider();
            IUpdateResolver updateResolver = new UpdateResolver();

            ActiveUpdater activeUpdate = new ActiveUpdater(currentVersionProvider, serverVersionProvider, updateResolver);

            if (activeUpdate.UpdateSuccessful())
            {

                CompletedFileHandler completedFileHander = new CompletedFileHandler(successDirectory, failureDirectory);

                ValidatorsProvider validatorsProvider = new ValidatorsProvider();

                if (System.IO.Directory.Exists(Path.GetDirectoryName(errors_file)))
                {
                    LogFile logFile = new LogFile(errors_file);

                    if (delimiter.Length == 1)
                    {
                        if (System.IO.Directory.Exists(input_folder))
                        {
                            if (file_mask.Length > 0)
                            {
                                FileValidator fileValidator = new FileValidator(validatorsProvider.GetValidators(), delimiter, logFile, completedFileHander);

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
                            logFile.WriteLine("input_folder does not exist. Check the appconfig is configured correctly.");
                        }
                    }
                    else
                    {
                        logFile.WriteLine("Delimiter can only be one character. Check the appconfig is configured correctly.");
                    }
                }
                else
                {
                    Console.WriteLine("errors_file folder path does not exist. Check the appconfig is configured correctly. " + errors_file);
                }
            }
        }
    }
}

