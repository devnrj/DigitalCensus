using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalCensus.Dotnet.Dal.Abstract;

namespace DigitalCensus.Dotnet.Dal.Entity
{
    public enum Gender
    {
        Male, Female, Transgender
    }
    public enum Relation
    {
        Self, Spouse, Son, Daughter, Sibling, Grandson, Granddaughter
    }
    public enum MaritalStatus
    {
        Single, Married, Divorced
    }
    public enum Occupation
    {
        Employeed, Selfemployeed, Student
    }

    public enum IndustryNature
    {
        Engineering, Medical, Pharmacy, Accounting, HumanResources
    }
    public class Citizen : IEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        [Required]
        public Guid UniqueKey { get; set; }
        [Required]
        public string PersonName { get; set; }
        [Required]
        public virtual Relation RelationWithHead { get; set; }
        [Required]
        public virtual Gender Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        public MaritalStatus? MaritalStatus { get; set; }
        public int? MarriageAge { get; set; }
        [Required]
        public virtual Occupation OccupationType { get; set; }
        [Required]
        public IndustryNature IndustryNature { get; set; }
        public int CitizenHouseNumberRefID { get; set; }
        [ForeignKey("CitizenHouseNumberRefID")]
        public House CitizenHouseNumber { get; set; }
    }
}
