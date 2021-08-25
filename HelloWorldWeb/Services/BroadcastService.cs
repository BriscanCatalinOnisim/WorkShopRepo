// <copyright file="BroadcastService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#pragma warning disable SA1600 // Elements should be documented

namespace HelloWorldWeb.Services
{
    public class BroadcastService : IBroadcastService
    {
        private readonly IHubContext<MessageHub> messageHub;

        public BroadcastService(IHubContext<MessageHub> messageHub)
        {
            this.messageHub = messageHub;
        }

        public void NewTeamMemberAdded(string name, int newId)
        {
            this.messageHub.Clients.All.SendAsync("NewTeamMemberAdded", name, newId);
        }

        public void TeamMemberDeleted(int memberId)
        {
            this.messageHub.Clients.All.SendAsync("TeamMemberDeleted", memberId);
        }

        public void UpdatedTeamMember(int memberId, string name)
        {
            this.messageHub.Clients.All.SendAsync("UpdatedTeamMember", memberId, name);
        }
    }

#pragma warning restore SA1600 // Elements should be documented
}
