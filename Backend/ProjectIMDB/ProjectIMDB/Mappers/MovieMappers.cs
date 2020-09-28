using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjectIMDB.Dto;
using ProjectIMDB.Entities;
using ProjectIMDB.Helpers;

namespace ProjectIMDB.Mappers
{
    public class MovieMappers : Profile
    {
        public MovieMappers()
        {
            CreateMap<MovieDtoInput, Movie>();

            CreateMap<Movie, MovieDtoUpdate>();

            CreateMap<Movie, MovieDtoOutput>()
                .ForMember(
                    destinationMember => destinationMember.ReleaseDate,
                    option => option.MapFrom(sourceMember => $"{sourceMember.ReleaseDate:dd MMMM yyyy}"))
                .ForMember(
                    destinationMember => destinationMember.Runtime,
                    option => option.MapFrom(sourceMember => TimeConverter.ToMovieTime(sourceMember.Runtime)));
        }
    }
}
