using HelloWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;

        public TeamService()
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team 2",
                TeamMembers = new List<TeamMember>()
            };
            teamInfo.TeamMembers.Add(new TeamMember(1, "Gabi"));
            teamInfo.TeamMembers.Add(new TeamMember(2, "Delia"));
            teamInfo.TeamMembers.Add(new TeamMember(3, "Rares"));
            teamInfo.TeamMembers.Add(new TeamMember(4, "Catalin"));         
}

        public TeamInfo GetTeamInfo()
        {
            return teamInfo;
        }

        public int AddTeamMember(string name)
        {
            int newId = teamInfo.TeamMembers.Count() + 1;
            teamInfo.TeamMembers.Add(new TeamMember(newId, name));
            return newId;
        }

        public void RemoveMember(int memberIndex)
        {
            teamInfo.TeamMembers.RemoveAt(memberIndex);
        }
    }
}
