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
  [Route("api/auditorium")]
  public class AuditoriumController : Controller
    {
    private readonly AuditoriumRepo _repo = new AuditoriumRepo(new AuditoriumMSSQLContext());

 
    [HttpGet("GetallAuditorium")]
    public ActionResult GetAllAuditorium()
    {
      return Ok(_repo.GetallAuditorium());
    }

    [HttpGet("GetAuditoirum")]
    public AuditoriumClass GetAuditorium(int id)
    {
      return _repo.GetAuditorium(id);
    }
  }
}
