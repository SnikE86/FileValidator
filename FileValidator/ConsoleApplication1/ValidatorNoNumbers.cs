using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileValidator
{
    public class ValidatorNoNumbers : IValidator
    {
        public Boolean ValidateField(string fieldText, out string errorText)
        {
            for (int index = 0; index < fieldText.Length; index++)
            {
                if (char.IsNumber(fieldText, index))
                {
                    errorText = "Field contains a number: " + fieldText;
                    return false;
                }
            }
            errorText = "";
            return true;
        }
    }
}
