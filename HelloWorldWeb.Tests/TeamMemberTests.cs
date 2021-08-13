using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Moq;
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
        private Mock<ITimeService> timeMock;

        private void InitializeTimeServiceMock()
        {
            timeMock = new Mock<ITimeService>();
            timeMock.Setup(_ => _.Now()).Returns(new DateTime(2021, 11, 11));
            
        }

        [Fact]
        public void GettingAge()
        {
            //Assume
            InitializeTimeServiceMock();
            var timeservice = timeMock.Object;
            var teamMember = new TeamMember(1, "John", timeservice);
            teamMember.Birthdate = new DateTime(1999, 11, 14);
           
            //Act
            int age = teamMember.getAge();

            //Assert
            timeMock.Verify(_ => _.Now(), Times.AtMostOnce());
            Assert.Equal(21, age);
        }


    }
}
