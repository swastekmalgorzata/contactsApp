using ContactsApp.Modules;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsApp
{
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RentId { get; set; }
        [ForeignKey("Apartment")]
        public long ApartmentId { get; set; }
        public double WholeAmount { get; set; }
        public bool CustomBreakdown { get; set; }
        public string Month { get; set; } = null!;
        public string Year { get; set; } = null!;
        public double? EvenBreakDown { get; set; }
        public ICollection<RoommatePart>? CustomCostBreakDown { get; set; }
    }
}
