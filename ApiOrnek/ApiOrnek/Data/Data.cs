using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOrnek.Data
{
    public class Datas
    {
        private static Datas _data;

        public static Datas Dummies
        {
            get
            {
                if (_data == null)
                {
                    _data = new Datas();
                }
                return _data;
            }
        }

        private Datas()
        {

        }

        public List<Dummy> dummiesList = new List<Dummy>()
        {
           new Dummy {ID =1,Name="Ediz", LastName="Ilkcakin",Age=29},
           new Dummy {ID =2,Name="Onur", LastName="Uygur",Age=33},
           new Dummy {ID =3,Name="Ahmet", LastName="Asd",Age=30},
           new Dummy {ID =4,Name="Mehmet", LastName="Dsa",Age=27}
        };
    }

}
