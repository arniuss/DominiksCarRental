using System.ComponentModel.DataAnnotations;

namespace DominiksCarRental.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Name { get; set; }
        public string CarName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Message { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
