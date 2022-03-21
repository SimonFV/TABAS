using System;
using System.ComponentModel.DataAnnotations;

namespace TabasApi.Dtos
{
    public class MaletaDto
    {
        [Required]
        public string usuario_cedula { get; set; }
        [Required]
        public string costo { get; set; }
        [Required]
        public string peso { get; set; }
        [Required]
        public string color { get; set; }
        [Required]
        public string idVuelo { get; set; }
    }
}