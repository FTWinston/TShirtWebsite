using Microsoft.AspNet.Identity.EntityFramework;

namespace TShirts.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<TShirts.Models.GarmentType> GarmentTypes { get; set; }

        public System.Data.Entity.DbSet<TShirts.Models.Range> Ranges { get; set; }

        public System.Data.Entity.DbSet<TShirts.Models.Color> Colors { get; set; }

        public System.Data.Entity.DbSet<TShirts.Models.Size> Sizes { get; set; }

        public System.Data.Entity.DbSet<TShirts.Models.News> News { get; set; }
    }
}