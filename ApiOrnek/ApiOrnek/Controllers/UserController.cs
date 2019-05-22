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
            try
            {
                var user = _userRepository.GetByID(id);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }

        // POST: api/Data
        [HttpPost]
        public ActionResult<User> Post([FromBody] User model)
        {
            try
            {
                if (_userRepository.Add(model) == true)
                {
                    return Ok(_userRepository.GetAll());
                }
                return StatusCode(500);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
        }

        // PUT: api/Data/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User model)
        {
            try
            {
                _userRepository.Update(id, model);
                return Ok(_userRepository.GetAll());
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            try
            {
                if (_userRepository.Delete(id))
                {
                    return Ok(_userRepository.GetAll());
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public ActionResult<User> ForgotPassword(int id, string email)
        {
            try
            {
                _userService.ForgotPassword(id, email);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
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
            try
            {
                var user = _userService.ValidateCredentials(email, password);
                if (user)
                {
                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public ActionResult<User> ChangePassword(int id,ChangePasswordModel model)
        {
            try
            {
                var changePass = _userService.ChangePassword(id, model);
                if (changePass)
                {
                    return Ok(model);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
