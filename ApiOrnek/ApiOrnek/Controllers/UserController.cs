using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core;
using BLL;
using System;
using System.Threading.Tasks;
using log4net;

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
        public ActionResult<IEnumerable<User>> Get()
        {
            try
            {
                var users = _userService.GetAll();
                log.Info("Users called successfully");
                return Ok(users);
            }
            catch (Exception ex)
            {
                log.Error("Couldn't called all users", ex);
                return NotFound(ex);
            }
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
                    log.Info($"User called by id: {id}");
                    return Ok(user);
                }
                log.Error($"Couldn't find user with the {id}");
                return NotFound();
            }
            catch (Exception ex)
            {
                log.Fatal("Fatal Error",ex); 
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
                    return Ok(_userService.GetAll());
                }
                log.Error("Post action error");
                return StatusCode(500);
            }
            catch (Exception ex)
            {
                log.Fatal("Fatal Error",ex);
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
                log.Info($"User succesfully updated with the id number:{model.ID}");
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {
                log.Error($"Couldn't find user with the {id}", ex);
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
                    log.Info($"User with the id number:{id} successfully deleted");
                    return Ok(_userService.GetAll());
                }
                log.Error($"Couldn't find user with the {id}");
                return NotFound();
            }
            catch (Exception ex)
            {
                log.Fatal("Fatal Error",ex);
                return StatusCode(500,ex);
            }
        }

        public ActionResult<User> ForgotPassword(int id, string email)
        {
            try
            {
                _userService.ForgotPassword(id, email);
                log.Info($"Forgot Password mail has been sent to the user with the email :{email}");
                return Ok();
            } 
            catch (Exception ex)
            {
                log.Fatal("Fatal Error", ex);
                return StatusCode(500,ex);
            }
        }

        public async Task<ActionResult<User>> RegisterUser(RegisterModel model)
        {
            try
            {
                User newUser = model;
                await _userService.RegisterUser(model);
                log.Info("User successfully has been registered.");
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {
                log.Fatal("Couldnt register user.", ex);
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
                    log.Info("User info matches with database.");
                    return Ok(user);
                }
                log.Error("User info didnt match with database.");
                return NotFound();
            }
            catch (Exception ex)
            {
                log.Fatal("Fatal Error", ex);
                return StatusCode(500);
            }
        }

        public async Task<ActionResult<User>> ChangePassword(int id,ChangePasswordModel model)
        {
            try
            {
                if (await _userService.ChangePassword(id, model))
                {
                    log.Info("User's password successfully has changed");
                    return Ok(model);
                }
                else
                {
                    log.Error("Couldnt change user's password");
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                log.Fatal("Fatal Error", ex);
                return StatusCode(500);
            }
        }
    }
}
