//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Net.Mail;
//using System.Windows;

//namespace EmployeeDatabase
//{
//    public class Employees
//    {
//        SqlCommand sqlCommand;
//        SqlDataAdapter sqlDataAdapter;
//        DataTable dataTable;
//        SqlConnection thisConnection;

//        public int ID { get; set; }
//        public string Name { get; set; }
//        public int Age { get; set; }
//        public string Gender { get; set; }
//        public string Address { get; set; }
//        public string Email { get; set; }

//        public DataTable ConnectionBuild()
//        {
//            var connectionBuilder = new SqlConnectionStringBuilder();
//            connectionBuilder.DataSource = ".";
//            connectionBuilder.InitialCatalog = "EmployeeDetailsDatabase";
//            connectionBuilder.UserID = "sa";
//            connectionBuilder.Password = "Install02";

//            thisConnection = new SqlConnection(connectionBuilder.ToString());
//            thisConnection.Open();
//            string GetQuery = "SELECT * FROM Employee";

//            sqlDataAdapter = new SqlDataAdapter(GetQuery, thisConnection);
//            dataTable = new DataTable();
//            sqlDataAdapter.Fill(dataTable);
//            return dataTable;
//        }

//        public bool Add(int ID, string Name, int Age, string Gender, string Address, string Email)
//        {
//            sqlCommand = new SqlCommand();
//            if (thisConnection.State != ConnectionState.Open)
//                thisConnection.Open();
//            sqlCommand.Connection = thisConnection;

//            bool status = true;// ValidateDetails(id, fn, ln, email);

//            if (status)
//            {
//                try
//                {
//                    sqlCommand.CommandText = "INSERT into Employee(ID,Name,Age,Gender,Address,Email) VALUES(@ID, @Name, @Age, @Gender, @Address, @Email)";

//                    sqlCommand.Parameters.AddWithValue("@ID", ID);
//                    sqlCommand.Parameters.AddWithValue("@Name", Name);
//                    sqlCommand.Parameters.AddWithValue("@Age", Age);
//                    sqlCommand.Parameters.AddWithValue("@Gender", Gender);
//                    sqlCommand.Parameters.AddWithValue("@Address", Address);
//                    sqlCommand.Parameters.AddWithValue("@Email", Email);

//                    sqlCommand.ExecuteNonQuery();
//                    return true;
//                }
//                catch
//                {
//                    MessageBox.Show("Employee ID Already Exists!!");
//                    return false;
//                }
//            }
//            else return false;
//        }

//        public bool Edit(int ID, string Name, int Age, string Gender, string Address)
//        {
//            bool status = true;// ValidateDetails(id, fn, ln, email);
//            if (status)
//            {
//                sqlCommand = new SqlCommand("UPDATE Employee SET Name=@Name, Age=@Age, Gender=@Gender, Address=@Address Where ID=@ID", thisConnection);

//                sqlCommand.Parameters.AddWithValue("@ID", ID);
//                sqlCommand.Parameters.AddWithValue("@Name", Name);
//                sqlCommand.Parameters.AddWithValue("@Age", Age);
//                sqlCommand.Parameters.AddWithValue("@Gender", Gender);
//                sqlCommand.Parameters.AddWithValue("@Address", Address);

//                sqlCommand.ExecuteNonQuery();
//                return true;
//            }
//            else
//                return false;
//        }

//        public bool Delete(string ID)
//        {
//            sqlCommand = new SqlCommand();
//            if (thisConnection.State != ConnectionState.Open)
//                thisConnection.Open();
//            sqlCommand.Connection = thisConnection;
//            bool status = true;// ValidateDetails(id, fn, ln, email);
//            if (status)
//            {
//                sqlCommand.CommandText = "delete from Employee where ID=@ID";
//                sqlCommand.Parameters.AddWithValue("@ID", Int32.Parse(ID));
//                sqlCommand.ExecuteNonQuery();
//                return true;
//            }
//            else
//                return false;
//        }

//        //delete all
//        public bool DeleteAll()
//        {
//            sqlCommand = new SqlCommand();
//            ConnectionBuild();
//            if (thisConnection.State != ConnectionState.Open)
//                thisConnection.Open();
//            sqlCommand.Connection = thisConnection;

//            sqlCommand.CommandText = "delete from Employee";
//            sqlCommand.ExecuteNonQuery();
//            return true;
//        }

//        //exit
//        public void Exit()
//        {
//            thisConnection.Close();
//        }

//        public bool ValidateDetails(string id, string fn, string ln, string email)
//        {
//            if (id == "")
//            {
//                //MessageBox.Show("Enter Employee ID..");
//                //return false;
//                throw new Exception("Enter Employee ID..");
//            }
//            if (fn == "")
//            {
//                //MessageBox.Show("First Name Cannot be Empty !!");
//                //return false;
//                throw new Exception("First Name Cannot be Empty !!");
//            }
//            if (ln == "")
//            {
//                //MessageBox.Show("Last Name Cannot be Empty !!");
//                //return false;
//                throw new Exception("Last Name Cannot be Empty !!");
//            }
//            if (email == "")
//            {
//                //MessageBox.Show("Email Field Cannot be Empty !!");
//                //return false;
//                throw new Exception("Email Field Cannot be Empty !!");
//            }
//            else
//            {
//                try
//                {
//                    MailAddress m = new MailAddress(email);
//                    return true;
//                }
//                catch
//                {
//                    //MessageBox.Show("Enter a Valid Email ID");
//                    //return false;
//                    throw new Exception("Invalid Email ID !!");
//                }
//            }
//        }
//    }
//}
