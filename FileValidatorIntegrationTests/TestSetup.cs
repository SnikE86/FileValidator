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
        FileCreator _fileCreator;

        public TestSetup(FileCreator fileCreator)
        {
            _fileCreator = fileCreator;
        }

        public string SetupAndReturnTempDirectory()
        {
            string tempPath = GetTemporaryDirectory();

            SetupFolders(tempPath);
            
            SetupConfig(tempPath);

            return tempPath;
        }

        private string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8));
            Directory.CreateDirectory(tempDirectory);

            if (!File.Exists(tempDirectory))
            {
                return tempDirectory;
            }
            else
            {
                return GetTemporaryDirectory();
            }
        }

        private void SetupFolders(string tempPath)
        {
            System.IO.Directory.CreateDirectory(tempPath);

            System.IO.Directory.CreateDirectory(Path.Combine(tempPath, "Input"));
            System.IO.Directory.CreateDirectory(Path.Combine(tempPath, "Success"));
            System.IO.Directory.CreateDirectory(Path.Combine(tempPath, "Failure"));
            System.IO.Directory.CreateDirectory(Path.Combine(tempPath, "Output"));
        }

        private void SetupConfig(string tempPath)
        {
            string configFilePath = GetConfigFilePath();

            if (File.Exists(configFilePath))
            {
                File.Delete(configFilePath);
            }

            _fileCreator.SetupFile(configFilePath);

            _fileCreator.AddLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            _fileCreator.AddLine("<configuration>");
            _fileCreator.AddLine("<configSections>");
            _fileCreator.AddLine("<section name=\"validators\" type=\"System.Configuration.DictionarySectionHandler\" />");
            _fileCreator.AddLine("</configSections>");
            _fileCreator.AddLine("<appSettings>");
            _fileCreator.AddLine("<add key=\"input_folder\" value=\"" + Path.Combine(tempPath, "Input") + "\" />");
            _fileCreator.AddLine("<add key=\"file_mask\" value=\"*.csv\" />");
            _fileCreator.AddLine("<add key=\"errors_file\" value=\"" + Path.Combine(tempPath, "Output", "results.log") + "\" />");
            _fileCreator.AddLine("<add key=\"delimiter\" value=\",\" />");
            _fileCreator.AddLine("<add key=\"successDirectory\" value=\"" + Path.Combine(tempPath, "Success") + "\" />");
            _fileCreator.AddLine("<add key=\"failureDirectory\" value=\"" + Path.Combine(tempPath, "Failure") + "\" />");
            _fileCreator.AddLine("<add key=\"ClientSettingsProvider.ServiceUri\" value=\"\" />");
            _fileCreator.AddLine("</appSettings>");
            _fileCreator.AddLine("<validators>");
            _fileCreator.AddLine("<add key=\"0\" value=\"ValidatorCurrency\" />");
            _fileCreator.AddLine("<add key=\"1\" value=\"ValidatorDateValidator_MMDDYYYY\" />");
            _fileCreator.AddLine("<add key=\"2\" value=\"ValidatorDateValidator_YYMMDD\" />");
            _fileCreator.AddLine("<add key=\"3\" value=\"ValidatorDateValidator_YYYYMMDD\" />");
            _fileCreator.AddLine("<add key=\"4\" value=\"ValidatorFieldIsNotBlank\" />");
            _fileCreator.AddLine("<add key=\"5\" value=\"ValidatorFieldLength_10\" />");
            _fileCreator.AddLine("<add key=\"6\" value=\"ValidatorMaxFieldLength_5\" />");
            _fileCreator.AddLine("<add key=\"7\" value=\"ValidatorNoNumbers\" />");
            _fileCreator.AddLine("<add key=\"8\" value=\"ValidatorNumber\" />");
            _fileCreator.AddLine("</validators>");
            _fileCreator.AddLine("<system.web>");
            _fileCreator.AddLine("<membership defaultProvider=\"ClientAuthenticationMembershipProvider\">");
            _fileCreator.AddLine("<providers>");
            _fileCreator.AddLine("<add name=\"ClientAuthenticationMembershipProvider\" type=\"System.Web.ClientServices.Providers.ClientFormsAuthenticationMembershipProvider, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\" serviceUri=\"\" />");
            _fileCreator.AddLine("</providers>");
            _fileCreator.AddLine("</membership>");
            _fileCreator.AddLine("<roleManager defaultProvider=\"ClientRoleProvider\" enabled=\"true\">");
            _fileCreator.AddLine("<providers>");
            _fileCreator.AddLine("<add name=\"ClientRoleProvider\" type=\"System.Web.ClientServices.Providers.ClientRoleProvider, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\" serviceUri=\"\" cacheTimeout=\"86400\" />");
            _fileCreator.AddLine("</providers>");
            _fileCreator.AddLine("</roleManager>");
            _fileCreator.AddLine("</system.web>");
            _fileCreator.AddLine("</configuration>");
        }

        private string GetConfigFilePath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string levelUp = Directory.GetParent(currentDirectory).FullName;
            levelUp = Directory.GetParent(levelUp).FullName;
            levelUp = Directory.GetParent(levelUp).FullName;

            return Path.Combine(levelUp, "ConsoleApplication1", "bin", "Release", "FileValidator.exe.config");
        }
    }
}
