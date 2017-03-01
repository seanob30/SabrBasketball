namespace Sabr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPositionsForeignKeyForPlayersToPositions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerPositions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Players", "FootHeight", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "InchHeight", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "PlayerPositionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Players", "PlayerPositionId");
            AddForeignKey("dbo.Players", "PlayerPositionId", "dbo.PlayerPositions", "Id", cascadeDelete: true);
            DropColumn("dbo.Players", "Height");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "Height", c => c.Int(nullable: false));
            DropForeignKey("dbo.Players", "PlayerPositionId", "dbo.PlayerPositions");
            DropIndex("dbo.Players", new[] { "PlayerPositionId" });
            DropColumn("dbo.Players", "PlayerPositionId");
            DropColumn("dbo.Players", "InchHeight");
            DropColumn("dbo.Players", "FootHeight");
            DropTable("dbo.PlayerPositions");
        }
    }
}
