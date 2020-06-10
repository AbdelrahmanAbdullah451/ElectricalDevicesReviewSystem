namespace ReviewArena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class time : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reviews", "AddedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "AddedAt", c => c.DateTime(nullable: false));
        }
    }
}
