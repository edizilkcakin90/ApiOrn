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
        //private static readonly List<Dummy> _dummies = new List<Dummy>()
        //{
        //   new Dummy {id =1,Name="Ediz", LastName="Ilkcakin",Age=29},
        //   new Dummy {id =2,Name="Onur", LastName="Uygur",Age=33},
        //   new Dummy {id =3,Name="Ahmet", LastName="Asd",Age=30},
        //   new Dummy {id =4,Name="Mehmet", LastName="Dsa",Age=27}
        //};

        List<Dummy> _dummies =  Data.Data.dummies._dummiesList.ToList();
        
        // GET: api/Data
        [HttpGet]
        public IEnumerable<Dummy> Get()
        {
            return _dummies;
        }

        // GET: api/Data/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Dummy> Get(int id)
        {
            var dummy = _dummies.FirstOrDefault(x => x.id == id);
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
                var _newDummy = new Dummy();
                _newDummy.id = model.id;
                _newDummy.Name = model.Name;
                _newDummy.LastName = model.LastName;
                _newDummy.Age = model.Age;
                _dummies.Add(_newDummy);
                return Ok(model);
            }
            catch (Exception)
            {
                return NotFound();
            }


        }

        // PUT: api/Data/5
        [HttpPut("{id}")]
        public ActionResult<Dummy> Put(int id, [FromBody] Dummy model)
        {
            var dummy = _dummies.FirstOrDefault(x => x.id == id);
            if (dummy != null)
            {
                dummy.Name = model.Name;
                dummy.LastName = model.LastName;
                dummy.Age = model.Age;
                return Ok(dummy);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Dummy> Delete(int id)
        {
            var dummy = _dummies.FirstOrDefault(x => x.id == id);
            if (dummy != null)
            {
                _dummies.Remove(dummy);
                return Ok();
            }
            return NotFound();
        }
    }
}
