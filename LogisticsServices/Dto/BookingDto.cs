using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticsServices.Dto
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string BookingId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string ModeOfTransport { get; set; }
        public string Status { get; set; }
    }
}
