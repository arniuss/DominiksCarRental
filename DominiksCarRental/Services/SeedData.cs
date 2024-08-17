using DominiksCarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace DominiksCarRental.Services
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT CarTypes ON");

                    if (!context.CarTypes.Any(ct => ct.Name == "Offroad"))
                    {
                        context.CarTypes.Add(new CarType { ID = 9, Name = "Offroad" });
                    }
                    if (!context.CarTypes.Any(ct => ct.Name == "Combi"))
                    {
                        context.CarTypes.Add(new CarType { ID = 5, Name = "Combi" });
                    }
                    if (!context.CarTypes.Any(ct => ct.Name == "Sedan"))
                    {
                        context.CarTypes.Add(new CarType { ID = 6, Name = "Sedan" });
                    }
                    if (!context.CarTypes.Any(ct => ct.Name == "Coupe"))
                    {
                        context.CarTypes.Add(new CarType { ID = 7, Name = "Coupe" });
                    }
                    if (!context.CarTypes.Any(ct => ct.Name == "Hatchback"))
                    {
                        context.CarTypes.Add(new CarType { ID = 8, Name = "Hatchback" });
                    }

                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT CarTypes OFF");

                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Cars ON");

                    if (!context.Cars.Any(c => c.Name == "BMW e46 M3"))
                    {
                        context.Cars.Add(new Car
                        {
                            Id = 2,
                            Name = "BMW e46 M3",
                            NumberOfSeats = 4,
                            Description = "The BMW M3 E46 is powered by a 3.2-liter inline-six naturally aspirated engine, known as the BMW S54B32. This engine produces approximately 333 horsepower at 7,900 rpm and a maximum torque of 355 Nm at 4,900 rpm. The car accelerates from 0 to 100 km/h in about 5 seconds and has an electronically limited top speed of 250 km/h. Its curb weight is around 1,570 kg, ensuring excellent driving dynamics and a thrilling driving experience, characteristic of its sporty tuning.",
                            RentalPrice = 350,
                            CarTypeID = 7,
                            MainImage = "https://lh3.googleusercontent.com/d/1DDLqIhDVPfAww4WYpRq0r4w-Oa4KvQOs?authuser=0"
                        });
                    }
                    if (!context.Cars.Any(c => c.Name == "Fiat Panda"))
                    {
                        context.Cars.Add(new Car
                        {
                            Id = 3,
                            Name = "Fiat Panda",
                            NumberOfSeats = 4,
                            Description = "The Fiat Panda is a compact city car equipped with a 1.2-liter petrol engine. This engine provides sufficient power for urban conditions, with a maximum output of around 69 horsepower (HP). The Panda is renowned for its simplicity, efficiency, and ability to maneuver easily in dense traffic due to its small size and agile handling.",
                            RentalPrice = 125,
                            CarTypeID = 8,
                            MainImage = "https://lh3.googleusercontent.com/d/1I9XZatmbt4Ndbt0igQHmEbnWL0evIL0c?authuser=0"
                        });
                    }   

                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Cars OFF");

                    transaction.Commit();
                }
            }
        }
    }
}
