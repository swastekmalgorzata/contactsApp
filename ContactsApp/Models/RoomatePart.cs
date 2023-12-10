using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsApp.Modules
{
    [Owned]
    public class RoomatePart
    { 
        [ForeignKey("AspNetUsers")]
        public Guid UserId { get; set; }
        public double Share { get; set; }
    }
}
