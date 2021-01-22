<img src="/FileValidator/fileValidatorLogo.ico"></img>

# FileValidator

FileValidator is a tool for validating column types in a csv file using a number of validators.

It is important to set up the config file correctly before using the program:

| config key | description |
|---|---|
| input_folder | The location of the files to be validated. eg: `C:\TestDirectory` |
| file_mask | Used to identify the file types to be validated. eg: `*.txt` |
| errors_file | Where the validation errors should be reported to. eg: `C:\TestDirectory\Output\results.log` |
| delimiter | The character denoting a new column in the files to be validated. **Note quoted fields are not currently supported** eg: `|`|
| successDirectory | Where files which have passed validation should be moved to after validation has completed. This directory will be created if it does not exist. eg: `C:\TestDirectory\Success` |
| failureDirectory | Where files which have failed validation should be moved to after validation has completed. This directory will be created if it does not exist eg: `C:\TestDirectory\Failure`|

The available validators are:

| validator | description |
|---|---|
| ValidatorDate\_YYMMDD | Validates that:</br>The field is exactly 6 characters in length</br>That all characters are numeric values</br>That the 3rd character is either 0 or 1</br>That the 5th character is either 0, 1, 2 or 3 |
| ValidatorDate\_YYYYMMDD | Validates that:</br>The field is exactly 8 characters in length</br>That all characters are numeric values</br>That the 5th character is either 0 or 1</br>That the 7th character is either 0, 1, 2 or 3 |
| ValidatorFieldLength\_X | X must be replaced with any positive integer (can be zero)</br>Validates that the field is exactly X characters in length |
| ValidatorMaxFieldLength\_X | X must be replaced with any positive integer (can be zero)</br>Validates that the field is less than or equal to X characters in length |
| ValidatorNumber | Validates that the field only contains numeric values |
| ValidatorNoNumbers | Validates that the field does not contain numeric values |
| ValidatorFieldIsNotBlank | Validates that the length of the field is greater than zero |

These validators can be used in any sensible combination on column indexes in the file. Column indexes begin with a zero. For example:

```
<validators>
    <add key="0" value="ValidatorDate_YYMMDD" />
    <add key="1" value="ValidatorNumber" />
    <add key="2" value="ValidatorFieldLength_10" />
    <add key="3" value="ValidatorDate_YYYYMMDD" />
    <add key="4" value="ValidatorNoNumbers" />
    <add key="5" value="ValidatorFieldIsNotBlank" />
    <add key="6" value="ValidatorFieldIsNotBlank" />
    <add key="7" value="ValidatorDate_YYMMDD" />
    <add key="8" value="ValidatorMaxFieldLength_150" />
</validators>
```

File Validator created by Michael Ekins 2015
