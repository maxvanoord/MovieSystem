using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectIMDB.Dto.CreatingMovie;

namespace ProjectIMDB.Dto
{
    public class MovieDtoUpdate
    {
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

        // List must consist of only Actors whom are not known by the system yet
        public ICollection<ActorDtoInput> NewActors { get; set; }

        // List must consist of only ActorId's whom are known by the system
        public ICollection<ActorDtoInputExisting> ExistingActors { get; set; }
    }
}
