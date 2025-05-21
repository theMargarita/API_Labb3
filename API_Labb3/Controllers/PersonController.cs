using API_Labb3.Data;
using API_Labb3.Models;
using API_Labb3.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Labb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonInterestDbContext _context;

        public PersonController(PersonInterestDbContext context)
        {
            _context = context;
        }

        // get all the people in person
        [HttpGet(Name = "GetPerson")]
        public async Task<ActionResult<ICollection<PersonDTO>>> GetPerson()
        {
            //return Ok( await _context.GetAll());
            return Ok(await _context.Persons
                .Select(p => new
                {
                    p.Firstname,
                    p.Lastname,
                    p.Age,
                    p.Phone
                }).ToListAsync());

            //return Ok(await _context.Persons.ToListAsync());
        }


        [HttpGet("{personId}/", Name = "GetPersonsInterestsByPeronId")]
        public async Task<ActionResult<GetPersonInterestDTO>> GetPersonAndInterestsById(int personId)
        {
            var person = await _context.PersonInterests
                .Where(p => p.Persons.Id == personId)
                .Select(p => new GetPersonInterestDTO
                {
                    FirstName = p.Persons.Firstname,
                    LastName = p.Persons.Lastname,
                    Title = p.Interests.Title,
                    Description = p.Interests.Description
                }).ToListAsync();

            if (person == null)
            {
                return NotFound(new { errorMessage = "Person not found" });
            }

            return Ok(person);
        }



        [HttpPost("{personId}/{interestId}/link/", Name = "CreateLinkToPersonInterest")]
        public async Task<ActionResult<GetPersonInterestDTO>> AddLinkToPersonInterest(int personId, int interestId, LinkDTO linkDTO)
        {
            //checks if the person exists
            var person = await _context.Persons.FindAsync(personId);
            if(person == null)
            {
                return NotFound(new { errorMessage = $"Person with personId: {personId} not found" });
            }

            //checks if person has this interest
            var personInterest = await _context.PersonInterests
             .FirstOrDefaultAsync(pi => pi.PersonID == personId && pi.InterestID == interestId);

            if(personInterest == null)
            {
                //maybe is just enough with personId variable
                return NotFound(new { errorMessage = $"Interest is not found for this person with personId: {personId}" });
            }

            var link = new Link
            {
                URL = linkDTO.URL,
                PersonInterestId = personInterest.Id
            };
            await _context.AddAsync(link);
            await _context.SaveChangesAsync();

            return Ok(link);
        }
    }
}
