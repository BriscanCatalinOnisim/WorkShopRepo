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
            this.teamInfo = new TeamInfo { Name = "name", TeamMembers = new List<string>() };
        }

        public TeamInfo GetTeamInfo()
        {
            return teamInfo;
        }

        public void AddTeamMember(string name)
        {
            teamInfo.TeamMembers.Add(name);
        }

    }
}
