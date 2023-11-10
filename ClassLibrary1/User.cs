using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class User
    {

        string name;
        string phone;
        string username;
        string type;


        public User(string name, string phone, string username, string type)
        {
            this.username = username;
            this.type = type;
            this.name = name;
            this.phone = phone;

        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
}
