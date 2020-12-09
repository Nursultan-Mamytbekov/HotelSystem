using System;
using System.Collections.Generic;

#nullable disable

namespace HotelSystem
{
    public partial class TotalPrice
    {
        public int Id { get; set; }
        public int? Client { get; set; }
        public int? SumPrice { get; set; }

        public virtual Client ClientNavigation { get; set; }
    }
}
