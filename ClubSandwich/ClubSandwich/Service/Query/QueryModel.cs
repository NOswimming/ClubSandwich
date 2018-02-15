using ClubSandwich.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubSandwich.Service.Query
{
    public class QueryModel
    {
        public string Version { get; set; }
        public User Me { get; set; }
        public User PrimaryShopper { get; set; }
        public List<User> Users { get; set; }
        public User User { get; set; }
        public Week ThisWeek { get; set; }
        public List<Week> Weeks { get; set; }
        public Week Week { get; set; }
        public WeekUserLink WeekLink { get; set; }

    }
}
