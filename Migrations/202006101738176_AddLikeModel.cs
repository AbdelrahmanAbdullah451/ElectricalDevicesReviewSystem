namespace ReviewArena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LikeAddedAt = c.DateTime(nullable: false),
                        ReviewId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Reviews", t => t.ReviewId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ReviewId);
            
            AddColumn("dbo.Reviews", "LikesNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "ReviewId", "dbo.Reviews");
            DropIndex("dbo.Likes", new[] { "ReviewId" });
            DropIndex("dbo.Likes", new[] { "UserId" });
            DropColumn("dbo.Reviews", "LikesNumber");
            DropTable("dbo.Likes");
        }
    }
}
