namespace Sabr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Repair : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HistoricalPerGameStatLines", "GamesPlayed", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "GamesStarted", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "MinutesPlayed", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "FieldGoalsMade", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "FieldGoalsAttemped", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "FieldGoalPercentage", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "ThreePointersMade", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "ThreePointersAttempted", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "ThreePointPercentage", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "TwoPointersMade", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "TwoPointersAttempted", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "TwoPointPercentage", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "EffectiveFieldGoalPercentage", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "FreeThrowsMade", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "FreeThrowsAttempted", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "FreeThrowPercentage", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "OffensiveRebounds", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "DefensiveRebounds", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "TotalRebounds", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "Assists", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "Steals", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "Blocks", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "Turnovers", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "PersonalFouls", c => c.String());
            AlterColumn("dbo.HistoricalPerGameStatLines", "Points", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.HistoricalPerGameStatLines", "Points", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "PersonalFouls", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "Turnovers", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "Blocks", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "Steals", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "Assists", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "TotalRebounds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "DefensiveRebounds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "OffensiveRebounds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "FreeThrowPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "FreeThrowsAttempted", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "FreeThrowsMade", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "EffectiveFieldGoalPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "TwoPointPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "TwoPointersAttempted", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "TwoPointersMade", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "ThreePointPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "ThreePointersAttempted", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "ThreePointersMade", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "FieldGoalPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "FieldGoalsAttemped", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "FieldGoalsMade", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "MinutesPlayed", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.HistoricalPerGameStatLines", "GamesStarted", c => c.Int(nullable: false));
            AlterColumn("dbo.HistoricalPerGameStatLines", "GamesPlayed", c => c.Int(nullable: false));
        }
    }
}
