using DL.Constants;
using DL.Models;
using DL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Services
{
    public class ProfileService
    {
        private BlogDbContext _context;

        private DbSet<UserProfile> _userdata;

        public ProfileService()
        {
            _context = new BlogDbContext();
            _userdata = _context.UserProfiles;
        }
        public IEnumerable<UserProfile> GetData(string UserProfileId)
        {
            var query = from u in _userdata
                        where u.OwnerId.Equals(UserProfileId)
                        select u;
            var data = query.ToList();

            return data;
        }

        public UserProfile GetUserData(string userId)
        {
            UserProfile user = _userdata.Where(u => u.OwnerId.Equals(userId)).FirstOrDefault();
            return user;
        }
        public UserProfile GetUserData(int userId)
        {
            UserProfile user = _context.UserProfiles.Where(u => u.Id.Equals(userId)).FirstOrDefault();
            return user;
        }
        public void UserProfileEdit(UserProfile user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
