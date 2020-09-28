using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjectIMDB.Dto;
using ProjectIMDB.Entities;

namespace ProjectIMDB.Mappers
{
    public class DirectorMapper : Profile
    {
        public DirectorMapper()
        {
            CreateMap<DirectorDtoInput, Director>();

            CreateMap<Director, DirectorDtoOutput>();
        }
    }
}
