using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticsServices.Dto;
using LogisticsServices.Entities;

namespace LogisticsServices.Services
{
    public class BookingsService : IBookingsService
    {
        private LogisticsDbContext _dbContext;

        public BookingsService(LogisticsDbContext pDbContext)
        {
            this._dbContext = pDbContext;
        }

        public BookingDto CreateBooking(BookingDto pNewBooking)
        {
            var lNewBookingEntity = new BookingEntity();
            lNewBookingEntity.PopulateFromDto(pNewBooking);

            this._dbContext.Bookings.Add(lNewBookingEntity);
            this._dbContext.SaveChanges();

            return this.FetchBooking(pNewBooking.BookingId);
           
        }

        public void DeleteBooking(string pBookingId)
        {
            var lBookingToDelete = this._dbContext.Bookings.Where(ent => ent.BookingId == pBookingId).FirstOrDefault();
            this._dbContext.Bookings.Remove(lBookingToDelete);
            this._dbContext.SaveChanges();
        }

        public BookingDto FetchBooking(string pBookingId)
        {
            var lReturn = this._dbContext.Bookings.Where(ent => ent.BookingId == pBookingId).Select(ent => new BookingDto
            {
                Id = ent.Id,
                BookingId = ent.BookingId,
                Description = ent.Description,
                Quantity = ent.Quantity,
                ModeOfTransport = ent.ModeOfTransportAsString(),
                Status = ent.StatusAsString(),
            }).FirstOrDefault();
            return lReturn;
        }

        public IEnumerable<BookingDto> ListAllBookings()
        {
            List<BookingDto> lReturnList = this._dbContext.Bookings.Select(ent => new BookingDto {
                Id = ent.Id,
                BookingId = ent.BookingId,
                Description = ent.Description,
                Quantity = ent.Quantity,
                ModeOfTransport = ent.ModeOfTransportAsString(),
                Status = ent.StatusAsString(),
           }).ToList();

            return lReturnList;
        }

        public BookingDto UpdateBooking(string pBookingId, BookingDto pUpdatedBooking)
        {
            var lNewBookingEntity = this._dbContext.Bookings.Where(ent => ent.BookingId == pBookingId).FirstOrDefault();
            lNewBookingEntity.PopulateFromDto(pUpdatedBooking);
            this._dbContext.SaveChanges();

            return this.FetchBooking(pUpdatedBooking.BookingId);
        }
    }
}
