using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string? HotelName { get; set; }

    public string? HotelStatus { get; set; }

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
