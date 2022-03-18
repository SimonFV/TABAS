using System;
using System.ComponentModel.DataAnnotations;

namespace TabasApi.Dtos
{
    public record LoginTrabajadorDto
    {
        [Required]
        public string nombre { get; init; }

        [Required]
        public string password { get; init; }

        [Required]
        public string nombre_rol { get; init; }
    }
}