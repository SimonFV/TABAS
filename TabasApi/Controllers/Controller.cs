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
        private readonly IDataBase repository;

        public Controller(IDataBase repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("employee")]
        public IEnumerable<Trabajador> GetEmployees()
        {
            var trabajadores = repository.trabajadores;
            return trabajadores;
        }

        [HttpGet("employee/{id}")]
        public ActionResult<Trabajador> GetEmployee(string id)
        {
            var trabajador = repository.trabajadores.Where(trabajador => trabajador.cedula == id).SingleOrDefault();
            if (trabajador is null)
            {
                return NotFound();
            }
            return trabajador;
        }

        [HttpPost]
        [Route("employee/register")]
        public ActionResult<Trabajador> RegisterEmployee(Trabajador employeeDto)
        {
            Trabajador employee = new()
            {
                cedula = employeeDto.cedula,
                nombre_rol = employeeDto.nombre_rol,
                nombre = employeeDto.nombre,
                apellido_1 = employeeDto.apellido_1,
                apellido_2 = employeeDto.apellido_2,
                password = employeeDto.password
            };

            repository.trabajadores.Add(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.cedula }, employee);
        }

        [HttpPost]
        [Route("employee/login")]
        public ActionResult LoginEmployee(LoginTrabajadorDto trabajadorDto)
        {
            var trabajador = repository.trabajadores.Where(trabajador =>
                trabajador.nombre == trabajadorDto.nombre &
                trabajador.password == trabajadorDto.password &
                trabajador.nombre_rol == trabajadorDto.nombre_rol).SingleOrDefault();
            if (trabajador is null)
            {
                return NotFound();
            }
            return NoContent();
        }
        /*
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