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

        [HttpGet]
        [Route("bagcar")]
        public IEnumerable<Bagcar> GetBagcar()
        {
            var bagcars = repository.bagcars;
            return bagcars;
        }

        [HttpGet]
        [Route("flights")]
        public IEnumerable<Vuelo> GetFlights()
        {
            var flights = repository.vuelos;
            return flights;
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
        public ActionResult<Maleta> GetBaggage(Guid number)
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
                return StatusCode(400);
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

        [HttpPost]
        [Route("baggage")]
        public ActionResult<Maleta> AddBaggage(MaletaDto bag)
        {
            var temp = repository.vuelos.Where(p => p.numero_vuelo == bag.idVuelo).SingleOrDefault();
            if (temp is null)
            {
                return NotFound();
            }
            Maleta newBag = new()
            {
                numero = Guid.NewGuid(),
                usuario_cedula = bag.usuario_cedula,
                costo = bag.costo,
                peso = bag.peso,
                color = bag.color,
                id_vuelo = bag.idVuelo
            };
            repository.maletas.Add(newBag);
            var indexFlight = repository.vuelos.FindIndex(p => p.numero_vuelo == bag.idVuelo);
            repository.vuelos[indexFlight].maletas_avion.Add(newBag.numero);
            repository.UpdateDB();
            return CreatedAtAction(nameof(GetBaggage), new { number = newBag.numero }, bag);
        }

        [HttpPut]
        [Route("cartoflight")]
        public ActionResult AddBagToFlight(CarVueloDto ids)
        {
            var bagcar = repository.bagcars.Where(p => p.identificador == ids.idBagCar).SingleOrDefault();
            var flight = repository.vuelos.Where(p => p.numero_vuelo == ids.idVuelo).SingleOrDefault();
            if (bagcar is null || flight is null)
            {
                return NotFound();
            }
            var index = repository.bagcars.FindIndex(p => p.identificador == ids.idBagCar);
            repository.bagcars[index].id_vuelo = ids.idVuelo;
            repository.UpdateDB();
            return NoContent();
        }
    }
}