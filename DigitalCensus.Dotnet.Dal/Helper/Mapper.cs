using AutoMapper;
using DigitalCensus.Dotnet.Dal.Entity;
using DigitalCensus.Dotnet.Dtos.Models;

namespace DigitialCensus.Dotenet.Dal.Helper
{
    class Mapper
    {
        public static MapperConfiguration config = new MapperConfiguration(cfg =>
           cfg.CreateMap<CitizenDto,Citizen>().ForMember(x=>x.CitizenHouseNumber, opt=>opt.Ignore()).ReverseMap());
        public static IMapper mapper = config.CreateMapper();
    }
}
