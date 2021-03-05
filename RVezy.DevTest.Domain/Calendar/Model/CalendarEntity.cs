using System;
using System.Collections.Generic;
using System.Text;

namespace RVezy.DevTest.Domain.Calendar.Model
{
    public class CalendarEntity
    {
        public int listing_id { get; set; }
        public DateTime date { get; set; }
        public bool available { get; set; }
        public decimal price { get; set; }
    }
}
