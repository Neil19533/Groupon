using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Groupon.Models
{
    public class GrouponData
    {
        public string Title { get; set; }

        public string Image { get; set; }

        public string URL { get; set; }

        public List<Groupon.Models.GrouponItem> Variations { get; set; }

        public TimeSpan TimeRemaining { get; set; }
    }

    public class GrouponItem
    {
        public string Title { get; set; }

        public string Sold { get; set; }


    }
}