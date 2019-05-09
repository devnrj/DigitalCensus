using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DigitalCensus.Dotnet.Dtos.Models;
using DigitialCensus.Dotenet.Services.Interface;

namespace DigitalCensus.Dotnet.Web.Controllers
{
    public class HouseController : ApiController
    {
        private IHouseService _houseService;

        public HouseController(IHouseService houseService)
        {
            _houseService = houseService;
        }

        [HttpGet]
        [Route("api/house/cnh/{censusHouseNumber}")]
        public HttpResponseMessage Get(string censusHouseNumber)
        {
            HouseDto result = _houseService.GetHouseByCHN(censusHouseNumber.Trim().ToLower());
            if (result !=null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,result);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Not a valid census house number");
        }

        [HttpGet]
        public IEnumerable<HouseDto> Get()
        {
            return _houseService.GetAll();
        }
        
        [HttpPost]
        public HttpResponseMessage Post([FromBody]HouseDto houseDto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Missing values");
            }
            string result = _houseService.Add(houseDto);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("api/statePopulation")]
        public HttpResponseMessage AllStatePopulation()
        {
            return Request.CreateResponse(HttpStatusCode.OK,_houseService.AllStatePopulation());
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody]HouseDto houseDto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Missing values");
            }
            string result = _houseService.Edit(houseDto);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
