using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Here we will set up info for a user account to seed the data

namespace BookStore.Models
{
    public static class IdentitySeedData
    {
        // Set up constant strings for password and username

        private const string adminUser = "Admin";
        private const string adminPassword = "413ExtraYeetPeriod(t)!";

        // Call method to make sure there is data in the database

        public static async void EnsurePopulated(IApplicationBuilder app)
        {

            // Create instance of database to make changes to it

            AppIdentityDBContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDBContext>();

            // If there are migrtaions that need to be ran, run them

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            // Set up for userManager

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            // See if there is a user for admin, and if not create a new one

            IdentityUser user = await userManager.FindByIdAsync(adminUser);

            if (user == null)
            {
                user = new IdentityUser(adminUser);

                user.Email = "egbert.seth@gmail.com";
                user.PhoneNumber = "208-571-3815";

                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
