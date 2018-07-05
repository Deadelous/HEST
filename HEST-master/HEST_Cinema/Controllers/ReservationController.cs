using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
  [Route("api/reservation")]
  public class ReservationController : Controller
  {
    private readonly ReservationRepo _repo = new ReservationRepo(new ReservationMSSQLContext());

    [HttpPost("Addreservation")]
    public void AddReservation([FromBody] ReservationClass reservation)
    {
      _repo.AddReservation(reservation);
    }

    [HttpDelete]
    public void DeleteReservation(int id)
    {
      _repo.DeleteReservation(id);
    }

    [HttpGet]
    public ReservationClass GetReservation(int id)
    {
      return _repo.GetReservation(id);
    }

    [HttpPost]
    public void UpdateReservation([FromBody] ReservationClass reservation)
    {
      _repo.UpdateReservation(reservation);
    }
  }
}
