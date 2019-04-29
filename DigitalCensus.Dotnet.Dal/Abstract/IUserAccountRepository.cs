using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalCensus.Dotnet.Dtos.Models;

namespace DigitalCensus.Dotnet.Dal.Abstract
{
    public interface IUserAccountRepository
    {
        void Add(UserAccountDto entity);
        void Delete(Guid guid);
        void Edit(UserAccountDto entity);
        IEnumerable<UserAccountDto> GetAll();
        UserAccountDto GetSingle(Guid key);
        Guid Get(UserAccountDto entity);
    }
}
