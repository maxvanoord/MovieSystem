using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using ProjectIMDB.Dto;
using ProjectIMDB.Dto.CreatingMovie;
using ProjectIMDB.Entities;
using ProjectIMDB.Helpers;
using ProjectIMDB.Repository;

namespace ProjectIMDB.Processes
{
    public class MovieProcess : ProcessBase
    {
        private readonly IMapper _mapper;
        private readonly IMDBInterfaceRepository<Movie> _movieRepo;

        public MovieProcess(InterfaceUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
            _movieRepo = unitOfWork.GetRepository<Movie>();
        }

        // Retreive all movies in database
        public IQueryable<Movie> GetAllMovies()
        {
            var allMovies = _movieRepo.GetAll()
                .Include(movie => movie.Director)
                .Include(movie => movie.MovieActors)
                    .ThenInclude(movieActor => movieActor.Actor);

            return allMovies;
        }

        // Retreive specific movies with provided filters 
        public List<MovieDtoOutput> GetMoviesFilter(SearchMovieFilter filter)
        {
            var query = GetAllMovies();

            switch (filter.SortBy)
            {
                case "title":
                    if (filter.Order == "asc")
                        query = query.OrderBy(k => k.Title);
                    else { query = query.OrderByDescending(k => k.Title); }
                    break;
                case "directorName":
                    if (filter.Order == "asc")
                        query = query.OrderBy(k => k.Director.Name);
                    else { query = query.OrderByDescending(k => k.Director.Name); }
                    break;
            }

            return _mapper.Map<List<MovieDtoOutput>>(query.ToList());
        }

        // Retreive a movie with provided MovieId
        public MovieDtoOutput GetMovieDtoById(Guid movieId)
        {
            var movieToReturn = _movieRepo.GetAll()
                .Include(movie => movie.Director)
                .Include(movie => movie.MovieActors)
                .ThenInclude(movieActor => movieActor.Actor)
                .First(movie => movie.MovieId == movieId);

            return _mapper.Map<MovieDtoOutput>(movieToReturn);
        }

        public Movie GetMovieById(Guid movieId)
        {
            var movieToReturn = _movieRepo.GetAll()
                .Include(movie => movie.Director)
                .Include(movie => movie.MovieActors)
                .ThenInclude(movieActor => movieActor.Actor)
                .First(movie => movie.MovieId == movieId);

            return movieToReturn;
        }


        // Adding a movie to a database
        public MovieDtoOutput InsertMovie(MovieDtoInput inputMovie)
        {
            // List of new Actor objects (still dto to remain some fields) refering to the movie
            ICollection<ActorDtoInput> actorsDtoInput = inputMovie.NewActorInstances;
            ICollection<ActorDtoInputExisting> actorDtoInputExistings = inputMovie.ExistingActorGuids;
            Movie movieToInsert = _mapper.Map<Movie>(inputMovie);

            // Mapping the related entities to the Movie 
            Movie movie = InsertMovieHelper.MapRelational(movieToInsert, actorsDtoInput, actorDtoInputExistings, _mapper);

            _movieRepo.Insert(movie);
            UnitOfWork.SaveChanges();

            return _mapper.Map<MovieDtoOutput>(GetMovieDtoById(movie.MovieId));
        }

        // Editing an existing movie from database
        public MovieDtoOutput UpdateMovie(Guid movieId, MovieDtoUpdate UpdatedMovie)
        {
            // Changing the movie to updated one
            _movieRepo.Update(_mapper.Map<Movie>(UpdatedMovie));
            UnitOfWork.SaveChanges();

            return GetMovieDtoById(movieId);

        }
    }
}
