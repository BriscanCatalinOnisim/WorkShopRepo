// <copyright file="ITeamService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;

#pragma warning disable SA1600 // Elements should be documented

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        int AddTeamMemberAsync(string name);

        TeamInfo GetTeamInfo();

        TeamMember GetTeamMemberById(int id);

        void EditTeamMember(int id, string name);

        public void RemoveMember(int memberIndex);
    }
#pragma warning restore SA1600 // Elements should be documented
}