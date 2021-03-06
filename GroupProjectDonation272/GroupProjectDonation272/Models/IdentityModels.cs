﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using GroupProjectDonation272.Models.Core;
using GroupProjectDonation272.Models.Core.Operations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GroupProjectDonation272.Models
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



        public DbSet<BookDonation> BookDonations { get; set; }
        public DbSet<StationaryDonation> StationaryDonations { get; set; }
        public DbSet<OfferBook> OfferBooks { get; set; }
        public DbSet<OfferStationary> OfferStationaries { get; set; }






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

            modelBuilder.Entity<BookDonation>()
                .HasRequired(d => d.Center)
                .WithMany(w => w.BookDonations)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<StationaryDonation>()
                .HasRequired(d => d.Center)
                .WithMany(w => w.StationaryDonations)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<OfferBook>()
                .HasRequired(d => d.Center)
                .WithMany(w => w.OfferBooks)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<OfferStationary>()
                .HasRequired(d => d.Center)
                .WithMany(w => w.OfferStationaries)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}