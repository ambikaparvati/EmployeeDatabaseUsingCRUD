using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDatabaseCRUD.Models;

namespace EmployeeDatabaseCRUD.Controllers
{
    public class EmployeesController : ApiController
    {
        static readonly IEmployeesRepository employeesRepository = new EmployeesRepository();
        ValdatingDetails employeeValidate = new ValdatingDetails();

        public HttpResponseMessage GetAllEmployees()
        {
            List<Employees> empList = employeesRepository.GetAll().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, empList);
        }

        public HttpResponseMessage GetEmployees(int id)
        {
            Employees employee = employeesRepository.Get(id);
            if (employee == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Not found for the Given ID");
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, employee);
            }
        }

        //public IEnumerable<Employees> GetEmployeesByGender(string gender)
        //{
        //    return employeesRepository.GetAll().Where(
        //        s => string.Equals(s.Gender, gender, StringComparison.OrdinalIgnoreCase));
        //}

        public HttpResponseMessage AddEmployees(Employees Employees)
        {
            if (employeeValidate.InsertEmployee(Employees))
            {
                return Request.CreateResponse(HttpStatusCode.Created, Employees);
                //string uri = Url.Link("DefaultApi", new { id = Employees.ID });
                //response.Headers.Location = new Uri(uri);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Employee Not Added");
            }
        }

        public HttpResponseMessage PutEmployees(int id, Employees Employee)
        {
            Employee.ID = id;
            if (!employeesRepository.Update(Employee))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Unable to Update the Employee for the Given ID");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        public HttpResponseMessage DeleteEmployees(int id)
        {
            Employees employee = employeesRepository.Get(id);
            if (employee == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee Not found for the Given ID");
            }
            else if(employee.Status.Equals("Activated"))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee is Activated");
            }
            else
            {
                employeesRepository.Remove(id);
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
        }
    }
}

////delete all
//public bool DeleteAll()
//{
//    sqlCommand = new SqlCommand();
//    ConnectionBuild();
//    if (thisConnection.State != ConnectionState.Open)
//        thisConnection.Open();
//    sqlCommand.Connection = thisConnection;

//    sqlCommand.CommandText = "delete from Employee";
//    sqlCommand.ExecuteNonQuery();
//    return true;
//}