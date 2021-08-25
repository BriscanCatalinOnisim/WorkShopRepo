// <copyright file="DbTeamService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using HelloWorldWeb.Data;
using HelloWorldWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable SA1600 // Elements should be documented

namespace HelloWorldWeb.Services
{
    public class DbTeamService : ITeamService
    {
        private readonly ApplicationDbContext context;
        private readonly IBroadcastService broadcastService;

        public DbTeamService(ApplicationDbContext context, IBroadcastService broadcastService)
        {
            this.context = context;
            this.broadcastService = broadcastService;
        }

        public int AddTeamMemberAsync(string name)
        {
            TeamMember teamMember = new TeamMember(name);
            List<TeamMember> teamService = this.context.TeamMembers.ToList();
            int index = teamService[teamService.Count - 1].Id + 1;
            teamMember.Id = index;
            this.context.Add(teamMember);
            this.context.SaveChanges();
            this.broadcastService.NewTeamMemberAdded(name, teamMember.Id);
            return teamMember.Id;
        }

        public void EditTeamMember(int id, string name)
        {
            var member = this.context.TeamMembers.ToList().Find(x => x.Id == id);
            member.Name = name;
            this.context.Update(member);
            this.context.SaveChanges();
            this.broadcastService.UpdatedTeamMember(id, name);
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
            return this.context.TeamMembers.ToList().Find(x => x.Id == id);
        }

        public void RemoveMember(int memberIndex)
        {
            TeamMember member = this.GetTeamMemberById(memberIndex);
            this.context.TeamMembers.Remove(member);
            this.context.SaveChanges();
            this.broadcastService.TeamMemberDeleted(member.Id);
        }
    }
#pragma warning restore SA1600 // Elements should be documented
}
