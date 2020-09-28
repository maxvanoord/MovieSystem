using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Entities
{
    public class Review : EntityBase
    {
        [Key]
        public Guid ReviewId { get; set; }

        [Required]
        public Guid MovieId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        [Required]
        public bool Rating { get; set; }

        [MaxLength(40)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Body { get; set; }
    }
}
