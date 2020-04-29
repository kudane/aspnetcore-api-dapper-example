namespace App.Data.Repository.Repositories
{
    using App.Data.Repository.Entities;
    using App.Data.Repository.Interfaces;
    using App.Data.Repository.Repositories.Base;
    using App.Data.Context.Interfaces;

    internal class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ISqlServerContext context) : base(context.Connection)
        { 
        }
    }
}
