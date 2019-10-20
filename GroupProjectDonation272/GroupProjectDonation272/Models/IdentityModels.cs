using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SDG_Education.Models.Core;
using SDG_Education.Models.Core.Operations;

namespace SDG_Education.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<StationaryType> StationaryTypes { get; set; }
        public DbSet<Stationary> Stationaries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Donee> Donees { get; set; }
        public DbSet<SponsorType> SponsorTypes { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<CenterType> CenterTypes { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<OfferDonation> OfferDonations { get; set; }
        public DbSet<OfferDonationDetail> OfferDonationDetails { get; set; }
        public DbSet<ReceiveDonation> ReceiveDonations { get; set; }
        public DbSet<ReceiveDonationDetail> ReceiveDonationDetails { get; set; }





        public ApplicationDbContext()
            : base("SDGConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceiveDonation>()
                .HasRequired(d => d.Center)
                .WithMany(w => w.ReceiveDonations)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OfferDonation>()
                .HasRequired(d => d.Center)
                .WithMany(w => w.OfferDonations)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}