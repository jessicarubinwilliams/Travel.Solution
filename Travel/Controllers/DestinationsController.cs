using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travel.Models;
using System.Linq;

namespace Travel.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DestinationsController : ControllerBase
  {
    private readonly TravelContext _db;

    public DestinationsController(TravelContext db)
    {
      _db = db;
    }

    // GET: api/Destinations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Destination>>> Get(string city, string state, string country, string visitDate, int rating)
    {
      var query = _db.Destinations.AsQueryable();

      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }

      if (state != null)
      {
        query = query.Where(entry => entry.State == state);
      }

      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }

      if (visitDate != null)
      {
        query = query.Where(entry => entry.VisitDate == visitDate);
      }

      //Ints can't be null in C#. Lines 49 & 50 both have the same problem:  We're able to use that code for the end point that actually searches for the ratings parameter but the main get endpoint now returns an empty body and we don't know why.  
      if (rating.ToString() != null)
      // if (!String.IsNullOrEmpty(rating.ToString()))
      {
        query = query.Where(entry => entry.Rating == rating);
      }

      return await query.ToListAsync();
    }
    
    // POST api/destinations
    [HttpPost]
    public async Task<ActionResult<Destination>> Post(Destination destination)
    {
      _db.Destinations.Add(destination);
      await _db.SaveChangesAsync();

     return CreatedAtAction(nameof(GetDestination), new { id = destination.DestinationId }, destination);
    }

    //GET api/Destinations/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Destination>> GetDestination(int id)
    {
        var destination = await _db.Destinations.FindAsync(id);

        if (destination == null)
        {
            return NotFound();
        }

        return destination;
    }
    
    // PUT: api/destinations/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Destination destination)
    {
      if (id != destination.DestinationId)
      {
        return BadRequest();
      }

      _db.Entry(destination).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DestinationExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
     private bool DestinationExists(int id)
    {
      return _db.Destinations.Any(e => e.DestinationId == id);
    }

    // DELETE: api/destinations/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDestination(int id)
    {
      var destination = await _db.Destinations.FindAsync(id);
      if (destination == null)
      {
        return NotFound();
      }

      _db.Destinations.Remove(destination);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}