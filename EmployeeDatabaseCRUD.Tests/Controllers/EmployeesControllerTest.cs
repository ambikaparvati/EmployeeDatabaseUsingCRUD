using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeDatabaseCRUD;
using EmployeeDatabaseCRUD.Controllers;
using EmployeeDatabaseCRUD.Models;
using Rhino.Mocks;

namespace EmployeeDatabaseCRUD.Tests
{
    /// <summary>
    /// Summary description for EmployeesController
    /// </summary>
    [TestClass]
    public class EmployeesControllerTest
    {
        Employees Employee1 = new Employees { ID = 1, FirstName = "John", LastName = "Doe", Gender = "Male", Email = "john@doe.com", Status = "Activated" };
        Employees Employee2 = new Employees { ID = 1, FirstName = "", LastName = "Doe", Gender = "Male", Email = "john@doe.com", Status = "Activated" };
        Employees Employee3 = new Employees { ID = 1, FirstName = "John", LastName = "", Gender = "Male", Email = "john@doe.com", Status = "Activated" };
        Employees Employee4 = new Employees { ID = 1, FirstName = "John", LastName = "Doe", Gender = "Male", Email = "", Status = "Activated" };
        Employees Employee5 = new Employees { ID = 1, FirstName = "John", LastName = "Doe", Gender = "Male", Email = "johndoe", Status = "Activated" };
        Employees Employee6 = new Employees { ID = 1, FirstName = "John", LastName = "Doe", Gender = "Male", Email = "john@doe.com", Status = "Deactivated" };

        [TestMethod]
        public void PostCorrectEmployee()
        {
            var mockEmployeesRepository = MockRepository.GenerateMock<IEmployeesRepository>();
            mockEmployeesRepository.Expect(x => x.Add(Employee1)).Return(true);

            ValdatingDetails mockEmployee = new ValdatingDetails(mockEmployeesRepository);
            bool result = mockEmployee.InsertEmployee(Employee1);
            Assert.AreEqual(true, result, "Added");
        }
        [TestMethod]
        public void PostWithEmptyFirstName()
        {
            var mockEmployeesRepository = MockRepository.GenerateMock<IEmployeesRepository>();
            mockEmployeesRepository.Expect(x => x.Add(Employee2)).Return(true);

            ValdatingDetails mockEmployee = new ValdatingDetails(mockEmployeesRepository);
            try
            {
                mockEmployee.InsertEmployee(Employee2);
            }
            catch (Exception e)
            {
                Assert.AreEqual("First Name cannot be empty \n", e.Message);
            }
        }
        [TestMethod]
        public void PostWithEmptyLastName()
        {
            var mockEmployeesRepository = MockRepository.GenerateMock<IEmployeesRepository>();
            mockEmployeesRepository.Expect(x => x.Add(Employee3)).Return(true);

            ValdatingDetails mockEmployee = new ValdatingDetails(mockEmployeesRepository);
            try
            {
                mockEmployee.InsertEmployee(Employee3);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Last Name cannot be empty \n", e.Message);
            }
        }
        [TestMethod]
        public void PostWithEmptyEmail()
        {
            var mockEmployeesRepository = MockRepository.GenerateMock<IEmployeesRepository>();
            mockEmployeesRepository.Expect(x => x.Add(Employee4)).Return(true);

            ValdatingDetails mockEmployee = new ValdatingDetails(mockEmployeesRepository);
            try
            {
                mockEmployee.InsertEmployee(Employee4);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Email cannot be empty \n", e.Message);
            }
        }
        [TestMethod]
        public void PostWithInvalidEmail()
        {
            var mockEmployeesRepository = MockRepository.GenerateMock<IEmployeesRepository>();
            mockEmployeesRepository.Expect(x => x.Add(Employee5)).Return(true);

            ValdatingDetails mockEmployee = new ValdatingDetails(mockEmployeesRepository);
            try
            {
                mockEmployee.InsertEmployee(Employee5);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Invalid Email Id", e.Message);
            }
        }
        [TestMethod]
        public void PutCorrectEmployee()
        {
            var mockEmployeesRepository = MockRepository.GenerateMock<IEmployeesRepository>();
            mockEmployeesRepository.Expect(x => x.Update(Employee1)).Return(true);

            ValdatingDetails mockEmployee = new ValdatingDetails(mockEmployeesRepository);
            bool result = mockEmployee.UpdateEmployee(Employee1);
            Assert.AreEqual(true, result, "Updated");
        }
        [TestMethod]
        public void PutWithEmptyFirstName()
        {
            var mockEmployeesRepository = MockRepository.GenerateMock<IEmployeesRepository>();
            mockEmployeesRepository.Expect(x => x.Update(Employee2)).Return(true);

            ValdatingDetails mockEmployee = new ValdatingDetails(mockEmployeesRepository);
            try
            {
                mockEmployee.UpdateEmployee(Employee2);
            }
            catch (Exception e)
            {
                Assert.AreEqual("First Name cannot be empty \n", e.Message);
            }
        }
        [TestMethod]
        public void PutWithEmptyLastName()
        {
            var mockEmployeesRepository = MockRepository.GenerateMock<IEmployeesRepository>();
            mockEmployeesRepository.Expect(x => x.Update(Employee3)).Return(true);

            ValdatingDetails mockEmployee = new ValdatingDetails(mockEmployeesRepository);
            try
            {
                mockEmployee.UpdateEmployee(Employee3);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Last Name cannot be empty \n", e.Message);
            }
        }
        [TestMethod]
        public void PutWithEmptyEmail()
        {
            var mockEmployeesRepository = MockRepository.GenerateMock<IEmployeesRepository>();
            mockEmployeesRepository.Expect(x => x.Update(Employee4)).Return(true);

            ValdatingDetails mockEmployee = new ValdatingDetails(mockEmployeesRepository);
            try
            {
                mockEmployee.UpdateEmployee(Employee4);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Email cannot be empty \n", e.Message);
            }
        }
        [TestMethod]
        public void PutWithInvalidEmail()
        {
            var mockEmployeesRepository = MockRepository.GenerateMock<IEmployeesRepository>();
            mockEmployeesRepository.Expect(x => x.Update(Employee5)).Return(true);

            ValdatingDetails mockEmployee = new ValdatingDetails(mockEmployeesRepository);
            try
            {
                mockEmployee.UpdateEmployee(Employee5);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Invalid Email Id", e.Message);
            }
        }
    }
}
