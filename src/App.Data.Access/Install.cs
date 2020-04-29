namespace App.Data.Repository
{
    using App.Data.Repository.Interfaces;
    using App.Data.Repository.Repositories;
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
