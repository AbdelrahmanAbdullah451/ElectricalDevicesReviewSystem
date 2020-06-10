namespace ReviewArena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveReviewer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviewers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "Reviewer_Id", "dbo.Reviewers");
            DropForeignKey("dbo.AspNetUserLogins", "Reviewer_Id", "dbo.Reviewers");
            DropForeignKey("dbo.Reviews", "Reviewer_Id", "dbo.Reviewers");
            DropForeignKey("dbo.AspNetUserRoles", "Reviewer_Id", "dbo.Reviewers");
            DropIndex("dbo.Reviews", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Reviews", new[] { "Reviewer_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "Reviewer_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "Reviewer_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "Reviewer_Id" });
            DropIndex("dbo.Reviewers", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            DropColumn("dbo.Reviews", "UserId");
            DropColumn("dbo.Reviews", "ApplicationUser_Id");
            DropColumn("dbo.Reviews", "Reviewer_Id");
            DropColumn("dbo.AspNetUserClaims", "Reviewer_Id");
            DropColumn("dbo.AspNetUserLogins", "Reviewer_Id");
            DropColumn("dbo.AspNetUserRoles", "Reviewer_Id");
            DropTable("dbo.Reviewers");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUserRoles", "Reviewer_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "Reviewer_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "Reviewer_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Reviews", "Reviewer_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Reviews", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Reviews", "UserId", c => c.String());
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            CreateIndex("dbo.Reviewers", "ApplicationUser_Id");
            CreateIndex("dbo.AspNetUserRoles", "Reviewer_Id");
            CreateIndex("dbo.AspNetUserLogins", "Reviewer_Id");
            CreateIndex("dbo.AspNetUserClaims", "Reviewer_Id");
            CreateIndex("dbo.Reviews", "Reviewer_Id");
            CreateIndex("dbo.Reviews", "ApplicationUser_Id");
            AddForeignKey("dbo.AspNetUserRoles", "Reviewer_Id", "dbo.Reviewers", "Id");
            AddForeignKey("dbo.Reviews", "Reviewer_Id", "dbo.Reviewers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "Reviewer_Id", "dbo.Reviewers", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "Reviewer_Id", "dbo.Reviewers", "Id");
            AddForeignKey("dbo.Reviewers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Reviews", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
