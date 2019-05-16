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
        private Dummy[] dummies = new Dummy[]
        {
            new Dummy{id=1,Name="Ediz",LastName="Ilkcakin",Age=29 },
            new Dummy{id=2,Name="Onur",LastName="Uygur",Age=33 },
            new Dummy{id=3,Name="Ahmet",LastName="Asd",Age=35 },
            new Dummy{id=4,Name="Mehmet",LastName="Dsa",Age=35 }
        };

        // GET: api/Data
        [HttpGet]
        public IEnumerable<Dummy> Get()
        {
            return dummies;
        }

        // GET: api/Data/5
        [HttpGet("{id}", Name = "Get")]
        public Dummy Get(int id)
        {
            var dummy = dummies.FirstOrDefault(x => x.id == id);
            if (dummy == null)
            {
                return Content(HttpStatusCode.NotFound, "Foo does not exist.");
            }
               return dummy;
        }

        private Dummy Content(HttpStatusCode notFound, string v)
        {
            throw new NotImplementedException();
        }

        // POST: api/Data
        [HttpPost]
        public void Post([FromBody] Dummy model)
        {
            Dummy _newDummy = new Dummy();
            model.id = _newDummy.id;
            model.Name = _newDummy.Name;
            model.LastName = _newDummy.LastName;
            model.Age = _newDummy.Age;
        }

        // PUT: api/Data/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Dummy model)
        {
            var dummy = dummies.FirstOrDefault(x => x.id == id);
            if (dummy!=null)
            {
                dummy.Name = model.Name;
                dummy.LastName = model.LastName;
                dummy.Age = model.Age;
            }
            else
            {
                NotFound();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var dummy = dummies.FirstOrDefault(x => x.id == id);
            if (dummy!=null)
            {
                Delete(id);
            }
        }
    }
}
