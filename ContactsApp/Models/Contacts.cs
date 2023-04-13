using System;
using System.Net.Mail;

namespace ContactsApp.Models
{
	public class Contacts
	{
		public int Id { get; set; }

		public string? Name { get; set; }

		public string? Surname { get; set; }

		public MailAddress? Email { get; set; }

		public string? Password { get; set; }

		public Enum? Category { get; set; }

		public string? PhoneNumber { get; set; }

		public DateOnly Birthdat { get; set; }

	}
}

