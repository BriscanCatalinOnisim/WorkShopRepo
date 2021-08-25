// <copyright file="TeamService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable SA1600 // Elements should be documented

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;
        private readonly ITimeService timeService;
        private readonly IBroadcastService broadcastService;

        public TeamService(IBroadcastService broadcastService)
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team1",
                TeamMembers = new List<TeamMember>(),
            };

            this.broadcastService = broadcastService;

            this.teamInfo.TeamMembers.Add(new TeamMember("Sorina", this.timeService));
            this.teamInfo.TeamMembers.Add(new TeamMember("Ema", this.timeService));
            this.teamInfo.TeamMembers.Add(new TeamMember("Radu", this.timeService));
            this.teamInfo.TeamMembers.Add(new TeamMember("Patrick", this.timeService));
            this.teamInfo.TeamMembers.Add(new TeamMember("Tudor", this.timeService));
            this.teamInfo.TeamMembers.Add(new TeamMember("Fineas", this.timeService));
        }

        public TeamInfo GetTeamInfo()
        {
            return this.teamInfo;
        }

        public int AddTeamMemberAsync(string name)
        {
            int newId = this.teamInfo.TeamMembers.Count() + 1;
            this.teamInfo.TeamMembers.Add(new TeamMember(newId, name, this.timeService));
            this.broadcastService.NewTeamMemberAdded(name, newId);
            return newId;
        }

        public void RemoveMember(int memberId)
        {
            TeamMember member = this.GetTeamMemberById(memberId);
            this.teamInfo.TeamMembers.Remove(member);
            this.broadcastService.TeamMemberDeleted(memberId);
        }

        public TeamMember GetTeamMemberById(int id)
        {
            return this.teamInfo.TeamMembers.Find(x => x.Id == id);
        }

        public void EditTeamMember(int id, string name)
        {
            TeamMember member = this.GetTeamMemberById(id);
            member.Name = name;
            this.broadcastService.UpdatedTeamMember(id, name);
        }
    }
#pragma warning restore SA1600 // Elements should be documented
}
