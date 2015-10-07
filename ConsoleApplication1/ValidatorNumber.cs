using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileValidator
{
    public class ValidatorNumber : IValidator
    {
        public Boolean ValidateField(string fieldText, out string errorText)
        {
            for (int index = 0; index < fieldText.Length; index++)
            {
                if (!char.IsNumber(fieldText, index))
                {
                    errorText = "Field does not only contain numbers: " + fieldText;
                    return false;
                }
            }
            errorText = "";
            return true;
        }
    }
}
