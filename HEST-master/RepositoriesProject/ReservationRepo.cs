using System;
using System.Collections.Generic;
using System.Text;
using InterfacesRepoProject;
using ModelLibary.Models;
using MSSQLContextclasses;

namespace RepositoriesProject
{
  public class ReservationRepo 
  {
    private IReservationContext _context;

    public ReservationRepo(IReservationContext context)
    {
      this._context = context;
    }

    public void AddReservation(ReservationClass reservation)
    {
      _context.AddReservation(reservation);
    }

    public void DeleteReservation(int id)
    {
      _context.DeleteReservation(id);
    }

    public ReservationClass GetReservation(int id)
    {
      return _context.GetReservation(id);
    }

    public void UpdateReservation(ReservationClass reservation)
    {
      _context.UpdateReservation(reservation);
    }
  }
}
