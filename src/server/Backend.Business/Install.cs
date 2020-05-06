namespace Backend.Business
{
    using Backend.Business.Interfaces;
    using Backend.Business.Services;
    using Microsoft.Extensions.DependencyInjection;

    public static class Install
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IGenreService, GenreService>();
        }
    }
}
