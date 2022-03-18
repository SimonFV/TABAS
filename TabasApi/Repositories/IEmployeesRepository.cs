
using System;
using System.Collections.Generic;
using TabasApi.Entities;

namespace TabasApi.Repositories
{
    public interface IEmployeesRepository
    {
        void AddEmployee(Employee employee);
        void DeleteEmployee(Int32 id);
        Employee GetEmployee(Int32 id);
        IEnumerable<Employee> GetEmployees();
        void UpdateEmployee(Employee employee);
        Employee CheckPassword(string name, string password);
    }
}
