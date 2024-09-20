namespace A2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class UpdateGameWithGameType : DbMigration
    {
        public override void Up()
        {
            // Remove dependencies and the Reviews table
            DropForeignKey("dbo.Reviews", "GameId", "dbo.Games");
            DropIndex("dbo.Reviews", new[] { "GameId" });
            DropTable("dbo.Reviews");

            // Create the GameTypes table
            CreateTable(
                "dbo.GameTypes",
                c => new
                {
                    GameTypeId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.GameTypeId);

            // Insert a default GameType 'ARPG'
            Sql("INSERT INTO dbo.GameTypes (Name) VALUES ('ARPG')");

            // Add the GameTypeId column with default value
            AddColumn("dbo.Games", "GameTypeId", c => c.Int(nullable: false, defaultValue: 1));
            CreateIndex("dbo.Games", "GameTypeId");
            AddForeignKey("dbo.Games", "GameTypeId", "dbo.GameTypes", "GameTypeId", cascadeDelete: true);
        }

        public override void Down()
        {
            // Recreate the Reviews table
            CreateTable(
                "dbo.Reviews",
                c => new
                {
                    ReviewId = c.Int(nullable: false, identity: true),
                    Content = c.String(nullable: false, maxLength: 500),
                    Rating = c.Int(nullable: false),
                    GameId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ReviewId);

            // Restore dependencies for the Reviews table
            CreateIndex("dbo.Reviews", "GameId");
            AddForeignKey("dbo.Reviews", "GameId", "dbo.Games", "Id", cascadeDelete: true);

            // Remove the GameType-related changes
            DropForeignKey("dbo.Games", "GameTypeId", "dbo.GameTypes");
            DropIndex("dbo.Games", new[] { "GameTypeId" });
            DropColumn("dbo.Games", "GameTypeId");
            DropTable("dbo.GameTypes");
        }
    }
}
