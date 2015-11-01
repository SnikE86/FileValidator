using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileValidator;

namespace FileValidatorUnitTests
{
    class FakeUpdateResolver : IUpdateResolver
    {
        Boolean _result;
        public Boolean wasCalled;

        public FakeUpdateResolver(Boolean result)
        {
            _result = result;
            wasCalled = false;
        }

        public Boolean ResolveUpdate()
        {
            wasCalled = true;
            return _result;
        }
    }
}
