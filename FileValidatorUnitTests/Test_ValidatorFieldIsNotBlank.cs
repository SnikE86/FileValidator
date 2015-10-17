using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileValidator;

namespace FileValidatorUnitTests
{
    [TestClass]
    public class Test_ValidatorFieldIsNotBlank
    {
        [TestMethod]
        public void FailWhenFieldIsBlank()
        {
            ValidatorFieldIsNotBlank validator = new ValidatorFieldIsNotBlank();

            string errorMsg;

            bool result = validator.ValidateField("", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is blank", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void PassWhenFieldIsNotBlank()
        {
            ValidatorFieldIsNotBlank validator = new ValidatorFieldIsNotBlank();

            string errorMsg;

            bool result = validator.ValidateField("123", out errorMsg);

            Assert.IsTrue(result);
            Assert.AreEqual(errorMsg, "", "errorMsg is: " + errorMsg);
        }
    }
}
