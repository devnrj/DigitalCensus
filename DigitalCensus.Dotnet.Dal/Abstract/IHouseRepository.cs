using System;
using System.Collections.Generic;
using DigitalCensus.Dotnet.Dtos.Models;

namespace DigitalCensus.Dotnet.Dal.Abstract
{
    public interface IHouseRepository : IEntity
    {
        void Add(HouseDto entity);
        void Delete(Guid guid);
        void Edit(HouseDto entity);
        IEnumerable<HouseDto> GetAll();
        HouseDto GetSingle(Guid key);
    }
}
