using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileValidator
{
    public class ValidatorMaxFieldLength : IValidator
    {
        private int maxFieldLength;

        public ValidatorMaxFieldLength(int aMaxFieldLength)
        {
            maxFieldLength = aMaxFieldLength;

        }

        public Boolean ValidateField(string fieldText, out string errorText)
        {
            if (fieldText.Length <= maxFieldLength)
            {
                errorText = "";
                return true;
            }
            else
            {
                errorText = "Field is longer than maximum length (max length: " + maxFieldLength.ToString() + "): " + fieldText;
                return false;
            }
        }
    }
}
