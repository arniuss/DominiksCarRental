using DominiksCarRental.Models;
using DominiksCarRental.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DominiksCarRental.Controllers
{
    [Authorize(Roles = "Admin, Owner, Customer Service Representative")]
    public class ContactFormsController : Controller
    {
        private ContactFormsService _contactFormsService;

        public ContactFormsController(ContactFormsService contactFormsService)
        {
            _contactFormsService = contactFormsService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ContactFormModel> forms = await _contactFormsService.GetAllForms();
            return View(forms);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var contactFormToDelete = await _contactFormsService.GetByIdAsync(id);
            if (contactFormToDelete == null)
            {
                return View("NotFound");
            }
            await _contactFormsService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
