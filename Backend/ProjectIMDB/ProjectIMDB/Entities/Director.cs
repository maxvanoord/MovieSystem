using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Entities
{
    public class Director : EntityBase
    {
        [Key]
        public Guid DirectorId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
