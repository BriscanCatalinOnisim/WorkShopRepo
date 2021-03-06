// <copyright file="ApplicationDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HelloWorldWeb.Models;

#pragma warning disable SA1600 // Elements should be documented

namespace HelloWorldWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HelloWorldWeb.Models.Skill> Skill { get; set; }

        public DbSet<HelloWorldWeb.Models.TeamMember> TeamMembers { get; set; }
    }
#pragma warning restore SA1600 // Elements should be documented
}
