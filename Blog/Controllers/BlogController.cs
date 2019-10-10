using DL.Constants;
using DL.Models;
using DL.Services;
using DL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        private EmailService _email;
        private BlogService _blog;
        public BlogController()
        {
            _email = new EmailService();
            _blog = new BlogService();
        }
        public ActionResult Index()
        {
            ViewBag.Posts = _blog.GetMostNewestPosts();
            return View();
        }
        public ActionResult Contact()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Wiadomość:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("test.test.v.54@gmail.com")); //replace with valid value
                message.Subject = "Pytanie do supportu";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
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
        public ActionResult Map()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Negative()
        {
            List<Difficulty> myDifficulty = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();
            ViewBag.Ilosc = TempData["Ilosc"];
            var bmi = ViewBag.Ilosc;
            ViewBag.IloscDip = Math.Round(ViewBag.Ilosc.Dips * 0.6);
            ViewBag.IloscPomp = Math.Round(ViewBag.Ilosc.PushUps * 0.6);
            ViewBag.IloscPod = Math.Round(ViewBag.Ilosc.PullUps * 0.6);
            ViewBag.IloscBrzuch = Math.Round(ViewBag.Ilosc.Abs * 0.6);
            var BMI = ((bmi.Weight) / Math.Pow(bmi.Heigth, 2));
            BMI = BMI * 10000;
            BMI = Math.Round(BMI, 2);
            ViewBag.BMI = "Twoje BMI wynosi " + BMI; ;
            if (BMI < 18.5)
                ViewBag.Waga = " i masz niedowagę";
            else if (BMI >= 18.5 && BMI < 25)
                ViewBag.Waga = " i Twoja waga jest prawidłowa";
            else if (BMI >= 25 && BMI < 30)
                ViewBag.Waga = " i masz nadwagę";
            else if (BMI >= 30)
                ViewBag.Waga = " i masz otyłość";
            ViewBag.Difficulties = new SelectList(myDifficulty);
            var exercises = _blog.GetNegExercises();
            return View(exercises);
        }
        [HttpGet]
        public ActionResult Beginner()
        {
            List<Difficulty> myDifficulty = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();
            ViewBag.Ilosc = TempData["Ilosc"];
            var bmi = ViewBag.Ilosc;
            ViewBag.IloscDip = Math.Round(ViewBag.Ilosc.Dips*0.6);
            ViewBag.IloscPomp = Math.Round(ViewBag.Ilosc.PushUps * 0.6);
            ViewBag.IloscPod = Math.Round(ViewBag.Ilosc.PullUps * 0.6);
            ViewBag.IloscBrzuch = Math.Round(ViewBag.Ilosc.Abs * 0.6);
            var BMI = ((bmi.Weight) / Math.Pow(bmi.Heigth, 2));
            BMI = BMI * 10000;
            BMI = Math.Round(BMI, 2);
            ViewBag.BMI = "Twoje BMI wynosi " + BMI;
            if (BMI < 18.5)
                ViewBag.Waga = " i masz niedowagę";
            else if (BMI >= 18.5 && BMI < 25)
                ViewBag.Waga = " i Twoja waga jest prawidłowa";
            else if (BMI >= 25 && BMI < 30)
                ViewBag.Waga = " i masz nadwagę";
            else if (BMI >= 30)
                ViewBag.Waga = " i masz otyłość";
            ViewBag.Difficulties = new SelectList(myDifficulty);
            var exercises = _blog.GetBegExercises();
            return View(exercises);
        }
        [HttpGet]
        public ActionResult Intermediate()
        {
            List<Difficulty> myDifficulty = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();
            ViewBag.Ilosc = TempData["Ilosc"];
            var bmi = ViewBag.Ilosc;
            ViewBag.IloscDip = Math.Round(ViewBag.Ilosc.Dips * 0.6);
            ViewBag.IloscPomp = Math.Round(ViewBag.Ilosc.PushUps * 0.6);
            ViewBag.IloscPod = Math.Round(ViewBag.Ilosc.PullUps * 0.6);
            ViewBag.IloscBrzuch = Math.Round(ViewBag.Ilosc.Abs * 0.6);
            var BMI = ((bmi.Weight) / Math.Pow(bmi.Heigth, 2));
            BMI = BMI * 10000;
            BMI = Math.Round(BMI, 2);
            ViewBag.BMI = "Twoje BMI wynosi " + BMI;
            if (BMI < 18.5)
                ViewBag.Waga = " i masz niedowagę";
            else if (BMI >= 18.5 && BMI < 25)
                ViewBag.Waga = " i Twoja waga jest prawidłowa";
            else if (BMI >= 25 && BMI < 30)
                ViewBag.Waga = " i masz nadwagę";
            else if (BMI >= 30)
                ViewBag.Waga = " i masz otyłość";
            ViewBag.Difficulties = new SelectList(myDifficulty);
            var exercises = _blog.GetIntExercises();
            return View(exercises);
        }
        [HttpGet]
        public ActionResult Advanced()
        {
            List<Difficulty> myDifficulty = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();
            ViewBag.Ilosc = TempData["Ilosc"];
            var bmi = ViewBag.Ilosc;
            ViewBag.IloscDip = Math.Round(ViewBag.Ilosc.Dips * 0.6);
            ViewBag.IloscPomp = Math.Round(ViewBag.Ilosc.PushUps * 0.6);
            ViewBag.IloscPod = Math.Round(ViewBag.Ilosc.PullUps * 0.6);
            ViewBag.IloscBrzuch = Math.Round(ViewBag.Ilosc.Abs * 0.6);
            var BMI = ((bmi.Weight) / Math.Pow(bmi.Heigth, 2));
            BMI = BMI * 10000;
            BMI = Math.Round(BMI, 2);
            ViewBag.BMI = "Twoje BMI wynosi " + BMI;
            if (BMI < 18.5)
                ViewBag.Waga = " i masz niedowagę";
            else if (BMI >= 18.5 && BMI < 25)
                ViewBag.Waga = " i Twoja waga jest prawidłowa";
            else if (BMI >= 25 && BMI < 30)
                ViewBag.Waga = " i masz nadwagę";
            else if (BMI >= 30)
                ViewBag.Waga = " i masz otyłość";
            ViewBag.Difficulties = new SelectList(myDifficulty);
            var exercises = _blog.GetAdvExercises();
            return View(exercises);
        }

        public ActionResult ChooseTraining()
        {
            return View(new BMI());
        }
        [HttpPost]
        public ActionResult ChooseTraining(BMI bmi)
        {
            TempData["Ilosc"] = bmi;

            if (bmi.PushUps < 10 || bmi.PullUps < 5 || bmi.Dips < 10 || bmi.Abs < 10)
                return RedirectToAction("Negative");
            else if (bmi.PushUps >= 10 && bmi.PushUps < 20 || bmi.PullUps >= 5 && bmi.PullUps < 10 || bmi.Dips >= 10 && bmi.Dips < 20 || bmi.Abs < 10 && bmi.Abs < 20)
                return RedirectToAction("Beginner");
            else if (bmi.PushUps >= 20 && bmi.PushUps < 40 || bmi.PullUps >= 10 && bmi.PullUps < 20 || bmi.Dips >= 20 && bmi.Dips < 40 || bmi.Abs < 20 && bmi.Abs < 40)
                return RedirectToAction("Intermediate");
            else if (bmi.PushUps >= 40 || bmi.PullUps >= 20 || bmi.Dips >= 40 || bmi.Abs >= 40)
                return RedirectToAction("Advanced");
            return View();

        }

        public ActionResult Exercises(string difficulty,string searchString)
        {


            List<Difficulty> myDifficulty = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToList();
            ViewBag.Difficulties = new SelectList(myDifficulty);
            var exercises = _blog.GetExercises(difficulty, searchString);

            return View(exercises);
        }

        [Route("{id}")]
        public ActionResult Komentarze(int id)
        {
            ViewBag.Post = _blog.GetPostById(id);
            ViewBag.Comments = _blog.GetPostComments(id);

            return View();
        }
        [Authorize]
        [Route("{id}")]
        public ActionResult AddComment()
        {
            return View();
        }
        [Route("{id}")]
        [HttpPost]
        public ActionResult AddComment(Comment comment,int id)
        {
            var userId = User.Identity.GetUserId();
            var user = _blog.GetUserData(userId);
            int userIntId = user.Id;
            _blog.AddComment(comment,id,userIntId);

            return RedirectToAction("Komentarze/"+id);
        }
        [Route("{id}")]
        public ActionResult EditComment(int? id)
        {
            var comment = _blog.GetComment(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }
            comment.Date = DateTime.Now;
            return View(comment);
        }
        [HttpPost]
        public ActionResult EditComment(Comment comment)
        {

            _blog.EditComment(comment);
            return RedirectToAction("Komentarze/"+comment.PostId);
        }
    }
}