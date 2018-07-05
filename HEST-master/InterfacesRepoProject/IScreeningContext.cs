using System;
using System.Collections.Generic;
using System.Text;
using ModelLibary.Models;

namespace InterfacesRepoProject
{
  public interface IScreeningContext 
  {
    ScreeningClass GetScreening(int id);

    IEnumerable<ScreeningClass> GetAllTimeForScreening();
  }
}
