using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Helpers
{
    public class SearchMovieFilter
    {
        public string SearchQuery { get; set; }
        public string SortBy { get; set; }
        public string Order { get; set; }
    }
}
