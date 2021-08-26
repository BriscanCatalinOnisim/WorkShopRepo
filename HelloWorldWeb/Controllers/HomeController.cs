// <copyright file="HomeController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using HelloWorldWeb.Models;
using HelloWorldWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable SA1101 // Prefix local calls with this

namespace HelloWorldWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly ITeamService teamService;
        private readonly ITimeService timeService;

        public HomeController(ILogger<HomeController> logger, ITeamService teamService, ITimeService timeService)
        {
            this.logger = logger;
            this.teamService = teamService;
            this.timeService = timeService;
        }

        [HttpPost]
        [Authorize]
        public void AddTeamMember(string name)
        {
            this.teamService.AddTeamMemberAsync(name);
        }

        [HttpDelete]
        [Authorize]
        public void RemoveMember(int id)
        {
            this.teamService.RemoveMember(id);
        }

        [HttpPost]
        [Authorize]
        public void RenameMember(int id, string name)
        {
            this.teamService.EditTeamMember(id, name);
        }

        [HttpGet]
        public int GetCount()
        {
            return this.teamService.GetTeamInfo().TeamMembers.Count;
        }

        public IActionResult Index()
        {
            return View(this.teamService.GetTeamInfo());
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

        public IActionResult Chat()
        {
            return View();
        }
    }
#pragma warning restore SA1101 // Prefix local calls with this
#pragma warning restore SA1600 // Elements should be documented
}
