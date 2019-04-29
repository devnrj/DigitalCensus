using System;
using System.Collections.Generic;
using DigitalCensus.Dotnet.Dtos.Models;

namespace DigitalCensus.Dotnet.Dal.Abstract
{
    public interface ICitizenRepository : IEntity
    {
        void Add(CitizenDto entity);
        void Delete(Guid guid);
        void Edit(CitizenDto entity);
        IEnumerable<CitizenDto> GetAll();
        CitizenDto GetSingle(Guid key);
    }
}
