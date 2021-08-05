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
            teamService.AddTeamMember(new Member("Geo", 5));

            // Assert
            Assert.Equal(4, teamService.GetTeamInfo().TeamMembers.Count);
            

        }
    }
}
