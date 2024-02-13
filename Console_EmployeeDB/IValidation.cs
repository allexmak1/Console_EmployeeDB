namespace Console_EmployeeDB;

internal interface IValidation
{
    bool Validate(ref string output, string input);
}
