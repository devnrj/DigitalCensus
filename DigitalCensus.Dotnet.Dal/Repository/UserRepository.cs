using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalCensus.Dotnet.Dal.Abstract;
using DigitalCensus.Dotnet.Dal.Entity;
using DigitalCensus.Dotnet.Dtos.Models;
using DigitialCensus.Dotenet.Dal.Helper;

namespace DigitalCensus.Dotnet.Dal.Repository
{
    public class UserRepository : IUserRepository
    {
        private DbContext _context;

        public Guid UniqueKey { get => this.UniqueKey; set => Guid.NewGuid(); }
        public UserRepository(DbContext context)
        {
            _context = context;
        }
        public void Add(UserDto entity)
        {
            User User = Mapper.mapper.Map<User>(entity);
            User.UniqueKey = Guid.NewGuid();
            User.UserAccount.UniqueKey = Guid.NewGuid();
            //User.ID=(_context.Set<User>().OrderByDescending(u => u.ID).FirstOrDefault()).ID+1;
            //User.UserAccount.ID = (_context.Set<UserAccount>().OrderByDescending(u => u.ID).FirstOrDefault()).ID + 1;
            _context.Set<User>().Add(User);
            try
            {
                _context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public void Delete(Guid guid)
        {
            Delete(GetSingle(guid));
        }

        public void Delete(UserDto entity)
        {
            User User = Mapper.mapper.Map<User>(entity);
            _context.Set<User>().Remove(User);
            _context.SaveChanges();
        }

        public void Edit(UserDto entity)
        {
            User User = Mapper.mapper.Map<User>(entity);
            User existingUser = Mapper.mapper.Map<User>(GetSingle(User.UniqueKey));
            existingUser = User;
             _context.SaveChanges();
        }

        public IEnumerable<UserDto> GetAll()
        {
            return Mapper.mapper.Map<List<UserDto>>(_context.Set<User>());
        }

        public UserDto GetSingle(Guid key)
        {
            User User = _context.Set<User>().Where(x => x.UniqueKey == key).FirstOrDefault<User>();
            return Mapper.mapper.Map<UserDto>(User);
        }

        public UserDto GetUserByAccountID(Guid key)
        {
            User User = _context.Set<User>().Where(x => x.UserAccount.UniqueKey == key).FirstOrDefault<User>();
            return Mapper.mapper.Map<UserDto>(User);
        }
    }
}
