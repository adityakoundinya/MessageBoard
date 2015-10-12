using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Models;
using MessageBoard.Services;

namespace MessageBoard.Controllers {
    public class HomeController : Controller {

        private IMailService _mail;

        public HomeController(IMailService mail) {
            _mail = mail;
        }

        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel model) {
            
            string msg = string.Format("Comment From: {1}{0}Email: {2}{0}Website: {3}{0}Comment: {4}{0}",
                Environment.NewLine, model.Name, model.Email, model.Website, model.Comment);
            if (_mail.SendMail("noreply@yourdomain.com", "foo@yourdomain.com", "Website Contact", msg)) {
                ViewBag.MailSent = true;
            } else {
                ViewBag.MailSent = false;
            }
            return View();
        }

        [Authorize]
        public ActionResult MyMessages() {
            return View();
        }
    }
}