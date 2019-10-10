using DL.Constants;
using DL.Models;
using DL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Services
{
    public class AdminService
    {
        private BlogDbContext _context;

        public AdminService()
        {
            _context = new BlogDbContext();
        }
        public UserProfile GetUserData(string userId)
        {
            UserProfile user = _context.UserProfiles.Where(u => u.OwnerId.Equals(userId)).FirstOrDefault();
            return user;
        }
        public IEnumerable<Post> GetPosts()
        {
            var query = from p in _context.Posts
                        select p;
            var posts = query.ToList();

            return posts;
        }
        public IEnumerable<Exercise> GetExercises()
        {
            var query = from e in _context.Exercises
                        select e;
            var exercises = query.ToList();

            return exercises;
        }
        public IEnumerable<Comment> GetComments()
        {
            var query = from c in _context.Comments
                        select c;
            var comments = query.ToList();

            return comments;
        }
        public IEnumerable<UserProfile> GetUsersEmails()
        {
            var query = from u in _context.UserProfiles
                        where u.Newsletter == true
                        select u;
            var users = query.ToList();

            return users;
        }

        public Post GetPost(int postId)
        {
            Post post = _context.Posts.Where(p => p.Id == postId).SingleOrDefault();
            if (post == null)
                return null;

            return post;
        }
        public Exercise GetExercise(int exerciseId)
        {
            Exercise exercise = _context.Exercises.Where(e => e.Id == exerciseId).SingleOrDefault();
            if (exercise == null)
                return null;

            return exercise;
        }
        public Comment GetComment(int commentId)
        {
            Comment comment = _context.Comments.Where(p => p.Id == commentId).SingleOrDefault();
            if (comment == null)
                return null;

            return comment;
        }
        public IEnumerable<UserProfile> GetUser()
        {
            var query = from u in _context.UserProfiles
                        select u;
            var users = query.ToList();

            return users;
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


        public IEnumerable<string> GetDifficulty()
        {
            return Enum.GetNames(typeof(Difficulty));
        }

        public void AddPost(Post post)
        {
            Post p = new Post
            {
                Date = DateTime.Now,
                Title = post.Title,
                Text = post.Text,
                VideoUrl = post.VideoUrl,

            };

            _context.Posts.Add(p);
            _context.SaveChanges();
        }
        public void AddComment(Comment comment)
        {
            Comment c = new Comment
            {
                Date = DateTime.Now,
                Text = comment.Text,
                PostId = comment.PostId,
                UserProfileId = comment.UserProfileId,

            };

            _context.Comments.Add(c);
            _context.SaveChanges();
        }

        public void AddExercise(Exercise exercise)
        {
            Exercise e = new Exercise
            {
                VideoUrl = exercise.VideoUrl,
                Text = exercise.Text,
                Difficulty = exercise.Difficulty,

            };

            _context.Exercises.Add(e);
            _context.SaveChanges();
        }

        public void DeletePost(int id)
        {
            var po = _context.Posts.Where(p => p.Id.Equals(id)).FirstOrDefault();
            _context.Posts.Remove(po);
            _context.SaveChanges();
        }
        public void DeleteComment(int id)
        {
            var co = _context.Comments.Where(c => c.Id.Equals(id)).FirstOrDefault();
            _context.Comments.Remove(co);
            _context.SaveChanges();
        }

        public void DeleteExercise(int id)
        {
            var ex = _context.Exercises.Where(e => e.Id.Equals(id)).FirstOrDefault();
            _context.Exercises.Remove(ex);
            _context.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var u = _context.UserProfiles.Where(p => p.Id.Equals(id)).FirstOrDefault();
            _context.UserProfiles.Remove(u);
            _context.SaveChanges();
        }

        public void EditPost(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void EditComment(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void EditExercise(Exercise exercise)
        {
            _context.Entry(exercise).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
