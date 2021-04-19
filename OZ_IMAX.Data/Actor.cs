using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OZ_IMAX.Data
{
    public class Actor : BaseClass
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public DateTime ActorBirthDate { get; set; }
        public string ActorDescription { get; set; }
        public decimal ActorPayment { get; set; }

        // One Actor - Many Movie
        public List<Movie> MoviesOfTheActor { get; set; }
    }
}

/* 
 * using System.ComponentModel.DataAnnotations;
 * [Required]			Allow null:false default
 * [Key]				Primary Key
 * [MaxLength(50)]
 * [Display(Name="Actor Name")]
 */