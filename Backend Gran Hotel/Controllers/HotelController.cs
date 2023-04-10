using System.Collections.Specialized;
using System.Text;
using System;
using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers;

[Microsoft.AspNetCore.Cors.EnableCors("_myAllowSpecificOrigins")]
[ApiController]
[Route("[controller]")]
public class HotelController : ControllerBase
{
    private readonly GranhotelContext _context;


    public HotelController(GranhotelContext logger)
    {
        this._context = logger;
    }

    [HttpGet("/GetHotels")]
    public IActionResult Get()
    {
        return Ok(_context.Hotels.ToList());
    }
}
