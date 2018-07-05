using System;
using System.Collections.Generic;
using System.Text;
using ModelLibary.Models;

namespace InterfacesRepoProject
{
  public interface IAuditoriumContext 
  {
    IReadOnlyCollection<AuditoriumClass> GetallAuditorium();

    AuditoriumClass GetAuditorium(int id);
  }
}
