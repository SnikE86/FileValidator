using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileValidator;

namespace FileValidatorUnitTests
{
    class FakeVersionProvider : IVersionProvider
    {
        string _version;

        public FakeVersionProvider(string version)
        {
            _version = version;
        }

        public string GetVersion(){
            return _version;
        }
    }
}
