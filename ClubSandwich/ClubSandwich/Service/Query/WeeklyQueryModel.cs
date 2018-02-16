using ClubSandwich.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubSandwich.Service.Query
{
    public class WeeklyQueryModel
    {
        public User Me { get; set; }
        public User PrimaryShopper { get; set; }
        public List<Week> Weeks { get; set; }
    }
}
