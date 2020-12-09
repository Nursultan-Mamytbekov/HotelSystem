using System;
using System.Collections.Generic;

#nullable disable

namespace HotelSystem
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? Position { get; set; }
        public int? Salary { get; set; }

        public virtual Position PositionNavigation { get; set; }
    }
}
