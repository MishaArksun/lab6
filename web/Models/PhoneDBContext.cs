using Microsoft.EntityFrameworkCore;

namespace web.Models
{
    public class PhoneDBContext : DbContext
    {
       public PhoneDBContext() : this(false) { }
        public PhoneDBContext(bool bFromScratch) : base()
        {
            if (bFromScratch)
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        public PhoneDBContext(DbContextOptions<PhoneDBContext> options)
            : base(options)
        {

        }

        // коллекцию объектов, которая сопоставляется с определенной таблицей в базе данных
        public DbSet<Phone> Phs { get; set; } 
        public DbSet<Brand> Avts { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Phsdb;Trusted_connection=TRUE");
            }
        }



    }
}
