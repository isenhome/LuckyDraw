using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyDraw.Models
{
    public class Award
    {
        public int ID { get; set; }
        public string AwardType { get; set; }
        public string AwardName { get; set; }
        public int AwardNumber { get; set; }
    }
}
