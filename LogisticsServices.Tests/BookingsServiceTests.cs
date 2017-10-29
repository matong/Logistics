using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogisticsServices.Services;
using Moq;
using LogisticsServices.Dto;
using LogisticsServices.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace LogisticsServices.Tests
{
    [TestClass]
    public class BookingsServiceTests
    {
        private BookingsService _bookingService;
        private Mock<LogisticsDbContext> _dbContext;
        private Mock<DbSet<BookingEntity>> _mockBookingsSet;

        [TestInitialize]
        public void Init()
        {
            var lData = new List<BookingEntity>
            {
                new BookingEntity { Id = 1, BookingId = "Test123", Description = "Trucks", ModeOfTransport = BookingEntity.ModeOfTransportType.SEA, Quantity = 200, Status = BookingEntity.StatusType.IN_TRANSIT},
            }.AsQueryable();

            this._mockBookingsSet = new Mock<DbSet<BookingEntity>>();
            this._mockBookingsSet.As<IQueryable<BookingEntity>>().Setup(m => m.Provider).Returns(lData.Provider);
            this._mockBookingsSet.As<IQueryable<BookingEntity>>().Setup(m => m.Expression).Returns(lData.Expression);
            this._mockBookingsSet.As<IQueryable<BookingEntity>>().Setup(m => m.ElementType).Returns(lData.ElementType);
            this._mockBookingsSet.As<IQueryable<BookingEntity>>().Setup(m => m.GetEnumerator()).Returns(lData.GetEnumerator());
            this._dbContext = new Mock<LogisticsDbContext>();
            this._dbContext.Setup(m => m.Bookings).Returns(this._mockBookingsSet.Object);
            this._bookingService = new BookingsService(this._dbContext.Object);
        }

        [TestMethod]
        public void AddBooking()
        {
            // Arrange
            var lNewBookingDto = new BookingDto()
            {
                BookingId = "ABC123",
                Description = "200 baby's toys",
                ModeOfTransport = "Sea",
                Quantity = 200,
                Status = "In Transit"
            };

            // Act
            this._bookingService.CreateBooking(lNewBookingDto);

            // Assert
            this._mockBookingsSet.Verify(m => m.Add(It.IsAny<BookingEntity>()), Times.Once());
            this._dbContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void UpdateBooking()
        {
            // Arrange
            BookingDto lUpdatedBooking = new BookingDto()
            {
                BookingId = "Test123",
                Description = "Cars",
                ModeOfTransport = "Rail",
                Quantity = 50,
                Status = "At Destination"
            };

            // Act
            BookingDto lReturnedBooking = this._bookingService.UpdateBooking("Test123", lUpdatedBooking);

            // Assert
            this._dbContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual("Test123", lReturnedBooking.BookingId);
            Assert.AreEqual("Cars", lReturnedBooking.Description);
            Assert.AreEqual("Rail", lReturnedBooking.ModeOfTransport);
            Assert.AreEqual(50, lReturnedBooking.Quantity);
            Assert.AreEqual("At Destination", lReturnedBooking.Status);
            Assert.AreEqual(1, lReturnedBooking.Id);
        }

        [TestMethod]
        public void FetchBooking()
        {
            // Arrange

            // Act
            BookingDto lFetchedBooking = this._bookingService.FetchBooking("Test123");

            // Assert
            Assert.AreEqual("Test123", lFetchedBooking.BookingId);
            Assert.AreEqual("Trucks", lFetchedBooking.Description);
            Assert.AreEqual("Sea", lFetchedBooking.ModeOfTransport);
            Assert.AreEqual(200, lFetchedBooking.Quantity);
            Assert.AreEqual("In Transit", lFetchedBooking.Status);
            Assert.AreEqual(1, lFetchedBooking.Id);
        }

        [TestMethod]
        public void DeleteBooking()
        {
            // Arrange

            // Act
            this._bookingService.DeleteBooking("Test123");

            // Assert
            this._mockBookingsSet.Verify(m => m.Remove(It.IsAny<BookingEntity>()), Times.Once());
            this._dbContext.Verify(m => m.SaveChanges(), Times.Once());


        }
    }
}
