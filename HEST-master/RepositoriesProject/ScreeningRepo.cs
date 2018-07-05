using System;
using System.Collections.Generic;
using System.Text;
using InterfacesRepoProject;
using ModelLibary.Models;
using MSSQLContextclasses;

namespace RepositoriesProject
{
  public class ScreeningRepo
  {
    private IScreeningContext _context;

    public ScreeningRepo(IScreeningContext context)
    {
      this._context = context;
    }

    public IEnumerable<ScreeningClass> GetAllTimeForScreening()
    {
      return _context.GetAllTimeForScreening();
    }

    public ScreeningClass GetScreening(int id)
    {
      return _context.GetScreening(id);
    }
  }
}
