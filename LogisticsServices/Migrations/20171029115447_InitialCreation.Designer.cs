﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LogisticsServices;
using LogisticsServices.Entities;

namespace LogisticsServices.Migrations
{
    [DbContext(typeof(LogisticsDbContext))]
    [Migration("20171029115447_InitialCreation")]
    partial class InitialCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LogisticsServices.Entities.BookingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BookingId");

                    b.Property<string>("Description");

                    b.Property<int>("ModeOfTransport");

                    b.Property<int>("Quantity");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Bookings");
                });
        }
    }
}
