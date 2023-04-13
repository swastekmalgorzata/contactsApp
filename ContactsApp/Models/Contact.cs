using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace ContactsApp.Models
{
	public class Contact
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		[Phone]
		public string? PhoneNumber { get; set; }

		public string? Name { get; set; }

		public string? Surname { get; set; }

		public MailAddress? Email { get; set; }

		public string? Password { get; set; }

		public Category Category { get; set; }

		public DateOnly Birthday { get; set; }

	}

	public enum Category
    {
		Boss,
		Coworker,
		Other
    }
}

