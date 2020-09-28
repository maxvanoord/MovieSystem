using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Entities
{
    public class Movie : EntityBase
    {
        [Key]
        public Guid MovieId { get; set; }

        [Required]
        public string Title { get; set; }

        public Director Director { get; set; }
        
        public Guid DirectorId { get; set; }

        [Required]
        public string Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Runtime { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}
