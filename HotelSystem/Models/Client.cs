using System;
using System.Collections.Generic;

#nullable disable

namespace HotelSystem
{
    public partial class Client
    {
        public Client()
        {
            Bookings = new HashSet<Booking>();
            Suggestions = new HashSet<Suggestion>();
            TotalPrices = new HashSet<TotalPrice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PassportId { get; set; }
        public string Phone { get; set; }
        public DateTime? DateRegister { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Suggestion> Suggestions { get; set; }
        public virtual ICollection<TotalPrice> TotalPrices { get; set; }
    }
}
