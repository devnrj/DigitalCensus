using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalCensus.Dotnet.Dtos.Models;

namespace DigitalCensus.Dotnet.Dal.Abstract
{
    public interface IUserRepository : IEntity
    {
        void Add(UserDto entity);
        void Delete(Guid id);
        void Edit(UserDto entity);
        IEnumerable<UserDto> GetAll();
        UserDto GetSingle(Guid key);
        UserDto GetUserByAccountID(Guid key);
    }
}
