namespace DigitalCensus.Dotnet.Dal.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DigitalCensus.Dotnet.Dal.Entity;
    internal sealed class Configuration : DbMigrationsConfiguration<DigitalCensus.Dotnet.Dal.DigitalCensusDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DigitalCensus.Dotnet.Dal.DigitalCensusDbContext";
        }

        protected override void Seed(DigitalCensusDbContext context)
        {
            var UserAccount = new List<UserAccount>
            {
                new UserAccount{UniqueKey=Guid.NewGuid(),Email="neeraj.kumar@neeraj.com",Password="Neeraj@123" },
                new UserAccount{UniqueKey=Guid.NewGuid(),Email="changu@mangu.com",Password="Changu@123" },
                new UserAccount{UniqueKey=Guid.NewGuid(),Email="prakhar@rastogi.com",Password="Prakhar@123" },
            };
            UserAccount.ForEach(x => context.UserAccounts.Add(x));
            context.SaveChanges();
            var User = new List<User>
            {
                new User{UniqueKey=Guid.NewGuid(),FirstName="Neeraj",LastName="Kumar",ProfilePictureAddress="~/Image/2.jpg",
                    AadharNumber ="123456789012",IsApprover =true,UserAccount=UserAccount[0]},
                new User{UniqueKey=Guid.NewGuid(),FirstName="Changu",LastName="Mangu",ProfilePictureAddress="~/Image/3.jpg",AadharNumber="123456789011",
                    IsApprover =false,UserAccount=UserAccount[1]},
                new User{UniqueKey=Guid.NewGuid(),FirstName="Prakhar",LastName="Rastogi",ProfilePictureAddress="~/Image/prakhar.jpg",AadharNumber="123456789012",
                    IsApprover=false,UserAccount=UserAccount[2],RequestStatus=VolunteerRequest.Approved}
            };
            User.ForEach(x => context.Users.Add(x));
            context.SaveChanges();
            var Citizen = new List<Citizen>()
            {
                new Citizen{UniqueKey=Guid.NewGuid(),PersonName="Babban",RelationWithHead=Relation.Son,Gender=Gender.Male,DateOfBirth=new DateTime(1999,02,25),
                            MaritalStatus=MaritalStatus.Single,MarriageAge=null,OccupationType=Occupation.Student,
                            IndustryNature =IndustryNature.Engineering}
            };
            Citizen.ForEach(x => context.Citizens.Add(x));
            context.SaveChanges();
            var House = new List<House>
            {
                new House{UniqueKey=Guid.NewGuid(),ApartmentNumber="303",StreetName="GandhiNagar",City="Delhi",State="Delhi",HouseHeadPerson="Mr. X",
                          OwnershipStatus=Ownership.Owned,RoomQuantity=4,Citizens= Citizen
                }
            };
            House.ForEach(x => context.Houses.Add(x));
            context.SaveChanges();
           
            base.Seed(context);
        }
    }
}
