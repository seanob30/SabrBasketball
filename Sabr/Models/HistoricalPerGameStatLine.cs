using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sabr.Models
{
    public class HistoricalPerGameStatLine
    {
        [Key]
        public int Id { get; set; } 
        public string Player { get; set; }
        public string GamesPlayed { get; set; }
        public string GamesStarted { get; set; }
        public string MinutesPlayed { get; set; }
        public string FieldGoalsMade { get; set; }
        public string FieldGoalsAttemped { get; set; }
        public string FieldGoalPercentage { get; set; }
        public string ThreePointersMade { get; set; }
        public string ThreePointersAttempted { get; set; }
        public string ThreePointPercentage { get; set; }
        public string TwoPointersMade { get; set; }
        public string TwoPointersAttempted { get; set; }
        public string TwoPointPercentage { get; set; }
        public string EffectiveFieldGoalPercentage { get; set; }
        public string FreeThrowsMade { get; set; }
        public string FreeThrowsAttempted { get; set; }
        public string FreeThrowPercentage { get; set; }
        public string OffensiveRebounds { get; set; }
        public string DefensiveRebounds { get; set; }
        public string TotalRebounds { get; set; }
        public string Assists { get; set; }
        public string Steals { get; set; }
        public string Blocks { get; set; }
        public string Turnovers { get; set; }
        public string PersonalFouls { get; set; }
        public string Points { get; set; }

        [ForeignKey("Season")]
        public int SeasonId { get; set; }
        public Season Season { get; set; }
    }
}