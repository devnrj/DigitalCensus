using System;

namespace DigitalCensus.Dotnet.Dtos.Models
{
    public enum VolunteerRequest
    {
        Pending,Approved,Declined
    }
    public class UserDto 
    {
        public int ID { get; set; }
        public Guid UniqueKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureAddress { get; set; }
        public string AadharNumber { get; set; }
        public bool IsApprover { get; set; }
        public virtual UserAccountDto UserAccount { get; set; }
        public VolunteerRequest RequestStatus { get; set; }
    }
}
