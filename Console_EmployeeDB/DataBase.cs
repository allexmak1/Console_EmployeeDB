using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using Mysqlx.Datatypes;
using Mysqlx.Crud;

namespace Console_EmployeeDB;

internal class DataBase
{
    private SqlConnection? _connection;
    private bool _state;
    public bool state { get { return _state; } }

    public void openConnection()
    {
        string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = EmployeeDB; Integrated Security = True;";
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

    public List<MEmployee> loadAll()
    {
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
                        DateOfBirth = DateOnly.FromDateTime(sqlDataReader.GetDateTime(4)),
                        Salary = sqlDataReader.GetDecimal(5)
                    };
                    LEmpl.Add(me);
                }
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
            //closeConnection(); //работаем все время с открытой базой
        }
        return LEmpl;
    }

    public void AddNewEmploee(MEmployee me)
    {
        try
        {
            SqlCommand command = new SqlCommand(
                    $"INSERT INTO [Employees] (FirstName, LastName, Email, DateOfBirth, Salary) VALUES (@FirstName, @LastName, @Email, @DateOfBirth, @Salary)",
                    _connection);
            command.Parameters.AddWithValue("FirstName", me.FirstName);
            command.Parameters.AddWithValue("LastName", me.LastName);
            command.Parameters.AddWithValue("Email", me.Email);
            command.Parameters.AddWithValue("DateOfBirth", me.DateOfBirth.ToDateTime(new TimeOnly()));
            command.Parameters.AddWithValue("Salary", me.Salary);
            if (command.ExecuteNonQuery() < 1)
            {
                _state = false;
                return;
            }

            _state = true;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            _state = false;
        }
    }

    public void DeleteEmploee(int id)
    {
        if (_connection != null)
        {
            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM Employees WHERE EmployeeID = {id}", _connection);

                if (command.ExecuteNonQuery() < 1)
                {
                    _state = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _state = false;
                return;
            }
        }
        _state = true;
        return;
    }

    public void UploadEmploee(MEmployee me)
    {
        if (_connection != null)
        {
            try
            {
                string cmd = $"UPDATE Employees SET FirstName = '{me.FirstName}', LastName = '{me.LastName}', Email = '{me.Email}', DateOfBirth = '{me.DateOfBirth}', Salary = '{me.Salary}' WHERE EmployeeID = {me.EmployeeID}";
                SqlCommand command = new SqlCommand(cmd, _connection);
                if (command.ExecuteNonQuery() < 1)
                {
                    _state = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _state = false;
                return;
            }
        }
        _state = true;
        return;
    }

    public void closeConnection()
    {
        if (_connection?.State == System.Data.ConnectionState.Open)
        {
            _connection.Close();
        }
    }

}
