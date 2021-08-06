using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using System;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume
            ITeamService teamService = new TeamService();

            // Act
            teamService.AddTeamMember( "Geo");

            // Assert
            Assert.Equal(5, teamService.GetTeamInfo().TeamMembers.Count);
            

        }
        [Fact]
        public void EditTeamMemberInTheTeam()
        {
            ITeamService teamService = new TeamService();
            teamService.EditTeamMember(3, "Name");
            Assert.Equal("Name", teamService.GetTeamMemberById(3).Name);
        }
    }
}
