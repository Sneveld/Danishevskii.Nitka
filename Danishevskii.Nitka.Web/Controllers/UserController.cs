using Danishevskii.Nitka.Dto;
using Danishevskii.Nitka.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Danishevskii.Nitka.Web.Controllers
{
    [Route("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public PageResponse Get(int pageCount, int pageNumber)
        {
            var pageRequest = new PageRequest();
            pageRequest.PageCount = pageCount;
            pageRequest.PageNumber = pageNumber;
            return _userService.GetUsers(pageRequest) ;
        }
        [HttpGet]
        [ResponseType(typeof(UserDto))]
        public IHttpActionResult Get(Guid id)
        {
            if (id != null)
            {
                return Ok(_userService.GetUser(id));
            }
            return NotFound();

        }
        [HttpPost]
        public IHttpActionResult Post([FromBody]UserDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _userService.AddUser(user);
            return StatusCode(HttpStatusCode.Created);
        }

        [HttpPut]
        public IHttpActionResult Put(UserDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _userService.UpdateUser(user);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            if (id != null && id != Guid.Empty)
            {
                _userService.DeleteUser(id);
                return StatusCode(HttpStatusCode.NoContent);                
            }
            return NotFound();
        }
    }
}
