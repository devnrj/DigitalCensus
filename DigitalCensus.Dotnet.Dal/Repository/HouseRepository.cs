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

        private int StateWisePopulation(string stateName)
        {
            int count = 0;
            return _context.Set<House>().Where(x => x.State.ToUpper().Equals(stateName)).Select(x => x.Citizens.Count).Sum();
        }

        public List<List<string>> AllStatePopulation()
        {
            List<string> states = _context.Set<House>().OrderBy(x => x.State).Select(x => x.State).Distinct().ToList<string>();
            List<string> population = new List<string>();
            
            foreach(string state in states)
            {
                population.Add(StateWisePopulation(state).ToString());
            }
            List<List<string>> p = new List<List<string>>();
            p.Add(states);
            p.Add(population);
            return p;
        }

        public string Add(HouseDto entity)
        {
            try
            {
                House House = Mapper.mapper.Map<House>(entity);
                House.UniqueKey = Guid.NewGuid();
                House.Citizens = Mapper.mapper.Map<List<Citizen>>(entity.Citizens);
                _context.Set<House>().Add(House);
                _context.SaveChanges();
                return House.CensusHouseNumber;
            }catch(Exception ex)
            {
                return ex.Message;
            }
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

        public string Edit(HouseDto entity)
        {
            try {
                House house = _context.Set<House>().Where(x => x.UniqueKey == entity.UniqueKey).FirstOrDefault<House>();
                house.Citizens = Mapper.mapper.Map<List<Citizen>>(entity.Citizens);
                _context.SaveChanges();
                return "Citizen Added Successfully";
            }catch(Exception ex)
            {
                return ex.Message;
            }
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

        public HouseDto GetHouseByCHN(string chn)
        {
            House House = null;
            try
            {
                House=_context.Set<House>().Where(x => x.CensusHouseNumber.Equals(chn)).FirstOrDefault<House>();
                House.Citizens = _context.Set<Citizen>().Where(x => x.CitizenHouseNumberRefID == House.ID).ToList<Citizen>();
            }catch(Exception ex)
            {

            }
            return Mapper.mapper.Map<HouseDto>(House);
        }
    }
}
