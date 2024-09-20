namespace A2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPosterPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "PosterPath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "PosterPath");
        }
    }
}
