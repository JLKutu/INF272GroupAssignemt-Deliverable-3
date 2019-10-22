namespace GroupProjectDonation272.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookDonations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookTitle = c.String(),
                        BookAuthor = c.String(),
                        BookPublisher = c.String(),
                        BookPublicationYear = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Status = c.String(maxLength: 500),
                        BookTypeId = c.Int(nullable: false),
                        CenterId = c.Int(nullable: false),
                        SponsorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sponsors", t => t.SponsorId, cascadeDelete: true)
                .ForeignKey("dbo.BookTypes", t => t.BookTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Centers", t => t.CenterId)
                .Index(t => t.BookTypeId)
                .Index(t => t.CenterId)
                .Index(t => t.SponsorId);
            
            CreateTable(
                "dbo.BookTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Edition = c.Int(nullable: false),
                        Publisher = c.String(),
                        Year = c.Int(nullable: false),
                        BookTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookTypes", t => t.BookTypeId, cascadeDelete: true)
                .Index(t => t.BookTypeId);
            
            CreateTable(
                "dbo.OfferDonationDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Quantity = c.Int(nullable: false),
                        StationaryId = c.Int(),
                        BookId = c.Int(),
                        OfferDonationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId)
                .ForeignKey("dbo.Stationaries", t => t.StationaryId)
                .ForeignKey("dbo.OfferDonations", t => t.OfferDonationId, cascadeDelete: true)
                .Index(t => t.StationaryId)
                .Index(t => t.BookId)
                .Index(t => t.OfferDonationId);
            
            CreateTable(
                "dbo.OfferDonations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        OfferDonationReference = c.String(),
                        DonationDate = c.DateTime(nullable: false),
                        CenterId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        DoneeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Donees", t => t.DoneeId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Centers", t => t.CenterId)
                .Index(t => t.CenterId)
                .Index(t => t.EmployeeId)
                .Index(t => t.DoneeId);
            
            CreateTable(
                "dbo.Centers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        ContactNo = c.String(),
                        Address = c.String(nullable: false, maxLength: 1000),
                        CenterTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CenterTypes", t => t.CenterTypeId, cascadeDelete: true)
                .Index(t => t.CenterTypeId);
            
            CreateTable(
                "dbo.CenterTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(nullable: false),
                        Code = c.String(),
                        ContactNo = c.String(nullable: false),
                        Address = c.String(maxLength: 1000),
                        CenterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Centers", t => t.CenterId, cascadeDelete: true)
                .Index(t => t.CenterId);
            
            CreateTable(
                "dbo.OfferBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonationDate = c.DateTime(nullable: false),
                        CenterId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        BookDonationId = c.Int(nullable: false),
                        DoneeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookDonations", t => t.BookDonationId, cascadeDelete: true)
                .ForeignKey("dbo.Centers", t => t.CenterId)
                .ForeignKey("dbo.Donees", t => t.DoneeId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.CenterId)
                .Index(t => t.EmployeeId)
                .Index(t => t.BookDonationId)
                .Index(t => t.DoneeId);
            
            CreateTable(
                "dbo.Donees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OfferStationaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonationDate = c.DateTime(nullable: false),
                        CenterId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        StationaryDonationId = c.Int(nullable: false),
                        DoneeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Centers", t => t.CenterId)
                .ForeignKey("dbo.Donees", t => t.DoneeId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.StationaryDonations", t => t.StationaryDonationId, cascadeDelete: true)
                .Index(t => t.CenterId)
                .Index(t => t.EmployeeId)
                .Index(t => t.StationaryDonationId)
                .Index(t => t.DoneeId);
            
            CreateTable(
                "dbo.StationaryDonations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(maxLength: 1000),
                        Status = c.String(maxLength: 500),
                        StationaryTypeId = c.Int(nullable: false),
                        CenterId = c.Int(nullable: false),
                        SponsorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Centers", t => t.CenterId)
                .ForeignKey("dbo.Sponsors", t => t.SponsorId, cascadeDelete: true)
                .ForeignKey("dbo.StationaryTypes", t => t.StationaryTypeId, cascadeDelete: true)
                .Index(t => t.StationaryTypeId)
                .Index(t => t.CenterId)
                .Index(t => t.SponsorId);
            
            CreateTable(
                "dbo.Sponsors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(maxLength: 1000),
                        SponsorTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SponsorTypes", t => t.SponsorTypeId, cascadeDelete: true)
                .Index(t => t.SponsorTypeId);
            
            CreateTable(
                "dbo.ReceiveDonations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        ReceiveDonationReference = c.String(),
                        DonationDate = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        CenterId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        SponsorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Centers", t => t.CenterId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Sponsors", t => t.SponsorId, cascadeDelete: true)
                .Index(t => t.CenterId)
                .Index(t => t.EmployeeId)
                .Index(t => t.SponsorId);
            
            CreateTable(
                "dbo.ReceiveDonationDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Quantity = c.Int(nullable: false),
                        StationaryId = c.Int(),
                        BookId = c.Int(),
                        ReceiveDonationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId)
                .ForeignKey("dbo.ReceiveDonations", t => t.ReceiveDonationId, cascadeDelete: true)
                .ForeignKey("dbo.Stationaries", t => t.StationaryId)
                .Index(t => t.StationaryId)
                .Index(t => t.BookId)
                .Index(t => t.ReceiveDonationId);
            
            CreateTable(
                "dbo.Stationaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StationaryTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StationaryTypes", t => t.StationaryTypeId, cascadeDelete: true)
                .Index(t => t.StationaryTypeId);
            
            CreateTable(
                "dbo.StationaryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SponsorTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.BookDonations", "CenterId", "dbo.Centers");
            DropForeignKey("dbo.BookDonations", "BookTypeId", "dbo.BookTypes");
            DropForeignKey("dbo.OfferDonationDetails", "OfferDonationId", "dbo.OfferDonations");
            DropForeignKey("dbo.OfferDonations", "CenterId", "dbo.Centers");
            DropForeignKey("dbo.OfferDonations", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.OfferBooks", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.OfferStationaries", "StationaryDonationId", "dbo.StationaryDonations");
            DropForeignKey("dbo.StationaryDonations", "StationaryTypeId", "dbo.StationaryTypes");
            DropForeignKey("dbo.StationaryDonations", "SponsorId", "dbo.Sponsors");
            DropForeignKey("dbo.Sponsors", "SponsorTypeId", "dbo.SponsorTypes");
            DropForeignKey("dbo.ReceiveDonations", "SponsorId", "dbo.Sponsors");
            DropForeignKey("dbo.Stationaries", "StationaryTypeId", "dbo.StationaryTypes");
            DropForeignKey("dbo.ReceiveDonationDetails", "StationaryId", "dbo.Stationaries");
            DropForeignKey("dbo.OfferDonationDetails", "StationaryId", "dbo.Stationaries");
            DropForeignKey("dbo.ReceiveDonationDetails", "ReceiveDonationId", "dbo.ReceiveDonations");
            DropForeignKey("dbo.ReceiveDonationDetails", "BookId", "dbo.Books");
            DropForeignKey("dbo.ReceiveDonations", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ReceiveDonations", "CenterId", "dbo.Centers");
            DropForeignKey("dbo.BookDonations", "SponsorId", "dbo.Sponsors");
            DropForeignKey("dbo.StationaryDonations", "CenterId", "dbo.Centers");
            DropForeignKey("dbo.OfferStationaries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.OfferStationaries", "DoneeId", "dbo.Donees");
            DropForeignKey("dbo.OfferStationaries", "CenterId", "dbo.Centers");
            DropForeignKey("dbo.OfferDonations", "DoneeId", "dbo.Donees");
            DropForeignKey("dbo.OfferBooks", "DoneeId", "dbo.Donees");
            DropForeignKey("dbo.OfferBooks", "CenterId", "dbo.Centers");
            DropForeignKey("dbo.OfferBooks", "BookDonationId", "dbo.BookDonations");
            DropForeignKey("dbo.Employees", "CenterId", "dbo.Centers");
            DropForeignKey("dbo.Centers", "CenterTypeId", "dbo.CenterTypes");
            DropForeignKey("dbo.OfferDonationDetails", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "BookTypeId", "dbo.BookTypes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Stationaries", new[] { "StationaryTypeId" });
            DropIndex("dbo.ReceiveDonationDetails", new[] { "ReceiveDonationId" });
            DropIndex("dbo.ReceiveDonationDetails", new[] { "BookId" });
            DropIndex("dbo.ReceiveDonationDetails", new[] { "StationaryId" });
            DropIndex("dbo.ReceiveDonations", new[] { "SponsorId" });
            DropIndex("dbo.ReceiveDonations", new[] { "EmployeeId" });
            DropIndex("dbo.ReceiveDonations", new[] { "CenterId" });
            DropIndex("dbo.Sponsors", new[] { "SponsorTypeId" });
            DropIndex("dbo.StationaryDonations", new[] { "SponsorId" });
            DropIndex("dbo.StationaryDonations", new[] { "CenterId" });
            DropIndex("dbo.StationaryDonations", new[] { "StationaryTypeId" });
            DropIndex("dbo.OfferStationaries", new[] { "DoneeId" });
            DropIndex("dbo.OfferStationaries", new[] { "StationaryDonationId" });
            DropIndex("dbo.OfferStationaries", new[] { "EmployeeId" });
            DropIndex("dbo.OfferStationaries", new[] { "CenterId" });
            DropIndex("dbo.OfferBooks", new[] { "DoneeId" });
            DropIndex("dbo.OfferBooks", new[] { "BookDonationId" });
            DropIndex("dbo.OfferBooks", new[] { "EmployeeId" });
            DropIndex("dbo.OfferBooks", new[] { "CenterId" });
            DropIndex("dbo.Employees", new[] { "CenterId" });
            DropIndex("dbo.Centers", new[] { "CenterTypeId" });
            DropIndex("dbo.OfferDonations", new[] { "DoneeId" });
            DropIndex("dbo.OfferDonations", new[] { "EmployeeId" });
            DropIndex("dbo.OfferDonations", new[] { "CenterId" });
            DropIndex("dbo.OfferDonationDetails", new[] { "OfferDonationId" });
            DropIndex("dbo.OfferDonationDetails", new[] { "BookId" });
            DropIndex("dbo.OfferDonationDetails", new[] { "StationaryId" });
            DropIndex("dbo.Books", new[] { "BookTypeId" });
            DropIndex("dbo.BookDonations", new[] { "SponsorId" });
            DropIndex("dbo.BookDonations", new[] { "CenterId" });
            DropIndex("dbo.BookDonations", new[] { "BookTypeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SponsorTypes");
            DropTable("dbo.StationaryTypes");
            DropTable("dbo.Stationaries");
            DropTable("dbo.ReceiveDonationDetails");
            DropTable("dbo.ReceiveDonations");
            DropTable("dbo.Sponsors");
            DropTable("dbo.StationaryDonations");
            DropTable("dbo.OfferStationaries");
            DropTable("dbo.Donees");
            DropTable("dbo.OfferBooks");
            DropTable("dbo.Employees");
            DropTable("dbo.CenterTypes");
            DropTable("dbo.Centers");
            DropTable("dbo.OfferDonations");
            DropTable("dbo.OfferDonationDetails");
            DropTable("dbo.Books");
            DropTable("dbo.BookTypes");
            DropTable("dbo.BookDonations");
        }
    }
}
