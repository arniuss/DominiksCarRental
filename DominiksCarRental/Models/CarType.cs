using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DominiksCarRental.Models
{
	public class CarType
	{
		[Key]
		public int ID { get; set; }
		public string Name { get; set; }
		public ICollection<Car>? Cars { get; set; }
	}
}
