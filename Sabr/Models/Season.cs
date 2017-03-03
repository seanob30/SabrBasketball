using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sabr.Models
{
    public class Season
    {
        [Key]
        public int Id { get; set; }

        public string Year { get; set; }
    }
}