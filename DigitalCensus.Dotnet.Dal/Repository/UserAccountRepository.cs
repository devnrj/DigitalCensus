using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalCensus.Dotnet.Dal.Abstract;
using DigitalCensus.Dotnet.Dtos.Models;
using DigitialCensus.Dotenet.Dal.Helper;
using DigitalCensus.Dotnet.Dal.Entity;
namespace DigitalCensus.Dotnet.Dal.Repository
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private DbContext _context;

        public UserAccountRepository(DbContext context)
        {
            _context = context;
        }
        public void Add(UserAccountDto entity)
        {
            UserAccount UserAccount = Mapper.mapper.Map<UserAccount>(entity);
            UserAccount.UniqueKey = Guid.NewGuid();
            //UserAccount.ID = (_context.Set<UserAccount>().OrderByDescending(u => u.ID).FirstOrDefault()).ID+1;
            _context.Set<UserAccount>().Add(UserAccount);
            _context.SaveChanges();
        }

        public void Delete(Guid guid)
        {
            Delete(GetSingle(guid));
        }

        public void Delete(UserAccountDto entity)
        {
            UserAccount UserAccount = Mapper.mapper.Map<UserAccount>(entity);
            _context.Set<UserAccount>().Remove(UserAccount);
            _context.SaveChanges();
        }

        public void Edit(UserAccountDto entity)
        {
            UserAccount UserAccount = Mapper.mapper.Map<UserAccount>(entity);
            UserAccount existingUserAccount = Mapper.mapper.Map<UserAccount>(GetSingle(UserAccount.UniqueKey));
            existingUserAccount = UserAccount;
            _context.SaveChanges();
        }

        public Guid Get(UserAccountDto entity)
        {
            UserAccount UserAccount = Mapper.mapper.Map<UserAccount>(entity);
            var result = _context.Set<UserAccount>().Where(x => x.Email.Equals(UserAccount.Email) &&
                                                   x.Password.Equals(UserAccount.Password)).
                                                   FirstOrDefault<UserAccount>();
            return result.UniqueKey;
        }

        public IEnumerable<UserAccountDto> GetAll()
        {
            return Mapper.mapper.Map<List<UserAccountDto>>(_context.Set<UserAccount>());
        }

        public UserAccountDto GetSingle(Guid key)
        {
            UserAccount UserAccount = _context.Set<UserAccount>().Where(x => x.UniqueKey == key).FirstOrDefault<UserAccount>();
            return Mapper.mapper.Map<UserAccountDto>(UserAccount);
        }
    }
}
