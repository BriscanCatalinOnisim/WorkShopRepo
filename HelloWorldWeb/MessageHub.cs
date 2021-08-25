// <copyright file="MessageHub.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

#pragma warning disable SA1600 // Elements should be documented

namespace HelloWorldWeb
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(string user, string message) => await this.Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
#pragma warning restore SA1600 // Elements should be documented
