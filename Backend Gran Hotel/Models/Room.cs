﻿using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string? RoomIden { get; set; }

    public string? RoomStatus { get; set; }

    public int? HotelId { get; set; }

    public virtual Hotel? Hotel { get; set; }

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
