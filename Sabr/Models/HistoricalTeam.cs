using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sabr.Models
{
    public class HistoricalTeam
    {
        [Key]
        public int Id { get; set; }

        public string TeamName { get; set; }
        [ForeignKey("Season")]
        public int SeasonId { get; set; }
        public Season Season { get; set; }
    }
}