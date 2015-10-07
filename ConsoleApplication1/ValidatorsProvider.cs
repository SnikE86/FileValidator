using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections;

namespace FileValidator
{
    class ValidatorsProvider
    {
        public Dictionary<int, List<IValidator>> GetValidators()
        {
            Dictionary<int, List<IValidator>> validators = new Dictionary<int, List<IValidator>>();

            var section = (Hashtable)ConfigurationManager.GetSection("validators");

            foreach (DictionaryEntry pair in section)
            {
                IValidator validator;

                int key = Int32.Parse(pair.Key.ToString());
                string value = pair.Value.ToString();

                switch (value)
                {
                    case "DateValidator_YYMMDD":
                        validator = new ValidatorDate_YYMMDD();
                        break;
                    case "DateValidator_YYYYMMDD":
                        validator = new ValidatorDate_YYYYMMDD();
                        break;
                    case "NumberValidator":
                        validator = new NumberValidator();
                        break;
                    case "NoNumbersValidator":
                        validator = new ValidatorNoNumbers();
                        break;
                    default: validator = null;
                        break;
                }

                if (value.Contains("ValidatorFieldLength_"))
                {
                    string[] parts = value.Split('_');

                    int fieldLength = Int32.Parse(parts[1].ToString());

                    validator = new ValidatorFieldLength(fieldLength);
                }

                if (validator != null)
                {

                    List<IValidator> validatorList;
                    if (!validators.TryGetValue(key, out validatorList))
                    {
                        validatorList = new List<IValidator>();

                        validators.Add(key, validatorList);
                    }

                    validatorList.Add(validator);
                }
            }

            return validators;
        }
    }
}
