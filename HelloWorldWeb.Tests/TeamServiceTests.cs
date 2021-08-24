using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Microsoft.AspNetCore.SignalR;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class TeamServiceTest
    {
        private Mock<IHubContext<MessageHub>> messageHub = null;
        ITimeService timeService = null;
        private Mock<IHubClients> hubClientsMock;
        private Mock<IClientProxy> hubAllClientsMock;

        [Fact]
        public void AddTeamMemberToTheTeam()
        {
            // Assume
            var hubSettings = new Mock<IHubContext<MessageHub>>();
            var mockClients = new Mock<IHubClients>();
            ITeamService teamService = new TeamService(hubSettings.Object);

            // Act
            teamService.AddTeamMember( "Geo");

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);    
        }

        [Fact]
        public void DeleteTeamMemberToTheTeam()
        {
            // Assume
            var hubSettings = new Mock<IHubContext<MessageHub>>();
            var mockClients = new Mock<IHubClients>();
            ITeamService teamService = new TeamService(hubSettings.Object);

            // Act
            teamService.AddTeamMember("john");
            teamService.RemoveMember(4);

            // Assert
            Assert.Equal(7, teamService.GetTeamInfo().TeamMembers.Count);
        }

        [Fact]
        public void EditTeamMemberInTheTeam()
        {
            //Assume
            var hubSettings = new Mock<IHubContext<MessageHub>>();
            var mockClients = new Mock<IHubClients>();
            ITeamService teamService = new TeamService(hubSettings.Object);
            
            //Act
            teamService.EditTeamMember(3, "NewName");
            //Assert
            Assert.Equal("NewName", teamService.GetTeamMemberById(3).Name);


        }

        [Fact]
        public void Check()
        {
            //Assume
            InitializeMessageHubMock();
            hubAllClientsMock.Setup(_ => _.SendAsync("NewTeamMemberAdded", "Catalin", 2, It.IsAny<CancellationToken>()));
            var messageHubMock = messageHub.Object;

            //Act
            messageHubMock.Clients.All.SendAsync("NewTeamMemberAdded", "Catalin", 2);

            //Assert
            hubAllClientsMock.Verify(hubAllClients => hubAllClients.SendAsync("NewTeamMemberAdded", "Catalin", 2, It.IsAny<CancellationToken>()), Times.Once(), "I exepect send async to be called once.");
            //Mock.Get(messageHub).Verify(_ => _.SendAsync("NewTeamMemberAdded", "Catalin", 2), Times.Once());
        }

        private void InitializeMessageHubMock()
        {
            // https://www.codeproject.com/Articles/1266538/Testing-SignalR-Hubs-in-ASP-NET-Core-2-1
            hubAllClientsMock = new Mock<IClientProxy>();
            hubClientsMock = new Mock<IHubClients>();
            hubClientsMock.Setup(_ => _.All).Returns(hubAllClientsMock.Object);
            messageHub = new Mock<IHubContext<MessageHub>>();

            messageHub.SetupGet(_ => _.Clients).Returns(hubClientsMock.Object);
        }

        private IHubContext<MessageHub> GetMockerMessageHub()
        {
            if (messageHub == null)
            {
                InitializeMessageHubMock();
            }
            return messageHub.Object;
        }
    }
}
