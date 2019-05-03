using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalCensus.Dotnet.Dtos.Models;

namespace DigitialCensus.Dotenet.Services.Interface
{
    public interface IHouseService
    {
        string Add(HouseDto House);
        void Edit(HouseDto House);
        IEnumerable<HouseDto> GetAll();
        HouseDto GetByID(Guid id);
        void Delete(Guid id);
        Boolean IsValidCensusHouseNumber(string chn);
    }
}
