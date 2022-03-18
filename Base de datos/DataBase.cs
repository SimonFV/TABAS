﻿using System;
using System.Collections.Generic;
using System.Text.Json;

namespace tablas_DB
{
	// Define la clase Rol que se usara en la Base de Datos
	public class Rol
	{
		public string nombre { get; set; }
		public string descripcion { get; set; }
	}

	// Define la clase Trabajador que se usara en la Base de Datos
	public class Trabajador
	{
		public string cedula { get; set; }
		public string nombre_rol { get; set; }
		public string nombre { get; set; }
		public string apellido_1 { get; set; }
		public string apellido_2 { get; set; }
	}

	// Define la clase Maleta que se usara en la Base de Datos
	public class Maleta
	{
		public string numero { get; set; }
		public string usuario_cedula { get; set; }
		public string trabajador_cedula { get; set; }
		public string id_bagcar { get; set; }
		public string id_vuelo { get; set; }
		public string costo { get; set; }
		public string peso { get; set; }
		public string color { get; set; }
	}

	// Define la clase Usuario que se usara en la Base de Datos
	public class Usuario
	{
		public string cedula { get; set; }
		public string nombre { get; set; }
		public string apellido_1 { get; set; }
		public string apellido_2 { get; set; }
		public string telefono { get; set; }
	}

	// Define la clase Bagcar que se usara en la Base de Datos
	public class Bagcar
	{
		public string identificador { get; set; }
		public string id_vuelo { get; set; }
		public string sello_seguridad { get; set; }
		public string cantidad_maleta { get; set; }
		public string modelo { get; set; }
		public string marca { get; set; }
	}

	// Define la clase Vuelo que se usara en la Base de Datos
	public class Vuelo
	{
		public string numero_vuelo { get; set; }
		public string id_avion { get; set; }
		public string total_maletas { get; set; }
		public string maletas_avion { get; set; }
		public string rechazadas { get; set; }
	}

	// Define la clase Avion que se usara en la Base de Datos
	public class Avion
	{
		public string identificador { get; set; }
		public string nombre { get; set; }
		public string capacidad { get; set; }
		public string tipo { get; set; }
	}

	// Creacion de la estructura de la Base de Datos
	public class DB
	{
		public List<Rol> rol { get; set; }
		public List<Trabajador> trabajador { get; set; }
		public List<Maleta> maleta { get; set; }
		public List<Usuario> usuario { get; set; }
		public List<Bagcar> bagcar { get; set; }
		public List<Vuelo> vuelo { get; set; }
		public List<Avion> avion { get; set; }
	}

	public class Program
	{
		public static void Main()
		{
			// Base de Datos (antigua creacion)
			/*var DB = new DB
			{
				rol = new List<Rol>
				{
					new Rol {nombre = "scan", descripcion = "escanea"},
					new Rol {nombre = "administrador", descripcion = "gestiona"},
					new Rol {nombre = "embarcador", descripcion = "manejo"},
					new Rol {nombre = "recepcionista", descripcion = "atencion"}
				},
				trabajador = new List<Trabajador>
				{
					new Trabajador {cedula = "201", nombre_rol="scan", nombre="Mario", apellido_1="Lópes", apellido_2="Valdez"},
					new Trabajador {cedula = "101", nombre_rol="administrador", nombre="Jimena", apellido_1="Arco", apellido_2="Suárez"},
					new Trabajador {cedula = "301", nombre_rol="embarcador", nombre="Kenneth", apellido_1="Rodríguez", apellido_2="Cruz"},
					new Trabajador {cedula = "401", nombre_rol="recepcionista", nombre="María", apellido_1="Jiménez", apellido_2="Sánchez"}
				},
				maleta = new List<Maleta>
				{
					new Maleta {numero = "1", usuario_cedula = "685", trabajador_cedula = "401", id_bagcar = "75", id_vuelo = "253", costo = "40", peso = "20", color = "rojizo"},
					new Maleta {numero = "2", usuario_cedula = "685", trabajador_cedula = "401", id_bagcar = "75", id_vuelo = "253", costo = "30", peso = "30", color = "blanco"},
					new Maleta {numero = "3", usuario_cedula = "714", trabajador_cedula = "401", id_bagcar = "75", id_vuelo = "253", costo = "80", peso = "80", color = "negro"},
					new Maleta {numero = "4", usuario_cedula = "347", trabajador_cedula = "401", id_bagcar = "855", id_vuelo = "268", costo = "50", peso = "20", color = "azul"},
					new Maleta {numero = "5", usuario_cedula = "347", trabajador_cedula = "401", id_bagcar = "855", id_vuelo = "268", costo = "44", peso = "15", color = "negro"},
					new Maleta {numero = "6", usuario_cedula = "952", trabajador_cedula = "401", id_bagcar = "855", id_vuelo = "268", costo = "33", peso = "25", color = "verde"}
				},
				usuario = new List<Usuario>
				{
					new Usuario {cedula = "685", nombre="Jacob", apellido_1="Trejos", apellido_2="García", telefono="89456231"},
					new Usuario {cedula = "714", nombre="Yara", apellido_1="Taylor", apellido_2="Licea", telefono="85624179"},
					new Usuario {cedula = "347", nombre="Pedro", apellido_1="Farran ", apellido_2="Osle", telefono="87459123"},
					new Usuario {cedula = "952", nombre="Griselda", apellido_1="Alguilera", apellido_2="Madrigal", telefono="82965147"}
				},
				bagcar = new List<Bagcar>
				{
					new Bagcar{identificador = "75", id_vuelo = "253", sello_seguridad = "15asdaw685", cantidad_maleta = "2", modelo = "ATX240EH", marca = "2018"},
					new Bagcar{identificador = "855", id_vuelo = "268", sello_seguridad = "8as4d63aw8", cantidad_maleta = "3", modelo = "ATX240EHL", marca = "2016"}
				},
				vuelo = new List<Vuelo>
				{
					new Vuelo {numero_vuelo = "253", id_avion = "001", total_maletas = "3", maletas_avion="2", rechazadas = "1"},
					new Vuelo {numero_vuelo = "268", id_avion = "002", total_maletas = "3", maletas_avion="3", rechazadas = "0"}
				},
				avion = new List<Avion>
				{
					new Avion {identificador = "001", nombre = "Boeing 747 – 400 ERF", capacidad = "100", tipo="carga"},
					new Avion {identificador = "002", nombre = "Boeing 737", capacidad = "50", tipo="mixtos"}
				}
			};*/

			// Path del archivo json
			string file = "DataBase.json";
			// Lectura del json
			string jsonS = File.ReadAllText(file);
			// Creacion del la base de datos
			DB DB = JsonSerializer.Deserialize<DB>(jsonS);


			// todo el json a string
			string jsonString = JsonSerializer.Serialize(DB);

			// Imprime todo el Json
			Console.WriteLine(jsonString);

			// Peticion del nombre del segundo rol
			Console.WriteLine(DB.rol[1].nombre);

			// Peticion del sello_seguridad del primer bagcar
			Console.WriteLine(DB.bagcar[0].sello_seguridad);

			// Peticion del peso de la segunda maleta
			Console.WriteLine(DB.maleta[2].peso);
		}
	}
}