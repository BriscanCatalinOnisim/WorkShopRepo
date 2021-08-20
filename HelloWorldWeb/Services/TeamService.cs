﻿using HelloWorldWeb.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable 1591

namespace HelloWorldWeb.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamInfo teamInfo;
        private readonly ITimeService timeService;
        private readonly IHubContext<MessageHub> messageHub;

        public TeamService(IHubContext<MessageHub> messageHubContext)
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team1",
                TeamMembers = new List<TeamMember>(),
            };

            this.messageHub = messageHubContext;

            teamInfo.TeamMembers.Add(new TeamMember("Sorina", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Ema", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Radu", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Patrick", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Tudor", timeService));
            teamInfo.TeamMembers.Add(new TeamMember("Fineas", timeService));
        }

        public TeamInfo GetTeamInfo()
        {
            return teamInfo;
        }

        public int AddTeamMember(string name)
        {
            int newId = teamInfo.TeamMembers.Count() + 1;
            teamInfo.TeamMembers.Add(new TeamMember(newId, name, timeService));
            messageHub.Clients.All.SendAsync("NewTeamMemberAdded", name, newId );
            return newId;
        }

        public void RemoveMember(int id)
        {
            teamInfo.TeamMembers.Remove(this.GetTeamMemberById(id));
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
            this.GetTeamMemberById(id).Name = name;
        }
    }
}
