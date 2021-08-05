using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Models
{
    public class Member
    {
        public string name { get; set; }
        public int id { get; set; }

        public Member(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

    }
}
