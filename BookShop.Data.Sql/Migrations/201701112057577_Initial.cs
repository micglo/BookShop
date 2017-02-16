namespace BookShop.Data.Sql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorReview",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ReviewRate = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Author", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        LastNameForDisplay = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        TitleForDisplay = c.String(nullable: false, maxLength: 100),
                        PublishingId = c.Int(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        ISBN = c.String(nullable: false, maxLength: 13),
                        PageSize = c.Int(),
                        BookSize = c.String(maxLength: 20),
                        Image = c.String(),
                        Bestseller = c.Boolean(),
                        Language = c.Int(nullable: false),
                        Cover = c.Int(),
                        Description = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publishing", t => t.PublishingId, cascadeDelete: true)
                .Index(t => t.PublishingId);
            
            CreateTable(
                "dbo.BookCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        NameForDisplay = c.String(nullable: false, maxLength: 100),
                        SubMainCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubMainCategory", t => t.SubMainCategoryId, cascadeDelete: true)
                .Index(t => t.SubMainCategoryId);
            
            CreateTable(
                "dbo.SubMainCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        NameForDisplay = c.String(nullable: false, maxLength: 100),
                        MainCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainCategory", t => t.MainCategoryId, cascadeDelete: true)
                .Index(t => t.MainCategoryId);
            
            CreateTable(
                "dbo.MainCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        NameForDisplay = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookReview",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ReviewRate = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Street = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        PostCode = c.String(maxLength: 6),
                        IsCompany = c.Boolean(nullable: false),
                        CompanyName = c.String(maxLength: 50),
                        Regon = c.String(maxLength: 9),
                        Nip = c.String(maxLength: 10),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(maxLength: 11),
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
            
            CreateTable(
                "dbo.PublishingReview",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ReviewRate = c.Int(nullable: false),
                        PublishingId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publishing", t => t.PublishingId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PublishingId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Publishing",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        NameForDisplay = c.String(nullable: false, maxLength: 100),
                        Image = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionStatus = c.Int(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.String(nullable: false, maxLength: 128),
                        PaymentId = c.Int(nullable: false),
                        DeliveryId = c.Int(nullable: false),
                        DeliveryAddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Delivery", t => t.DeliveryId, cascadeDelete: true)
                .ForeignKey("dbo.Payment", t => t.PaymentId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PaymentId)
                .Index(t => t.DeliveryId);
            
            CreateTable(
                "dbo.Delivery",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeliveryType = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryAddress",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Street = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        PostCode = c.String(nullable: false, maxLength: 6),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Transaction", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransactionBookQuantity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        BookPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        TransactionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Transaction", t => t.TransactionId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.TransactionId);
            
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
                "dbo.BookBookCategory",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        BookCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.BookCategoryId })
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.BookCategory", t => t.BookCategoryId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.BookCategoryId);
            
            CreateTable(
                "dbo.BookSubMainCategory",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        SubMainCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.SubMainCategoryId })
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.SubMainCategory", t => t.SubMainCategoryId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.SubMainCategoryId);
            
            CreateTable(
                "dbo.AuthorBook",
                c => new
                    {
                        AuthorId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AuthorId, t.BookId })
                .ForeignKey("dbo.Author", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AuthorReview", "AuthorId", "dbo.Author");
            DropForeignKey("dbo.AuthorBook", "BookId", "dbo.Book");
            DropForeignKey("dbo.AuthorBook", "AuthorId", "dbo.Author");
            DropForeignKey("dbo.BookSubMainCategory", "SubMainCategoryId", "dbo.SubMainCategory");
            DropForeignKey("dbo.BookSubMainCategory", "BookId", "dbo.Book");
            DropForeignKey("dbo.Book", "PublishingId", "dbo.Publishing");
            DropForeignKey("dbo.Transaction", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TransactionBookQuantity", "TransactionId", "dbo.Transaction");
            DropForeignKey("dbo.TransactionBookQuantity", "BookId", "dbo.Book");
            DropForeignKey("dbo.Transaction", "PaymentId", "dbo.Payment");
            DropForeignKey("dbo.DeliveryAddress", "Id", "dbo.Transaction");
            DropForeignKey("dbo.Transaction", "DeliveryId", "dbo.Delivery");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PublishingReview", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PublishingReview", "PublishingId", "dbo.Publishing");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BookReview", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AuthorReview", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BookReview", "BookId", "dbo.Book");
            DropForeignKey("dbo.BookBookCategory", "BookCategoryId", "dbo.BookCategory");
            DropForeignKey("dbo.BookBookCategory", "BookId", "dbo.Book");
            DropForeignKey("dbo.BookCategory", "SubMainCategoryId", "dbo.SubMainCategory");
            DropForeignKey("dbo.SubMainCategory", "MainCategoryId", "dbo.MainCategory");
            DropIndex("dbo.AuthorBook", new[] { "BookId" });
            DropIndex("dbo.AuthorBook", new[] { "AuthorId" });
            DropIndex("dbo.BookSubMainCategory", new[] { "SubMainCategoryId" });
            DropIndex("dbo.BookSubMainCategory", new[] { "BookId" });
            DropIndex("dbo.BookBookCategory", new[] { "BookCategoryId" });
            DropIndex("dbo.BookBookCategory", new[] { "BookId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.TransactionBookQuantity", new[] { "TransactionId" });
            DropIndex("dbo.TransactionBookQuantity", new[] { "BookId" });
            DropIndex("dbo.DeliveryAddress", new[] { "Id" });
            DropIndex("dbo.Transaction", new[] { "DeliveryId" });
            DropIndex("dbo.Transaction", new[] { "PaymentId" });
            DropIndex("dbo.Transaction", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.PublishingReview", new[] { "UserId" });
            DropIndex("dbo.PublishingReview", new[] { "PublishingId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.BookReview", new[] { "UserId" });
            DropIndex("dbo.BookReview", new[] { "BookId" });
            DropIndex("dbo.SubMainCategory", new[] { "MainCategoryId" });
            DropIndex("dbo.BookCategory", new[] { "SubMainCategoryId" });
            DropIndex("dbo.Book", new[] { "PublishingId" });
            DropIndex("dbo.AuthorReview", new[] { "UserId" });
            DropIndex("dbo.AuthorReview", new[] { "AuthorId" });
            DropTable("dbo.AuthorBook");
            DropTable("dbo.BookSubMainCategory");
            DropTable("dbo.BookBookCategory");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TransactionBookQuantity");
            DropTable("dbo.Payment");
            DropTable("dbo.DeliveryAddress");
            DropTable("dbo.Delivery");
            DropTable("dbo.Transaction");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Publishing");
            DropTable("dbo.PublishingReview");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.BookReview");
            DropTable("dbo.MainCategory");
            DropTable("dbo.SubMainCategory");
            DropTable("dbo.BookCategory");
            DropTable("dbo.Book");
            DropTable("dbo.Author");
            DropTable("dbo.AuthorReview");
        }
    }
}
