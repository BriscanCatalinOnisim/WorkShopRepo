#pragma warning disable 1591

using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        int AddTeamMember(string name);

        TeamInfo GetTeamInfo();

        TeamMember GetTeamMemberById(int id);
        void EditTeamMember(int id, string name);

        public void RemoveMember(int memberIndex);
    }
}