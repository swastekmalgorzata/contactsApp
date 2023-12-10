using System.ComponentModel.DataAnnotations;

namespace ContactsApp
{
    public class RegistrationRequest
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;

    }
}
