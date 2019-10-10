namespace DL.Migrations.Blog
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DL.Models;

    internal sealed class ConfigurationBlog : DbMigrationsConfiguration<DL.BlogDbContext>
    {
        public ConfigurationBlog()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Blog";
        }

        protected override void Seed(DL.BlogDbContext context)
        {



            UserProfile[] profiles = new UserProfile[]
            {
                new UserProfile { Id = 1, OwnerId = "49ccafca-1aad-44a5-a9c8-3852f1c483e2", Name = "Michal", Surname = "Godun", Email ="test.test.v.54@gmail.com",City="Bialystok",PhotoUrl="https://ssl.gstatic.com/accounts/ui/avatar_2x.png", Newsletter=true },
                new UserProfile { Id = 2, OwnerId = "5e891d52-4550-411b-ba42-418ce9658d1e",Name = "Pawel", Surname = "Milewski", Email ="bayeux1@o2.pl",  City="Suwa³ki",PhotoUrl="https://ssl.gstatic.com/accounts/ui/avatar_2x.png", Newsletter=false },
            };

            context.UserProfiles.AddOrUpdate(profiles);


        }
    }
}
