// <copyright file="Startup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using HelloWorldWeb.Controllers;
using HelloWorldWeb.Data;
using HelloWorldWeb.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

#pragma warning disable SA1600 // Elements should be documented

namespace HelloWorldWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITeamService, DbTeamService>();
            services.AddControllersWithViews();
            services.AddSingleton<IWeatherControllerSettings, WeatherControllerSettings>();
            services.AddSingleton<ITimeService, TimeService>();
            services.AddSingleton<IBroadcastService, BroadcastService>();
            services.AddSingleton<IWeatherControllerSettings, WeatherControllerSettings>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hello World API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                   .AddRoles<IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddSignalR();

            this.AssignRoleProgramaticaly(services.BuildServiceProvider());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));

                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<MessageHub>("/messagehub");
            });
        }

        private async void AssignRoleProgramaticaly(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var user = await userManager.FindByNameAsync("catalin.briscan@principal33.com");
            await userManager.AddToRoleAsync(user, "Administrators");
        }

        private static async Task EnsureUsersCreated(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var adminUser = await EnsureUserCreated(userManager, "borys.lebeda@principal33.com", "TzfOh22_FCbjxXQt6U");
            var operatorUser = await EnsureUserCreated(userManager, "borys.lebeda2@principal33.com", "TzfOh22_FCbjxXQt6U2");

            var adminRole = await EnsureRoleCreated(serviceProvider, "Administrator");
            var operatorRole = await EnsureRoleCreated(serviceProvider, "Operator");

            await userManager.AddToRoleAsync(adminUser, adminRole.Name);
            await userManager.AddToRoleAsync(operatorUser, operatorRole.Name);

            var users = await userManager.Users.ToListAsync();
            Console.WriteLine($"There are {users.Count} users now.");
        }

        private static async Task<IdentityUser> EnsureUserCreated(UserManager<IdentityUser> userManager, string name, string password)
        {
            var adminUser = await userManager.FindByNameAsync(name);
            if (adminUser == null)
            {
                await userManager.CreateAsync(new IdentityUser(name));
                adminUser = await userManager.FindByNameAsync(name);
                var tokenChangePassword = await userManager.GeneratePasswordResetTokenAsync(adminUser);

                var result = await userManager.ResetPasswordAsync(adminUser, tokenChangePassword, password);

                if (!adminUser.EmailConfirmed)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(adminUser);
                    await userManager.ConfirmEmailAsync(adminUser, token);
                }
            }

            return adminUser;
        }

        private static async Task<IdentityRole> EnsureRoleCreated(ServiceProvider serviceProvider, string roleName)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            var adminRole = await roleManager.FindByNameAsync(roleName);
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
                adminRole = await roleManager.FindByNameAsync(roleName);
            }

            return adminRole;
        }
    }
#pragma warning restore SA1600 // Elements should be documented
}