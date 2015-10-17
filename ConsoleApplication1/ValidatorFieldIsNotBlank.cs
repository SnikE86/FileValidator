using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileValidator
{
    public class ValidatorFieldIsNotBlank : IValidator
    {
        public Boolean ValidateField(string fieldText, out string errorText)
        {
            if (fieldText.Length == 0)
            {
                errorText = "Field is blank";
                return false;
            }
            else
            {
                errorText = "";
                return true;
            }
        }
    }
}
