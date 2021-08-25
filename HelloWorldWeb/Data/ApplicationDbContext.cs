using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace HelloWorldWeb.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<HelloWorldWeb.Models.Skill> Skill { get; set; }

        public DbSet<HelloWorldWeb.Models.TeamMember> TeamMembers { get; set; }
    }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
