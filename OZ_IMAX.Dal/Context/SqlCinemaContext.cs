using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OZ_IMAX.Data;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OZ_IMAX.Dal.Context
{
    public class SqlCinemaContext : DbContext
    {
        public SqlCinemaContext()
            : base("Server=.; Database=CinemaDB; Integrated Security=SSPI")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Movie> MovieTable { get; set; }
        public DbSet<MovieCategory> MovieCategoryTable { get; set; }
        public DbSet<Actor> ActorTable { get; set; }
        public DbSet<MovieDetail> MovieDetailTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Actor>().ToTable("Actors");
            // It changes the table name from actor to actors.

            // Set movieId to primary key
            modelBuilder.Entity<Movie>().HasKey(x => x.MovieId);

            // Set the annotations one after the other.
            modelBuilder.Entity<Movie>().Property(x => x.MovieName).HasMaxLength(50).IsRequired().HasColumnName("Movie Name");

            // HasRequired for One, HasMany for Many
            // ONE movie HAS ONE category. ONE category HAS MANY movie. (ONE to MANY)

            // One to Many
            modelBuilder.Entity<Movie>().HasRequired(x => x.CategoryOfTheMovie)
                .WithMany(x => x.MoviesOfTheCategory).HasForeignKey(x => x.MovieCategoryId);

            // Many to One
            modelBuilder.Entity<MovieCategory>().HasMany(x => x.MoviesOfTheCategory)
                .WithRequired(x => x.CategoryOfTheMovie).HasForeignKey(x => x.MovieCategoryId);

            // ONE movie HAS MANY actor. ONE actor HAS MANY movie. (MANY to MANY)
            modelBuilder.Entity<Movie>().HasMany(x => x.ActorsOfTheMovie)
                .WithMany(x => x.MoviesOfTheActor);

            // ONE MovieDetail HAS ONE Movie, ONE Movie HAS ONE MovieDetail. (ONE to ONE)
            // From movie to detail
            modelBuilder.Entity<MovieDetail>().HasRequired(x => x.MovieOfTheDetail)
                .WithOptional(x => x.DetailOfTheMovie);

            // From detail to movie
            // modelBuilder.Entity<Movie>().HasOptional(x => x.DetailOfTheMovie).WithRequired(x => x.MovieOfTheDetail);

            // Also, MovieDetail doesn't have its own primary key, it uses Movies'.
            modelBuilder.Entity<MovieDetail>().HasKey(x => x.MovieId);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
