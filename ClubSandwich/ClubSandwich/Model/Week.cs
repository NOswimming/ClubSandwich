using System;
using System.Collections.Generic;
using System.Text;

namespace ClubSandwich.Model
{
    public class Week
    {

        public int WeekId { get; set; }
        public int ShopperUserId { get; set; }
        public float Cost { get; set; }
        public decimal CostPerUser { get; set; }
        public List<WeekUserLink> Users { get; set; }
        public User Shopper { get; set; }

    }
}
