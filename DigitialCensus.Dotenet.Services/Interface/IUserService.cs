using System;
using System.Collections.Generic;
using DigitalCensus.Dotnet.Dtos.Models;

namespace DigitialCensus.Dotenet.Services.Interface
{
    public interface IUserService
    {
        void Add(UserDto User);
        void Edit(UserDto User);
        IEnumerable<UserDto> GetAll();
        UserDto GetUserByAccountID(Guid id);
        UserDto GetByID(Guid id);
        void Delete(Guid id);
        IEnumerable<UserDto> GetByStatus(VolunteerRequest request);
    }
}
