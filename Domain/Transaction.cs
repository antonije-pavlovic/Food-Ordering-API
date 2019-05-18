using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Transaction: BaseEntity
    {
        public double Amount { get; set; }
        public string Type { get; set; }
        public int WalletID { get; set; }
        public Wallet Wallet { get; set; }
    }
}
