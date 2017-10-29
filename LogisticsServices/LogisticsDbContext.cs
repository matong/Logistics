using LogisticsServices.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticsServices
{
    public class LogisticsDbContext : DbContext
    {
        public LogisticsDbContext()
        {

        }

        public LogisticsDbContext(DbContextOptions<LogisticsDbContext> options) : base(options)
        {
        }

        public virtual DbSet<BookingEntity> Bookings { get; set; }
    }

}
