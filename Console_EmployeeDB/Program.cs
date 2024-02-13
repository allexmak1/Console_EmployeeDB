namespace Console_EmployeeDB;

class Program
{
    static void Main(string[] args)
    {

        View view = new View();
        DBsql DB = new DBsql(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = EmployeeDB; Integrated Security = True;");

        view.Head();
        DB.openConnection();
        view.ConectDB(DB.stateComand);
        if (!DB.stateComand)
        {
            Console.ReadKey();
            return;
        }
        if (!view.Menu())
        {
            DB.closeConnection();
            return;
        }
        while (true)
        {
            view.Head();
            switch (view.menuComand)
            {
                case 1:
                    DB.AddRowComand(view.MenuAddEmployee());
                    view.StatusOperation(DB.stateComand);
                    break;
                case 2:
                    view.MenuAllEmployee(DB.getAllRowComand());
                    view.StatusOperation(DB.stateComand);
                    break;
                case 3:
                    DB.uploadComand(view.MenuUpdateEmployee());
                    view.StatusOperation(DB.stateComand);
                    break;
                case 4:
                    int id = view.MenuDeleteEmployee();
                    //TODO добавить проверку на наличие id
                    if (DB.findId(id))
                    {
                        DB.deleteComand(id);
                        view.StatusOperation(DB.stateComand);
                    }
                    else
                    {
                        view.ErrorNotId();
                    }
                    break;
                default:
                    view.ErrorWrite();
                    break;
            }
            if (!view.Menu())
            {
                DB.closeConnection();
                return;
            }
        }
    }
}
