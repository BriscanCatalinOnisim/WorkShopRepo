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

            teamInfo.TeamMembers.Add(new TeamMember("Sorina", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Ema", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Radu", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Patrick", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Tudor", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Fineas", timeService));
        }

        public TeamInfo GetTeamInfo() 
        {
            return this.teamInfo;
        }

        public int AddTeamMemberAsync(string name)
        {
            int newId = teamInfo.TeamMembers.Count() + 1;
            teamInfo.TeamMembers.Add(new TeamMember(newId, name, timeService));
            this.broadcastService.NewTeamMemberAdded(name, newId);
            return newId;
        }

        public void RemoveMember(int memberId)
        {
            TeamMember member = GetTeamMemberById(memberId);
            teamInfo.TeamMembers.Remove(member);
            this.broadcastService.TeamMemberDeleted(memberId);
        }


        public TeamMember GetTeamMemberById(int id)
        {
            // foreach (TeamMember member in this.teamInfo.TeamMembers)
            // {
            //    if (member.Id == id)
            //    {
            //        return member;
            //    }

            // }

            // return null;
            Console.WriteLine(id);
            return this.teamInfo.TeamMembers.Find(x => x.Id == id);
        }

        public void EditTeamMember(int id, string name)
        {
            TeamMember member = GetTeamMemberById(id);
            member.Name = name;
            broadcastService.UpdatedTeamMember(id, name);
        }
    }
#pragma warning restore SA1600 // Elements should be documented
}
