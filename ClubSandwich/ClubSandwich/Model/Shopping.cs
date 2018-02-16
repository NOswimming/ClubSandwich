using System;
using System.Collections.Generic;
using System.Text;

namespace ClubSandwich.Model
{
    public class Shopping
    {
        public DateTime Date { get; set; }
        public String ShopperName { get; set; }
        public double Cost { get; set; }
        public double Paid { get; set; }
        public double Owed { get; set; }
    }
}
