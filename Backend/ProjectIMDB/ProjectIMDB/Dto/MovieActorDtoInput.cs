using System;
using ProjectIMDB.Entities;

namespace ProjectIMDB.Dto
{
    public class MovieActorDtoInput
    {
        public ActorDtoInput Actor { get; set; }

        public bool IsStar { get; set; }
    }
}