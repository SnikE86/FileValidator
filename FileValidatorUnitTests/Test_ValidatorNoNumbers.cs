using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileValidator;

namespace FileValidatorUnitTests
{
    [TestClass]
    public class Test_ValidatorNoNumbers
    {
        [TestMethod]
        public void Test_FieldIsNotNumeric()
        {
            ValidatorNoNumbers validator = new ValidatorNoNumbers();

            string errorMsg;

            bool result = validator.ValidateField("abc", out errorMsg);

            Assert.IsTrue(result);
            Assert.AreEqual(errorMsg, "", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIsNumeric()
        {
            ValidatorNoNumbers validator = new ValidatorNoNumbers();

            string errorMsg;

            bool result = validator.ValidateField("12345", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field contains a number: 12345", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIsMixed()
        {
            ValidatorNoNumbers validator = new ValidatorNoNumbers();

            string errorMsg;

            bool result = validator.ValidateField("12345abc", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field contains a number: 12345abc", "errorMsg is: " + errorMsg);
        }

        
    }
}
