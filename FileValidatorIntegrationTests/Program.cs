using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileValidatorIntegrationTests
{
    class Program
    {
        static void Main(string[] args)
        {
            FileCreator fileCreator = new FileCreator();

            TestSetup testSetup = new TestSetup(fileCreator);

            MainForm mainForm = new MainForm();

            TestExecutor testExecutor = new TestExecutor(testSetup, fileCreator, mainForm);

            testExecutor.Execute();
        }
    }
}
