using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectIMDB.Entities;

namespace ProjectIMDB.Dto
{
    public class DirectorDtoOutput
    {
        public Guid DirectorId { get; set; }

        public string Name { get; set; }

        //public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
