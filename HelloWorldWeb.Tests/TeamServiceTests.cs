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
            teamService.AddTeamMemberAsync( "Geo");

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);    
        }

        [Fact]
        public void DeleteTeamMemberToTheTeam()
        {
            // Assume
            ITeamService teamService = new TeamService();

            // Act
            teamService.AddTeamMemberAsync("john");
            teamService.RemoveMember(4);

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void EditTeamMemberInTheTeam()
        {
            //Assume
            ITeamService teamService = new TeamService();
            //Act
            teamService.EditTeamMember(3, "NewName");
            //Assert
            Assert.Equal("NewName", teamService.GetTeamMemberById(3).Name);


        }


    }
}
