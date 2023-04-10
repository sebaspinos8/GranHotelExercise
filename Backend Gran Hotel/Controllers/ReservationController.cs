using System.Collections.Specialized;
using System.Text;
using System;
using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers;



public class requestReservationIn
{
  public string guestName {set;get;}

  public string guestIdent {set;get;}

  public int roomId {set;get;}

  public DateTime reservationInDate{set;get;}

  public DateTime reservationoutDate{set;get;}
}

public class requestReservationOut
{
  public int reservationId {set;get;}

}

[Microsoft.AspNetCore.Cors.EnableCors("_myAllowSpecificOrigins")]
[ApiController]
[Route("[controller]")]
public class ReservationController : ControllerBase
{
    private readonly GranhotelContext _context;

    public ReservationController(GranhotelContext logger)
    {
        this._context = logger;
    }

    [HttpGet("GetReservations")]
    public IActionResult Get()
    {
        return Ok(_context.Guests.ToList());
    }

    [HttpGet("/GetReservationsOut")]
    public IActionResult GetReservationsOut()
    {
        var reservations = from reserv in _context.Reservations
                           join room in _context.Rooms
                           on reserv.RoomId equals room.RoomId
                           join guest in _context.Guests
                           on reserv.GuestId equals guest.GuestId
                           where reserv.ReservationStatus == "N"
                           select new {
                            reservationId = reserv.ReservationId,
                            guestId = reserv.GuestId,
                            guestName = guest.GuestName,
                            roomId= reserv.RoomId,
                            roomName = room.RoomIden,
                            reservationInDate = reserv.ReservationInDate,
                            reservationOutDate = reserv.ReservationOutDate,
                            reservationStatus = reserv.ReservationStatus
                           };
        if(reservations == null)
            return Ok("[]");
        else
            return Ok(reservations);
    }

    [HttpPost("/CheckIn")]
    public IActionResult CheckIn([FromBody] requestReservationIn reserv)
    {
        try{
            Reservation aux = new Reservation();
            var searchGuestP = from b in _context.Guests
                   where b.GuestIdent.Equals(reserv.guestIdent)
                   select b;
            Guest guest = new Guest();

            if(searchGuestP.Count() == 0 || searchGuestP ==null){
                guest.GuestId = _context.Guests.OrderBy(x=>x.GuestId).Last().GuestId +1;
                guest.GuestIdent = reserv.guestIdent;
                guest.GuestName = reserv.guestName;
                guest.GuestStatus = "A";
                _context.Guests.Add(guest);
            }else{
                guest = (Guest)searchGuestP.First();
            }


            var searchRoom = from b in _context.Rooms
                   where b.RoomId.Equals(reserv.roomId)
                   select b;
            
            if(searchRoom.Count()>0){
                if(((Room)searchRoom.First()).RoomStatus.Equals("A")){
                    var searchGuestAv = from b in _context.Reservations
                    where b.GuestId.Equals(guest.GuestId) && b.ReservationStatus.Equals("N")
                    select b;
                    if(searchGuestAv.Count() > 0){
                        return BadRequest("The Guest already have a reservation in a room");
                    }else{
                        Reservation reservation = new Reservation();
                        Room room = (Room)searchRoom.First();
                        reservation.Guest = guest;
                        reservation.GuestId = guest.GuestId;
                        reservation.ReservationId = _context.Reservations.OrderBy(x=>x.ReservationId).Last().ReservationId +1;
                        reservation.RoomId = room.RoomId;
                        reservation.Room = room;
                        reservation.ReservationInDate = DateTime.Now;
                        reservation.ReservationStatus = "N";
                        room.RoomStatus = "N";
                        _context.Reservations.Add(reservation);
                        _context.SaveChanges();
                        return Ok(new Dictionary<string,string>{{"message", "Your reservation has been made successfully"}});
                    }

                }else{
                    return BadRequest("Room is not availability");
                }

            }else{
                return BadRequest("The Room does not exists");
            }
        }catch(Exception ex){
            return BadRequest("Error: "+ex);
        }
        
    }


    [HttpPost("/CheckOut")]
    public IActionResult CheckOut([FromBody] requestReservationOut reserv)
    {
        try{
            Reservation reservation = _context.Reservations.Find(reserv.reservationId);

            if(reservation !=null){            
                reservation.ReservationStatus = "A";
                Room room = _context.Rooms.Find(reservation.RoomId);
                room.RoomStatus = "A";
                reservation.ReservationOutDate = DateTime.Now;
                _context.SaveChanges();
                return Ok(new Dictionary<string,string>{{"message", "Your reservation has check out successfully"}});

            }else{
                return BadRequest("Guest does not exist");
            }
   
        }catch(Exception ex){
            return BadRequest("Error: "+ex);
        }
        
    }



}
