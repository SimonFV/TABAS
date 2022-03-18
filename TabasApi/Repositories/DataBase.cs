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
    }

}