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
#if true
            dataBase.AddNewEmploee(view.AddEmployee());
#else
            MEmployee ds = new MEmployee { Salary = 22, FirstName = "dd", LastName = "ssa", Email = "gdd@dss.df", DateOfBirth = new DateOnly(2000, 10, 16) };
            dataBase.AddNewEmploee(ds);
#endif
            view.MessStatusProcess(dataBase.state);
            break;
        case 2:
            view.TableDB(dataBase.loadAll());
            break;
        case 3:
            dataBase.UploadEmploee(view.UpdateEmployee());
            view.MessStatusProcess(dataBase.state);
            break;
        case 4:
            dataBase.DeleteEmploee(view.DeleteEmployee());
            view.MessStatusProcess(dataBase.state);
            break;
        default:
            view.ErrorWrite();
            break;
    }
    if (!view.Menu()) return;
}
