﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Type { get; set; }
    }
}
