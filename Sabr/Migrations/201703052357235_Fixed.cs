namespace Sabr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixed : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.HistoricalPerGameStatLines");
            AddColumn("dbo.HistoricalPerGameStatLines", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.HistoricalPerGameStatLines", "Player", c => c.String());
            AddPrimaryKey("dbo.HistoricalPerGameStatLines", "Id");
        }

        public override void Down()
        {
            DropPrimaryKey("dbo.HistoricalPerGameStatLines");
            AlterColumn("dbo.HistoricalPerGameStatLines", "Player", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.HistoricalPerGameStatLines", "Id");
            AddPrimaryKey("dbo.HistoricalPerGameStatLines", "Player");
        }
    }
}
