using System.Text.RegularExpressions;

namespace Console_EmployeeDB;

internal class Validation
{
    public static bool isName(string text)
    {
        if (Regex.IsMatch(text, @"^[а-яА-Яa-zA-Z][a-zA-Z0-9а-яА-Я-]+$", RegexOptions.IgnoreCase))
            if (text.Length <= 50)
                return true;
        return false;
    }

    public static bool isEmail(string text)
    {
        if (Regex.IsMatch(text, @"([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+)", RegexOptions.IgnoreCase))
            if (text.Length <= 100)
                return true;
        return false;
    }
    public static bool isDate(string text)
    {
        if (Regex.IsMatch(text, @"(0?[1-9]|[12][0-9]|3[01]).(0?[1-9]|1[012]).((19|20)\d\d)", RegexOptions.IgnoreCase))
            return true;
        return false;
    }
    public static bool isDecimal(ref string text)
    {
        if (Regex.IsMatch(text, @"(^\d*.?\d*$)", RegexOptions.IgnoreCase))
            if (text.Length <= 15)
            {
                text = Regex.Replace(text, "([.]+)", ",");
                return true;
            }
        return false;
    }
}
