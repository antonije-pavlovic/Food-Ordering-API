using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class OrderSearch
    {
        public double? MinTotal { get; set; }
        public double? MaxTotal { get; set; }   
        public int PerPage { get; set; } = 2;
        public int PageNumber { get; set; } = 1;
        public int UserId { get; set; }
    }
}
