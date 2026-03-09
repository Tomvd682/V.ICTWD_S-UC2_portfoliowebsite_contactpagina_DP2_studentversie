using Microsoft.AspNetCore.Mvc;
using Portfoliowebsite.Models;
using Portfoliowebsite.Services;

namespace Portfoliowebsite.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailSender _email;

        public ContactController(IEmailSender email)
        {
            _email = email;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ContactFormModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ContactFormModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Website))
            {
                ViewBag.DebugMessage = "Honeypot gevuld";
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                var errors = new List<string>();

                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        errors.Add($"{entry.Key}: {error.ErrorMessage}");
                    }
                }

                ViewBag.DebugMessage = "ModelState ongeldig";
                ViewBag.DebugErrors = errors;

                return View(model);
            }

            TempData["ThanksName"] = model.Name;
            TempData["ThanksEmail"] = model.Email;
            TempData["ThanksMessage"] = model.Message;

            return RedirectToAction(nameof(Thanks));
        }

        [HttpGet]
        public IActionResult Thanks()
        {
            return View();
        }
    }
}
