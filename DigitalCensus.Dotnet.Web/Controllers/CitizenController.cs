using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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

        public HttpResponseMessage Post([FromBody]CitizenDto citizenDto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Missing values");
            }
            _citizenService.Add(citizenDto);
            return Request.CreateResponse(HttpStatusCode.OK, "Citizen added in National Population Register");
        }

        [HttpGet]
        [Route("api/agePopulation")]
        public HttpResponseMessage AllStatePopulation()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _citizenService.TotalPopulation());
        }
    }
}
