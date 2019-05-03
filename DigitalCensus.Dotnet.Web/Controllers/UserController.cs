using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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

        [HttpPost]
        [Route("api/UploadImage")]
        public HttpResponseMessage UploadImage()
        {
            string imageName="";
            try
            {
                var httpRequest = HttpContext.Current.Request;
                Debug.WriteLine(httpRequest);
                var postedFile = httpRequest.Files.Count>0? httpRequest.Files[0]:null;
                imageName = new string(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(' ', '-');
                imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
                var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
                postedFile.SaveAs(filePath);
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, imageName);
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


        [HttpGet]
        [Route("api/user/status/{status}")]
        public HttpResponseMessage Get(VolunteerRequest status)
        {
            var result = _service.GetByStatus(status);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, result as IEnumerable<UserDto>);
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody]UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            _service.Edit(user);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Missing values");
            }
            _service.Add(user);
            return Request.CreateResponse(HttpStatusCode.OK, "User Added");
        }


    }
}
