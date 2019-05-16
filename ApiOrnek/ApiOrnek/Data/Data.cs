using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOrnek.Data
{
    public class Data
    {
        public void Add(Dummy model)
        {
            Dummy dum = new Dummy();
            dum.id = model.id;
            dum.Name = model.Name;
            dum.LastName = model.LastName;
            dum.Age = model.Age;
        }
    }
}
