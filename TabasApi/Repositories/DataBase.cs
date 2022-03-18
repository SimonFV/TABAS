using System;
using System.Collections.Generic;
using System.Text.Json;

namespace TabasApi.Repositories
{
    public class Rol
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }

    public class Trabajador
    {
        public string cedula { get; set; }
        public string nombre_rol { get; set; }
        public string nombre { get; set; }
        public string apellido_1 { get; set; }
        public string apellido_2 { get; set; }
        public string password { get; set; }
    }

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

    public class Usuario
    {
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido_1 { get; set; }
        public string apellido_2 { get; set; }
        public string telefono { get; set; }
    }

    public class Bagcar
    {
        public string identificador { get; set; }
        public string id_vuelo { get; set; }
        public string sello_seguridad { get; set; }
        public string cantidad_maleta { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
    }

    public class Vuelo
    {
        public string numero_vuelo { get; set; }
        public string id_avion { get; set; }
        public string total_maletas { get; set; }
        public string maletas_avion { get; set; }
        public string rechazadas { get; set; }
    }

    public class Avion
    {
        public string identificador { get; set; }
        public string nombre { get; set; }
        public string capacidad { get; set; }
        public string tipo { get; set; }
    }

    public class DataBase : IDataBase
    {
        public List<Rol> roles { get; set; }
        public List<Trabajador> trabajadores { get; set; }
        public List<Maleta> maletas { get; set; }
        public List<Usuario> usuarios { get; set; }
        public List<Bagcar> bagcars { get; set; }
        public List<Vuelo> vuelos { get; set; }
        public List<Avion> aviones { get; set; }

        public DataBase()
        {
            roles = new List<Rol>
                {
                    new Rol {nombre = "scan", descripcion = "escanea"},
                    new Rol {nombre = "administrador", descripcion = "gestiona"},
                    new Rol {nombre = "embarcador", descripcion = "manejo"},
                    new Rol {nombre = "recepcionista", descripcion = "atencion"}
                };
            trabajadores = new List<Trabajador>
                {
                    new Trabajador {cedula = "201", nombre_rol="scan", nombre="Mario", apellido_1="Lópes", apellido_2="Valdez", password="123"},
                    new Trabajador {cedula = "101", nombre_rol="admin", nombre="Jimena", apellido_1="Arco", apellido_2="Suárez", password="123"},
                    new Trabajador {cedula = "301", nombre_rol="embarcador", nombre="Kenneth", apellido_1="Rodríguez", apellido_2="Cruz", password="123"},
                    new Trabajador {cedula = "401", nombre_rol="receptionist", nombre="Maria", apellido_1="Jiménez", apellido_2="Sánchez", password="123"}
                };
            maletas = new List<Maleta>
                {
                    new Maleta {numero = "1", usuario_cedula = "685", trabajador_cedula = "401", id_bagcar = "75", id_vuelo = "253", costo = "40", peso = "20", color = "rojizo"},
                    new Maleta {numero = "2", usuario_cedula = "685", trabajador_cedula = "401", id_bagcar = "75", id_vuelo = "253", costo = "30", peso = "30", color = "blanco"},
                    new Maleta {numero = "3", usuario_cedula = "714", trabajador_cedula = "401", id_bagcar = "75", id_vuelo = "253", costo = "80", peso = "80", color = "negro"},
                    new Maleta {numero = "4", usuario_cedula = "347", trabajador_cedula = "401", id_bagcar = "855", id_vuelo = "268", costo = "50", peso = "20", color = "azul"},
                    new Maleta {numero = "5", usuario_cedula = "347", trabajador_cedula = "401", id_bagcar = "855", id_vuelo = "268", costo = "44", peso = "15", color = "negro"},
                    new Maleta {numero = "6", usuario_cedula = "952", trabajador_cedula = "401", id_bagcar = "855", id_vuelo = "268", costo = "33", peso = "25", color = "verde"}
                };
            usuarios = new List<Usuario>
                {
                    new Usuario {cedula = "685", nombre="Jacob", apellido_1="Trejos", apellido_2="García", telefono="89456231"},
                    new Usuario {cedula = "714", nombre="Yara", apellido_1="Taylor", apellido_2="Licea", telefono="85624179"},
                    new Usuario {cedula = "347", nombre="Pedro", apellido_1="Farran ", apellido_2="Osle", telefono="87459123"},
                    new Usuario {cedula = "952", nombre="Griselda", apellido_1="Alguilera", apellido_2="Madrigal", telefono="82965147"}
                };
            bagcars = new List<Bagcar>
                {
                    new Bagcar{identificador = "75", id_vuelo = "253", sello_seguridad = "15asdaw685", cantidad_maleta = "2", modelo = "ATX240EH", marca = "2018"},
                    new Bagcar{identificador = "855", id_vuelo = "268", sello_seguridad = "8as4d63aw8", cantidad_maleta = "3", modelo = "ATX240EHL", marca = "2016"}
                };
            vuelos = new List<Vuelo>
                {
                    new Vuelo {numero_vuelo = "253", id_avion = "001", total_maletas = "3", maletas_avion="2", rechazadas = "1"},
                    new Vuelo {numero_vuelo = "268", id_avion = "002", total_maletas = "3", maletas_avion="3", rechazadas = "0"}
                };
            aviones = new List<Avion>
                {
                    new Avion {identificador = "001", nombre = "Boeing 747 - 400 ERF", capacidad = "100", tipo="carga"},
                    new Avion {identificador = "002", nombre = "Boeing 737", capacidad = "50", tipo="mixtos"}
                };
        }
    }

}