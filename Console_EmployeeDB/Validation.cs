using System.Text.RegularExpressions;

namespace Console_EmployeeDB;


class EmployeeID : IValidation
{
    public bool Validate(ref string output, string input)
    {
        if (Regex.IsMatch(input, @"^[0-9]+$", RegexOptions.IgnoreCase))
        {
            input = Regex.Replace(input, @"\D", "");
            int temp = Convert.ToInt32(input);
            output = input;
            return true;
        }
        return false;
    }
}

class FirstName : IValidation
{
    public bool Validate(ref string output, string input)
    {
        if (Regex.IsMatch(input, @"^[а-яА-Яa-zA-Z][a-zA-Z0-9а-яА-Я-]+$", RegexOptions.IgnoreCase) &&
            input.Length <= 50)
        {
            output = input;
            return true;
        }
        return false;
    }
}


class Email : IValidation
{
    public bool Validate(ref string output, string input)
    {
        if (Regex.IsMatch(input, @"([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+)", RegexOptions.IgnoreCase) &&
            input.Length <= 100)
        {
            output = input;
            return true;
        }
        return false;
    }
}


class Date : IValidation
{
    public bool Validate(ref string output, string input)
    {
        if (Regex.IsMatch(input, @"(0?[1-9]|[12][0-9]|3[01]).(0?[1-9]|1[012]).((19|20)\d\d)", RegexOptions.IgnoreCase))
        {
            //DateOnly temp = DateOnly.FromDateTime(Convert.ToDateTime(input));// сделанно для вызова Exception
            DateTime temp = Convert.ToDateTime(input);// сделанно для вызова Exception
            output = input;
            return true;
        }
        return false;
    }
}


class Salary : IValidation
{
    public bool Validate(ref string output, string input)
    {
        if (Regex.IsMatch(input, @"(^\d*.?\d*$)", RegexOptions.IgnoreCase) &&
            input.Length <= 15)
        {
            input = Regex.Replace(input, "([.]+)", ",");
            decimal temp = Convert.ToDecimal(input);// сделанно для вызова Exception
            output = input;
            return true;
        }
        return false;
    }
}
