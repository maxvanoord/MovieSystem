using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectIMDB.Entities;

namespace ProjectIMDB.Dto
{
    public class MovieDtoOutput
    {
        public Guid MovieId { get; set; }

        public string Title { get; set; }

        public DirectorDtoOutput Director { get; set; }

        public string Genre { get; set; }

        public string ReleaseDate { get; set; }

        public string Runtime { get; set; }

        public string Description { get; set; }

        public List<MovieActorDtoOutput> MovieActors = new List<MovieActorDtoOutput>();
    }
}
