using DominiksCarRental.Models;
using DominiksCarRental.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DominiksCarRental.Controllers
{    
    public class ContactController : Controller
    {
        private ContactService _contactService;
        private UserManager<AppUser> _userManager;

        public ContactController(ContactService contactService, UserManager<AppUser> userManager)
        {
            _contactService = contactService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ContactFormModel();
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                model.Name = user.UserName;
                model.Email = user.Email;
                model.Phone = user.PhoneNumber;
            }
            return View(model);
        }
        public IActionResult ContactConfirmation()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactFormModel contactForm)
        {
            if (ModelState.IsValid)
            {
                await _contactService.AddContactFormAsync(contactForm);
                return RedirectToAction("Index");
            }

            return View(contactForm);
        }


    }
}
