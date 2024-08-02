using DominiksCarRental.Models;

namespace DominiksCarRental.Services
{
    public class ContactService
    {
        private ApplicationDbContext _applicationDbContext;

        public ContactService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        internal async Task AddContactFormAsync(ContactFormModel contactForm)
        {
            await _applicationDbContext.ContactForms.AddAsync(contactForm);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
