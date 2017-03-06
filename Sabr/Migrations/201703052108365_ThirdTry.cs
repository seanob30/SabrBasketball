namespace Sabr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdTry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistoricalPerGameStatLines",
                c => new
                {
                    Player = c.String(nullable: false, maxLength: 128),
                    GamesPlayed = c.Int(nullable: false),
                    GamesStarted = c.Int(nullable: false),
                    MinutesPlayed = c.Decimal(nullable: false, precision: 18, scale: 2),
                    FieldGoalsMade = c.Decimal(nullable: false, precision: 18, scale: 2),
                    FieldGoalsAttemped = c.Decimal(nullable: false, precision: 18, scale: 2),
                    FieldGoalPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ThreePointersMade = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ThreePointersAttempted = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ThreePointPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    TwoPointersMade = c.Decimal(nullable: false, precision: 18, scale: 2),
                    TwoPointersAttempted = c.Decimal(nullable: false, precision: 18, scale: 2),
                    TwoPointPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    EffectiveFieldGoalPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    FreeThrowsMade = c.Decimal(nullable: false, precision: 18, scale: 2),
                    FreeThrowsAttempted = c.Decimal(nullable: false, precision: 18, scale: 2),
                    FreeThrowPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    OffensiveRebounds = c.Decimal(nullable: false, precision: 18, scale: 2),
                    DefensiveRebounds = c.Decimal(nullable: false, precision: 18, scale: 2),
                    TotalRebounds = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Assists = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Steals = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Blocks = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Turnovers = c.Decimal(nullable: false, precision: 18, scale: 2),
                    PersonalFouls = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Points = c.Decimal(nullable: false, precision: 18, scale: 2),
                    SeasonId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Player)
                .ForeignKey("dbo.Seasons", t => t.SeasonId, cascadeDelete: true)
                .Index(t => t.SeasonId);

        }

        public override void Down()
        {
            DropTable("dbo.HistoricalPerGameStatLines");
        }
    }
}
