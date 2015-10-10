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

            bool result = validator.ValidateField("151007", out errorMsg);

            Assert.IsTrue(result);
            Assert.AreEqual(errorMsg, "", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIsTooShort()
        {
            ValidatorDate_YYMMDD validator = new ValidatorDate_YYMMDD();

            string errorMsg;

            bool result = validator.ValidateField("15100", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not correct length (expected 6): 15100", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIsTooLong()
        {
            ValidatorDate_YYMMDD validator = new ValidatorDate_YYMMDD();

            string errorMsg;

            bool result = validator.ValidateField("1510070", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not correct length (expected 6): 1510070", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_DayIsInvalid()
        {
            ValidatorDate_YYMMDD validator = new ValidatorDate_YYMMDD();

            string errorMsg;

            bool result = validator.ValidateField("151047", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not a date: 151047", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_MonthIsInvalid()
        {
            ValidatorDate_YYMMDD validator = new ValidatorDate_YYMMDD();

            string errorMsg;

            bool result = validator.ValidateField("153007", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not a date: 153007", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldContainsAlphaChars()
        {
            ValidatorDate_YYMMDD validator = new ValidatorDate_YYMMDD();

            string errorMsg;

            bool result = validator.ValidateField("abcdef", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not a date: abcdef", "errorMsg is: " + errorMsg);
        }
    }
}
