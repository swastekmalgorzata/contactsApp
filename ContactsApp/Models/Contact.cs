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
		[EmailAddress]
		public string? Email { get; set; }

		public string? Password { get; set; }

		public string? Category { get; set; }
		public DateTime Birthday { get; set; }
		public void Update(Contact newContactData)
		{
			PhoneNumber = newContactData.PhoneNumber;
			Name = newContactData.Name;
			Surname = newContactData.Surname;
			Email = newContactData.Email;
			Category = newContactData.Category;
			Birthday = newContactData.Birthday;
		}

	}
}

