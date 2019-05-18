using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Order: BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public double Total { get; set; }
    }
}
