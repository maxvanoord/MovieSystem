using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Dto.CreatingMovie
{
    public class ActorDtoInputExisting
    {
        public Guid Guid { get; set; }
        public bool IsStarInThisMovie { get; set; }
    }
}
