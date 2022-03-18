using TabasApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TabasApi.Entities;
using System;
using System.Linq;
using TabasApi.Dtos;

namespace TabasApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        private readonly IEmployeesRepository repository;

        public Controller(IEmployeesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("employee")]
        public IEnumerable<EmployeeDto> GetEmployees()
        {
            var employees = repository.GetEmployees().Select(employees => employees.AsDto());
            return employees;
        }

        [HttpGet("employee/{id}")]
        public ActionResult<EmployeeDto> GetEmployee(Int32 id)
        {
            var item = repository.GetEmployee(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }

        [HttpPost]
        [Route("employee/register")]
        public ActionResult<EmployeeDto> RegisterEmployee(RegisterEmployeeDto employeeDto)
        {
            Employee employee = new()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Password = employeeDto.Password,
                RegisteredDate = DateTimeOffset.UtcNow,
                Job = employeeDto.Job
            };

            repository.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee.AsDto());
        }

        [HttpPost]
        [Route("employee/login")]
        public ActionResult LoginEmployee(LoginEmployeeDto employeeDto)
        {
            var validEmployee = repository.CheckPassword(employeeDto.Name, employeeDto.Password);
            if (validEmployee is null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // color usuario peso costo vuelo
        [HttpPost]
        [Route("baggage")]
        public ActionResult<EmployeeDto> AddBaggage(RegisterEmployeeDto employeeDto)
        {
            Employee employee = new()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Password = employeeDto.Password,
                RegisteredDate = DateTimeOffset.UtcNow,
                Job = employeeDto.Job
            };

            repository.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee.AsDto());
        }

        /*
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Int32 id, UpdateItemDto employeeDto)
        {
            var existingItem = repository.GetEmployee(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                Name = employeeDto.Name,
                Price = employeeDto.Price
            };

            repository.UpdateItem(updatedItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            repository.DeleteItem(id);

            return NoContent();
        }
        */
    }
}