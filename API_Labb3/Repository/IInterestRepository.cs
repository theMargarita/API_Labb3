using API_Labb3.Models;

namespace API_Labb3.Respetories
{
    public interface IInterestRepository
    {
        public Task<IEnumerable<Interest>> GetAllInterest();
        public Task<Interest> GetById(int id);
        public Task CreateTask(Interest interst);

        //person with interest 
        public Task<IEnumerable<Person>> GetPersonWithInterests(int id);
    }
}
