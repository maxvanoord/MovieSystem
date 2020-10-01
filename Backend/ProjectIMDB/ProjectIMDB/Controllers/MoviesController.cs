using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectIMDB.Context;
using ProjectIMDB.Dto;
using ProjectIMDB.Entities;
using ProjectIMDB.Helpers;
using ProjectIMDB.Processes;
using ProjectIMDB.Repository;

namespace ProjectIMDB.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieProcess _movieProcess;

        public MoviesController(MovieProcess movieProcess)
        {
            _movieProcess = movieProcess;
        }

        [HttpGet]
        public IEnumerable<MovieDtoOutput> GetMovies([FromQuery] SearchMovieFilter filter)
        {
            return _movieProcess.GetMoviesFilter(filter);
        }

        [HttpGet("{movieId}", Name = "GetMovieById")]
        public ActionResult<MovieDtoOutput> GetMovieById(Guid movieId)
        {
            return _movieProcess.GetMovieDtoById(movieId);
        }

        [HttpPost("addmovie")]
        public ActionResult<MovieDtoOutput> AddMovie([FromBody] MovieDtoInput inputMovie)
        {
            MovieDtoOutput movieCreated = _movieProcess.InsertMovie(inputMovie);

            return CreatedAtRoute("GetMovieById", new { movieId = movieCreated.MovieId }, movieCreated);
        }

        [HttpPost("update/{movieId}")]
        public ActionResult<MovieDtoOutput> UpdateMovie(Guid movieId, MovieDtoUpdate updatedMovie)
        {
            var res = _movieProcess.UpdateMovie(movieId, updatedMovie);

            return res;
        }
    }
}
