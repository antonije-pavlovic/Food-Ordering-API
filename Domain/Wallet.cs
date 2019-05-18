using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Wallet
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
