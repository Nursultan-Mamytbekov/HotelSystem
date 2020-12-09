using System;
using System.Collections.Generic;

#nullable disable

namespace HotelSystem
{
    public partial class RpBooking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Expr1 { get; set; }
        public DateTime? DateSet { get; set; }
        public DateTime? DateOut { get; set; }
        public int? Service { get; set; }
    }
}
