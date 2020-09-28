using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjectIMDB.Dto;
using ProjectIMDB.Dto.CreatingMovie;
using ProjectIMDB.Entities;

namespace ProjectIMDB.Helpers
{
    public class InsertMovieMagic
    {
        public static Movie Magic(Movie movieToInsert, ICollection<ActorDtoInput> actorsDtoInput, ICollection<ActorDtoInputExisting> actorDtoInputExistings, IMapper mapper)
        {
            // Adding (NEW ACTOR OBJECTS) relational instances to the new movie object 
            if (actorsDtoInput != null)
            {
                foreach (ActorDtoInput actor in actorsDtoInput)
                {
                    movieToInsert.MovieActors.Add(new MovieActor
                    {
                        Movie = movieToInsert,
                        Actor = mapper.Map<Actor>(actor),
                        IsStar = actor.IsStarInThisMovie
                    });
                }
            }

            // Adding (EXISTING ACTOR ID'S) to the new movie object to define relations
            if (actorDtoInputExistings != null)
            {
                foreach (ActorDtoInputExisting actor in actorDtoInputExistings)
                {
                    movieToInsert.MovieActors.Add(new MovieActor
                    {
                        MovieId = movieToInsert.MovieId,
                        ActorId = actor.Guid,
                        IsStar = actor.IsStarInThisMovie
                    });
                }
            }

            return movieToInsert;
        }
    }
}
