using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileValidator;

namespace FileValidatorUnitTests
{
    [TestClass]
    public class Test_ValidatorFieldLength
    {
        [TestMethod]
        public void Test_FieldIs5_Pass()
        {
            ValidatorFieldLength validator = new ValidatorFieldLength(5);

            string errorMsg;

            bool result = validator.ValidateField("12345", out errorMsg);

            Assert.IsTrue(result);
            Assert.AreEqual(errorMsg, "", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIs5_TooShort()
        {
            ValidatorFieldLength validator = new ValidatorFieldLength(5);

            string errorMsg;

            bool result = validator.ValidateField("1234", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not correct length (expected 5): 1234", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIs5_TooLong()
        {
            ValidatorFieldLength validator = new ValidatorFieldLength(5);

            string errorMsg;

            bool result = validator.ValidateField("123456", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not correct length (expected 5): 123456", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIs8_Pass()
        {
            ValidatorFieldLength validator = new ValidatorFieldLength(8);

            string errorMsg;

            bool result = validator.ValidateField("12345678", out errorMsg);

            Assert.IsTrue(result);
            Assert.AreEqual(errorMsg, "", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIs8_TooShort()
        {
            ValidatorFieldLength validator = new ValidatorFieldLength(8);

            string errorMsg;

            bool result = validator.ValidateField("1234567", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not correct length (expected 8): 1234567", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIs8_TooLong()
        {
            ValidatorFieldLength validator = new ValidatorFieldLength(8);

            string errorMsg;

            bool result = validator.ValidateField("123456789", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not correct length (expected 8): 123456789", "errorMsg is: " + errorMsg);
        }
        
    }
}
