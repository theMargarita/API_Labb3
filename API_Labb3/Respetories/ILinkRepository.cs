using API_Labb3.Models;

namespace API_Labb3.Respetories
{
    public interface ILinkRepository
    {
        public Task<ICollection<Link>> AddLink(Link link);

        public Task<IEnumerable<Link>> GetLink();

        public Task<IEnumerable<PersonInterest>> PersonWithLinks();

    }
}
