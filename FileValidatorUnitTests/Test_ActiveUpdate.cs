using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileValidator;

namespace FileValidatorUnitTests
{
    [TestClass]
    public class Test_ActiveUpdate
    {
        [TestMethod]
        public void CurrentVersionIsHigherThanServerVersion()
        {
            FakeVersionProvider currentVersion = new FakeVersionProvider("1.0.0.2");
            FakeVersionProvider serverVersion = new FakeVersionProvider("1.0.0.1");
            FakeUpdateResolver updateResolver = new FakeUpdateResolver(true);

            ActiveUpdater activeUpdater = new ActiveUpdater(currentVersion, serverVersion, updateResolver);

            Assert.IsTrue(activeUpdater.UpdateSuccessful());
            Assert.IsFalse(updateResolver.wasCalled);
        }

        [TestMethod]
        public void CurrentVersionIsSameAsServerVersion()
        {
            FakeVersionProvider currentVersion = new FakeVersionProvider("1.0.0.1");
            FakeVersionProvider serverVersion = new FakeVersionProvider("1.0.0.1");
            FakeUpdateResolver updateResolver = new FakeUpdateResolver(true);

            ActiveUpdater activeUpdater = new ActiveUpdater(currentVersion, serverVersion, updateResolver);

            Assert.IsTrue(activeUpdater.UpdateSuccessful());
            Assert.IsFalse(updateResolver.wasCalled);
        }

        [TestMethod]
        public void CurrentVersionIsLowerThanServerVersion_UpdateRequested()
        {
            FakeVersionProvider currentVersion = new FakeVersionProvider("1.0.0.1");
            FakeVersionProvider serverVersion = new FakeVersionProvider("1.0.0.2");
            FakeUpdateResolver updateResolver = new FakeUpdateResolver(true);

            ActiveUpdater activeUpdater = new ActiveUpdater(currentVersion, serverVersion, updateResolver);

            Assert.IsTrue(activeUpdater.UpdateSuccessful());
            Assert.IsTrue(updateResolver.wasCalled);
        }

        public void CurrentVersionIsLowerThanServerVersion_UpdateRejected()
        {
            FakeVersionProvider currentVersion = new FakeVersionProvider("1.0.0.1");
            FakeVersionProvider serverVersion = new FakeVersionProvider("1.0.0.2");
            FakeUpdateResolver updateResolver = new FakeUpdateResolver(false);

            ActiveUpdater activeUpdater = new ActiveUpdater(currentVersion, serverVersion, updateResolver);

            Assert.IsFalse(activeUpdater.UpdateSuccessful());
            Assert.IsTrue(updateResolver.wasCalled);
        }
    }
}
