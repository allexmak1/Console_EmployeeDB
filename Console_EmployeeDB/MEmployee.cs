namespace Console_EmployeeDB;

internal class MEmployee
{
    public int EmployeeID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public decimal Salary { get; set; }

}
