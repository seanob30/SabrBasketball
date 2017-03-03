using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sabr.Models
{
    public class HistoricalPlayer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FootHeight { get; set; }
        public int InchHeight { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }

        [ForeignKey("PlayerPosition")]
        public int PlayerPositionId { get; set; }

        public PlayerPosition PlayerPosition { get; set; }

        [ForeignKey("HistoricalTeam")]
        public int HistoricalTeamId { get; set; }
        public HistoricalTeam HistoricalTeam { get; set; }
    }
}