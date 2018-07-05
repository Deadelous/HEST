using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibary;
using MSSQLContextclasses;
using InterfacesRepoProject;
using ModelLibary.Models;
using RepositoriesProject;

namespace HEST_Cinema.Controllers
{
  [Produces("application/json")]
  [Route("api/screening")]
  public class ScreeningController : Controller
    {
    private readonly ScreeningRepo _repo = new ScreeningRepo(new ScreeningMSSQLContext());

    [HttpGet]
    public IEnumerable<ScreeningClass> GetAllTimeForScreening()
    {
     return _repo.GetAllTimeForScreening();
    }

    [HttpGet]
    public ScreeningClass GetScreening(int id)
    {
      return _repo.GetScreening(id);
    }
  }
}
