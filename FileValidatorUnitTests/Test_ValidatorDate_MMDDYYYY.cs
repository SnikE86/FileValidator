using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileValidator;

namespace FileValidatorUnitTests
{
    [TestClass]
    public class Test_ValidatorDate_MMDDYYYY
    {
        [TestMethod]
        public void Test_FieldIsMMDDYYYY()
        {
            ValidatorDate_MMDDYYYY validator = new ValidatorDate_MMDDYYYY();

            string errorMsg;

            bool result = validator.ValidateField("12012015", out errorMsg);

            Assert.IsTrue(result);
            Assert.AreEqual(errorMsg, "", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIsTooShort()
        {
            ValidatorDate_MMDDYYYY validator = new ValidatorDate_MMDDYYYY();

            string errorMsg;

            bool result = validator.ValidateField("120120", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not correct length (expected 8): 120120", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldIsTooLong()
        {
            ValidatorDate_MMDDYYYY validator = new ValidatorDate_MMDDYYYY();

            string errorMsg;

            bool result = validator.ValidateField("120120150", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not correct length (expected 8): 120120150", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_DayIsInvalid()
        {
            ValidatorDate_MMDDYYYY validator = new ValidatorDate_MMDDYYYY();

            string errorMsg;

            bool result = validator.ValidateField("12992015", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not a date: 12992015", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_MonthIsInvalid()
        {
            ValidatorDate_MMDDYYYY validator = new ValidatorDate_MMDDYYYY();

            string errorMsg;

            bool result = validator.ValidateField("99012015", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not a date: 99012015", "errorMsg is: " + errorMsg);
        }

        [TestMethod]
        public void Test_FieldContainsAlphaChars()
        {
            ValidatorDate_MMDDYYYY validator = new ValidatorDate_MMDDYYYY();

            string errorMsg;

            bool result = validator.ValidateField("abcdefgh", out errorMsg);

            Assert.IsFalse(result);
            Assert.AreEqual(errorMsg, "Field is not a date: abcdefgh", "errorMsg is: " + errorMsg);
        }
    }
}
