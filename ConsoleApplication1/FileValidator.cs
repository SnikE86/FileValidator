using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileValidator
{
    class FileValidator
    {
        private Dictionary<int, List<IValidator>> validators;  //ColumnIndex, list of Validator

        private LogFile logFile;

        private string delimiter;

        private CompletedFileHandler completedFileHandler;

        public FileValidator(Dictionary<int, List<IValidator>> aValidators, string adelimiter, LogFile alogFile, CompletedFileHandler acompletedFileHandler)
        {
            validators = aValidators;
            delimiter = adelimiter;
            logFile = alogFile;
            completedFileHandler = acompletedFileHandler;
        }

        public void ValidateFile(string file)
        {
            bool fileSuccess = true;

            try
            {
                string errorText = ""; //for logFile

                string line;

                using (StreamReader sr = new StreamReader(file))
                {
                    int lineIndex = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        lineIndex++;

                        if (!validateLine(line, out errorText))
                        {
                            logFile.WriteLine("Error with file: " + file + " on line: " + lineIndex + " " + errorText);

                            fileSuccess = false;
                        }
                    }
                }

                if (fileSuccess)
                {
                    completedFileHandler.MoveFileToSuccessDirectory(file);
                }
                else
                {
                    completedFileHandler.MoveFileToFailureDirectory(file);
                }
            }
            catch (Exception e)
            {
                logFile.WriteLine("The file could not be read: " + file);
                logFile. WriteLine(e.Message);
            }
        }
 
        private Boolean validateLine(string line, out string errorText)
        {
            string[] fields = line.Split(delimiter[0]);

            foreach (var pair in validators)
            {
                string field = fields[pair.Key];

                List<IValidator> validatorList = pair.Value;

                foreach (IValidator validator in validatorList)
                {
                    if (!validator.ValidateField(field, out errorText))
                    {
                        errorText = "in field " + pair.Key.ToString() + ": " + errorText;

                        return false;
                    }
                }
            }
            errorText = "";
            return true;
        }
    }
}
