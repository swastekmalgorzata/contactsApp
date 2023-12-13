using ContactsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp
{

    public class ApartmentsContext : DbContext
    {
        public ApartmentsContext(DbContextOptions<ApartmentsContext> options)
        : base(options) { }

        public DbSet<Apartment> Apartments => Set<Apartment>();
        public DbSet<Rent> Rents => Set<Rent>();
        public DbSet<Roommate> Roommates => Set<Roommate>();
    }
}
