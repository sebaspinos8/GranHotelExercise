using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public partial class GranhotelContext : DbContext
{
    public GranhotelContext()
    {
    }

    public GranhotelContext(DbContextOptions<GranhotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.GuestId).HasName("PRIMARY");

            entity.ToTable("guest");

            entity.Property(e => e.GuestId)
                .ValueGeneratedNever()
                .HasColumnName("guestId");
            entity.Property(e => e.GuestIdent)
                .HasMaxLength(45)
                .HasColumnName("guestIdent");
            entity.Property(e => e.GuestName)
                .HasMaxLength(45)
                .HasColumnName("guestName");
            entity.Property(e => e.GuestStatus)
                .HasMaxLength(2)
                .HasDefaultValueSql("'A'")
                .HasColumnName("guestStatus");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PRIMARY");

            entity.ToTable("hotel");

            entity.Property(e => e.HotelId)
                .ValueGeneratedNever()
                .HasColumnName("hotelId");
            entity.Property(e => e.HotelName)
                .HasMaxLength(45)
                .HasColumnName("hotelName");
            entity.Property(e => e.HotelStatus)
                .HasMaxLength(2)
                .HasDefaultValueSql("'A'")
                .HasColumnName("hotelStatus");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PRIMARY");

            entity.ToTable("reservation");

            entity.HasIndex(e => e.GuestId, "guestReservFK_idx");

            entity.HasIndex(e => e.RoomId, "roomReservFK_idx");

            entity.Property(e => e.ReservationId)
                .ValueGeneratedNever()
                .HasColumnName("reservationId");
            entity.Property(e => e.GuestId).HasColumnName("guestId");
            entity.Property(e => e.ReservationInDate)
                .HasColumnType("datetime")
                .HasColumnName("reservationInDate");
            entity.Property(e => e.ReservationOutDate)
                .HasColumnType("datetime")
                .HasColumnName("reservationOutDate");
            entity.Property(e => e.ReservationStatus)
                .HasMaxLength(2)
                .HasDefaultValueSql("'N'")
                .HasColumnName("reservationStatus");
            entity.Property(e => e.RoomId).HasColumnName("roomId");

            entity.HasOne(d => d.Guest).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.GuestId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("guestReservFK");

            entity.HasOne(d => d.Room).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("roomReservFK");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PRIMARY");

            entity.ToTable("room");

            entity.HasIndex(e => e.HotelId, "hotelRoomFK_idx");

            entity.Property(e => e.RoomId)
                .ValueGeneratedNever()
                .HasColumnName("roomId");
            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.RoomIden)
                .HasMaxLength(45)
                .HasColumnName("roomIden");
            entity.Property(e => e.RoomStatus)
                .HasMaxLength(45)
                .HasDefaultValueSql("'A'")
                .HasColumnName("roomStatus");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("hotelRoomFK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
