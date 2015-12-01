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
            TestSetup testSetup = new TestSetup();

            TestExecutor testExecutor = new TestExecutor(testSetup);

            testExecutor.Execute();
        }
    }
}
