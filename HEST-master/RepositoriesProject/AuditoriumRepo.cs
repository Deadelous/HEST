using System;
using System.Collections.Generic;
using System.Text;
using InterfacesRepoProject;
using ModelLibary.Models;
using MSSQLContextclasses;

namespace RepositoriesProject
{
  public class AuditoriumRepo
  {
    private IAuditoriumContext _context;

    public AuditoriumRepo(IAuditoriumContext context)
    {
      this._context = context;
    }

    public IReadOnlyCollection<AuditoriumClass> GetallAuditorium()
    {
      return _context.GetallAuditorium();
    }

    public AuditoriumClass GetAuditorium(int id)
    {
      return _context.GetAuditorium(id);
    }
  }
}
