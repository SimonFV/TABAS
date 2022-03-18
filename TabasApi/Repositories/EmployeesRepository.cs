using System;
using System.Collections.Generic;
using System.Linq;
using TabasApi.Entities;

namespace TabasApi.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly List<Employee> employees = new();

        public IEnumerable<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee GetEmployee(Int32 id)
        {
            return employees.Where(employee => employee.Id == id).SingleOrDefault();
        }

        public Employee CheckPassword(string name, string password, string job)
        {
            return employees.Where(employee => employee.Name == name & employee.Password == password & employee.Job == job).SingleOrDefault();
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            var index = employees.FindIndex(existingEmployee => existingEmployee.Id == employee.Id);
            employees[index] = employee;
        }

        public void DeleteEmployee(Int32 id)
        {
            var index = employees.FindIndex(existingEmployee => existingEmployee.Id == id);
            employees.RemoveAt(index);
        }

    }
}