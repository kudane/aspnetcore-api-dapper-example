namespace Frontend.Blazor.Interface
{
    using Domain.Entity;
    using Frontend.Blazor.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMovieService: IDisposable
    {
        Task LoadAsync(int genreId, int pageSize = 5, int pageNumber = 1, string search = "");

        List<Movie> Movies { get; }

        string CurrentPage { get; }

        PaginationViewModel Pagination { get; }
    }
}
