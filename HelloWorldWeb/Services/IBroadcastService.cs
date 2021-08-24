namespace HelloWorldWeb.Services
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

    public interface IBroadcastService
    {
        void NewTeamMemberAdded(string name, int newId);
        void TeamMemberDeleted(int memberId);
        void UpdatedTeamMember(int memberId, string name);
    }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}