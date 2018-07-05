using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibary.Models
{
  public class ReservationClass
  {
    public int Id { get; }

    public string Title { get; }

    public DateTime Date { get;}

    public Decimal Price { get;}

    public Boolean Paid { get;}

    private AuditoriumClass Auditorium { get; }

    public List<MovieClass> movies { get; }
  
    public ReservationClass()
    {

    }

    public ReservationClass(int id, string title, DateTime date, Decimal price, bool paid, AuditoriumClass auditorium)
    {
      this.Id = id;
      this.Title = title;
      this.Date = date;
      this.Price = price;
      this.Paid = paid;
      this.Auditorium = auditorium;
    }
  }
}
