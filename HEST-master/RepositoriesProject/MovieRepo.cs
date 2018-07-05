using System;
using System.Collections.Generic;
using System.Text;
using InterfacesRepoProject;
using ModelLibary.Models;
using MSSQLContextclasses;

namespace RepositoriesProject
{
  public class MovieRepo 
  {
    private IMovieContext _context;

    public MovieRepo(IMovieContext context)
    {
      this._context = context;
    }

    public void AddMovie(int id, string title, string director, DateTime releasedate)
    {
      _context.AddMovie(id,title,director, releasedate);
    }

    public void DeleteMovie(int id)
    {
      _context.DeleteMovie(id);
    }

    public IReadOnlyCollection<MovieClass> GetAllMovies()
    {
      return _context.GetAllMovies();
    }

    public MovieClass GetMovie(int id)
    {
      return _context.GetMovie(id);
    }

    public void ChangeMovie(MovieClass movie)
    {
      _context.ChangeMovie(movie);
    }
  }
}
