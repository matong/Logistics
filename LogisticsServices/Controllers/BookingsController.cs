using LogisticsServices.Dto;
using LogisticsServices.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticsServices.Controllers
{
    [Route("bookings")]
    public class BookingsController : Controller
    {
        private IBookingsService _bookingsService;

        public BookingsController(IBookingsService pBookingsService)
        {
            this._bookingsService = pBookingsService;
        }

        [HttpGet]
        public IEnumerable<BookingDto> ListAllBookings()
        {
            return this._bookingsService.ListAllBookings();
        }

        [HttpPost]
        public BookingDto CreateBooking(BookingDto pNewBooking)
        {
            return this._bookingsService.CreateBooking(pNewBooking);
        }

        [HttpGet("{BookingId}")]
        public BookingDto FetchBooking(string BookingId)
        {
            return this._bookingsService.FetchBooking(BookingId);
        }

        [HttpPut("{BookingId}")]
        public BookingDto UpdateBooking(string BookingId, BookingDto pUpdatedBooking)
        {
            return this._bookingsService.UpdateBooking(BookingId, pUpdatedBooking);
        }

        [HttpDelete("{BookingId}")]
        public void DeleteBooking(string BookingId)
        {
            this._bookingsService.DeleteBooking(BookingId);
        }

    }
}
