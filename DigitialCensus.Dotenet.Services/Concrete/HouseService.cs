using System;
using System.Collections.Generic;
using DigitalCensus.Dotnet.Dtos.Models;
using DigitialCensus.Dotenet.Services.Interface;
using DigitalCensus.Dotnet.Dal.Abstract;

namespace DigitialCensus.Dotenet.Services.Concrete
{
    public class HouseService : IHouseService
    {
        private readonly IHouseRepository _repository;

        public HouseService(IHouseRepository repository)
        {
            _repository = repository;
        }
        public string Add(HouseDto House)
        {
            return _repository.Add(House);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public string Edit(HouseDto House)
        {
            return _repository.Edit(House);
        }

        public IEnumerable<HouseDto> GetAll()
        {
            return _repository.GetAll();
        }

        public HouseDto GetByID(Guid id)
        {
            return _repository.GetSingle(id);
        }

        public HouseDto GetHouseByCHN(string chn)
        {
            return _repository.GetHouseByCHN(chn);
        }

        public List<List<string>> AllStatePopulation()
        {
            return _repository.AllStatePopulation();
        }
    }
}
