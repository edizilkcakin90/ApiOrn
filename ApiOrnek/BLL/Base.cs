using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLL;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace BLL
{
    public class Base
    {
        List<Dummy> dummies = Datas.Dummies.dummiesList;

        public IEnumerable<Dummy> GetAll()
        {
            return dummies;
        }

        public Dummy GetByID(int id)
        {
            var dummy = dummies.FirstOrDefault(x => x.ID == id);
            return dummy;
        }

        public bool Delete(int id)
        {
            try
            {
                var dummy = dummies.FirstOrDefault(x => x.ID == id);
                dummies.Remove(dummy);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Add(Dummy model)
        {
            try
            {
                var newDummy = new Dummy();
                newDummy.ID = model.ID;
                newDummy.Name = model.Name;
                newDummy.LastName = model.LastName;
                newDummy.Age = model.Age;
                dummies.Add(newDummy);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Dummy model)
        {
            var dummy = dummies.FirstOrDefault(x => x.ID == model.ID);
            if (dummy != null)
            {
                dummy.Name = model.Name;
                dummy.LastName = model.LastName;
                dummy.Age = model.Age;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
