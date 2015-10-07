using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileValidator
{
    public class ValidatorFieldLength : IValidator
    {
        private int fieldLength;

        public ValidatorFieldLength(int aFieldLength)
        {
            fieldLength = aFieldLength;
            
        }

        public Boolean ValidateField(string fieldText, out string errorText)
        {
            if(fieldText.Length == fieldLength){
                errorText = "";
                return true;
            }
            else{
                errorText = "Field is not correct length (expected " + fieldLength.ToString() + "): " + fieldText;
                return false;
            }
        }
    }
}
