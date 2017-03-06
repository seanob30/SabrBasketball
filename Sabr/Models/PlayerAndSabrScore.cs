using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sabr.Models
{
    public class PlayerAndSabrScore
    {
        public string PlayerName { get; set; }
        public int SabrScore { get; set; }
        public int PositionId { get; set; }
        public PlayerPosition Position { get; set; }
        public int TeamId { get; set; }
    }
}