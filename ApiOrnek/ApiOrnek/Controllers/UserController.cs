﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Core;
using BLL;
using System;
using DAL;

namespace ApiOrnek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
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
            try
            {
                var user = _userService.GetByID(id);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound();
            }
            catch (Exception ex)
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
                if (_userService.Add(model) == true)
                {
                    return Ok(_userService.GetAll());
                }
                return StatusCode(500);
            }
            catch (Exception ex)
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
                _userService.Update(id, model);
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
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
                if (_userService.Delete(id))
                {
                    return Ok(_userService.GetAll());
                }
                return NotFound();
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
