using System;
using System.Collections.Generic;
using System.Text;

namespace ClubSandwich.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public decimal Amount { get; set; }
        public User user { get; set; }
    }
}
