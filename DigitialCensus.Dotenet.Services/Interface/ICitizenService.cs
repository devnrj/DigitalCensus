using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalCensus.Dotnet.Dtos.Models;

namespace DigitialCensus.Dotenet.Services.Interface
{
    public interface ICitizenService
    {
        void Add(CitizenDto Citizen);
        void Edit(CitizenDto Citizen);
        IEnumerable<CitizenDto> GetAll();
        CitizenDto GetByID(Guid id);
        void Delete(Guid id);
        List<List<int>> TotalPopulation();
    }
}
