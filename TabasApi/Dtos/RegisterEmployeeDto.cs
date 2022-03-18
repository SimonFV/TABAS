using System;
using System.ComponentModel.DataAnnotations;

namespace TabasApi.Dtos
{
    public record RegisterEmployeeDto
    {
        [Required]
        public Int32 Id { get; init; }

        [Required]
        public string Name { get; init; }

        [Required]
        public string Password { get; init; }

        [Required]
        public string Job { get; init; }
    }
}