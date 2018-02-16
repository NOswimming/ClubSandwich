using ClubSandwich.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubSandwich.Service.Query
{
    public class ShoppingQueryModel
    {
        public User Me { get; set; }
        public User PrimaryShopper { get; set; }
        public List<Week> Weeks { get; set; }
        public List<User> Users { get; set; }
    }
}
