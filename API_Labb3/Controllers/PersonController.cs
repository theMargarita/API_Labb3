using API_Labb3.Data;
using API_Labb3.Models;
using API_Labb3.Models.DTOs;
using API_Labb3.Respetories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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


        //search by their id (dont forget the {id}, so controller understand which id which 
        [HttpGet("{id}/interest", Name = "GetPersonById")]
        public async Task<ActionResult<GetPersonInterestDTO>> GetPersonById(int id)
        {
            var person = await _context.Persons
                .Include(p => p.PersonInterests)
                .ThenInclude(pi => pi.Interests)
                .Where(p => p.Id == id)
                .Select(p => new GetPersonInterestDTO
                {
                    FirstName = p.Firstname,
                    LastName = p.Lastname,
                    Interests = p.PersonInterests.Select(pi => new InterestDTO
                    {
                        Title = pi.Interests.Title,
                        Description = pi.Interests.Description
                    }).ToList()

                }).FirstOrDefaultAsync();

            if (person == null)
            {
                return NotFound(new { errorMessage = "Person not found" });
            }

            return Ok(person);
        }

        [HttpGet ("{id}/link", Name = "GetPersonWithLinksById")]
        public async Task<ActionResult<GetPersonInterestDTO>>GetPersonWithLinksById(int id)
        {
            var person = await _context.Persons
                .Include(p => p.PersonInterests)
                .ThenInclude(pi => pi.Links)
                .Where(p => p.Id == id)
                .Select(p => new 
            {
                
            }).ToListAsync();

            return Ok();
        }
    }
}
