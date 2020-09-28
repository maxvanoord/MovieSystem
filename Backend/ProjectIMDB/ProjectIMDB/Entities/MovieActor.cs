using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Entities
{
    public class MovieActor : EntityBase
    {
        public Guid MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        public Guid ActorId { get; set; }

        [ForeignKey("ActorId")]
        public Actor Actor { get; set; }

        public bool IsStar {get; set;}
    }
}
