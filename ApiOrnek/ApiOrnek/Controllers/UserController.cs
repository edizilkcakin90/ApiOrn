using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core;
using BLL;
using System;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace ApiOrnek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private static readonly ILog log = LogManager.GetLogger(typeof(UserController));
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Data
        [HttpGet]
        public IEnumerable<User> Get()
        {
            log.Info("Success");
            return _userService.GetAll();
        }

        // GET: api/Data/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<User> Get(int id)
        {
            try
            {
                var user = _userService.GetByID(id);
                if (user != null)
                {
                    log.Info("Success");
                    return Ok(user);
                }
                log.Info("Not Found");
                return NotFound();
            }
            catch (Exception ex)
            {
                log.Info("Not Found",ex);
                return NotFound(ex);
            }

        }

        // POST: api/Data
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] RegisterModel model)
        {
            try
            {
                if (await _userService.RegisterUser(model) == true)
                {
                    log.Info("Success");
                    return Ok(_userService.GetAll());
                }
                log.Fatal("Error");
                return StatusCode(500);
            }
            catch (Exception ex)
            {
                log.Fatal("Error",ex);
                return StatusCode(500,ex);
            }
            
        }

        // PUT: api/Data/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User model)
        {
            try
            {
                await _userService.Update(id, model);
                log.Info("Success");
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {
                log.Info("Not Found", ex);
                return NotFound(ex);
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            try
            {
                if (await _userService.Delete(id))
                {
                    log.Info("Success");
                    return Ok(_userService.GetAll());
                }
                log.Info("Not Found");
                return NotFound();
            }
            catch (Exception ex)
            {
                log.Fatal("Error",ex);
                return StatusCode(500,ex);
            }
        }

        public ActionResult<User> ForgotPassword(int id, string email)
        {
            try
            {
                _userService.ForgotPassword(id, email);
                log.Info("Success");
                return Ok();
            } 
            catch (Exception ex)
            {
                log.Fatal("Error", ex);
                return StatusCode(500,ex);
            }
        }

        public async Task<ActionResult<User>> RegisterUser(RegisterModel model)
        {
            try
            {
                User newUser = model;
                await _userService.RegisterUser(model);
                log.Info("Success");
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {
                log.Fatal("Error", ex);
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
                    log.Info("Success");
                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                log.Info("Not Found", ex);
                return NotFound(ex);
            }
        }

        public async Task<ActionResult<User>> ChangePassword(int id,ChangePasswordModel model)
        {
            try
            {
                if (await _userService.ChangePassword(id, model))
                {
                    log.Info("Success");
                    return Ok(model);
                }
                else
                {
                    log.Fatal("Error");
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                log.Fatal("Error", ex);
                return StatusCode(500);
            }
        }
    }
}
