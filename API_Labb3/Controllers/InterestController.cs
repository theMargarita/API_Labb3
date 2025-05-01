using API_Labb3.Data;
using API_Labb3.Models;
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
        public async Task<ActionResult<Interest>> CreateInterest(Interest createInterest, int id)
        {
            if(createInterest == null)
            {
                return BadRequest(new {errorMessage = "Invalid or empty request" });
            }

            var addCreateInterest = new Interest()
            {
                Title = createInterest.Title,
                Description = createInterest.Description
            };

            await _context.AddAsync(addCreateInterest);
            return addCreateInterest;
        }
        
    }
}
