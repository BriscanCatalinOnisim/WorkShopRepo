// <copyright file="TeamInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;

#pragma warning disable SA1600 // Elements should be documented

#pragma warning disable 1591

namespace HelloWorldWeb.Models
{
    public class TeamInfo
    {
        public string Name { get; set; }

        public List<TeamMember> TeamMembers { get; set; }
    }
#pragma warning restore SA1600 // Elements should be documented
}