namespace Sabr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPropDataOnStatLines : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PerGameStatLines", "GamesPlayed", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "GamesStarted", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "MinutesPlayed", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "FieldGoalsMade", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "FieldGoalsAttemped", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "FieldGoalPercentage", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "ThreePointersMade", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "ThreePointersAttempted", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "ThreePointPercentage", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "TwoPointersMade", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "TwoPointersAttempted", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "TwoPointPercentage", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "EffectiveFieldGoalPercentage", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "FreeThrowsMade", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "FreeThrowsAttempted", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "FreeThrowPercentage", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "OffensiveRebounds", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "DefensiveRebounds", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "TotalRebounds", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "Assists", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "Steals", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "Blocks", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "Turnovers", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "PersonalFouls", c => c.String());
            AlterColumn("dbo.PerGameStatLines", "Points", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PerGameStatLines", "Points", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "PersonalFouls", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "Turnovers", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "Blocks", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "Steals", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "Assists", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "TotalRebounds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "DefensiveRebounds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "OffensiveRebounds", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "FreeThrowPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "FreeThrowsAttempted", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "FreeThrowsMade", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "EffectiveFieldGoalPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "TwoPointPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "TwoPointersAttempted", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "TwoPointersMade", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "ThreePointPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "ThreePointersAttempted", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "ThreePointersMade", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "FieldGoalPercentage", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "FieldGoalsAttemped", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "FieldGoalsMade", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "MinutesPlayed", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PerGameStatLines", "GamesStarted", c => c.Int(nullable: false));
            AlterColumn("dbo.PerGameStatLines", "GamesPlayed", c => c.Int(nullable: false));
        }
    }
}
