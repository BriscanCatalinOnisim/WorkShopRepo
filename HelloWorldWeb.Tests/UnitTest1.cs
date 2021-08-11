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
        public void DeleteTeamMemberToTheTeam()
        {
            // Assume
            ITeamService teamService = new TeamService();

            // Act
            teamService.AddTeamMember("john");
            teamService.RemoveMember(4);

            // Assert
            Assert.Equal(4, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void EditTeamMemberInTheTeam()
        {
            //Assume
            ITeamService teamService = new TeamService();
           
            //Act
            teamService.EditTeamMember(4, "Name");
            
            //Assert
            Assert.Equal("Name", teamService.GetTeamMemberById(4).Name);
        }

        [Fact]
        public void CheckIdProblem()
        {
            //Assume
            ITeamService teamService = new TeamService();
            var memberToBeDeleted = teamService.GetTeamInfo().TeamMembers[teamService.GetTeamInfo().TeamMembers.Count - 2];
            var newMemberName = "Borys";

            //Act
            teamService.RemoveMember(memberToBeDeleted.Id);
            var id = teamService.AddTeamMember(newMemberName);
            teamService.RemoveMember(id);

            //Assert
            var team = teamService.GetTeamInfo().TeamMembers.Find(el => el.Name == newMemberName);
            Assert.Null(team);
        }

    }
}
