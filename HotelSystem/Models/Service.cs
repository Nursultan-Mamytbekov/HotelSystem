using System;
using System.Collections.Generic;

#nullable disable

namespace HotelSystem
{
    public partial class Service
    {
        public Service()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
