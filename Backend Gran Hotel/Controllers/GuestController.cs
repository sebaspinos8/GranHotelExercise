using System.Collections.Specialized;
using System.Text;
using System;
using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers;


public class requestGuest
{
  public string? guestName {set;get;}
  public string? guestIdent {set;get;}
}
[Microsoft.AspNetCore.Cors.EnableCors("_myAllowSpecificOrigins")]
[ApiController]
[Route("[controller]")]
public class GuestController : ControllerBase
{
    private readonly GranhotelContext _context;

    public GuestController(GranhotelContext logger)
    {
        this._context = logger;
    }

    [HttpGet("/GetGuests")]
    public IActionResult Get()
    {
        var guests = from guest in _context.Guests
                    where guest.GuestStatus == "A"
                    select guest;
        if(guests == null)
            return Ok("[]");
        else
            return Ok(guests);
    }

    [HttpPost("/CreateGuest")]
    public IActionResult CreateGuest([FromBody] requestGuest guest)
    {
        try{
            Guest aux = new Guest();
            var busqueda = from b in _context.Guests
                   where b.GuestIdent.Equals(guest.guestIdent)
                   select b;
        if(busqueda.Count() == 0){
            aux.GuestId = _context.Guests.OrderBy(x=>x.GuestId).Last().GuestId +1;
            aux.GuestName = guest.guestName;
            aux.GuestIdent = guest.guestIdent;
            aux.GuestStatus = "A";
            _context.Guests.Add(aux);
            _context.SaveChanges();
            return Ok(aux);
        }else{
            return BadRequest("Identificaction is duplicated, try again with another");
        }
        }catch(Exception ex){
            return BadRequest("Error: "+ex);
        }
        
    }

}
