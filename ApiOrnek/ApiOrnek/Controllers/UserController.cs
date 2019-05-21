using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Core;
using BLL;
using System;

namespace ApiOrnek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserService _userService;
        public UserController()
        {
            _userRepository = new InMemoryUserRepository();
            _userService = new UserService();
        }

        // GET: api/Data
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAll();
        }

        // GET: api/Data/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<User> Get(int id)
        {
            var user = _userRepository.GetByID(id);
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
            if (_userRepository.Add(model) == true)
            {
                return Ok(_userRepository.GetAll());
            }
            return StatusCode(500);
        }

        // PUT: api/Data/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User model)
        {
            _userRepository.Update(id, model);
            return Ok(_userRepository.GetAll());
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            if (_userRepository.Delete(id))
            {
                return Ok(_userRepository.GetAll());
            }
            return NotFound();
        }

        public ActionResult<User> ForgotPassword(int id, string email)
        {
            User forgotUser = _userRepository.GetByID(id);
            if (forgotUser.Email == email)
            {
                return Ok(forgotUser.Email);
            }
            return NotFound();
        }

        public ActionResult<User> RegisterUser(RegisterModel model)
        {
            try
            {
                User newUser = model;
                _userService.RegisterUser(model);
                return Ok(_userRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        public ActionResult<User> ValidateCredentials(string email, string password)
        {
            //doldur
        }

        public void ChangePassword(ChangePasswordModel model)
        {
            //doldur
        }
    }
}
