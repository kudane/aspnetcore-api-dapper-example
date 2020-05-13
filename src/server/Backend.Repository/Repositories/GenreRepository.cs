namespace Backend.Repository.Repositories
{
    using Backend.Context.Interfaces;
    using Backend.Repository.Interfaces;
    using Backend.Repository.Repositories.Base;
    using Domain.Entity;

    internal class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ISqlServerContext context) : base(context.Connection)
        { 
        }
    }
}
