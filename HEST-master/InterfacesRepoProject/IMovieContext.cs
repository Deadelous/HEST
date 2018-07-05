using System;
using System.Collections.Generic;
using System.Text;
using ModelLibary.Models;

namespace InterfacesRepoProject
{
  public interface IMovieContext 
  {
    MovieClass GetMovie(int movieid);

    IReadOnlyCollection<MovieClass> GetAllMovies();

    void AddMovie(int id, string title, string director, DateTime releasedate);

    void ChangeMovie(MovieClass movie);

    void DeleteMovie(int id);

  }
}
