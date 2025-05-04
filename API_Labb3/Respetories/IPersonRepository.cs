using API_Labb3.Models;

namespace API_Labb3.Respetories
{
    public interface IPersonRepository
    {
        public Task<IEnumerable<Person>> GetAll();
        public Task<Person?> GetById(int id);
        public Task CreatePerson(Person person);
        public Task<IEnumerable<Interest>> GetPersonInterest(int id);
    }
}
