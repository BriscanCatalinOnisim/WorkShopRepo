using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamMemberTests
    {
        private ITimeService timeservice;

        public TeamMemberTests()
        {
            timeservice = new FakeTimeService();
        }

        [Fact]
        public void GettingAge()
        {
            //Assume
            var teamMember = new TeamMember(1, "John", timeservice);
            teamMember.Birthdate = new DateTime(1999, 11, 14);

            //Act
            int age = teamMember.getAge();

            //Assert
            Assert.Equal(21, age);
        }


    }

    internal class FakeTimeService : ITimeService
    {
        public DateTime Now()
        {
            return new DateTime(2021, 8, 11);
        }      

    }
}
