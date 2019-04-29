using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using DigitalCensus.Dotnet.Dal.Abstract;
using DigitalCensus.Dotnet.Dtos.Models;
using DigitialCensus.Dotenet.Dal.Helper;
using DigitalCensus.Dotnet.Dal.Entity;

namespace DigitalCensus.Dotnet.Dal.Repository
{
    public class HouseRepository : IHouseRepository
    {
        private DbContext _context;

        public Guid UniqueKey { get => this.UniqueKey; set => Guid.NewGuid(); }

        public HouseRepository(DbContext context)
        {
            _context = context;
        }
        public void Add(HouseDto entity)
        {
            House House = Mapper.mapper.Map<House>(entity);
            House.UniqueKey = Guid.NewGuid();
            //House.ID = (_context.Set<House>().OrderByDescending(u => u.ID).FirstOrDefault()).ID+1;
            _context.Set<House>().Add(House);
            _context.SaveChanges();
        }

        public void Delete(Guid guid)
        {
            Delete(GetSingle(guid));
        }

        public void Delete(HouseDto entity)
        {
            House House = Mapper.mapper.Map<House>(entity);
            _context.Set<House>().Remove(House);
            _context.SaveChanges();
        }

        public void Edit(HouseDto entity)
        {
            House House = Mapper.mapper.Map<House>(entity);
            House existingHouse = Mapper.mapper.Map<House>(GetSingle(House.UniqueKey));
            existingHouse = House;
            _context.SaveChanges();
        }

        public IEnumerable<HouseDto> GetAll()
        {
            return Mapper.mapper.Map<List<HouseDto>>(_context.Set<House>());
        }

        public HouseDto GetSingle(Guid key)
        {
            House House = _context.Set<House>().Where(x => x.UniqueKey == key).FirstOrDefault<House>();
            return Mapper.mapper.Map<HouseDto>(House);
        }
    }
}
