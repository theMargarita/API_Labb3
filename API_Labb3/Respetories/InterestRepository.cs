using API_Labb3.Data;
using API_Labb3.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Labb3.Respetories
{
    public class InterestRepository : IInterestRepository
    {
        private readonly PersonInterestDbContext _context;
        public InterestRepository(PersonInterestDbContext context)
        {
            _context = context;
        }
        public async Task CreateTask(Interest interest)
        {
            await _context.Interests.AddAsync(interest);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Interest>> GetAllInterest()
        {
            return await _context.Interests.ToListAsync();
        }

        public async Task<Interest?> GetById(int id)
        {
            return await _context.Interests.FindAsync(id);
        }

        public async Task<IEnumerable<Person>> GetPersonWithInterests(int id)
        {
            var personWithInterest = await _context.PersonInterests
                .Where(pi => pi.Id == id)
                .Select(pi => new Person
                {
                    Firstname = pi.Persons.Firstname,
                    Lastname = pi.Persons.Lastname,
                    Age = pi.Persons.Age,
                    Phone = pi.Persons.Phone
                }).ToListAsync();

            return personWithInterest.ToList();
                
        }
    }
}
