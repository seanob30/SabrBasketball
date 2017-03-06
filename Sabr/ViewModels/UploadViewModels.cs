using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sabr.Models;

namespace Sabr.ViewModels
{
    public class UploadViewModels
    {
        public class HistoricalUploadViewModel
        {
            public int SeasonId { get; set; }
            public IEnumerable<Season> SeasonsList { get; set; }
        }
    }
}