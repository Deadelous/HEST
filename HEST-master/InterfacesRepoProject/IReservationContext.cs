using System;
using System.Collections.Generic;
using System.Text;
using ModelLibary.Models;

namespace InterfacesRepoProject
{
  public interface IReservationContext 
  {
    ReservationClass GetReservation(int id);

    void AddReservation(ReservationClass reservation);

    void UpdateReservation(ReservationClass reservation);

    void DeleteReservation(int id);
  }
}
