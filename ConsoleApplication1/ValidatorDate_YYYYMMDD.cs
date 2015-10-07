using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileValidator
{
    class ValidatorDate_YYYYMMDD : IValidator
    {
        public Boolean ValidateField(string fieldText, string errorText)
        {
            //We want to validate that field is in format YYYYMMDD

            if (fieldText.Length == 8)
            {
                if (char.IsNumber(fieldText, 0))  //Y can be any digit value
                {
                    if (char.IsNumber(fieldText, 1)) //Y can be any digit value
                    {
                        if (char.IsNumber(fieldText, 2)) //Y can be any digit value
                        {
                            if (char.IsNumber(fieldText, 3)) //Y can be any digit value
                            {
                                if (char.IsNumber(fieldText, 4) && (char.GetNumericValue(fieldText, 4) == 0 || char.GetNumericValue(fieldText, 4) == 1)) //M must be 0 or 1
                                {
                                    if (char.IsNumber(fieldText, 5)) //M can be any value
                                    {
                                        if (char.IsNumber(fieldText, 6) && (char.GetNumericValue(fieldText, 6) == 0 || char.GetNumericValue(fieldText, 6) == 1 || char.GetNumericValue(fieldText, 6) == 2 || char.GetNumericValue(fieldText, 6) == 3)) //D must be 0, 1, 2 or 3
                                        {
                                            if (char.IsNumber(fieldText, 7)) //D can be any value
                                            {
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
                        errorText = "Field is too long: " + fieldText;
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
    }
}
