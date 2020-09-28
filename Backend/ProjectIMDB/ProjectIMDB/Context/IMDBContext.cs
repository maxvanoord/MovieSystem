using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectIMDB.Entities;

namespace ProjectIMDB.Context
{
    public class IMDBContext : DbContext
    {
        public IMDBContext(DbContextOptions<IMDBContext> options) : base(options)
        {
        }


        // List here Classes that should be mapped to database tables
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<MovieActor> MovieActor { get; set; }


        // Contains configuration information for EF Core
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieId, ma.ActorId });
            
        }
    }
}
