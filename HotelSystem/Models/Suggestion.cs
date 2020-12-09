using System;
using System.Collections.Generic;

#nullable disable

namespace HotelSystem
{
    public partial class Suggestion
    {
        public int Id { get; set; }
        public int Client { get; set; }
        public string Text { get; set; }

        public virtual Client ClientNavigation { get; set; }
    }
}
