using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileValidator;

namespace FileValidatorUnitTests
{
    [TestClass]
    public class Test_ValidatorNumber
    {
        [TestMethod]
        public void Test_FieldIsNotNumeric()
        {
            ValidatorNumber validator = new ValidatorNumber();

            string errorMsg;

            bool result = validator.ValidateField("abc", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field does not only contain numbers: abc", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIsNumeric()
        {
            ValidatorNumber validator = new ValidatorNumber();

            string errorMsg;

            bool result = validator.ValidateField("12345", out errorMsg);

            Assert.IsTrue(result);
            Assert.AreEqual(errorMsg, "", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIsMixed()
        {
            ValidatorNumber validator = new ValidatorNumber();

            string errorMsg;

            bool result = validator.ValidateField("12345abc", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field does not only contain numbers: 12345abc", "errorMsg is: " + errorMsg);
        }


    }
}
