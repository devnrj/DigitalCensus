using System.Collections.Generic;
using System.Web.Http;
using DigitalCensus.Dotnet.Dtos.Models;
using DigitialCensus.Dotenet.Services.Interface;

namespace DigitalCensus.Dotnet.Web.Controllers
{
    public class CitizenController : ApiController
    {
        private ICitizenService _citizenService;

        public CitizenController(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public IEnumerable<CitizenDto> Get()
        {
            return _citizenService.GetAll();
        }
    }
}
