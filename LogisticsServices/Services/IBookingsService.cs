using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticsServices.Dto;

namespace LogisticsServices.Services
{
    public interface IBookingsService
    {
        IEnumerable<BookingDto> ListAllBookings();
        BookingDto CreateBooking(BookingDto pNewBooking);

        BookingDto FetchBooking(string pBookingId);
        void DeleteBooking(string pBookingId);
        BookingDto UpdateBooking(string pBookingId, BookingDto pUpdatedBooking);
    }
}
