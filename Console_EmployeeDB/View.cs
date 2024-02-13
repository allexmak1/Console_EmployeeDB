namespace Console_EmployeeDB;

class View
{
    private int _menuComand;

    public int menuComand { get { return _menuComand; } }

    public void Head()
    {
        Console.Clear();
        Console.WriteLine("Employee Data Base");
        Console.WriteLine("=======================\n");
    }

    public bool Menu()
    {
        Console.WriteLine("Меню:");
        Console.WriteLine("1: добавить нового сотрудника.");
        Console.WriteLine("2: Посмотреть всех сотрудников.");
        Console.WriteLine("3: Обновить  информацию о сотруднике.");
        Console.WriteLine("4: Удалить сотрудника.");
        Console.WriteLine("5: Закрыть приложение.");
        try
        {
            _menuComand = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception)
        {
            //просто обновим экран
        }
        if (menuComand == 5)
        {
            Console.WriteLine("Закрываем приложение.");
            return false;
        }
        return true;
    }

    public MEmployee MenuAddEmployee()
    {
        Console.WriteLine(">> Введите нового сотрудника.");
        return InputEmployee(new MEmployee());
    }

    public void MenuAllEmployee(List<MEmployee> LE)
    {
        Console.WriteLine(">> Сотрудники:");
        DB(LE);
    }

    public MEmployee MenuUpdateEmployee()
    {
        Console.WriteLine(">> Обновляем информацию сотрудника");
        MEmployee me = new MEmployee();
        me.EmployeeID = Convert.ToInt32(InputAndValidation("ID", new EmployeeID()));
        InputEmployee(me);
        return me;
    }

    public int MenuDeleteEmployee()
    {
        Console.WriteLine(">> Удаление сотрудника.");
        return Convert.ToInt32(InputAndValidation("ID", new EmployeeID()));
    }


    // метод ввода
    private MEmployee InputEmployee(MEmployee me)
    {

        try
        {
            me.FirstName = InputAndValidation("Имя", new FirstName());
            me.LastName = InputAndValidation("Фамилию", new FirstName());
            me.Email = InputAndValidation("адрес электронной почты", new Email());
            //me.DateOfBirth = DateOnly.FromDateTimeConvert.ToDateTime(InputAndValidation("дату рождения", new Date())));
            me.DateOfBirth = Convert.ToDateTime(InputAndValidation("дату рождения", new Date()));
            me.Salary = Convert.ToDecimal(InputAndValidation("зарплату", new Salary()));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Data);
            Console.WriteLine(">>! Конвертация не удалась!");
            return me;
        }

        //вывод на экран
        Console.WriteLine(">> Итоговая строка: ");
        DB(new List<MEmployee> { me });
        return me;
    }

    // повторный ввод
    protected string InputAndValidation(string column, IValidation v)
    {
        string readline = default(string);
        while (true)
        {
            Console.WriteLine(">> Введите " + column + ":");
            try
            {
                if (v.Validate(ref readline, Console.ReadLine()))
                    break;
                ErrorWrite();
            }
            catch (Exception)
            {
                ErrorWrite();
            }
        }
        return readline;
    }

    //вывод бд
    private void DB(List<MEmployee> LE)
    {
        Console.WriteLine("=======================");
        Console.WriteLine("id\tИмя\tФамилия\temail\t\tдата рождения\t\tзарплата");
        foreach (var row in LE)
        {
            //Console.WriteLine($"{row.EmployeeID}\t{row.FirstName}\t{row.LastName}\t{row.Email}\t{row.DateOfBirth}\t{row.Salary}");
            Console.WriteLine(row.EmployeeID + "\t" + row.FirstName + "\t" + row.LastName + "\t" + row.Email + "\t" + row.DateOfBirth + "\t" + row.Salary);
        }
        Console.WriteLine("=======================\n");
    }



    public void ErrorWrite()
    {
        Console.WriteLine(">>! Неверный формат ввода.");
    }

    public void ConectDB(bool state)
    {
        if (state)
            Console.WriteLine(">> База данных подключена.");

        else
            Console.WriteLine(">>! База данных не подключена !!");
        Console.WriteLine("=======================\n");
    }

    public void StatusOperation(bool state)
    {
        if (state)
            Console.WriteLine(">> Операция выполненна.");
        else
            Console.WriteLine(">>! Операцию не удалось выполнить !!");
        Console.WriteLine("=======================\n");
    }

    public void ErrorNotId() { Console.WriteLine(">>! Не найден ID !!"); }
}
