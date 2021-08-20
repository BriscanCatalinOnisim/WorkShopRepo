// <copyright file="TeamService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;
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
        private ITimeService timeService;

        public TeamService()
        {
            this.teamInfo = new TeamInfo
            {
                Name = "Team1",
                TeamMembers = new List<TeamMember>(),
            };

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
            return newId;
        }

        public void RemoveMember(int id)
        {
            this.teamInfo.TeamMembers.Remove(this.GetTeamMemberById(id));
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
#pragma warning restore SA1600 // Elements should be documented
}
