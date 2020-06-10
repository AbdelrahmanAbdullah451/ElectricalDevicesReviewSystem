namespace ReviewArena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class time2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "AddedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "AddedAt");
        }
    }
}
