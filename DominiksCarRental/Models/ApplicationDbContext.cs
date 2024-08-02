using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DominiksCarRental.Models
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<ContactFormModel> ContactForms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Car>()
				.HasOne(c => c.CarType)
				.WithMany(ct => ct.Cars)
				.HasForeignKey(c => c.CarTypeID)
				.OnDelete(DeleteBehavior.Cascade);

			base.OnModelCreating(modelBuilder);
		}

        internal Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
