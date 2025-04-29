using API_Labb3.Data;
using API_Labb3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Labb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PiDbContext _context;

        public PersonController(PiDbContext context)
        {
            _context = context;
        }

        //to be able to get all the people in person
        [HttpGet (Name = "GetPerson")]
        public async Task<ActionResult<ICollection<Person>>> GetPerson()
        {
            return Ok(await _context.Persons.ToListAsync());
        }

        //to be able to seach by their id
        [HttpGet (Name = "GetPersonById")]
        public async Task<ActionResult<ICollection<Person>>> GetPersonById(int id)
        {
            return Ok(await _context.Persons.FindAsync(id));
        }

        //to be able to create a new person 
        [HttpPost(Name = "CreatePerson")]
        public async Task<IActionResult> CreatePerson(Person newPerson)
        {
            if(newPerson == null)
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

            await _context.AddAsync(personToAdd);
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
