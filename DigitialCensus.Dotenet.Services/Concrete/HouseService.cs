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
        public void Add(HouseDto House)
        {
            _repository.Add(House);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public void Edit(HouseDto House)
        {
            _repository.Edit(House);
        }

        public IEnumerable<HouseDto> GetAll()
        {
            return _repository.GetAll();
        }

        public HouseDto GetByID(Guid id)
        {
            return _repository.GetSingle(id);
        }
    }
}
