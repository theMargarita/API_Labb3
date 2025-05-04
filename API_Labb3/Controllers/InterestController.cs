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
        //[HttpGet(Name = "GetInterest")]
        //public async Task<ActionResult<ICollection<Interest>>> GetInterest()
        //{
        //    return Ok(await _context.Interests.Select(i => new { i.Id, i.Title, i.Description, i.PersonInterests }).ToListAsync());
        //    //return Ok(await _context.Links.ToListAsync());
        //}

        //search by id - repository pattern
        [HttpGet("{id}", Name = "GetInterestById")]
        public async Task<ActionResult<ICollection<Interest>>> GetInterestById(int id)
        {
            return Ok(await _context.Interests.FindAsync(id));
        }


        //create new interest
        [HttpPost(Name = "CreateInterest")]
        public async Task<ActionResult> InterestToPerson(InterestRequest createInterest, int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return BadRequest(new { errorMessage = $"could not find the person by id: {person}" });
            }

            var interest = await _context.Interests
                .FirstOrDefaultAsync(i => i.Title == createInterest.Title);

            //creates new interest if interest is null/non existent
            if (interest == null)
            {
                interest = new Interest
                {
                    Title = createInterest.Title,
                    Description = createInterest.Description,
                };

                await _context.AddAsync(interest);
                await _context.SaveChangesAsync();
            }

            //to check if the interest and  person exists
            var personInterest = await _context.PersonInterests
                .FirstOrDefaultAsync(pi => pi.PersonID == id && pi.InterestID == interest.Id);

            if (personInterest != null)
            {
                return BadRequest(new { errorMessage = "Something is not right" });
            }

            //add new / 
            personInterest = new PersonInterest
            {
                InterestID = interest.Id,
                PersonID = id
            };

            //await _context.AddAsync(new {personInterest, interest});
            await _context.PersonInterests.AddAsync(personInterest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInterestById), new { id = person.Id }, new { personInterest, interest });
        }

    }
}
