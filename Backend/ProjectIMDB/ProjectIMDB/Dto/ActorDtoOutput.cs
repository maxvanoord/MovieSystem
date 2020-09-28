using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Dto
{
    public class ActorDtoOutput
    {
        public Guid ActorId { get; set; }

        public string Name { get; set; }

        public string Info { get; set; }
    }
}
