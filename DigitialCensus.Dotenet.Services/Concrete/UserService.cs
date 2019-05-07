using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalCensus.Dotnet.Dal.Abstract;
using DigitalCensus.Dotnet.Dal.Entity;
using DigitalCensus.Dotnet.Dtos.Models;
using DigitialCensus.Dotenet.Services.Interface;

namespace DigitialCensus.Dotenet.Services.Concrete
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Add(UserDto User)
        {
            _repository.Add(User);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public void Edit(UserDto User)
        {
            _repository.Edit(User);
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _repository.GetAll();
        }

        public UserDto GetByID(Guid id)
        {
            return _repository.GetSingle(id); 
        }

        public IEnumerable<UserDto> GetByStatus(DigitalCensus.Dotnet.Dtos.Models.VolunteerRequest request)
        {
            return _repository.GetByStatus(request);
        }

        public UserDto GetUserByAccountID(Guid id)
        {
            return _repository.GetUserByAccountID(id);
        }

        public bool IsUniqueAadhar(string aadharNumber)
        {
            return _repository.IsUniqueAadhar(aadharNumber);
        }
    }
}
