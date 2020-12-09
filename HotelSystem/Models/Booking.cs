using System;
using System.Collections.Generic;

#nullable disable

namespace HotelSystem
{
    public partial class Booking
    {
        public int Id { get; set; }
        public int? IdClient { get; set; }
        public int? IdNumber { get; set; }
        public DateTime? DateSet { get; set; }
        public DateTime? DateOut { get; set; }
        public int? Service { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Number IdNumberNavigation { get; set; }
        public virtual Service ServiceNavigation { get; set; }
    }
}
