using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DigitalCensus.Dotnet.Dtos.Models;
using DigitialCensus.Dotenet.Services.Concrete;
using DigitialCensus.Dotenet.Services.Interface;

namespace DigitalCensus.Dotnet.Web.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private IUserService _service;
        private IUserAccountService _userAccountService;

        public UserController(IUserService service,IUserAccountService userAccountService)
        {
            _service = service;
            _userAccountService=userAccountService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public HttpResponseMessage Get(Guid id)
        {
            var result = _service.GetByID(id);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, result as UserDto);
        }
        //login
        
        //public HttpResponseMessage Post([FromBody]UserAccountDto userAccountDto)
        //{
        //    Guid result = _userAccountService.Get(userAccountDto);
        //    UserDto User;
        //    if (Guid.Empty == result || result == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }
        //    else
        //    {
        //        User=_service.GetUserByAccountID(result);
        //        if (User == null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.BadRequest);
        //        }
        //    }
        //    User.ID = 0;
        //    return Request.CreateResponse(HttpStatusCode.OK, User);
        //}
        [HttpPost]
        public HttpResponseMessage Post([FromBody]UserDto user)
        {
            _service.Add(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
