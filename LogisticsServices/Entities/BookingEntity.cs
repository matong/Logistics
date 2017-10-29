using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogisticsServices.Dto;

namespace LogisticsServices.Entities
{
    public class BookingEntity
    {
        public enum ModeOfTransportType {
            SEA,
            RAIL,
            ROAD,
        }

        public enum StatusType
        {
            AT_SOURCE,
            IN_TRANSIT,
            AT_DESTINATION,
        }

        public int Id { get; set; }
        public string BookingId { get; set; } // Needs unique index
        public string Description { get; set; }
        public int Quantity { get; set; }
        public ModeOfTransportType ModeOfTransport { get; set; }
        public StatusType Status { get; set; }

        public string ModeOfTransportAsString()
        {
            // There's probably a better way of doing this mapping
            switch (this.ModeOfTransport)
            {
                case ModeOfTransportType.SEA:
                    return "Sea";
                case ModeOfTransportType.ROAD:
                    return "Road";
                case ModeOfTransportType.RAIL:
                    return "Rail";
            }

            return "Unknown";
        }

        public string StatusAsString()
        {
            // There's probably a better way of doing this mapping
            switch (this.Status)
            {
                case StatusType.AT_SOURCE:
                    return "At Source";
                case StatusType.IN_TRANSIT:
                    return "In Transit";
                case StatusType.AT_DESTINATION:
                    return "At Destination";
               
            }

            return "Unknown";
        }

        internal void PopulateFromDto(BookingDto pNewBooking)
        {
            // TODO Use Automapper
            this.BookingId = pNewBooking.BookingId;
            this.Description = pNewBooking.Description;
            this.Quantity = pNewBooking.Quantity;


            // There's probably a better way of doing this!
            switch (pNewBooking.ModeOfTransport)
            {
                case "Sea":
                    this.ModeOfTransport = BookingEntity.ModeOfTransportType.SEA;
                    break;

                case "Rail":
                    this.ModeOfTransport = BookingEntity.ModeOfTransportType.RAIL;
                    break;

                case "Road":
                    this.ModeOfTransport = BookingEntity.ModeOfTransportType.ROAD;
                    break;
                default:
                    throw new NotImplementedException("Mode of Transport " + pNewBooking.ModeOfTransport + " Not Found");
            }

            switch (pNewBooking.Status)
            {
                case "At Source":
                    this.Status = BookingEntity.StatusType.AT_SOURCE;
                    break;
                case "In Transit":
                    this.Status = BookingEntity.StatusType.IN_TRANSIT;
                    break;
                case "At Destination":
                    this.Status = BookingEntity.StatusType.AT_DESTINATION;
                    break;
                default:
                    throw new NotImplementedException("Status " + pNewBooking.ModeOfTransport + " Not Found");
            }

        }
    }
}
