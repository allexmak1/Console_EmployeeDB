using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace Console_EmployeeDB;

class DBsql
{
    private string connectionString { get; set; }
    private SqlConnection? _connection;
    private bool _state;
    public bool stateComand { get { return _state; } }
    public DBsql(string connection)
    {
        connectionString = connection;
    }

    public void openConnection()
    {
        try
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            if (_connection.State == ConnectionState.Open)
            {
                _state = true;
                return;
            }
        }
        catch (SqlException ex)
        {
            //Console.WriteLine(ex.Message);
            _state = false;
        }
        _state = false;
    }

    public void closeConnection()
    {
        if (_connection?.State == ConnectionState.Open)
        {
            _connection.Close();
            _state = true;
            return;
        }
        _state = false;
    }

    public void AddRowComand(MEmployee me)
    {
        try
        {
            SqlCommand command = new SqlCommand(
                    $"INSERT INTO [Employees] (FirstName, LastName, Email, DateOfBirth, Salary) VALUES (@FirstName, @LastName, @Email, @DateOfBirth, @Salary)",
                    _connection);
            command.Parameters.AddWithValue("FirstName", me.FirstName);
            command.Parameters.AddWithValue("LastName", me.LastName);
            command.Parameters.AddWithValue("Email", me.Email);
            command.Parameters.AddWithValue("DateOfBirth", me.DateOfBirth);
            command.Parameters.AddWithValue("Salary", me.Salary);
            if (command.ExecuteNonQuery() < 1)
            {
                _state = false;
                return;
            }

            _state = true;
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            _state = false;
        }
        _state = false;
    }

    public List<MEmployee> getAllRowComand()
    {
        _state = false;
        List<MEmployee> LEmpl = new List<MEmployee>();
        if (_connection != null)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Employees",
                    _connection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    // заполняем list
                    MEmployee me = new MEmployee()
                    {
                        EmployeeID = sqlDataReader.GetInt32(0),
                        FirstName = sqlDataReader.GetString(1),
                        LastName = sqlDataReader.GetString(2),
                        Email = sqlDataReader.GetString(3),
                        DateOfBirth = sqlDataReader.GetDateTime(4),
                        Salary = sqlDataReader.GetDecimal(5)
                    };
                    LEmpl.Add(me);
                }
                _state = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlDataReader != null && !sqlDataReader.IsClosed)
                {
                    sqlDataReader.Close();
                }
            }
        }
        return LEmpl;





        _state = false;
        return LEmpl;
    }

    public void uploadComand(MEmployee me)
    {
        _state = false;
        if (_connection != null)
        {
            try
            {
                //string cmd = $"UPDATE Employees SET FirstName = '{me.FirstName}', LastName = '{me.LastName}', Email = '{me.Email}', DateOfBirth = '{me.DateOfBirth}', Salary = '{me.Salary}' WHERE EmployeeID = {me.EmployeeID}";
                //SqlCommand command = new SqlCommand(cmd, _connection);

                SqlCommand command = new SqlCommand(
                $"UPDATE Employees SET FirstName = '{me.FirstName}', LastName = '{me.LastName}', Email = '{me.Email}', DateOfBirth = '{me.DateOfBirth}', Salary = '{me.Salary}' WHERE EmployeeID = {me.EmployeeID}",
                        _connection);
                if (command.ExecuteNonQuery() < 1)
                {
                    return;
                }
                _state = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }

    public void deleteComand(int id)
    {

        if (_connection != null)
        {
            try
            {
                _state = false;
                SqlCommand command = new SqlCommand($"DELETE FROM Employees WHERE EmployeeID = {id}", _connection);

                if (command.ExecuteNonQuery() < 1)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        _state = true;
    }

    public bool findId(int id)
    {
        Console.WriteLine("...db findId");
        return true;
    }
}
