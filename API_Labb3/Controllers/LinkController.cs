using API_Labb3.Data;
using API_Labb3.Models;
using API_Labb3.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace API_Labb3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly PersonInterestDbContext _context;
        public LinkController(PersonInterestDbContext context)
        {
            _context = context;
        }

        [HttpGet("person", Name = "GetAllLinksConnectedToAPerson")]
        public async Task<ActionResult<GetPersonInterestDTO>> GetAllLinkConnectedToAPerson(int personId)
        {
            var linkToPerson = await _context.PersonInterests
                .Where(pi => pi.Id == personId)
                .Select(pi => new GetPersonInterestDTO
                {
                    FirstName = pi.Persons.Firstname,
                    LastName = pi.Persons.Lastname,
                    URL = pi.Links
                    .Select(l => new LinkDTO
                    {
                        URL = l.URL
                    }).ToList()

                }).ToListAsync();


            return Ok(linkToPerson);

        }

        /*Lägga till nya länkar för en specifik person och ett specifikt intresse*/

        [HttpPost("/CreateNewLink")]
        public async Task<ActionResult> CreateLink(int personId, int interestId, string createLink)
        {
            var personInterest = await _context.PersonInterests
                .FirstOrDefaultAsync(p => p.PersonID == personId && p.InterestID == interestId);

            if (personInterest is null)
            {
                return NotFound();
            }

            var linkToAdd = new Link()
            {
                URL = createLink,
                PersonInterests = personInterest
            };

            await _context.AddAsync(linkToAdd);
            await _context.SaveChangesAsync();

            //return CreatedAtAction((nameof(GetAllLinkConnectedToAPerson)), new { personId = linkToAdd.Id }, linkToAdd);
            return Ok(linkToAdd);
        }
    }
}
