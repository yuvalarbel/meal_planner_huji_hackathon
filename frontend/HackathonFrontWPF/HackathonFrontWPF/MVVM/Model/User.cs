using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{

    public class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Vegetarian { get; set; }
        public bool Vegan { get; set; }
        public bool Kosher { get; set; }
        public bool NoGluten { get; set; }
        public bool Nosoy { get; set; }
        public bool NoMilk { get; set; }
        public bool Nonuts { get; set; }

        // create class constructor
        public User(string userName, string email, string password, bool vegetarian, bool vegan, bool kosher, bool noGluten, bool nosoy, bool noMilk, bool nonuts)
        {
            UserName = userName;
            Email = email;
            Password = password;
            Vegetarian = vegetarian;
            Vegan = vegan;
            Kosher = kosher;
            NoGluten = noGluten;
            Nosoy = nosoy;
            NoMilk = noMilk;
            Nonuts = nonuts;
        }
    }
}
