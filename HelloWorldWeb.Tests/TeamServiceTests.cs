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
        private IBroadcastService broadcastService;
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            broadcastService = broadcastServiceMock.Object;
            ITeamService teamService = new TeamService(broadcastService);

            // Act
            teamService.AddTeamMember( "Geo");

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);
            broadcastServiceMock.Verify(_ => _.NewTeamMemberAdded("Geo", 7), Times.Once());
        }

        [Fact]
        public void DeleteTeamMemberToTheTeam()
        {
            // Assume
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            broadcastService = broadcastServiceMock.Object;
            ITeamService teamService = new TeamService(broadcastService);

            // Act
            teamService.AddTeamMember("john");
            teamService.RemoveMember(4);

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void EditTeamMemberInTheTeam()
        {
            //Assume
            Mock<IBroadcastService> broadcastServiceMock = new Mock<IBroadcastService>();
            broadcastService = broadcastServiceMock.Object;
            ITeamService teamService = new TeamService(broadcastService);

            //Act
            teamService.EditTeamMember(3, "NewName");

            //Assert
            Assert.Equal("NewName", teamService.GetTeamInfo().TeamMembers[3].Name);


        }


    }
}
