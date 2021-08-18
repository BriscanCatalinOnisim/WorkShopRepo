﻿using HelloWorldWeb.Services;
using System;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamMemberTests
    {
        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume
            TeamService teamService = new TeamService();

            // Act
            teamService.AddTeamMember("intern");

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact(Skip = "Skipped for the moment")]
        public void RemoveMemberFromTheTeamAfterAdding()
        {
            // Assume
            TeamService teamService = new TeamService();

            // Act
            teamService.AddTeamMember("intern");
            teamService.RemoveMember(0);

            // Assert
            Assert.Equal(6, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void UpdateMemberName()
        {
            // Assume
            ITeamService teamService = new TeamService();

            // Act
            teamService.UpdateMemberName(0, "UnitTest");

            // Assert
            var member = teamService.GetTeamMemberById(0);
            Assert.Equal("UnitTest", member.Name);
        }
    }
}