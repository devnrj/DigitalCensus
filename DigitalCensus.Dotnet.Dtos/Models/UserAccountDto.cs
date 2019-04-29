using System;

namespace DigitalCensus.Dotnet.Dtos.Models
{
    public class UserAccountDto 
    {
        public int ID { get; set; }
        public Guid UniqueKey { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
