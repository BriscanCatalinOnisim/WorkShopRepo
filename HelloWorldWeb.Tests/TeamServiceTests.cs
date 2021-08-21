using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Microsoft.AspNetCore.SignalR;
using Moq;
using System;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
           /* // Assume
            var hubSettings = new Mock<IHubContext<MessageHub>>();
            var mockClients = new Mock<IHubClients>();
            ITeamService teamService = new TeamService(hubSettings.Object);

            // Act
            teamService.AddTeamMember( "Geo");

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);    */
        }

        [Fact]
        public void DeleteTeamMemberToTheTeam()
        {
           /* // Assume
            var hubSettings = new Mock<IHubContext<MessageHub>>();
            var mockClients = new Mock<IHubClients>();
            ITeamService teamService = new TeamService(hubSettings.Object);

            // Act
            teamService.AddTeamMember("john");
            teamService.RemoveMember(4);

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);*/
        }

        [Fact]
        public void EditTeamMemberInTheTeam()
        {
           /* //Assume
            var hubSettings = new Mock<IHubContext<MessageHub>>();
            var mockClients = new Mock<IHubClients>();
            ITeamService teamService = new TeamService(hubSettings.Object);
            
            //Act
            teamService.EditTeamMember(3, "NewName");
            //Assert
            Assert.Equal("NewName", teamService.GetTeamMemberById(3).Name);*/


        }


    }
}
