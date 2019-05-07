using System;

namespace DigitalCensus.Dotnet.Dtos.Models
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
    public class CitizenDto
    {
        public int ID { get; set; }
        public Guid UniqueKey { get; set; }
        public string PersonName { get; set; }
        public virtual Relation RelationWithHead { get; set; }
        public virtual Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public int? MarriageAge { get; set; }
        public virtual Occupation OccupationType { get; set; }
        public IndustryNature IndustryNature { get; set; }
        public int CitizenHouseNumberRefID { get; set; }
    }
}
