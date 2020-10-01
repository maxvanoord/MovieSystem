using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Helpers
{
    public class SearchMovieFilter
    {
        public string SortBy { get; set; }          // Must be an Movie field
        public string Order { get; set; }           // Must be ascending or descending
    }
}
