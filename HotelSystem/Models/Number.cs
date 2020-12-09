using System;
using System.Collections.Generic;

#nullable disable

namespace HotelSystem
{
    public partial class Number
    {
        public Number()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public int? Price { get; set; }

        public virtual NumberType TypeNavigation { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
