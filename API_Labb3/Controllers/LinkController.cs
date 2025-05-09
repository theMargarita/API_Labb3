﻿using API_Labb3.Data;
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

        [HttpGet("{id}/person", Name = "GetLinkById")]
        public async Task<ActionResult<GetPersonInterestDTO>> GetLinkById(int id)
        {
            var linkToPerson = await _context.PersonInterests
                .Where(pi => pi.Id == id)
                .Select(pi => new GetPersonInterestDTO
                {
                    FirstName = pi.Persons.Firstname,
                    LastName = pi.Persons.Firstname,
                    LinkPerson = pi.Links.Select(l => new LinkDTO
                    {
                        URL = l.URL
                    }).ToList()

                }).FirstOrDefaultAsync();


            return Ok(linkToPerson);

        }

        [HttpPost ( Name = "CreateNewLink")]
        public async Task<ActionResult<Link>> CreateLink(int id, Link createLink)
        {
            if(createLink == null)
            {
                return BadRequest(new { errorMessage = "Data missing"});
            }

            var linkToAdd = new Link()
            {
                URL = createLink.URL
            };
            await _context.AddAsync(linkToAdd);
            //return CreatedAtAction(nameof(GetPersonById), new { id = personToAdd.Id }, personToAdd);

            return CreatedAtAction((nameof(GetLinkById)), new { id = linkToAdd.Id}, linkToAdd);
        }
    }
}
