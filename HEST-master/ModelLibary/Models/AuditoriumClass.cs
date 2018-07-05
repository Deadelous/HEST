using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibary.Models
{
  public class AuditoriumClass
  {
    public int Id { get; }

    public string Name { get; }

    public string Description { get; }

    public string PictureURL { get; }

    public int Seats { get;}

    public ScreeningClass screening { get; }

    public AuditoriumClass()
    {

    }

    public AuditoriumClass(int id, string name, string description, int seats)
    {
      this.Id = id;
      this.Name = name;
      this.Description = description;
      this.Seats = seats;
    }
  }
}
