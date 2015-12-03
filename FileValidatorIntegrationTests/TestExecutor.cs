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
            ExecuteValidatorsFailOnCurrencyValidator();

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

        private void ExecuteValidatorsFailOnCurrencyValidator()
        {
            string tempDirectory = _testSetup.SetupAndReturnTempDirectory();

            TestResult testResult = new TestResult();

            testResult.testName = "ExecuteValidatorsFailOnCurrencyValidator";

            _fileCreator.SetupFile(Path.Combine(tempDirectory, "Input", "TestInputFile.csv"));
            _fileCreator.AddLine("FAIL_HERE,12022015,151202,20151202,1,1010101010,12345,abc,123");

            ExecuteFileValidator();

            if (File.Exists(Path.Combine(tempDirectory, "Failure", "TestInputFile.csv"))
                && (!File.Exists(Path.Combine(tempDirectory, "Input", "TestInputFile.csv")))
                && (!File.Exists(Path.Combine(tempDirectory, "Success", "TestInputFile.csv")))
                && (File.Exists(Path.Combine(tempDirectory, "Output", "results.log"))))
            {
                if(GetErrorMsg(tempDirectory).Contains("Field is not a currency (expected format: dd.dd): "))
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
