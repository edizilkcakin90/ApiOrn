using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DLL;
using BLL;

namespace ApiOrnek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        Base _base;
        public DataController()
        {
            _base = new Base();
        }
        
        // GET: api/Data
        [HttpGet]
        public IEnumerable<Dummy> Get()
        {
            return _base.GetAll();
        }

        // GET: api/Data/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Dummy> Get(int id)
        {

            var dummy = _base.GetByID(id);
            if (dummy == null)
            {
                return NotFound();
            }
            return Ok(dummy);
        }

        // POST: api/Data
        [HttpPost]
        public ActionResult<Dummy> Post([FromBody] Dummy model)
        {
            if (_base.Add(model) == true)
            {
                return Ok(_base.GetAll().ToList());
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/Data/5
        [HttpPut("{id}")]
        public ActionResult<Dummy> Put(int id, [FromBody] Dummy model)
        {
            if (_base.Update(model) == true)
            {
                return Ok(_base.GetAll().ToList());
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Dummy> Delete(int id)
        {
            if (_base.Delete(id))
            {
                return Ok(_base.GetAll());
            }
            return NotFound();
        }
    }
}
