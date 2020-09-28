using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjectIMDB.Dto;
using ProjectIMDB.Entities;

namespace ProjectIMDB.Mappers
{
    public class ActorMapper : Profile
    {
        public ActorMapper()
        {
            CreateMap<ActorDtoInput, Actor>();

            CreateMap<Actor, ActorDtoOutput>();
        }
    }
}
