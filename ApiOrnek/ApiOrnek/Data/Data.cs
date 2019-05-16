using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiOrnek.Data
{
    public class Data
    {
        private Dummy[] dummies = new Dummy[]
        {
            new Dummy{id=1,Name="Ediz",LastName="Ilkcakin",Age=29 },
            new Dummy{id=2,Name="Onur",LastName="Uygur",Age=33 },
            new Dummy{id=3,Name="Ahmet",LastName="Asd",Age=35 },
            new Dummy{id=4,Name="Mehmet",LastName="Dsa",Age=35 }
        };

    }
}
