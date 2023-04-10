using System.Collections.Specialized;
using System.Text;
using System;
using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers;


public class requestRoom
{
  public string roomIdent {set;get;}
  public int hotelId {set;get;}
}

[Microsoft.AspNetCore.Cors.EnableCors("_myAllowSpecificOrigins")]
[ApiController]
[Route("[controller]")]
public class RoomController : ControllerBase
{
    private readonly GranhotelContext _context;

    public RoomController(GranhotelContext logger)
    {
        this._context = logger;
    }

    [HttpGet("/GetAllRooms")]
    public IActionResult Get(int hotelId)
    {
        var rooms = from room in _context.Rooms
                    where room.HotelId == hotelId
                    select room;
        if(rooms == null)
            return Ok("[]");
        else
            return Ok(rooms);
    }

    [HttpGet("/GetAllRoomsAvailabilityByHotel")]
    public IActionResult GetAllbyHotel(int hotelId)
    {
        var rooms = from room in _context.Rooms
                    where room.HotelId == hotelId && room.RoomStatus.Equals("A")
                    select room;
        if(rooms == null)
            return Ok("[]");
        else
            return Ok(rooms);
    }


    [HttpGet("/GetAllRoomsNotAvailabilityByHotel")]
    public IActionResult GetAllNotAvaibyHotel(int hotelId)
    {
        var rooms = from room in _context.Rooms
                    where room.HotelId == hotelId && room.RoomStatus.Equals("N")
                    select room;
        if(rooms == null)
            return Ok("[]");
        else
            return Ok(rooms);
    }



    [HttpPost("/CreateRoom")]
    public IActionResult CreateRoom([FromBody] requestRoom room)
    {
        try{
            Room aux = new Room();
            var busqueda = from b in _context.Rooms
                   where b.RoomIden.ToLower().Equals(room.roomIdent.ToLower())
                   select b;
        if(busqueda.Count() == 0){
            aux.RoomId = _context.Rooms.OrderBy(x=>x.RoomId).Last().RoomId +1;
            aux.RoomIden = room.roomIdent;
            aux.RoomStatus = "A";
            aux.HotelId = room.hotelId;
            _context.Rooms.Add(aux);
            _context.SaveChanges();
            return Ok(aux);
        }else{
            return BadRequest("Room Name is duplicated, try again with another");
        }
        }catch(Exception ex){
            return BadRequest("Error: "+ex);
        }
        
    }
}
