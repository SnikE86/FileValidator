using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileValidator
{
    class ValidatorFieldLength : IValidator
    {
        private int fieldLength;

        public ValidatorFieldLength(int aFieldLength)
        {
            fieldLength = aFieldLength;
            
        }

        public Boolean ValidateField(string fieldText, string errorText)
        {
            if(fieldText.Length == fieldLength){
                return true;
            }
            else{
                errorText = "Field is not of length " + fieldLength.ToString() + ": " + fieldText;
                return false;
            }
        }
    }
}
