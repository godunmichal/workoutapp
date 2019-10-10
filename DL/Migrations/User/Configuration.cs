namespace DL.Migrations.User
{
    using DL.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationUser : DbMigrationsConfiguration<DL.UserDbContext>
    {
        public ConfigurationUser()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\User";
        }

        protected override void Seed(DL.UserDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var adminRole = new IdentityRole { Name = "admin" };
                var customerRole = new IdentityRole { Name = "customer" };

                manager.Create(adminRole);
                manager.Create(customerRole);
            }

            if (!context.Users.Any(u => u.Email == "admin@admin.com"))
            {
                var admin = new Models.ApplicationUser()
                {
                    Id = "49ccafca-1aad-44a5-a9c8-3852f1c483e2",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    PasswordHash = "ABjRYco5oquViVD8L4uqRU5jGyteKOkBgP2ORQLcD8QeTsbqKneFfc6uPFbf/Sp2gA==",
                    SecurityStamp = "cb202b6f-4ed1-43d3-8823-63abf3fd2d30",
                    PhoneNumber = "123123123",
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    UserName = "admin@admin.com"
                };

                var customer = new Models.ApplicationUser()
                {
                    Id = "5e891d52-4550-411b-ba42-418ce9658d1e",
                    Email = "customer@wp.pl",
                    EmailConfirmed = false,
                    PasswordHash = "AEvOIZNw0esU9PDZCJW887/bXvLTvHZemr8IME4J+k+CYxt+Xiuwr/++aDcsVxaQBQ==",
                    SecurityStamp = "8f5ef714-5cb9-4654-a5eb-bff03f976006",
                    PhoneNumber = "123123123",
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    UserName = "customer@wp.pl",
                };

                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                manager.Create(admin);
                manager.Create(customer);

                manager.AddToRole(admin.Id, "admin");
                manager.AddToRole(customer.Id, "customer");
            }
        }
    }
}
