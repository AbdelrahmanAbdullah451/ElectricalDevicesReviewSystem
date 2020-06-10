namespace ReviewArena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAdmin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Reviews", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Reviews", name: "CategoryId", newName: "Category_CategoryId");
            AlterColumn("dbo.Reviews", "Category_CategoryId", c => c.Int());
            CreateIndex("dbo.Reviews", "Category_CategoryId");
            AddForeignKey("dbo.Reviews", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Reviews", new[] { "Category_CategoryId" });
            AlterColumn("dbo.Reviews", "Category_CategoryId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Reviews", name: "Category_CategoryId", newName: "CategoryId");
            CreateIndex("dbo.Reviews", "CategoryId");
            AddForeignKey("dbo.Reviews", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
    }
}
