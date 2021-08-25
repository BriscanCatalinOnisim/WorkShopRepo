﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloWorldWeb.Data;
using HelloWorldWeb.Models;

#pragma warning disable 1591

namespace HelloWorldWeb.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkillsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET: Skills
        public async Task<IActionResult> Index()
        {
            return this.View(await this._context.Skill.ToListAsync());
        }

        // GET: Skills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var skill = await this._context.Skill
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skill == null)
            {
                return this.NotFound();
            }

            return this.View(skill);
        }

        // GET: Skills/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SkillUrl")] Skill skill)
        {
            if (this.ModelState.IsValid)
            {
                this._context.Add(skill);
                await this._context.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(skill);
        }

        // GET: Skills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var skill = await this._context.Skill.FindAsync(id);
            if (skill == null)
            {
                return this.NotFound();
            }

            return this.View(skill);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SkillUrl")] Skill skill)
        {
            if (id != skill.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this._context.Update(skill);
                    await this._context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.SkillExists(skill.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(skill);
        }

        // GET: Skills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var skill = await this._context.Skill
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skill == null)
            {
                return this.NotFound();
            }

            return this.View(skill);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skill = await this._context.Skill.FindAsync(id);
            this._context.Skill.Remove(skill);
            await this._context.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool SkillExists(int id)
        {
            return this._context.Skill.Any(e => e.Id == id);
        }
    }
}