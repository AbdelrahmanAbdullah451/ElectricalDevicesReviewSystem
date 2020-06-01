namespace ReviewArena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        ProductNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 150),
                        price = c.Int(nullable: false),
                        ProductImage = c.String(nullable: false),
                        ProductDescription = c.String(nullable: false),
                        category_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.category_id, cascadeDelete: true)
                .Index(t => t.category_id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewTitle = c.String(nullable: false, maxLength: 150),
                        Pros = c.String(nullable: false, maxLength: 150),
                        Cons = c.String(nullable: false, maxLength: 150),
                        ReviewImage = c.String(nullable: false),
                        ReviewDescription = c.String(nullable: false),
                        AddedAt = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UserId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Reviewer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Reviewers", t => t.Reviewer_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Reviewer_Id);
            
            CreateTable(
                "dbo.Reviewers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 150),
                        LastName = c.String(nullable: false, maxLength: 150),
                        ReviewsNumber = c.Int(nullable: false),
                        CoinsNumber = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUserRoles", "Reviewer_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "Reviewer_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "Reviewer_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUserClaims", "Reviewer_Id");
            CreateIndex("dbo.AspNetUserLogins", "Reviewer_Id");
            CreateIndex("dbo.AspNetUserRoles", "Reviewer_Id");
            AddForeignKey("dbo.AspNetUserClaims", "Reviewer_Id", "dbo.Reviewers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "Reviewer_Id", "dbo.Reviewers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "Reviewer_Id", "dbo.Reviewers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "Reviewer_Id", "dbo.Reviewers");
            DropForeignKey("dbo.Reviews", "Reviewer_Id", "dbo.Reviewers");
            DropForeignKey("dbo.AspNetUserLogins", "Reviewer_Id", "dbo.Reviewers");
            DropForeignKey("dbo.AspNetUserClaims", "Reviewer_Id", "dbo.Reviewers");
            DropForeignKey("dbo.Reviewers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Reviews", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Reviews", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "category_id", "dbo.Categories");
            DropIndex("dbo.Reviewers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "Reviewer_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "Reviewer_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "Reviewer_Id" });
            DropIndex("dbo.Reviews", new[] { "Reviewer_Id" });
            DropIndex("dbo.Reviews", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Reviews", new[] { "ProductId" });
            DropIndex("dbo.Reviews", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "category_id" });
            DropColumn("dbo.AspNetUserLogins", "Reviewer_Id");
            DropColumn("dbo.AspNetUserClaims", "Reviewer_Id");
            DropColumn("dbo.AspNetUserRoles", "Reviewer_Id");
            DropTable("dbo.Reviewers");
            DropTable("dbo.Reviews");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
