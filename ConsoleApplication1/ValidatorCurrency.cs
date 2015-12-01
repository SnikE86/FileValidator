using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileValidator
{
    public class ValidatorCurrency : IValidator
    {
        public Boolean ValidateField(string fieldText, out string errorText)
        {
            int fieldLength = fieldText.Length;

            for (int index = 0; index < fieldLength; index++)
            {
                if (index != fieldLength - 3)
                {
                    if (!char.IsNumber(fieldText, index))
                    {
                        errorText = "Field is not a currency (expected format: dd.dd): " + fieldText;
                        return false;
                    }
                }
                else
                {
                    if (fieldText[index] != '.')
                    {
                        errorText = "Field is not a currency (expected format: dd.dd): " + fieldText;
                        return false;
                    }
                }
            }
            errorText = "";
            return true;
        }
    }
}
