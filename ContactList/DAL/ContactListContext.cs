using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ContactList.Models;

namespace ContactList.DAL
{
    public class ContactListContext : DbContext
    {
        public ContactListContext() : base("Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog=ContactListDB; Integrated Security=SSPI;Database=ContactListDB")
        {
            Database.SetInitializer(new ContactListContextSeeder());
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    }
}
