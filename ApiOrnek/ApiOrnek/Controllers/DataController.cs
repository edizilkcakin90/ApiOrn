using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiOrnek.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiOrnek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        List<Dummy> dummies = Datas.Dummies.dummiesList;
        
        // GET: api/Data
        [HttpGet]
        public IEnumerable<Dummy> Get()
        {
            return dummies.ToList();
        }

        // GET: api/Data/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Dummy> Get(int id)
        {
            var dummy = dummies.FirstOrDefault(x => x.ID == id);
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
            try
            {
                var newDummy = new Dummy();
                newDummy.ID = model.ID;
                newDummy.Name = model.Name;
                newDummy.LastName = model.LastName;
                newDummy.Age = model.Age;
                dummies.Add(newDummy);
                return Ok(dummies.ToList());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/Data/5
        [HttpPut("{id}")]
        public ActionResult<Dummy> Put(int id, [FromBody] Dummy model)
        {
            var dummy = dummies.FirstOrDefault(x => x.ID == id);
            if (dummy != null)
            {
                dummy.Name = model.Name;
                dummy.LastName = model.LastName;
                dummy.Age = model.Age;
                return Ok(dummies.ToList());
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
            var dummy = dummies.FirstOrDefault(x => x.ID == id);
            if (dummy != null)
            {
                dummies.Remove(dummy);
                return Ok(dummies.ToList());
            }
            return NotFound();
        }
    }
}
