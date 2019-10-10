using DL.Models;
using DL.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Services
{
    public class BlogService
    {
        private BlogDbContext _context;
        public BlogService()
        {
            _context = new BlogDbContext();
        }
        public IEnumerable<Exercise> GetNegExercises()
        {
            var query = from e in _context.Exercises
                        where e.Difficulty == Constants.Difficulty.Negative
                        select e;
            var exercises = query.ToList();

            return exercises;
        }
        public IEnumerable<Exercise> GetBegExercises()
        {
            var query = from e in _context.Exercises where e.Difficulty == Constants.Difficulty.Beginner 
                        select e;
            var exercises = query.ToList();

            return exercises;
        }
        public IEnumerable<Exercise> GetIntExercises()
        {
            var query = from e in _context.Exercises
                        where e.Difficulty == Constants.Difficulty.Intermediate
                        select e;
            var exercises = query.ToList();

            return exercises;
        }
        public IEnumerable<Exercise> GetAdvExercises()
        {
            var query = from e in _context.Exercises
                        where e.Difficulty == Constants.Difficulty.Advenced
                        select e;
            var exercises = query.ToList();

            return exercises;
        }
        public IEnumerable<PostViewModel> GetMostNewestPosts()
        {
            return _context.Posts
                .Take(5)
                .OrderByDescending(p => p.Date)
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Text = p.Text,
                    VideoUrl = p.VideoUrl,
                });
        }
        public IEnumerable<Exercise> GetExercises(string difficulty, string searchString)
        {

            var exercises = from e in _context.Exercises
                            select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                exercises = exercises.Where(e => e.Text.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(difficulty))
            {
                int diff = Int32.Parse(difficulty);
                exercises = exercises.Where(d => (int)d.Difficulty == diff);   
            }

            return exercises;
        }
        public IEnumerable<CommentViewModel> GetPostComments(int postId)
        {
            return _context.Comments
                .Where(c => c.PostId == postId)
                .OrderByDescending(c => c.Date)
                .Select(c => new CommentViewModel
                {
                    Id = c.Id,
                    Text = c.Text,
                    UserProfile = c.UserProfile,
                    UserProfileId = c.UserProfileId,
                    Date = c.Date.Value,
                });
        }

        public IEnumerable<PostViewModel> GetPostById(int postId)
        {
            return _context.Posts
                .Where(p => p.Id == postId)
                .Select(p => new PostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Text = p.Text,
                    VideoUrl = p.VideoUrl,
                });
        }
        public void AddComment(Comment comment,int postId,int userId)
        {
            Comment c = new Comment
            {
                Date = DateTime.Now,
                Text = comment.Text,
                PostId = postId,
                UserProfileId = userId,

            };

            _context.Comments.Add(c);
            _context.SaveChanges();
        }
        public UserProfile GetUserData(string userId)
        {
            UserProfile user = _context.UserProfiles.Where(u => u.OwnerId.Equals(userId)).FirstOrDefault();
            return user;
        }
        public Comment GetComment(int commentId)
        {
            Comment comment = _context.Comments.Where(p => p.Id == commentId).SingleOrDefault();
            if (comment == null)
                return null;

            return comment;
        }

        public void EditComment(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
