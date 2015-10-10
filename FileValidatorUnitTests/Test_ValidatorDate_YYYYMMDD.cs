using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileValidator;

namespace FileValidatorUnitTests
{
    [TestClass]
    public class Test_ValidatorDate_YYYYMMDD
    {
        [TestMethod]
        public void Test_FieldIsYYYYMMDD()
        {
            ValidatorDate_YYYYMMDD validator = new ValidatorDate_YYYYMMDD();

            string errorMsg;

            bool result = validator.ValidateField("20151007", out errorMsg);

            Assert.IsTrue(result);
            Assert.AreEqual(errorMsg, "", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIsTooShort()
        {
            ValidatorDate_YYYYMMDD validator = new ValidatorDate_YYYYMMDD();

            string errorMsg;

            bool result = validator.ValidateField("2015100", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not correct length (expected 8): 2015100", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIsTooLong()
        {
            ValidatorDate_YYYYMMDD validator = new ValidatorDate_YYYYMMDD();

            string errorMsg;

            bool result = validator.ValidateField("201510070", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not correct length (expected 8): 201510070", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_DayIsInvalid()
        {
            ValidatorDate_YYYYMMDD validator = new ValidatorDate_YYYYMMDD();

            string errorMsg;

            bool result = validator.ValidateField("20151047", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not a date: 20151047", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_MonthIsInvalid()
        {
            ValidatorDate_YYYYMMDD validator = new ValidatorDate_YYYYMMDD();

            string errorMsg;

            bool result = validator.ValidateField("20153007", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not a date: 20153007", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldContainsAlphaChars()
        {
            ValidatorDate_YYYYMMDD validator = new ValidatorDate_YYYYMMDD();

            string errorMsg;

            bool result = validator.ValidateField("abcdefgh", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not a date: abcdefgh", "errorMsg is: " + errorMsg);
        }
    }
}
