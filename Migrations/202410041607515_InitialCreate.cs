namespace A2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Rating = c.Single(nullable: false),
                        Description = c.String(),
                        PosterPath = c.String(nullable: false),
                        Developer = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        GameTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameTypes", t => t.GameTypeId, cascadeDelete: true)
                .Index(t => t.GameTypeId);
            
            CreateTable(
                "dbo.GameTypes",
                c => new
                    {
                        GameTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GameTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "GameTypeId", "dbo.GameTypes");
            DropIndex("dbo.Games", new[] { "GameTypeId" });
            DropTable("dbo.GameTypes");
            DropTable("dbo.Games");
        }
    }
}
