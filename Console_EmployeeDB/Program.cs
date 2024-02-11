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
            if (!dataBase.AddNewEmploee(view.AddEmployee()))
                view.notAddInDB();
            else
                view.AddInDB();
            break;
        case 2:
            view.TableDB(dataBase.loadAll());
            break;
        case 3:
            view.UpdateEmployee();
            break;
        case 4:
            view.DeleteEmployee();
            break;
        default:
            view.ErrorWrite();
            break;
    }
    if (!view.Menu()) return;
}
