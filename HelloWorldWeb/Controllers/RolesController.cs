// <copyright file="RolesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#pragma warning disable SA1600 // Elements should be documented

namespace HelloWorldWeb.Controllers
{
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        // GET: RolesController
        public ActionResult Index()
        {
            return this.View(this.roleManager.Roles);
        }

        // GET: RolesController/Details/5
        public ActionResult Details(int id)
        {
            return this.View();
        }

        // GET: RolesController/Create
        public ActionResult Create()
        {
            return this.View(new IdentityRole());
        }

        // POST: RolesController/Create
        [HttpPost]
        public async Task<ActionResult> Create(IdentityRole role)
        {
            try
            {
                await this.roleManager.CreateAsync(role);
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }
    }

#pragma warning restore SA1600 // Elements should be documented
}
