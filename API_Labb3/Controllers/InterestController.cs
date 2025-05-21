using API_Labb3.Data;
using API_Labb3.Models;
using API_Labb3.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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

        //search by id - repository pattern
        [HttpGet("{id}", Name = "GetInterestById")]
        public async Task<ActionResult<ICollection<Interest>>> GetInterestById(int id)
        {
            return Ok(await _context.Interests.FindAsync(id));
        }


        ////create new interest
        //[HttpPost("{personId}", Name = "CreateInterest")]
        //public async Task<ActionResult> InterestToPerson(InterestRequest createInterest, int personId)
        //{
        //    var person = await _context.Persons.FindAsync(personId);
        //    if (person == null)
        //    {
        //        return BadRequest(new { errorMessage = $"could not find the person by id: {person}" });
        //    }

        //    var interest = await _context.Interests
        //        .FirstOrDefaultAsync(i => i.Title == createInterest.Title);

        //    //creates new interest if interest is null/non existent
        //    if (interest == null)
        //    {
        //        interest = new Interest
        //        {
        //            Title = createInterest.Title,
        //            Description = createInterest.Description,

        //        };

        //        await _context.AddAsync(interest);
        //        await _context.SaveChangesAsync();
        //    }

        //    //to check if the interest and  person exists
        //    var personInterest = await _context.PersonInterests.FirstOrDefaultAsync(pi => pi.PersonID == personId && pi.InterestID == interest.Id);
        //    //and if null
        //    if (personInterest != null)
        //    {
        //        return BadRequest(new { errorMessage = "Person already have this interest" });
        //    }

        //    //add new
        //    personInterest = new PersonInterest
        //    {
        //        InterestID = interest.Id,
        //        PersonID = personId
        //    };

        //    await _context.PersonInterests.AddAsync(personInterest);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetInterestById), new { id = person.Id }, new { personInterest, interest });
        //}



        //kopplar personid och interestid - bara koppla


        [HttpPost("AddNewInterestToPerson", Name = "AddNewInterestToPerson")]
        //so this works now, not the prettiest but works as it should
        public async Task<ActionResult> ConnectPersonWithNewInterest(int personId, int interestId)
        {
            var personInterest = await _context.PersonInterests.FirstOrDefaultAsync(pi => pi.PersonID == personId && pi.InterestID == interestId);

            //var interest = await _context.Interests.FirstOrDefaultAsync(i => i.Title)

            if (personInterest is not null)
            {
                return BadRequest(new { errorMessage = "Person have already this interest" });
            }
            //add new interest to person (add from
            personInterest = new PersonInterest
            {
                PersonID = personId,
                InterestID = interestId,
            };

            await _context.PersonInterests.AddAsync(personInterest);
            await _context.SaveChangesAsync();

            var showPersonInfo = await _context.PersonInterests
                .Where(pi => pi.Persons.Id == personId && pi.Interests.Id == interestId)
                .Select(pi => new GetPersonInterestDTO
                 {
                    FirstName = pi.Persons.Firstname,
                    LastName = pi.Persons.Lastname,
                    Title = pi.Interests.Title,
                    Description = pi.Interests.Description
                 }).ToListAsync();


            return CreatedAtAction(nameof(GetInterestById), new { id = personId }, new { personInterest, showPersonInfo });
        }

    }
}
