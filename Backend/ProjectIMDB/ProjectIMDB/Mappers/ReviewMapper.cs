using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjectIMDB.Dto;
using ProjectIMDB.Entities;

namespace ProjectIMDB.Mappers
{
    public class ReviewMapper : Profile
    {
        public ReviewMapper()
        {
            CreateMap<ReviewDtoInput, Review>();

            CreateMap<Review, ReviewDtoOutput>();
        }
    }
}
