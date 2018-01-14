using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileValidator;

namespace FileValidatorUnitTests
{
    [TestClass]
    public class Test_ValidatorMaxFieldLength
    {
        [TestMethod]
        public void Test_FieldIs5_PassWhenSameLength()
        {
            ValidatorMaxFieldLength validator = new ValidatorMaxFieldLength(5);

            string errorMsg;

            bool result = validator.ValidateField("12345", out errorMsg);

            Assert.IsTrue(result);
            Assert.AreEqual(errorMsg, "", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIs5_PassWhenShorter()
        {
            ValidatorMaxFieldLength validator = new ValidatorMaxFieldLength(5);

            string errorMsg;

            bool result = validator.ValidateField("1234", out errorMsg);

            Assert.IsTrue(result);
            Assert.AreEqual(errorMsg, "" + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIs5_FailWhenTooLong()
        {
            ValidatorMaxFieldLength validator = new ValidatorMaxFieldLength(5);

            string errorMsg;

            bool result = validator.ValidateField("123456", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is longer than maximum length (max length: 5): 123456", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIs8_PassWhenSameLength()
        {
            ValidatorMaxFieldLength validator = new ValidatorMaxFieldLength(8);

            string errorMsg;

            bool result = validator.ValidateField("12345678", out errorMsg);

            Assert.IsTrue(result);
            Assert.AreEqual(errorMsg, "", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIs8_PassWhenShorter()
        {
            ValidatorMaxFieldLength validator = new ValidatorMaxFieldLength(8);

            string errorMsg;

            bool result = validator.ValidateField("1234567", out errorMsg);

            Assert.IsTrue(result);
            Assert.AreEqual(errorMsg, "", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIs8_FailWhenTooLong()
        {
            ValidatorMaxFieldLength validator = new ValidatorMaxFieldLength(8);

            string errorMsg;

            bool result = validator.ValidateField("123456789", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is longer than maximum length (max length: 8): 123456789", "errorMsg is: " + errorMsg);
        }
    }
}
