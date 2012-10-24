using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LuckyDraw.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string Assigned { get; set; }
        public string LuckyDog { get; set; }
        public int IsLuckyDog { get; set; }
    }
}
