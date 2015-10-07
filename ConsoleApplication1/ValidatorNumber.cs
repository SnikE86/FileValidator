using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileValidator
{
    class NumberValidator : IValidator
    {
        public Boolean ValidateField(string fieldText, string errorText)
        {
            for (int index = 0; index < fieldText.Length; index++)
            {
                if (!char.IsNumber(fieldText, index))
                {
                    errorText = "Field does not only contain numbers: " + fieldText;
                    return false;
                }
            }
            return true;
        }
    }
}
