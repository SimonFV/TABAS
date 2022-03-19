using TabasApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using TabasApi.Dtos;
using System.Text.Json;

namespace TabasApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        // Path del archivo json\
        // Creacion del la base de datos
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

        [HttpGet]
        [Route("baggage")]
        public IEnumerable<Maleta> GetBags()
        {
            var bags = repository.maletas;
            return bags;
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

        [HttpGet("baggage/{number}")]
        public ActionResult<Maleta> GetBaggage(string number)
        {
            var bag = repository.maletas.Where(p => p.numero == number).SingleOrDefault();
            if (bag is null)
            {
                return NotFound();
            }
            return bag;
        }

        [HttpPost]
        [Route("employee/register")]
        public ActionResult<Trabajador> RegisterEmployee(Trabajador employee)
        {
            var match = repository.trabajadores.Where(p => p.cedula == employee.cedula).SingleOrDefault();
            if (match is not null)
            {
                return employee;
            }

            repository.trabajadores.Add(employee);
            repository.UpdateDB();
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

        // color usuario peso costo vuelo
        [HttpPost]
        [Route("baggage")]
        public ActionResult<Maleta> AddBaggage(Maleta bag)
        {
            var match = repository.maletas.Where(p => p.numero == bag.numero).SingleOrDefault();
            if (match is not null)
            {
                return bag;
            }
            repository.maletas.Add(bag);
            repository.UpdateDB();
            return CreatedAtAction(nameof(GetBaggage), new { number = bag.numero }, bag);
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