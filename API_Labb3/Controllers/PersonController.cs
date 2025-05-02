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
    public class PersonController : ControllerBase
    {
        private readonly PersonInterestDbContext _context;

        public PersonController(PersonInterestDbContext context)
        {
            _context = context;
        }

        // get all the people in person
        [HttpGet(Name = "GetPerson")]
        public async Task<ActionResult<ICollection<CreatePersonDTO>>> GetPerson()
        {
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
        [HttpGet("{id}", Name = "GetPersonById")]
        public async Task<ActionResult<ICollection<GetPersonInterestDTO>>> GetPersonById(int id)
        {
            var person = await _context.Persons
                .Where(p => p.Id == id)
                .Select(P => new GetPersonInterestDTO
                {
                    FirstName = P.Firstname,
                    LastName = p.LastName,
                    //Interests = new InterestDTO { Title = P.}

                }).FirstOrDefaultAsync();


            return Ok(await _context.Persons.FindAsync(id));
        }

        // create a new person 
        [HttpPost(Name = "CreatePerson")]
        public async Task<IActionResult> CreatePerson(Person newPerson)
        {
            if (newPerson == null)
            {
                return BadRequest(new { errorMessage = "Data is missing" });
            }

            var personToAdd = new Person()
            {
                Firstname = newPerson.Firstname,
                Lastname = newPerson.Lastname,
                Age = newPerson.Age,
                Phone = newPerson.Phone
            };

             _context.AddAsync(personToAdd);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonById), new { id = personToAdd.Id }, personToAdd);
        }

        //update part
        //[HttpPut(Name = "UpdatePerson")]
        //public async Task<IActionResult> UpdatePerson(int id, Person updatePerson)
        //{
        //    //var personToUpdate = await _context.Update(id);

        //    if ()
        //}
    }
}
