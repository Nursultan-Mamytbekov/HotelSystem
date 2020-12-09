using System;
using System.Collections.Generic;

#nullable disable

namespace HotelSystem
{
    public partial class NumberType
    {
        public NumberType()
        {
            Numbers = new HashSet<Number>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Number> Numbers { get; set; }
    }
}
