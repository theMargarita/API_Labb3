using API_Labb3.Data;
using API_Labb3.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Labb3.Respetories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonInterestDbContext _context;

        public PersonRepository(PersonInterestDbContext context)
        {
            _context = context;
        }

        public async Task CreatePerson(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person?> GetById(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<ICollection<Interest>> GetPersonInterest(int id)
        {
            var personInterests = await _context.PersonInterests
                .Where(pi => pi.Id == id).Include(p => p.Persons)
                .Select(pi => new Interest
                {
                    Title = pi.Interests.Title,
                    Description = pi.Interests.Description,
                  
                }).ToListAsync();

            return personInterests;
        }
    }
}
