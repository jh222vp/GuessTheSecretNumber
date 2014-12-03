using GuessTheSecretNumber.Models;
using GuessTheSecretNumber.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuessTheSecretNumber.Controllers
{
    public class SecretNumberController : Controller
    {
        protected SecretNumber SessionGuess
        {
            get
            {
                return Session["SessionGuess"] as SecretNumber ?? (SecretNumber)(Session["SessionGuess"] = new SecretNumber());
            }
        }

        // GET: /SecretNumber/
        public ActionResult Index()
        {
            SessionGuess.Initialize();
            var model = new HomeIndexViewModel() { SecretNumber = SessionGuess };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeIndexViewModel model)
        {
            if (Session.IsNewSession)
            {
                model = new HomeIndexViewModel()
                {
                    SecretNumber = SessionGuess
                };
                ModelState.AddModelError(String.Empty, "Din session har tyvärr gått ut, startar ett nytt spel");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        SessionGuess.MakeGuess(model.Guess.Value);
                        model.SecretNumber = SessionGuess;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(String.Empty, ex.Message);
                    }
                }
            }
            return View(model);
        }
    }
}