namespace Backend.Business.Interfaces
{
    using Domain.Entities;
    using Optional;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenreService
    {
        IEnumerable<Genre> GetAll();

        Task<Option<Genre, Error>> GetAsync(int key);
    }
}
