using DominiksCarRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DominiksCarRental.Services
{
    public class ContactFormsService
    {
        private ApplicationDbContext _applicationDbContext;

        public ContactFormsService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        internal async Task<IEnumerable<ContactFormModel>> GetAllForms()
        {
            var allForms = await _applicationDbContext.ContactForms.ToListAsync();
            return allForms;
        }
        internal async Task<ContactFormModel> GetByIdAsync(int id)
        {
            var contactForm = await _applicationDbContext.ContactForms.FirstOrDefaultAsync(x => x.Id == id);
            if (contactForm != null)
            {
                return contactForm;
            }
            else
            {
                return null;
            }
        }
        public async Task DeleteAsync(int id)
        {
            var contactFormToDelete = await _applicationDbContext.ContactForms.FirstOrDefaultAsync(cf => cf.Id == id);
            _applicationDbContext.ContactForms.Remove(contactFormToDelete);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
