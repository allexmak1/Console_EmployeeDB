namespace Console_EmployeeDB;

internal class View
{
    public int menuComand { get; set; } = 0;
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
            menuComand = Convert.ToInt32(Console.ReadLine());
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
    public void Head()
    {
        Console.Clear();
        Console.WriteLine("Employee Data Base");
        Console.WriteLine("=======================\n");
    }
    public MEmployee AddEmployee()
    {
        Console.WriteLine(">> Введите нового сотрудника.");
        MEmployee mEmployee = new MEmployee();
        string? tempStr;
        // TODO вынести валидацию в отдельный класс

        while (true)
        {
            Console.WriteLine("Введите Имя:");
            tempStr = Console.ReadLine();
            if (Validation.isName(tempStr))
                break;
            Console.WriteLine("Имя введено неверно!");
        }
        mEmployee.FirstName = tempStr;


        while (true)
        {
            Console.WriteLine("Введите Фамилию:");
            tempStr = Console.ReadLine();
            if (Validation.isName(tempStr))
                break;
            Console.WriteLine("Фамилия введена неверно!");
        }
        mEmployee.LastName = tempStr;


        while (true)
        {
            Console.WriteLine("Введите адрес электронной почты:");
            tempStr = Console.ReadLine();
            if (Validation.isEmail(tempStr))
                break;
            Console.WriteLine("Email введено неверно!");
        }
        mEmployee.Email = tempStr;


        while (true)
        {
            Console.WriteLine("Введите дату рождения:");
            tempStr = Console.ReadLine();
            if (Validation.isDate(tempStr))
                break;
            Console.WriteLine("Дата введена неверно!");
        }
        mEmployee.DateOfBirth = DateOnly.FromDateTime(Convert.ToDateTime(tempStr));


        while (true)
        {
            Console.WriteLine("Введите зарплату:");
            tempStr = Console.ReadLine();
            if (Validation.isDecimal(ref tempStr))
                break;
            Console.WriteLine("Число введено неверно!");
        }
        mEmployee.Salary = Convert.ToDecimal(tempStr);

        return mEmployee;
    }

    public void TableDB(List<MEmployee> LE)
    {
        Console.WriteLine(">> Сотрудники:");
        Console.WriteLine("=======================");
        Console.WriteLine("id\tИмя\tФамилия\temail\t\tдата рождения\tзарплата");
        foreach (var row in LE)
        {
            Console.WriteLine($"{row.EmployeeID}\t{row.FirstName}\t{row.LastName}\t{row.Email}\t{row.DateOfBirth}\t{row.Salary}");
        }
        Console.WriteLine("=======================\n");
    }

    public int UpdateEmployee()
    {
        Console.WriteLine(">> Обновляем информацию сотрудника");
        Console.WriteLine("Введите ID:");
        int id = Convert.ToInt32(Console.ReadLine());
        return id;
    }
    public int DeleteEmployee()
    {
        Console.WriteLine(">> Удаление сотрудника.");
        Console.WriteLine("Введите ID:");
        int id;
        try
        {
            id = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception)
        {
            id = 0;
        }
        return id;
    }
    public void ErrorWrite()
    {
        Console.WriteLine(">> Неправельный ввод.");
        Console.WriteLine("=======================\n");
    }
    public void ErrorConectDB()
    {
        Console.WriteLine(">> База данных не подключена !!");
        Console.WriteLine("=======================\n");
    }
    public void ConectDB()
    {
        Console.WriteLine(">> База данных подключена.");
        Console.WriteLine("=======================\n");
    }


    public void notAddInDB()
    {
        Console.WriteLine("Данные не добавленны !!");
        Console.WriteLine("=======================\n");
    }

    public void AddInDB()
    {
        Console.WriteLine("Данные добавленны.");
        Console.WriteLine("=======================\n");
    }

    public void MessTrue()
    {
        Console.WriteLine("Операция выполненна.");
        Console.WriteLine("=======================\n");
    }

    public void MessFalse()
    {
        Console.WriteLine("Операцию не удалось выполнить!!");
        Console.WriteLine("=======================\n");
    }
}
