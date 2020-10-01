using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectIMDB.Dto.CreatingMovie;
using ProjectIMDB.Entities;

namespace ProjectIMDB.Dto
{
    public class MovieDtoUpdate
    {
        public Guid MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }

        // Date must be in folowing json format: "year-month-day (f.e.(2010-7-15))"
        public DateTime ReleaseDate { get; set; }
        public int Runtime { get; set; }
        
        // Used for creating new Director entity linked to the movie
        public DirectorDtoInput Director { get; set; }
        
        // Used for linking an existing Director to the movie
        public Guid DirectorId { get; set; }

        public ICollection<MovieActorDtoInput> MovieActors { get; set; }
    }
}
