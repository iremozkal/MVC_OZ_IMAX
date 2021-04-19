using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_IMAX.Data
{
	public class Movie : BaseClass
	{
		public int MovieId { get; set; }
		public string MovieName { get; set; }
		public string MovieDescription { get; set; }
		public decimal MovieBudget { get; set; }

		// One Movie - One Category
		public int MovieCategoryId { get; set; }
		public virtual MovieCategory CategoryOfTheMovie { get; set; }

		// One Movie - Many Actors
		public virtual List<Actor> ActorsOfTheMovie { get; set; }

		// One Movie - One Detail
		public MovieDetail DetailOfTheMovie { get; set; }
	}
}
