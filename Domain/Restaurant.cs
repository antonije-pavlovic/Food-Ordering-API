using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Restaurant : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public City City { get; set; }
        public int  CityId { get; set; }
    }
}
