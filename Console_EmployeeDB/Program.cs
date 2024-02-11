using Console_EmployeeDB;

View view = new();
DataBase dataBase = new();

view.Head();
dataBase.openConnection();
if (!dataBase.state)
{
    view.ErrorConectDB();
    return;
}
view.ConectDB();
if (!view.Menu()) return;


while (true)
{
    view.Head();
    switch (view.menuComand)
    {
        case 1:
#if false
            if (!dataBase.AddNewEmploee(view.AddEmployee()))
#else
            MEmployee ds = new MEmployee { Salary = 22, FirstName = "dd" ,LastName = "ssa", Email = "gdd@dss.df", DateOfBirth = new DateOnly(2000, 10, 16) };
            if (!dataBase.AddNewEmploee(ds))
#endif
                view.notAddInDB();
            else
                view.AddInDB();
            break;
        case 2:
            view.TableDB(dataBase.loadAll());
            break;
        case 3:
            if(dataBase.UploadEmploee(view.UpdateEmployee()))
                view.MessTrue();
            else
                view.MessFalse();
            break;
        case 4:
            if (dataBase.DeleteEmploee(view.DeleteEmployee()))
                view.MessTrue();
            else
                view.MessFalse();
            break;
        default:
            view.ErrorWrite();
            break;
    }
    if (!view.Menu()) return;
}
