using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibary.Models
{
  public class ScreeningClass
  {
    public int Id { get;  }

    public string Title { get; }

    public DateTime Date { get; }

    public DateTime Starttime { get;  }

  
    public List<MovieClass> Movies { get; }

    public ScreeningClass()
    {

    }

    public ScreeningClass(int id, string title, DateTime starttime)
    {
      this.Id = id;
      this.Title = title;
      this.Starttime = starttime;
    }
  }
}
