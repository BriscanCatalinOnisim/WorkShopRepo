// <copyright file="TeamMember.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using HelloWorldWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1101 // Prefix local calls with this
#pragma warning disable SA1300 // Element should begin with upper-case letter

namespace HelloWorldWeb.Models
{
    public class TeamMember
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        private static int idCount = 0;

        private ITimeService TimeService { get; set; }

        public TeamMember(int id, string name, ITimeService timeService)
        {
            this.Name = name;
            this.Id = id;
            this.TimeService = timeService;
            idCount++;
        }

        public TeamMember(string name, ITimeService timeService)
        {
            this.TimeService = timeService;
            this.Id = idCount;
            this.Name = name;

            idCount++;
        }

        public TeamMember(string name)
        {
            this.Id = idCount;
            this.Name = name;

            idCount++;
        }

        public int getAge()
        {
            TimeSpan age;
            DateTime birthDate;
            birthDate = this.Birthdate;

            DateTime zeroTime = new DateTime(1, 1, 1);
            age = TimeService.Now() - birthDate;
            int years = (zeroTime + age).Year - 1;

            return years;
        }
    }
#pragma warning restore SA1300 // Element should begin with upper-case letter
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning restore SA1600 // Elements should be documented
}
