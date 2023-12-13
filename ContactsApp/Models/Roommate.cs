using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsApp.Models
{
    public class Roommate
    {
        [ForeignKey("AspNetUsers")]
        [Key]
        public Guid UserId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RoommateId { get; set; }
        [ForeignKey("Apartment")]
        public long ApartmentId { get; set; }
    }
}
