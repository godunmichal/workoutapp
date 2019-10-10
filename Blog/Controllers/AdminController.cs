using DL.Constants;
using DL.Models;
using DL.Services;
using DL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.IO;
using Microsoft.AspNet.Identity;

namespace Blog.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private AdminService _adminService;
        private EmailService _emailService;
        public AdminController()
        {
            _adminService = new AdminService();
            _emailService = new EmailService();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = _adminService.GetUser();
            return PartialView(@"~/Views/Admin/Users.cshtml", users);

        }
        [HttpGet]
        public ActionResult GetPosts()
        {
            var posts = _adminService.GetPosts();
            return PartialView(@"~/Views/Admin/Posts.cshtml", posts);

        }
        [HttpGet]
        public ActionResult GetExercises()
        {
            List<Difficulty> myDifficulty = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();

            ViewBag.Difficulties = new SelectList(myDifficulty);
            var exercises = _adminService.GetExercises();
            return PartialView(@"~/Views/Admin/Exercises.cshtml", exercises);

        }
        [HttpGet]
        public ActionResult GetComments()
        {
            var posts = _adminService.GetComments();
            return PartialView(@"~/Views/Admin/Comments.cshtml", posts);

        }


        [Route("{id}")]
        public ActionResult EditUser(int? id)
        {
            var user = _adminService.GetUserData(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [Route("{id}")]
        public ActionResult DetailsUser(int? id)
        {
            var user = _adminService.GetUserData(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [Route("{id}")]
        public ActionResult DeleteUser(int? id)
        {
            var user = _adminService.GetUserData(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        [HttpPost]
        public ActionResult EditUser(UserProfile user)
        {
            _adminService.UserProfileEdit(user);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            var user = _adminService.GetUserData(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            _adminService.DeleteUser(id);
            return RedirectToAction("Index");
        }

        public ActionResult Posts()
        {
            return View(_adminService.GetPosts());
        }
        public ActionResult Comments()
        {
            return View(_adminService.GetComments());
        }
        public ActionResult Exercises()
        {
            List<Difficulty> myDifficulty = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();

            ViewBag.Difficulties = new SelectList(myDifficulty);
            return View(_adminService.GetExercises());
        }

        [Route("{id}")]
        public ActionResult DetailsPost(int? id)
        {
            var post = _adminService.GetPost(id.Value);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        [Route("{id}")]
        public ActionResult DetailsComment(int? id)
        {
            var comment = _adminService.GetComment(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        [Route("{id}")]
        public ActionResult DetailsExercise(int? id)
        {
            var exercise = _adminService.GetExercise(id.Value);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }


        [Route("{id}")]
        public ActionResult EditPost(int? id)
        {
            var post = _adminService.GetPost(id.Value);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        [Route("{id}")]
        public ActionResult EditComment(int? id)
        {
            var comment = _adminService.GetComment(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        [Route("{id}")]
        public ActionResult EditExercise(int? id)
        {
            List<Difficulty> myDifficulty = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();

            ViewBag.Difficulties = new SelectList(myDifficulty);
            var exercise = _adminService.GetExercise(id.Value);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        [Route("{id}")]
        public ActionResult DeletePost(int? id)
        {
            var post = _adminService.GetPost(id.Value);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        [Route("{id}")]
        public ActionResult DeleteComment(int? id)
        {
            var comment = _adminService.GetComment(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        [Route("{id}")]
        public ActionResult DeleteExercise(int? id)
        {
            var exercise = _adminService.GetExercise(id.Value);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        public ActionResult AddPost()
        {
            return View();
        }
        public ActionResult AddComment()
        {
            return View();
        }

        public ActionResult AddExercise()
        {
            List<Difficulty> myDifficulty = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();

            ViewBag.Difficulties = new SelectList(myDifficulty);
            return View();
        }

        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            var post = _adminService.GetPost(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            _adminService.DeletePost(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteComment(int id)
        {
            var comment = _adminService.GetComment(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            _adminService.DeleteComment(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteExercise(int id)
        {
            var exercise = _adminService.GetExercise(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            _adminService.DeleteExercise(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditPost(Post post)
        {

            _adminService.EditPost(post);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditComment(Comment comment)
        {

            _adminService.EditComment(comment);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EditExercise(Exercise exercise)
        {

            _adminService.EditExercise(exercise);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddPost(Post post)
        {
            _adminService.AddPost(post);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult AddComment(Comment comment)
        {
            _adminService.AddComment(comment);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddExercise(Exercise exercise)
        {
            _adminService.AddExercise(exercise);

            return RedirectToAction("Index");
        }

        public ActionResult MassEmail()
        {

            return PartialView(@"~/Views/Admin/MassEmail.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MassEmail(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email od: {0} ({1})</p><p>Wiadomość:</p><p>{2}</p>";
                var message = new MailMessage();
                foreach (var item in _emailService.GetUsersEmails())
                {
                    message.To.Add(new MailAddress(item.Email));
                }
                //replace with valid value
                message.Subject = "Newsletter";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                if (model.Upload != null && model.Upload.ContentLength > 0)
                {
                    message.Attachments.Add(new Attachment(model.Upload.InputStream, Path.GetFileName(model.Upload.FileName)));
                }
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }

    }
}