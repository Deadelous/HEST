using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibary.Models
{
  public class MovieClass
  {
    public int Id { get; }

    public string Title { get; }

    public string Director { get; }

    public string Description { get; }

    public DateTime Releasedate { get; }

    public string Poster { get; }

    public string Trailer { get; }

    public string Genre { get; }

    public decimal Rating { get; }

    public int Price { get; }

    public List<ReviewClass> reviews { get; }

 
    public MovieClass()
    {

    }

    public MovieClass(int id, string title, string director, string description, string genre, DateTime releasedate,
      decimal rating, string trailer, string poster, int price)
    {
      this.Id = id;
      this.Title = title;
      this.Director = director;
      this.Description = description;
      this.Genre = genre;
      this.Releasedate = releasedate;
      this.Rating = rating;
      this.Trailer = trailer;
      this.Poster = poster;
      this.Price = price;
    }
  }
}
