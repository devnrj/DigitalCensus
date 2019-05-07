using System;
using System.Collections.Generic;

namespace DigitalCensus.Dotnet.Dtos.Models
{
    public enum Ownership
    {
        Owned,Rented
    }
    public class HouseDto
    {
        public int ID { get; set; }
        public Guid UniqueKey { get; set; }
        public string ApartmentNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string HouseHeadPerson { get; set; }
        public virtual Ownership OwnershipStatus { get; set; }
        public int RoomQuantity { get; set; }
        public string CensusHouseNumber { get; set; }
        public virtual List<CitizenDto> Citizens { get; set; }
    }
}
