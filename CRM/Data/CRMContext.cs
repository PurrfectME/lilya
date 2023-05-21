using Microsoft.EntityFrameworkCore;
using CRM.Models;

namespace CRM.Data
{
    public class CRMContext : DbContext
    {
        public CRMContext(DbContextOptions<CRMContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}