using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibary.Models
{
  public class ReviewClass
  {
    public int Id { get; }

    public string Name { get;}

    public string Description { get; }

    public Decimal Rating { get;}

    public DateTime Date { get; }

    public int MovieID { get;}

    public int AccountID { get;}

    public string AccountName { get;  }

    public string MovieName { get; }
 
    public ReviewClass()
    {

    }

    public ReviewClass(int id, string name, string description, Decimal rating, DateTime date, int accountid, string accountname, int movieid,string movieName)
    {
      this.Id = id;
      this.Name = name;
      this.Description = description;
      this.Rating = rating;
      this.Date = date;
      this.AccountID = accountid;
      this.AccountName = accountname;
      this.MovieID = movieid;
      this.MovieName = movieName;
    }
  }
}
