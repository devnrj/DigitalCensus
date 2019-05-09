using System;
using System.Collections.Generic;
using DigitalCensus.Dotnet.Dal.Abstract;
using DigitalCensus.Dotnet.Dtos.Models;
using DigitialCensus.Dotenet.Services.Interface;

namespace DigitialCensus.Dotenet.Services.Concrete
{
    public class CitizenService : ICitizenService
    {
        private readonly ICitizenRepository _repository;

        public CitizenService(ICitizenRepository repository)
        {
            _repository = repository;
        }
        public List<List<int>> TotalPopulation()
        {
            return _repository.TotalPopulation();
        }
        public void Add(CitizenDto Citizen)
        {
            _repository.Add(Citizen);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public void Edit(CitizenDto Citizen)
        {
            _repository.Edit(Citizen);
        }

        public IEnumerable<CitizenDto> GetAll()
        {
            return _repository.GetAll();
        }

        public CitizenDto GetByID(Guid id)
        {
            return _repository.GetSingle(id);
        }

     
    }
}
