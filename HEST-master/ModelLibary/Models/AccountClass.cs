using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ModelLibary.Models
{
  public class AccountClass
  {

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }
    
    public string Adress { get; set; }

    public string City { get; set; }

    public string Postalcode { get; set; }

    public string Phonenumber { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public Decimal Credit { get; set; }

    public string PictureUrl { get; set; }

    public string Token { get; set; }

    public bool Valid { get; set; }

    public List<ReviewClass> reviews { get; }

    public AccountClass()
    {

    }

    public AccountClass(int id, string firstname, string lastname, string email, string adress, string username, Decimal credit, string picture)
    {
      Id = id;
      FirstName = firstname;
      LastName = lastname;
      Email = email;
      Adress = adress;
      Username = username;
      Credit = credit;
      PictureUrl = picture;
    }
  }
}
