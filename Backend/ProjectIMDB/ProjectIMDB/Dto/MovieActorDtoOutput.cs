using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Dto
{
    public class MovieActorDtoOutput
    {
        public ActorDtoOutput Actor { get; set; }

        public bool IsStar { get; set;  }
    }
}
