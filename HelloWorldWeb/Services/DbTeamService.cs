using HelloWorldWeb.Data;
using HelloWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Services
{
    public class DbTeamService : ITeamService
    {
        private readonly ApplicationDbContext context;
        public DbTeamService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int AddTeamMemberAsync(string name)
        {
            TeamMember teamMember = new TeamMember(name);
            this.context.Add(name);
            this.context.SaveChanges();
            return teamMember.Id;
        }

        public void EditTeamMember(int id, string name)
        {
            throw new NotImplementedException();
        }

        public TeamInfo GetTeamInfo()
        {            
            var newList = this.context.TeamMembers.ToList();

            var teamInfo = new TeamInfo();
            teamInfo.Name = "Catalin";
            teamInfo.TeamMembers = newList;

            return teamInfo;
        }

        public TeamMember GetTeamMemberById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveMember(int memberIndex)
        {
            throw new NotImplementedException();
        }
    }
}
