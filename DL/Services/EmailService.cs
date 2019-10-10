using DL.Models;
using DL.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Services
{
    public class EmailService : IIdentityMessageService
    {
        private BlogDbContext _context;

        private DbSet<UserProfile> _userdata;


        public EmailService()
        {
            _context = new BlogDbContext();
            _userdata = _context.UserProfiles;
        }

        public IEnumerable<UserProfile> GetUsersEmails()
        {
            var query = from u in _userdata
                        where u.Newsletter == true
                        select u;
            var users = query.ToList();

            return users;
        }
        public UserProfile GetUserEmail(int userId)
        {
            UserProfile user = _context.UserProfiles.Where(u => u.Id == userId).SingleOrDefault();
            if (user == null)
                return null;

            return user;
        }

        public Task SendAsync(IdentityMessage message)
        {
            return Task.FromResult(0);
        }
    }
}