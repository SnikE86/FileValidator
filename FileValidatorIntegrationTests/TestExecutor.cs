using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace FileValidatorIntegrationTests
{
    class TestExecutor
    {
        TestSetup _testSetup;
        FileCreator _fileCreator;
        MainForm _mainForm;

        public TestExecutor(TestSetup testSetup, FileCreator fileCreator, MainForm mainForm)
        {
            _testSetup = testSetup;
            _fileCreator = fileCreator;
            _mainForm = mainForm;
        }

        public void Execute()
        {
            ExecuteValidatorsAllPassTest();
            ExecuteValidatorFailOnValidatorCurrency();
            ExecuteValidatorFailOnValidatorDate_MMDDYYYY();
            ExecuteValidatorFailOnValidatorDate_YYMMDD();
            ExecuteValidatorFailOnValidatorDate_YYYYMMDD();
            ExecuteValidatorFieldIsNotBlank();
            ExecuteValidatorFieldLength();
            ExecuteValidatorMaxFieldLength();
            ExecuteValidatorNoNumbers();
            ExecuteValidatorNumber();

            _mainForm.ShowDialog();
        }

        private void ExecuteFileValidator()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string levelUp = Directory.GetParent(currentDirectory).FullName;
            levelUp = Directory.GetParent(levelUp).FullName;
            levelUp = Directory.GetParent(levelUp).FullName;

            string ExeName = Path.Combine(levelUp, "ConsoleApplication1", "bin", "Release", "FileValidator.exe");

            ProcessStartInfo start = new ProcessStartInfo();
           
            start.FileName = ExeName;

            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;

            using (Process proc = Process.Start(start))
            {
                proc.WaitForExit();
            }
        }

        private void ExecuteValidatorsAllPassTest()
        {
            string tempDirectory = _testSetup.SetupAndReturnTempDirectory();

            TestResult testResult = new TestResult();

            testResult.testName = "ExecuteValidatorsAllPassTest";

            _fileCreator.SetupFile(Path.Combine(tempDirectory, "Input", "TestInputFile.csv"));
            _fileCreator.AddLine("99.99,12022015,151202,20151202,1,1010101010,12345,abc,123");

            ExecuteFileValidator();

            if (File.Exists(Path.Combine(tempDirectory, "Success", "TestInputFile.csv"))
                &&(!File.Exists(Path.Combine(tempDirectory, "Input", "TestInputFile.csv")))
                &&(!File.Exists(Path.Combine(tempDirectory, "Failure", "TestInputFile.csv")))
                &&(!File.Exists(Path.Combine(tempDirectory, "Output", "results.log"))))
            {
                testResult.testPassed = true;
            }
            else
            { 
                testResult.testPassed = false;
                testResult.errorMessage = GetErrorMsg(tempDirectory);
            }

            _mainForm.AddTestResult(testResult);

            Directory.Delete(tempDirectory, true);
        }

        private void ExecuteValidatorFailOnValidatorCurrency()
        {
            string tempDirectory = _testSetup.SetupAndReturnTempDirectory();

            TestResult testResult = new TestResult();

            testResult.testName = "ExecuteValidatorFailOnCurrencyValidator";

            _fileCreator.SetupFile(Path.Combine(tempDirectory, "Input", "TestInputFile.csv"));
            _fileCreator.AddLine("FAIL_HERE,12022015,151202,20151202,1,1010101010,12345,abc,123");

            ExecuteFileValidator();

            if (File.Exists(Path.Combine(tempDirectory, "Failure", "TestInputFile.csv"))
                && (!File.Exists(Path.Combine(tempDirectory, "Input", "TestInputFile.csv")))
                && (!File.Exists(Path.Combine(tempDirectory, "Success", "TestInputFile.csv")))
                && (File.Exists(Path.Combine(tempDirectory, "Output", "results.log"))))
            {
                if (GetErrorMsg(tempDirectory).Contains("Field is not a currency (expected format: dd.dd): FAIL_HERE"))
                {
                    testResult.testPassed = true;
                }
                else
                {
                    testResult.testPassed = false;
                    testResult.errorMessage = GetErrorMsg(tempDirectory);
                }
            }
            else
            {
                testResult.testPassed = false;
                testResult.errorMessage = GetErrorMsg(tempDirectory);
            }

            _mainForm.AddTestResult(testResult);

            Directory.Delete(tempDirectory, true);
        }

        private void ExecuteValidatorFailOnValidatorDate_MMDDYYYY()
        {
            string tempDirectory = _testSetup.SetupAndReturnTempDirectory();

            TestResult testResult = new TestResult();

            testResult.testName = "ExecuteValidatorFailOnValidatorDate_MMDDYYYY";

            _fileCreator.SetupFile(Path.Combine(tempDirectory, "Input", "TestInputFile.csv"));
            _fileCreator.AddLine("99.99,FAIL_HERE,151202,20151202,1,1010101010,12345,abc,123");

            ExecuteFileValidator();

            if (File.Exists(Path.Combine(tempDirectory, "Failure", "TestInputFile.csv"))
                && (!File.Exists(Path.Combine(tempDirectory, "Input", "TestInputFile.csv")))
                && (!File.Exists(Path.Combine(tempDirectory, "Success", "TestInputFile.csv")))
                && (File.Exists(Path.Combine(tempDirectory, "Output", "results.log"))))
            {
                if (GetErrorMsg(tempDirectory).Contains("Field is not correct format (MMDDYYYY): FAIL_HERE"))
                {
                    testResult.testPassed = true;
                }
                else
                {
                    testResult.testPassed = false;
                    testResult.errorMessage = GetErrorMsg(tempDirectory);
                }
            }
            else
            {
                testResult.testPassed = false;
                testResult.errorMessage = GetErrorMsg(tempDirectory);
            }

            _mainForm.AddTestResult(testResult);

            Directory.Delete(tempDirectory, true);
        }

        private void ExecuteValidatorFailOnValidatorDate_YYMMDD()
        {
            string tempDirectory = _testSetup.SetupAndReturnTempDirectory();

            TestResult testResult = new TestResult();

            testResult.testName = "ExecuteValidatorFailOnValidatorDate_YYMMDD";

            _fileCreator.SetupFile(Path.Combine(tempDirectory, "Input", "TestInputFile.csv"));
            _fileCreator.AddLine("99.99,12022015,FAIL_HERE,20151202,1,1010101010,12345,abc,123");

            ExecuteFileValidator();

            if (File.Exists(Path.Combine(tempDirectory, "Failure", "TestInputFile.csv"))
                && (!File.Exists(Path.Combine(tempDirectory, "Input", "TestInputFile.csv")))
                && (!File.Exists(Path.Combine(tempDirectory, "Success", "TestInputFile.csv")))
                && (File.Exists(Path.Combine(tempDirectory, "Output", "results.log"))))
            {
                if (GetErrorMsg(tempDirectory).Contains("Field is not correct format (YYMMDD): FAIL_HERE"))
                {
                    testResult.testPassed = true;
                }
                else
                {
                    testResult.testPassed = false;
                    testResult.errorMessage = GetErrorMsg(tempDirectory);
                }
            }
            else
            {
                testResult.testPassed = false;
                testResult.errorMessage = GetErrorMsg(tempDirectory);
            }

            _mainForm.AddTestResult(testResult);

            Directory.Delete(tempDirectory, true);
        }

        private void ExecuteValidatorFailOnValidatorDate_YYYYMMDD()
        {
            string tempDirectory = _testSetup.SetupAndReturnTempDirectory();

            TestResult testResult = new TestResult();

            testResult.testName = "ExecuteValidatorFailOnValidatorDate_YYYYMMDD";

            _fileCreator.SetupFile(Path.Combine(tempDirectory, "Input", "TestInputFile.csv"));
            _fileCreator.AddLine("99.99,12022015,151202,FAIL_HERE,1,1010101010,12345,abc,123");

            ExecuteFileValidator();

            if (File.Exists(Path.Combine(tempDirectory, "Failure", "TestInputFile.csv"))
                && (!File.Exists(Path.Combine(tempDirectory, "Input", "TestInputFile.csv")))
                && (!File.Exists(Path.Combine(tempDirectory, "Success", "TestInputFile.csv")))
                && (File.Exists(Path.Combine(tempDirectory, "Output", "results.log"))))
            {
                if (GetErrorMsg(tempDirectory).Contains("Field is not correct format (YYYYMMDD): FAIL_HERE"))
                {
                    testResult.testPassed = true;
                }
                else
                {
                    testResult.testPassed = false;
                    testResult.errorMessage = GetErrorMsg(tempDirectory);
                }
            }
            else
            {
                testResult.testPassed = false;
                testResult.errorMessage = GetErrorMsg(tempDirectory);
            }

            _mainForm.AddTestResult(testResult);

            Directory.Delete(tempDirectory, true);
        }

        private void ExecuteValidatorFieldIsNotBlank()
        {
            string tempDirectory = _testSetup.SetupAndReturnTempDirectory();

            TestResult testResult = new TestResult();

            testResult.testName = "ExecuteValidatorFieldIsNotBlank";

            _fileCreator.SetupFile(Path.Combine(tempDirectory, "Input", "TestInputFile.csv"));
            _fileCreator.AddLine("99.99,12022015,151202,20151202,,1010101010,12345,abc,123");

            ExecuteFileValidator();

            if (File.Exists(Path.Combine(tempDirectory, "Failure", "TestInputFile.csv"))
                && (!File.Exists(Path.Combine(tempDirectory, "Input", "TestInputFile.csv")))
                && (!File.Exists(Path.Combine(tempDirectory, "Success", "TestInputFile.csv")))
                && (File.Exists(Path.Combine(tempDirectory, "Output", "results.log"))))
            {
                if (GetErrorMsg(tempDirectory).Contains("Field is blank"))
                {
                    testResult.testPassed = true;
                }
                else
                {
                    testResult.testPassed = false;
                    testResult.errorMessage = GetErrorMsg(tempDirectory);
                }
            }
            else
            {
                testResult.testPassed = false;
                testResult.errorMessage = GetErrorMsg(tempDirectory);
            }

            _mainForm.AddTestResult(testResult);

            Directory.Delete(tempDirectory, true);
        }

        private void ExecuteValidatorFieldLength()
        {
            string tempDirectory = _testSetup.SetupAndReturnTempDirectory();

            TestResult testResult = new TestResult();

            testResult.testName = "SetupAndReturnTempDirectory";

            _fileCreator.SetupFile(Path.Combine(tempDirectory, "Input", "TestInputFile.csv"));
            _fileCreator.AddLine("99.99,12022015,151202,20151202,1,FAIL_HERE,12345,abc,123");

            ExecuteFileValidator();

            if (File.Exists(Path.Combine(tempDirectory, "Failure", "TestInputFile.csv"))
                && (!File.Exists(Path.Combine(tempDirectory, "Input", "TestInputFile.csv")))
                && (!File.Exists(Path.Combine(tempDirectory, "Success", "TestInputFile.csv")))
                && (File.Exists(Path.Combine(tempDirectory, "Output", "results.log"))))
            {
                if (GetErrorMsg(tempDirectory).Contains("Field is not correct length (expected 10): FAIL_HERE"))
                {
                    testResult.testPassed = true;
                }
                else
                {
                    testResult.testPassed = false;
                    testResult.errorMessage = GetErrorMsg(tempDirectory);
                }
            }
            else
            {
                testResult.testPassed = false;
                testResult.errorMessage = GetErrorMsg(tempDirectory);
            }

            _mainForm.AddTestResult(testResult);

            Directory.Delete(tempDirectory, true);
        }

        private void ExecuteValidatorMaxFieldLength()
        {
            string tempDirectory = _testSetup.SetupAndReturnTempDirectory();

            TestResult testResult = new TestResult();

            testResult.testName = "ExecuteValidatorMaxFieldLength";

            _fileCreator.SetupFile(Path.Combine(tempDirectory, "Input", "TestInputFile.csv"));
            _fileCreator.AddLine("99.99,12022015,151202,20151202,1,1010101010,FAIL_HERE,abc,123");

            ExecuteFileValidator();

            if (File.Exists(Path.Combine(tempDirectory, "Failure", "TestInputFile.csv"))
                && (!File.Exists(Path.Combine(tempDirectory, "Input", "TestInputFile.csv")))
                && (!File.Exists(Path.Combine(tempDirectory, "Success", "TestInputFile.csv")))
                && (File.Exists(Path.Combine(tempDirectory, "Output", "results.log"))))
            {
                if (GetErrorMsg(tempDirectory).Contains("Field is longer than maximum length (max length: 5): FAIL_HERE"))
                {
                    testResult.testPassed = true;
                }
                else
                {
                    testResult.testPassed = false;
                    testResult.errorMessage = GetErrorMsg(tempDirectory);
                }
            }
            else
            {
                testResult.testPassed = false;
                testResult.errorMessage = GetErrorMsg(tempDirectory);
            }

            _mainForm.AddTestResult(testResult);

            Directory.Delete(tempDirectory, true);
        }

        private void ExecuteValidatorNoNumbers()
        {
            string tempDirectory = _testSetup.SetupAndReturnTempDirectory();

            TestResult testResult = new TestResult();

            testResult.testName = "ExecuteValidatorNoNumbers";

            _fileCreator.SetupFile(Path.Combine(tempDirectory, "Input", "TestInputFile.csv"));
            _fileCreator.AddLine("99.99,12022015,151202,20151202,1,1010101010,12345,FAIL_HERE_123,123");

            ExecuteFileValidator();

            if (File.Exists(Path.Combine(tempDirectory, "Failure", "TestInputFile.csv"))
                && (!File.Exists(Path.Combine(tempDirectory, "Input", "TestInputFile.csv")))
                && (!File.Exists(Path.Combine(tempDirectory, "Success", "TestInputFile.csv")))
                && (File.Exists(Path.Combine(tempDirectory, "Output", "results.log"))))
            {
                if (GetErrorMsg(tempDirectory).Contains("Field contains a number: FAIL_HERE_123"))
                {
                    testResult.testPassed = true;
                }
                else
                {
                    testResult.testPassed = false;
                    testResult.errorMessage = GetErrorMsg(tempDirectory);
                }
            }
            else
            {
                testResult.testPassed = false;
                testResult.errorMessage = GetErrorMsg(tempDirectory);
            }

            _mainForm.AddTestResult(testResult);

            Directory.Delete(tempDirectory, true);
        }

        private void ExecuteValidatorNumber()
        {
            string tempDirectory = _testSetup.SetupAndReturnTempDirectory();

            TestResult testResult = new TestResult();

            testResult.testName = "ExecuteValidatorNumber";

            _fileCreator.SetupFile(Path.Combine(tempDirectory, "Input", "TestInputFile.csv"));
            _fileCreator.AddLine("99.99,12022015,151202,20151202,1,1010101010,12345,abc,FAIL_HERE");

            ExecuteFileValidator();

            if (File.Exists(Path.Combine(tempDirectory, "Failure", "TestInputFile.csv"))
                && (!File.Exists(Path.Combine(tempDirectory, "Input", "TestInputFile.csv")))
                && (!File.Exists(Path.Combine(tempDirectory, "Success", "TestInputFile.csv")))
                && (File.Exists(Path.Combine(tempDirectory, "Output", "results.log"))))
            {
                if (GetErrorMsg(tempDirectory).Contains("Field does not only contain numbers: FAIL_HERE"))
                {
                    testResult.testPassed = true;
                }
                else
                {
                    testResult.testPassed = false;
                    testResult.errorMessage = GetErrorMsg(tempDirectory);
                }
            }
            else
            {
                testResult.testPassed = false;
                testResult.errorMessage = GetErrorMsg(tempDirectory);
            }

            _mainForm.AddTestResult(testResult);

            Directory.Delete(tempDirectory, true);
        }

        private string GetErrorMsg(string tempDirectory)
        {
            string fileName = Path.Combine(tempDirectory, "Output", "results.log");
            return File.ReadLines(fileName).Last();
        }
    }
}
