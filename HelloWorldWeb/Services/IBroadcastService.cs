// <copyright file="IBroadcastService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1600 // Elements should be documented

namespace HelloWorldWeb.Services
{
    public interface IBroadcastService
    {
        void NewTeamMemberAdded(string name, int newId);

        void TeamMemberDeleted(int memberId);

        void UpdatedTeamMember(int memberId, string name);
    }

#pragma warning restore SA1600 // Elements should be documented
}