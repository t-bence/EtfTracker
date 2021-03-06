// <auto-generated />
using System;
using EtfTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EtfTracker.Migrations
{
    [DbContext(typeof(EtfTrackerContext))]
    partial class EtfTrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("EtfTracker.Models.EtfPurchase", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<double>("EurPrice")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.ToTable("EtfPurchase");
                });

            modelBuilder.Entity("EtfTracker.Models.Exchange", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<double>("EurAmount")
                        .HasColumnType("REAL");

                    b.Property<double>("EurRateInHuf")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.ToTable("Exchange");
                });

            modelBuilder.Entity("EtfTracker.Models.Transfer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<double>("EurAmount")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.ToTable("Transfer");
                });
#pragma warning restore 612, 618
        }
    }
}
