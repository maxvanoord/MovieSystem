using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Dto
{
    public class ActorDtoInput
    {
        public string Name { get; set; }

        public string Info { get; set; }

        public bool IsStarInThisMovie { get; set; }

    }
}
