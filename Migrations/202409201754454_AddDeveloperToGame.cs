namespace A2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeveloperToGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Developer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "Developer");
        }
    }
}
