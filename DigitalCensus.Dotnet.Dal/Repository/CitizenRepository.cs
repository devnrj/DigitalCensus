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
    public class CitizenRepository : ICitizenRepository
    {
        private DbContext _context;

        public Guid UniqueKey { get => this.UniqueKey; set => Guid.NewGuid(); }

        public CitizenRepository(DbContext context)
        {
            _context = context;
        }

        private int AgeWisePopulation(int year)
        {
            return _context.Set<Citizen>().Where(x => x.DateOfBirth.Year == year).Count();
        }

        public List<List<int>> TotalPopulation()
        {
            List<int> years= _context.Set<Citizen>().OrderBy(x => x.DateOfBirth.Year).Select(x => x.DateOfBirth.Year).Distinct().ToList<int>();
            years.Reverse();
            List<int> count = new List<int>();
            foreach(int year in years)
            {
                count.Add(AgeWisePopulation(year));
            }
            List<List<int>> allPopulation = new List<List<int>>();
            years=years.Select(x => x = DateTime.Now.Year - x).ToList();
            allPopulation.Add(years);
            allPopulation.Add(count);
            return allPopulation;
        }

        public void Add(CitizenDto entity)
        {
            Citizen Citizen = Mapper.mapper.Map<Citizen>(entity);
            Citizen.UniqueKey = Guid.NewGuid();
            //Citizen.ID = (_context.Set<Citizen>().OrderByDescending(u => u.ID).FirstOrDefault()).ID+1;
            _context.Set<Citizen>().Add(Citizen);
            _context.SaveChanges();
        }

        public void Delete(Guid guid)
        {
            Delete(GetSingle(guid));
        }

        public void Delete(CitizenDto entity)
        {
            Citizen Citizen = Mapper.mapper.Map<Citizen>(entity);
            _context.Set<Citizen>().Remove(Citizen);
            _context.SaveChanges();
        }

        public void Edit(CitizenDto entity)
        {
            Citizen Citizen = Mapper.mapper.Map<Citizen>(entity);
            Citizen existingCitizen = Mapper.mapper.Map<Citizen>(GetSingle(Citizen.UniqueKey));
            existingCitizen = Citizen;
            _context.SaveChanges();
        }

        public IEnumerable<CitizenDto> GetAll()
        {
            return Mapper.mapper.Map<List<CitizenDto>>(_context.Set<Citizen>());
        }

        public CitizenDto GetSingle(Guid key)
        {
            Citizen Citizen = _context.Set<Citizen>().Where(x => x.UniqueKey == key).FirstOrDefault<Citizen>();
            return Mapper.mapper.Map<CitizenDto>(Citizen);
        }
    }
}
