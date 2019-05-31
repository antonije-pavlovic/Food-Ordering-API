using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class OrderDTO
    {
        public int UserId { get; set; }
        public int? Id { get; set; }
        public DateTime CreateAt { get; set; }
        public double Total { get; set; }
        public string Description { get; set; }
    }
}
