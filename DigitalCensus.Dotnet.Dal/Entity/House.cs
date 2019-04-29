using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalCensus.Dotnet.Dal.Abstract;

namespace DigitalCensus.Dotnet.Dal.Entity
{
    public enum Ownership
    {
        Owned,Rented
    }
    public class House : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CensusHouseNumber")]
        public int? ID { get; set; }
        public Guid UniqueKey { get; set; }
        public string ApartmentNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string HouseHeadPerson { get; set; }
        public virtual Ownership OwnershipStatus { get; set; }
        public int RoomQuantity { get; set; }
        public virtual IEnumerable<Citizen> Citizens { get; set; }
    }
}
