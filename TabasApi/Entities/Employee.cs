using System;

namespace TabasApi.Entities
{
    public record Employee
    {
        public Int32 Id { get; init; }
        public string Name { get; init; }
        public string Password { get; init; }
        public DateTimeOffset RegisteredDate { get; init; }
        public string Job { get; init; }
    }
}