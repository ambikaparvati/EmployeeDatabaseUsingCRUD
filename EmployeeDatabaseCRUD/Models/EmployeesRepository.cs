using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeDatabaseCRUD.Models
{
    public class EmployeesRepository : IEmployeesRepository
    {
        //SqlCommand sqlCommand;
        //SqlDataAdapter sqlDataAdapter;
        //DataTable dataTable;
        //SqlConnection thisConnection;
        //public List<Employees> employees = new List<Employees>();

        public EmployeesRepository()
        {
            List<Employees> employees = new List<Employees>();

            using (var cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from Employee;";
                cmd.Connection = GetOpenDataConnection();
                Employees employee; // new Employee();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employee = new Employees();
                    employee.ID = reader.GetInt32(0);
                    employee.FirstName = reader.GetString(1);
                    employee.LastName = reader.GetString(2);
                    employee.Gender = reader.GetString(3);
                    employee.Email = reader.GetString(4);
                    employee.Status = reader.GetString(5);
                    employees.Add(employee);
                }
                cmd.Connection.Close();
            }
            //var connectionBuilder = new SqlConnectionStringBuilder();
            //connectionBuilder.DataSource = ".";
            //connectionBuilder.InitialCatalog = "EmployeesDetails";
            //connectionBuilder.UserID = "sa";
            //connectionBuilder.Password = "Install02";

            //thisConnection = new SqlConnection(connectionBuilder.ToString());
            //string GetQuery = "SELECT * FROM Employee";
            //using (sqlCommand = new SqlCommand(GetQuery, thisConnection))
            //{
            //    thisConnection.Open();
            //    using (var reader = sqlCommand.ExecuteReader())
            //    {
            //        while (reader.Read())
            //            Add(new Employees
            //            {
            //                ID = reader.GetInt32(0),
            //                FirstName = reader.GetString(1),
            //                LastName = reader.GetString(2),
            //                Gender = reader.GetString(3),
            //                Email = reader.GetString(4),
            //                Status = reader.GetString(5)
            //            });
            //    }
            //}
        }

        public SqlConnection GetOpenDataConnection()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = ".";
            builder.InitialCatalog = "EmployeesDetails";
            builder.UserID = "sa";
            builder.Password = "Install02";

            var connection = new SqlConnection(builder.ToString());
            connection.Open();
            return connection;
        }
        public IEnumerable<Employees> GetAll()
        {
            List<Employees> employees = new List<Employees>();

            using (var cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from Employee;";
                cmd.Connection = GetOpenDataConnection();
                Employees employee; // new Employee();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employee = new Employees();
                    employee.ID = reader.GetInt32(0);
                    employee.FirstName = reader.GetString(1);
                    employee.LastName = reader.GetString(2);
                    employee.Gender = reader.GetString(3);
                    employee.Email = reader.GetString(4);
                    employee.Status = reader.GetString(5);
                    employees.Add(employee);
                }
                cmd.Connection.Close();
            }
            return employees;
        }

        public Employees Get(int id)
        {
            using (var cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from Employee;";
                cmd.Connection = GetOpenDataConnection();
                Employees employee; // new Employee();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employee = new Employees();
                    employee.ID = reader.GetInt32(0);
                    employee.FirstName = reader.GetString(1);
                    employee.LastName = reader.GetString(2);
                    employee.Gender = reader.GetString(3);
                    employee.Email = reader.GetString(4);
                    employee.Status = reader.GetString(5);
                    if (employee.ID == id)
                        return employee;
                }
                cmd.Connection.Close();
            }
            return null;
            //return employees.Find(s => s.ID == id);
        }

        public bool Add(Employees employee)
        {
            if (employee == null)
            {
                return false;
            }

            //int index = employees.FindIndex(s => s.ID == employee.ID);
            //if (index == -1)
            try
            {
                using (var sqlCommand = new SqlCommand())
                {
                    sqlCommand.CommandText = "INSERT into Employee(ID,FirstName,LastName,Gender,Email,Status) VALUES(@ID, @FirstName, @LastName, @Gender, @Email, @Status)";

                    sqlCommand.Parameters.AddWithValue("@ID", employee.ID);
                    sqlCommand.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", employee.LastName);
                    sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
                    sqlCommand.Parameters.AddWithValue("@Email", employee.Email);
                    sqlCommand.Parameters.AddWithValue("@Status", employee.Status);
                    sqlCommand.Connection = GetOpenDataConnection();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();
                }
                return true;
            }
            catch
            {
                //ID already exists
                return false;
            }
        }

        public void Remove(int id)
        {
            using (var cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from Employee;";
                cmd.Connection = GetOpenDataConnection();
                Employees employees; // new Employee();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employees = new Employees();
                    employees.ID = reader.GetInt32(0);
                    employees.FirstName = reader.GetString(1);
                    employees.LastName = reader.GetString(2);
                    employees.Gender = reader.GetString(3);
                    employees.Email = reader.GetString(4);
                    employees.Status = reader.GetString(5);
                    if (employees.ID == id)
                    {
                        var cmdUpdate = new SqlCommand();
                        cmdUpdate.Connection = GetOpenDataConnection();
                        cmdUpdate.CommandText = "delete from Employee where ID=@ID";
                        cmdUpdate.Parameters.AddWithValue("@ID", id);
                        //if (employees.status.Equals("deactivated"))
                        //{
                        int row = cmdUpdate.ExecuteNonQuery();
                        if (row != 0)
                        {
                            cmdUpdate.Connection.Close();
                        }
                        //}
                    }
                }
                cmd.Connection.Close();
            }
        }

        public bool Update(Employees employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("employees");
            }
            //int index = employees.FindIndex(s => s.ID == employee.ID);
            //if (index == -1)
            //{
            //    return false;
            //}
            //employees.RemoveAt(index);
            //employees.Add(employee);
            using (var cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from Employee;";
                cmd.Connection = GetOpenDataConnection();
                Employees employees; // new Employee();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employees = new Employees();
                    employees.ID = reader.GetInt32(0);
                    employees.FirstName = reader.GetString(1);
                    employees.LastName = reader.GetString(2);
                    employees.Gender = reader.GetString(3);
                    employees.Email = reader.GetString(4);
                    employees.Status = reader.GetString(5);
                    if (employees.ID == employee.ID)
                    {
                        var cmdUpdate = new SqlCommand();
                        cmdUpdate.Connection = GetOpenDataConnection();
                        cmdUpdate.CommandText = "UPDATE Employee SET FirstName=@FirstName, LastName=@LastName, Gender=@Gender, Status=@Status Where ID=@ID";

                        cmdUpdate.Parameters.AddWithValue("@ID", employee.ID);
                        cmdUpdate.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        cmdUpdate.Parameters.AddWithValue("@LastName", employee.LastName);
                        cmdUpdate.Parameters.AddWithValue("@Gender", employee.Gender);
                        cmdUpdate.Parameters.AddWithValue("@Status", employee.Status);

                        int row = cmdUpdate.ExecuteNonQuery();
                        if (row != 0)
                        {
                            cmdUpdate.Connection.Close();
                            cmd.Connection.Close();
                            return true;
                        }
                    }
                }
                cmd.Connection.Close();
            }

            return false;
        }
    }
}