using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sabr.Models
{
    public class PlayerPosition
    {
        [Key]
        public int Id { get; set; }

        public string Position { get; set; }
    }
}