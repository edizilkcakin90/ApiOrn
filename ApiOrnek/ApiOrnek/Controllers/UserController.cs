using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using BLL;

namespace ApiOrnek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }
        
        // GET: api/Data
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetAll();
        }

        // GET: api/Data/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<User> Get(int id)
        {

            var user = _userService.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/Data
        [HttpPost]
        public ActionResult<User> Post([FromBody] User model)
        {
            if (_userService.Add(model) == true)
            {
                return Ok(_userService.GetAll());
            }
            return StatusCode(500);
        }

        // PUT: api/Data/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User model)
        {
            _userService.Update(id, model);
            return Ok(_userService.GetAll());
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            if (_userService.Delete(id))
            {
                return Ok(_userService.GetAll());
            }
            return NotFound();
        }
    }
}
