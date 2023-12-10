using ContactsApp.Modules;

namespace ContactsApp.Requests.ApartmentRequests
{
    public class AddRentRequest
    {
        public double WholeAmount { get; set; }
        public bool CustomBreakdown { get; set; }
        public string Month { get; set; } = null!;
        public string Year { get; set; } = null!;
        public ICollection<RoomatePart>? CustomCostBreakDown { get; set; }
        public double? EvenBreakDown { get; set; }

    }
}
