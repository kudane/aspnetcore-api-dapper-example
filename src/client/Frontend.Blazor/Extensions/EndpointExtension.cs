using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Blazor.Extensions
{
    public class EndpointExtension
    {
        public static string GetMovie(int genreId, int pageSize, int pageNumber)
        {
            return $"api/genre/{genreId}/movies?pagesize={pageSize}&pagenumber={pageNumber}";
        }
    }
}
