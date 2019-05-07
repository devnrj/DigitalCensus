using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            User user = _context.Set<User>().Where(x=>x.UniqueKey==entity.UniqueKey).FirstOrDefault<User>();
            if(user != null)
            {
                user.IsApprover = entity.IsApprover;
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.ProfilePictureAddress = entity.ProfilePictureAddress;
                user.RequestStatus = Mapper.mapper.Map<DigitalCensus.Dotnet.Dal.Entity.VolunteerRequest>(entity.RequestStatus);
                user.UserAccount = Mapper.mapper.Map<UserAccount>(entity.UserAccount);
                user.AadharNumber = entity.AadharNumber;
                _context.SaveChanges();
            }
        }

        public IEnumerable<UserDto> GetAll()
        {
            return Mapper.mapper.Map<List<UserDto>>(_context.Set<User>());
        }

        public IEnumerable<UserDto> GetByStatus(DigitalCensus.Dotnet.Dtos.Models.VolunteerRequest request)
        {
            return Mapper.mapper.Map<List<UserDto>>(_context.Set<User>().
                                                    Where(x=>x.RequestStatus.ToString().Equals(request.ToString())
                                                    && x.IsApprover==false)
                                   );
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

        public bool IsUniqueAadhar(string aadharNumber)
        {
            bool result = _context.Set<User>().Where(x => x.AadharNumber.Equals(aadharNumber)).FirstOrDefault()==null?true:false;
            return result;
        }
    }
}
