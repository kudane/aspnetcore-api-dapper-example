namespace App.Business
{
    using App.Business.Interfaces;
    using App.Business.Services;
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
