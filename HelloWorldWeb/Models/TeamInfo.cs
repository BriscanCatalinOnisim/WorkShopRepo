using System.Collections.Generic;

#pragma warning disable 1591

namespace HelloWorldWeb.Models
{
    public class TeamInfo
    {
        public string Name { get; set; }
        public List<TeamMember> TeamMembers { get; set; } 
    }


}