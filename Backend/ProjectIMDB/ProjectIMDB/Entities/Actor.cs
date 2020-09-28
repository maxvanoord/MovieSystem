using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Entities
{
    public class Actor : EntityBase
    {
        [Key]
        public Guid ActorId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [MaxLength(200)]
        public string Info { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}
