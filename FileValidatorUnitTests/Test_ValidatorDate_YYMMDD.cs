using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileValidator;

namespace FileValidatorUnitTests
{
    [TestClass]
    public class Test_ValidatorDate_YYMMDD
    {
        [TestMethod]
        public void Test_FieldIsYYMMDD()
        {
            ValidatorDate_YYMMDD validator = new ValidatorDate_YYMMDD();

            string errorMsg;

            bool result = validator.ValidateField("071015", out errorMsg);

            Assert.IsTrue(result);
            Assert.AreEqual(errorMsg, "", "errorMsg is: " + errorMsg);
        }
    }
}
