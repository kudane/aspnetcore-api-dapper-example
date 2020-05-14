namespace Frontend.Blazor.Data
{
    using Domain.Entity;
    using Domain.Entity.Produces;
    using Frontend.Blazor.Extensions;
    using Frontend.Blazor.Interface;
    using Frontend.Blazor.ViewModels;
    using Microsoft.AspNetCore.Components;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class MovieService : IMovieService
    {
        private readonly HttpClient _http;
        private PageResult<Movie> _pageResult;

        public MovieService(HttpClient http)
        {
            _http = http;
            _pageResult = new PageResult<Movie>();
            Pagination = new PaginationViewModel();
        }

        #region Get, Set
        public List<Movie> Movies => _pageResult.Items ?? (_pageResult.Items = new List<Movie>());

        public string CurrentPage => _pageResult.CurrentPage.ToString();

        public PaginationViewModel Pagination { get; }
        #endregion

        #region Method
        public async Task LoadAsync(int genreId, int pageSize = 5, int pageNumber = 1, string search = "")
        {
            var url = EndpointExtension.GetMovie(genreId, pageSize, pageNumber, search);
            _pageResult = await _http.GetJsonAsync<PageResult<Movie>>(url);
            Pagination.PageToPager(pageNumber, _pageResult.TotalPages);
        }

        public void Dispose()
        {
            _pageResult.Items.Clear();
            Pagination.PageItems.Clear();
            Pagination.PageItems = null;
        }
        #endregion
    }
}
