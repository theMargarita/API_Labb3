using API_Labb3.Data;
using API_Labb3.Models;
using API_Labb3.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Labb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private readonly PersonInterestDbContext _context;

        public InterestController(PersonInterestDbContext context)
        {
            _context = context;
        }

        //get all interest
        [HttpGet(Name = "GetInterest")]
        public async Task<ActionResult<ICollection<Interest>>> GetInterest()
        {
            return Ok(await _context.Interests.Select(i => new {i.Id, i.Title, i.Description, i.PersonInterests}).ToListAsync());
            //return Ok(await _context.Links.ToListAsync());
        }

        //search by id
        [HttpGet("{id}", Name = "GetInterestById")]
        public async Task<ActionResult<ICollection<Interest>>> GetInterestById(int id)
        {
            return Ok(await _context.Links.FindAsync(id));
        }

        //create new interest
        [HttpPost (Name = "CreateInterest")]
        public async Task<ActionResult<InterestDTO>> CreateInterest(Interest createInterest)
        {
            //var personInterest = new List<PersonInterest>();

            if(createInterest == null)
            {
                return BadRequest(new {errorMessage = "Invalid or empty request" });
            }

            var addCreateInterest = _context.Interests.Select(i => new InterestDTO
            {
                Title = i.Title,
                Description = i.Description,
                //PersonInterests = personInterest
            }).ToListAsync();

             _context.AddAsync(addCreateInterest);
            await _context.SaveChangesAsync();
            return Ok(addCreateInterest);
        }
        
    }
}
