using API_Labb3.Data;
using API_Labb3.Models;
using API_Labb3.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace API_Labb3.Respetories
{
    public class LinkRepository : ILinkRepository
    {
        private readonly PersonInterestDbContext _context;
        public LinkRepository(PersonInterestDbContext context)
        {
            _context = context;
        }
        public Task<ICollection<Link>> AddLink(Link link)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Link>> GetLink()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonInterest>> PersonWithLinks()
        {
            throw new NotImplementedException();

            //var personInterestLinks = await _context.PersonInterests
            //    .Where(pi => pi.Id == id)
            //    .Include(pi => pi.Interests)
            //    .Select(p => new Person
            //    {
            //      Firstname = p.Persons.Firstname,
            //      Lastname = p.Persons.Lastname,
            //      PersonInterests = p.Links.SelectMany(l => new LinkDTO
            //      {
            //          URL = l.URL

            //      }).ToList()
            //    }).ToListAsync();

            //return personInterestLinks;
        }
    }
}
