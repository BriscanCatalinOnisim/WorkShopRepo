﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private static int idCount = 0;

        public TeamMember(int id, string name)
        {
            this.Name = name;
            this.Id = id;
            idCount++;
        }

    }
}
