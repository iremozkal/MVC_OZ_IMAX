using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_IMAX.Data
{
    public class MovieCategory : BaseClass
    {
        public int MovieCategoryId { get; set; }
        public string CategoryName { get; set; }

        // One Category - Many Movie
        public List<Movie> MoviesOfTheCategory { get; set; }
    }
}
