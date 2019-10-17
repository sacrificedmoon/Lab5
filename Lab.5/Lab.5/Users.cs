using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab._5
{
    public class Users
    {
        public static List<Users> users = new List<Users>();
        public static List<Users> admins = new List<Users>();
       
        public Users(string name, string email)
        {
            Name = name;
            Mail = email;
        }

        public string Name { get; set; }
        public string Mail { get; set; }
    }
}