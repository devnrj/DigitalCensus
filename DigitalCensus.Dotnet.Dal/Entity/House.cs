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
        public int ID { get; set; }
        [Required]
        public Guid UniqueKey { get; set; }
        [Required]
        public string ApartmentNumber { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string HouseHeadPerson { get; set; }
        [Required]
        public virtual Ownership OwnershipStatus { get; set; }
        [Required]
        public int RoomQuantity { get; set; }
        private string censusHouseNumber;
        [Required]
        public string CensusHouseNumber { get
            {
             return (HouseHeadPerson + StreetName + City).Trim().Replace(" ", string.Empty).ToLower();
            }
            set
            {
                censusHouseNumber = (HouseHeadPerson + StreetName + City).Trim().Replace(" ",string.Empty).ToLower();
            }
        }
        public virtual List<Citizen> Citizens { get; set; }
    }
}
