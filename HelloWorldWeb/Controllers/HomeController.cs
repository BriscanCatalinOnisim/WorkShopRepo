using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITeamService teamService;
        private int index;

        public HomeController(ILogger<HomeController> logger, ITeamService teamService)
        {
            _logger = logger;
            this.teamService = teamService;
            this.index = teamService.GetTeamInfo().TeamMembers.Count;
        }

        [HttpPost]
        public void AddTeamMember(string name)
        {
            this.index++;
            Member member = new Member(name, this.index);
            teamService.AddTeamMember(member);
        }

        [HttpPost]
        public void DeleteTeamMember(int id)
        {
            string nameMember = "";
            foreach(Member m in teamService.GetTeamInfo().TeamMembers)
            {
                if (m.id == id)
                { 
                    nameMember = m.name; 
                    break; 
                }
            }
            Member member = new Member(nameMember, id);
            teamService.DeleteTeamMember(member);
        }

        [HttpGet]
        public int GetCount()
        {
            return teamService.GetTeamInfo().TeamMembers.Count;
        }
        public IActionResult Index()
        {
            return View(teamService.GetTeamInfo());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
