using System;
using System.Collections.Generic;
using System.Text;

namespace ClubSandwich.Model
{
    public class WeekUserLink
    {
        public int UserId { get; set; }
        public int WeekId { get; set; }
        public float Paid { get; set; }
        public int Slices { get; set; }
        public User User { get; set; }
        public Week Week { get; set; }

    }
}
