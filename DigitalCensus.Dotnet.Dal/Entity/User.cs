using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalCensus.Dotnet.Dal.Abstract;

namespace DigitalCensus.Dotnet.Dal.Entity
{
    public enum VolunteerRequest
    {
        Pending,Approved,Declined
    }
    public class User : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        public Guid UniqueKey { get; set; }
        [Required(ErrorMessage="Please provide Firstname")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Please provide Lastname")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please provide profile picture")]
        public string ProfilePictureAddress { get; set; }
        [Required(ErrorMessage ="Please provide AadharNumber")]
        public string AadharNumber { get; set; }
        [Required]
        public bool IsApprover { get; set; }
        [Required]
        public virtual UserAccount UserAccount { get; set; }
        [Required]
        public VolunteerRequest RequestStatus { get; set; }
    }
}
