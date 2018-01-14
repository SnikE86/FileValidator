using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FileValidator
{
    class FileValidationFormModel
    {
        public List<StringValue> toProcess;
        public List<StringValue> success;
        public List<StringValue> failures;

        private CompletedFileHandler _completedFileHander;
        private ValidatorsProvider _validatorsProvider;

        string input_folder = ConfigurationManager.AppSettings["input_folder"];
        string file_mask = ConfigurationManager.AppSettings["file_mask"];
        string errors_file = ConfigurationManager.AppSettings["errors_file"];
        string delimiter = ConfigurationManager.AppSettings["delimiter"];
        string successDirectory = ConfigurationManager.AppSettings["successDirectory"];
        string failureDirectory = ConfigurationManager.AppSettings["failureDirectory"];

        public FileValidationFormModel()
        {
            _completedFileHander = new CompletedFileHandler(successDirectory, failureDirectory);
            _validatorsProvider = new ValidatorsProvider();

            toProcess = new List<StringValue>();
            success = new List<StringValue>();
            failures = new List<StringValue>();
        }

        public void AddToProcess(String filename){
            StringValue value = new StringValue(filename);
            toProcess.Add(value);
        }

        public void AddSuccess(String filename)
        {
            StringValue value = new StringValue(filename);
            success.Add(value);
        }

        public void AddFailure(String filename)
        {
            StringValue value = new StringValue(filename);
            failures.Add(value);
        }

        public void DoStuff()
        {
            if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(errors_file)))
                {
                    LogFile logFile = new LogFile(errors_file);

                    if (delimiter.Length == 1)
                    {
                        if (System.IO.Directory.Exists(input_folder))
                        {
                            if (file_mask.Length > 0)
                            {
                                FileValidator fileValidator = new FileValidator(_validatorsProvider.GetValidators(), delimiter, logFile, _completedFileHander);

                                foreach (var file in System.IO.Directory.EnumerateFiles(input_folder, file_mask))
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

    public class StringValue
    {
        public StringValue(string s)
        {
            _value = s;
        }
        public string Value { get { return _value; } set { _value = value; } }
        string _value;
    }
}
