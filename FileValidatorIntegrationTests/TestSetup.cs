using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileValidatorIntegrationTests
{
    class TestSetup
    {
        public void Execute(string tempPath)
        {
            SetupFolders(tempPath);
            
            SetupConfig();
        }

        private void SetupFolders(string tempPath)
        {
            System.IO.Directory.CreateDirectory(tempPath);

            System.IO.Directory.CreateDirectory(Path.Combine(tempPath, "Input"));
            System.IO.Directory.CreateDirectory(Path.Combine(tempPath, "Success"));
            System.IO.Directory.CreateDirectory(Path.Combine(tempPath, "Failure"));
        }

        private void SetupConfig()
        {
            string configFilePath = GetConfigFilePath();

            if (File.Exists(configFilePath))
            {
                File.Delete(configFilePath);
            }

            //config must contain all validators
            System.IO.StreamWriter file = new System.IO.StreamWriter(configFilePath);

            file.WriteLine();
        }

        private string GetConfigFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string levelUp = Directory.GetParent(currentDirectory).FullName;

            return Path.Combine(levelUp, "ConsoleApplication1", "bin", "Release", "FileValidator.config");
        }
    }
}
