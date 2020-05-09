using Domain.Entity;
using Frontend.Blazor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Blazor.Interface
{
    public interface IMovieService: IDisposable
    {
        Task LoadAsync(int genreId, int pageSize = 5, int pageNumber = 1);

        List<Movie> Movies { get; }

        string CurrentPage { get; }

        PaginationViewModel Pagination { get; }
    }
}
