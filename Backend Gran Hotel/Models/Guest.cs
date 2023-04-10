using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Guest
{
    public int GuestId { get; set; }

    public string? GuestName { get; set; }

    public string? GuestIdent { get; set; }

    public string? GuestStatus { get; set; }

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
