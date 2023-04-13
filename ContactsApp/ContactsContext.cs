using ContactsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options)
            : base (options)
            {
            }
        DbSet<Contact> Contacts { get; set; }
        
    }
}
