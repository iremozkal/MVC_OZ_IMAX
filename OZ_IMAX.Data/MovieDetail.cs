using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_IMAX.Data
{
    public class MovieDetail : BaseClass
    {
        // It doesn't have its own id, it uses movie id from movie table as a primary key.
        public int MovieId { get; set; }
        public int OscarCount { get; set; }
        public DateTime ProductionYear { get; set; }
        public string Region { get; set; }
        public int MovieScore { get; set; }

        public Movie MovieOfTheDetail { get; set; }
    }
}
