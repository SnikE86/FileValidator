using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileValidator
{
    public class ValidatorDate_MMDDYYYY : IValidator
    {
        public Boolean ValidateField(string fieldText, out string errorText)
        {
            //We want to validate that field is in format MMDDYYYY

            if (fieldText.Length == 8)
            {
                if (char.IsNumber(fieldText, 0) && (char.GetNumericValue(fieldText, 0) == 0 || char.GetNumericValue(fieldText, 0) == 1)) //M must be 0 or 1
                {
                    if (char.IsNumber(fieldText, 1)) //M can be any value
                    {
                        if (char.IsNumber(fieldText, 2) && (char.GetNumericValue(fieldText, 2) == 0 || char.GetNumericValue(fieldText, 2) == 1 || char.GetNumericValue(fieldText, 2) == 2 || char.GetNumericValue(fieldText, 2) == 3)) //D must be 0, 1, 2 or 3
                        {
                            if (char.IsNumber(fieldText, 3)) //D can be any value
                            {
                                if (char.IsNumber(fieldText, 4))  //Y can be any digit value
                                {
                                    if (char.IsNumber(fieldText, 5)) //Y can be any digit value
                                    {
                                        if (char.IsNumber(fieldText, 6))  //Y can be any digit value
                                        {
                                            if (char.IsNumber(fieldText, 7)) //Y can be any digit value
                                            {
                                                errorText = "";
                                                return true;
                                            }
                                            else
                                            {
                                                errorText = "Field is not a date: " + fieldText;
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            errorText = "Field is not a date: " + fieldText;
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        errorText = "Field is not a date: " + fieldText;
                                        return false;
                                    }
                                }
                                else
                                {
                                    errorText = "Field is not a date: " + fieldText;
                                    return false;
                                }
                            }
                            else
                            {
                                errorText = "Field is not a date: " + fieldText;
                                return false;
                            }
                        }
                        else
                        {
                            errorText = "Field is not a date: " + fieldText;
                            return false;
                        }
                    }
                    else
                    {
                        errorText = "Field is not a date: " + fieldText;
                        return false;
                    }
                }
                else
                {
                    errorText = "Field is not a date: " + fieldText;
                    return false;
                }
            }
            else
            {
                errorText = "Field is not correct length (expected 8): " + fieldText;
                return false;
            }
        }
    }
}
