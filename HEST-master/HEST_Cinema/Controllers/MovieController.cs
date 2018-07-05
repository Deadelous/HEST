using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibary;
using MSSQLContextclasses;
using InterfacesRepoProject;
using ModelLibary.Models;
using RepositoriesProject;

namespace HEST_Cinema.Controllers
{
  [Produces("application/json")]
  [Microsoft.AspNetCore.Mvc.Route("api/movie")]
  public class MovieController : Controller
  {
    private readonly MovieRepo _repo = new MovieRepo(new MovieMSSQLContext());

    [HttpPost("AddMovie")]
    public void AddMovie([Microsoft.AspNetCore.Mvc.FromBody]Tuple<int, string, string, DateTime> parameters)
    {
      _repo.AddMovie(parameters.Item1, parameters.Item2, parameters.Item3, parameters.Item4);
    }
    
    [HttpGet("{id}")]
    public ActionResult GetMovie (int id)
    {
        var movie = _repo.GetMovie(id);
        return Ok(movie);   
    }

    [HttpGet("GetAllMovies")]
    public ActionResult GetAllMovies()
    {
      return Ok(_repo.GetAllMovies());
    }

    [HttpPost("Changemovie")]
    public void ChangeMovie(MovieClass movie)
    {
       _repo.ChangeMovie(movie);
    }

    [HttpDelete("DeleteMovie")]
    public void DeleteMovie([Microsoft.AspNetCore.Mvc.FromBody] MovieClass movie)
    {
      _repo.DeleteMovie(movie.Id);
    }
  }
}
