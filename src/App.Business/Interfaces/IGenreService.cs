namespace App.Business.Interfaces
{
    using App.Data.Repository.Entities;
    using Optional;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenreService
    {
        IEnumerable<Genre> GetAll();

        Task<Option<Genre, Error>> Get(int key);
    }
}
