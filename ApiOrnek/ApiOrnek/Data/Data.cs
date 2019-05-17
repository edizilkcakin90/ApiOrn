using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOrnek.Data
{
    public class Data
    {
        private static Data _data;

        public static Data dummies
        {
            get
            {
                if (_data == null)
                {
                    _data = new Data();
                }
                return _data;
            }
        }

        private Data()
        {

        }

        public List<Dummy> _dummiesList = new List<Dummy>()
        {
           new Dummy {id =1,Name="Ediz", LastName="Ilkcakin",Age=29},
           new Dummy {id =2,Name="Onur", LastName="Uygur",Age=33},
           new Dummy {id =3,Name="Ahmet", LastName="Asd",Age=30},
           new Dummy {id =4,Name="Mehmet", LastName="Dsa",Age=27}
        };
    }

}
