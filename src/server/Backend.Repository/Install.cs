namespace Backend.Repository
{
    using Backend.Repository.Interfaces;
    using Backend.Repository.Repositories;
    using Microsoft.Extensions.DependencyInjection;

    public static class Install
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
        }
    }
}
