namespace Frontend.Blazor.Extensions
{
    public class EndpointExtension
    {
        public static string GetMovie(int genreId, int pageSize, int pageNumber, string search)
        {
            return $"api/genre/{genreId}/movies?pagesize={pageSize}&pagenumber={pageNumber}&search={search}";
        }
    }
}
