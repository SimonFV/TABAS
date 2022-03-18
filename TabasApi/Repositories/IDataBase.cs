using System.Collections.Generic;

namespace TabasApi.Repositories
{
    public interface IDataBase
    {
        List<Rol> roles { get; set; }
        List<Trabajador> trabajadores { get; set; }
        List<Maleta> maletas { get; set; }
        List<Usuario> usuarios { get; set; }
        List<Bagcar> bagcars { get; set; }
        List<Vuelo> vuelos { get; set; }
        List<Avion> aviones { get; set; }
    }
}
