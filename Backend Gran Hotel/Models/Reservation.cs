using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int? GuestId { get; set; }

    public int? RoomId { get; set; }

    public DateTime? ReservationInDate { get; set; }

    public DateTime? ReservationOutDate { get; set; }

    public string? ReservationStatus { get; set; }

    public virtual Guest? Guest { get; set; }

    public virtual Room? Room { get; set; }
}
