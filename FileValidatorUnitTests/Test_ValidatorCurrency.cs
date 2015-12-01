using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileValidator;

namespace FileValidatorUnitTests
{
    [TestClass]
    public class Test_ValidatorCurrency
    {
        [TestMethod]
        public void PassWhenFieldIsCurrency()
        {
            ValidatorCurrency validator = new ValidatorCurrency();

            string errorMsg;

            bool result = validator.ValidateField("1234567.89", out errorMsg);

            Assert.IsTrue(result);
            Assert.AreEqual(errorMsg, "", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void FailWhenFieldContainsCurrencySymbol()
        {
            ValidatorCurrency validator = new ValidatorCurrency();

            string errorMsg;

            bool result = validator.ValidateField("£1234567.89", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not a currency (expected format: dd.dd): £1234567.89", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void FailWhenPointIsMissing()
        {
            ValidatorCurrency validator = new ValidatorCurrency();

            string errorMsg;

            bool result = validator.ValidateField("123456789", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not a currency (expected format: dd.dd): 123456789", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void FailWhenPointIsTooFarLeft()
        {
            ValidatorCurrency validator = new ValidatorCurrency();

            string errorMsg;

            bool result = validator.ValidateField("123456.789", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not a currency (expected format: dd.dd): 123456.789", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void FailWhenPointIsTooFarRight()
        {
            ValidatorCurrency validator = new ValidatorCurrency();

            string errorMsg;

            bool result = validator.ValidateField("12345678.9", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not a currency (expected format: dd.dd): 12345678.9", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void FailWhenFieldContainsANonNumericChar()
        {
            ValidatorCurrency validator = new ValidatorCurrency();

            string errorMsg;

            bool result = validator.ValidateField("a1234567.89", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not a currency (expected format: dd.dd): a1234567.89", "errorMsg is: " + errorMsg);
        }
    }
}
