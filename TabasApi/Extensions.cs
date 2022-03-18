using TabasApi.Dtos;
using TabasApi.Entities;

namespace TabasApi
{
    public static class Extensions
    {
        public static EmployeeDto AsDto(this Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Password = employee.Password,
                RegisteredDate = employee.RegisteredDate,
                Job = employee.Job
            };
        }
    }
}