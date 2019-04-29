using System;
using System.Collections.Generic;
using DigitalCensus.Dotnet.Dal.Abstract;
using DigitalCensus.Dotnet.Dtos.Models;
using DigitialCensus.Dotenet.Services.Interface;

namespace DigitialCensus.Dotenet.Services.Concrete
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserAccountRepository _repository;

        public UserAccountService(IUserAccountRepository repository)
        {
            _repository = repository;
        }
        public void Add(UserAccountDto UserAccount)
        {
            _repository.Add(UserAccount);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public void Edit(UserAccountDto UserAccount)
        {
            _repository.Edit(UserAccount);
        }

        public Guid Get(UserAccountDto userAccount)
        {
            return _repository.Get(userAccount);
        }

        public IEnumerable<UserAccountDto> GetAll()
        {
            return _repository.GetAll();
        }

        public UserAccountDto GetByID(Guid id)
        {
            return _repository.GetSingle(id);
        }
    }
}
