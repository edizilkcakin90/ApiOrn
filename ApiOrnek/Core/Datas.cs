using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Datas
    {
        private static Datas _data;

        public static Datas Users
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

        public List<User> userList = new List<User>()
        {
           new User {ID =1,Name="Ediz", LastName="Ilkcakin",Age=29, Email="edizilkcakin@gmail.com", IdentityNo="12345678941", Sex='m', Password="123456"},
           new User {ID =2,Name="Onur", LastName="Uygur",Age=33, Email="onuruygur@gmail.com", IdentityNo="12345678942", Sex='m', Password="1234567"},
           new User {ID =3,Name="Ahmet", LastName="Asd",Age=30, Email="ahmetasd@gmail.com", IdentityNo="12345678943", Sex='m', Password="12345678"},
           new User {ID =4,Name="Mehmet", LastName="Dsa",Age=27, Email="mehmetdsa@gmail.com", IdentityNo="12345678944", Sex='m', Password="123456789"}
        };
    }

}
