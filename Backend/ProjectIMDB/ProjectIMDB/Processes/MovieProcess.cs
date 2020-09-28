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
        private readonly IMDBInterfaceRepository<Movie> _movies;

        public MovieProcess(InterfaceUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
            _movies = unitOfWork.GetRepository<Movie>();
        }

        // Retreive all movies in database
        public IQueryable<Movie> GetAllMovies()
        {
            var movies = _movies.GetAll()
                .Include(movie => movie.Director)
                .Include(movie => movie.MovieActors)
                .ThenInclude(movieActor => movieActor.Actor);

            return movies;
        }

        // Retreive specific movies with provided filters 
        public IEnumerable<MovieDtoOutput> GetMovies(SearchMovieFilter filter)
        {
            if (string.IsNullOrWhiteSpace(filter.SearchQuery))
                return _mapper.Map<IEnumerable<MovieDtoOutput>>(GetAllMovies().ToList());

            IQueryable<Movie> movies = GetAllMovies();
            movies = movies.Where(movie => movie.Title.Contains(filter.SearchQuery));
            
            return _mapper.Map<IEnumerable<MovieDtoOutput>>(movies.ToList());
        }

        // Retreive a movie with provided MovieId
        public MovieDtoOutput GetMovieById(Guid movieId)
        {
            var movieToReturn = _movies.GetAll()
                .Include(movie => movie.Director)
                .Include(movie => movie.MovieActors)
                .ThenInclude(movieActor => movieActor.Actor)
                .First(movie => movie.MovieId == movieId);

            return _mapper.Map<MovieDtoOutput>(movieToReturn);
        }

        // Adding a movie to a database
        public MovieDtoOutput InsertMovie(MovieDtoInput inputMovie)
        {
            // List of new Actor objects (still dto to remain some fields) refering to the movie
            ICollection<ActorDtoInput> actorsDtoInput = inputMovie.NewActors;
            ICollection<ActorDtoInputExisting> actorDtoInputExistings = inputMovie.ExistingActors;
            Movie movieToInsert = _mapper.Map<Movie>(inputMovie);

            Movie movie = InsertMovieMagic.Magic(movieToInsert, actorsDtoInput, actorDtoInputExistings, _mapper);

            _movies.Insert(movie);
            UnitOfWork.SaveChanges();

            return _mapper.Map<MovieDtoOutput>(GetMovieById(movie.MovieId));
        }

        // Editing an existing movie from database
        public void UpdateMovie(Guid movieId, MovieDtoInput UpdatedMovie)
        {
            Movie movieToUpdate = _mapper.Map<Movie>(GetMovieById(movieId));

            if (UpdatedMovie.Title != null)
                movieToUpdate.Title = UpdatedMovie.Title;
            
        }
    }
}
