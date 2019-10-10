using DL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext()
            : base("DefaultConnection")
        {
        }
        public static UserDbContext Create()
        {
            return new UserDbContext();
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<PostComments> PostComments { get; set; }
    }
}
//Enable-Migrations -ContextTypeName DL.UserDbContext -MigrationsDirectory "Migrations\User" -ProjectName DL
//Add-Migration -ConfigurationTypeName ConfigurationBlog -ProjectName DL initial
//Update-Database -ProjectName DL -ConfigurationTypeName ConfigurationBlog