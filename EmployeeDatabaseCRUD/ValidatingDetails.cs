using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeDatabaseCRUD.Models;
using System.Net.Mail;

namespace EmployeeDatabaseCRUD
{
    public class ValdatingDetails
    {
        private readonly IEmployeesRepository employeesRep;
        public ValdatingDetails()
        {
            employeesRep = new EmployeesRepository();
        }

        public ValdatingDetails(IEmployeesRepository employee)
        {
            if (employee != null)
                employeesRep = employee;
        }
        public IEnumerable<Employees> GetAll()
        {
            return employeesRep.GetAll();
        }

        public Employees Get(int ID)
        {
            return employeesRep.Get(ID);
        }

        public bool InsertEmployee(Employees Employee)
        {
            if (verify(Employee.FirstName, Employee.LastName, Employee.Email))
                return employeesRep.Add(Employee);
            else
                return false;
        }

        public bool UpdateEmployee(Employees Employee)
        {
            if (verify(Employee.FirstName, Employee.LastName, Employee.Email))
                return employeesRep.Update(Employee);
            else
                return false;
        }

        public static bool verify(string firstName, string lastName, string email)
        {
            string error = "";
            if (string.IsNullOrEmpty(firstName))
                error += "First Name cannot be empty \n";
            if (string.IsNullOrEmpty(lastName))
                error += "Last Name cannot be empty \n";
            if (string.IsNullOrEmpty(email))
                error += "Email cannot be empty \n";
            if (error != "")
            {
                throw (new Exception(error));
            }
            IsValidEmail(email);

            return true;

        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var address = new MailAddress(email);
                return address.Address == email;
            }
            catch
            {
                throw (new Exception("Invalid Email Id"));
            }
        }
    }
}