CREATE TABLE Employees2(
EmployeeID  int IDENTITY(1,1) NOT NULL,
FirstName nvarchar(50) NOT NULL,
LastName nvarchar(50) NOT NULL,
Email nvarchar(100) NOT NULL,
DateOfBirth date NOT NULL,
Salary decimal(5,2) NOT NULL,
PRIMARY KEY (EmployeeID)
);