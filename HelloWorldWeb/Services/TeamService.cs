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

            this.AddTeamMember("Gabi");
            this.AddTeamMember("Delia");
            this.AddTeamMember("Rares");
            this.AddTeamMember("Catalin");        
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
