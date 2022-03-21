using System;
using System.ComponentModel.DataAnnotations;

namespace TabasApi.Dtos
{
    public record CarVueloDto
    {
        [Required]
        public string idBagCar { get; init; }

        [Required]
        public string idVuelo { get; init; }
    }
}