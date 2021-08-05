using HelloWorldWeb.Models;

namespace HelloWorldWeb.Services
{
    public interface ITeamService
    {
        void AddTeamMember(Member member);


        TeamInfo GetTeamInfo();

        void DeleteTeamMember(Member member);
    }
}