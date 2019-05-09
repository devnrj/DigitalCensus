using System;
using System.Collections.Generic;
using DigitalCensus.Dotnet.Dtos.Models;

namespace DigitialCensus.Dotenet.Services.Interface
{
    public interface IUserAccountService
    {
        void Add(UserAccountDto UserAccount);
        void Edit(UserAccountDto UserAccount);
        IEnumerable<UserAccountDto> GetAll();
        UserAccountDto GetByID(Guid id);
        Guid Get(UserAccountDto userAccount);
        void Delete(Guid id);
        string Encryptdata(string password);
    }
}
