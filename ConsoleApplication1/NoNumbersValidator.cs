using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileValidator
{
    class NoNumbersValidator : IValidator
    {
        public Boolean ValidateField(string fieldText, string errorText)
        {
            for (int index = 0; index < fieldText.Length; index++)
            {
                if (char.IsNumber(fieldText, index))
                {
                    errorText = "Field contains a number: " + fieldText;
                    return false;
                }
            }
            return true;
        }
    }
}
