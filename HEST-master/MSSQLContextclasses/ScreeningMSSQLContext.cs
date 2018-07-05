using System;
using System.Collections.Generic;
using System.Text;
using InterfacesRepoProject;
using ModelLibary.Models;
using System.Data.SqlClient;

namespace MSSQLContextclasses
{
  public class ScreeningMSSQLContext : IScreeningContext
  {

    public IEnumerable<ScreeningClass> GetAllTimeForScreening()
    {
      List<ScreeningClass> screenings = new List<ScreeningClass>();
      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {
        command.Connection = connection;
        command.CommandText = "Select * from Screening";

        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            screenings.Add((new ScreeningClass()));
          }
        }

      }
      return screenings.AsReadOnly();
    }

    public ScreeningClass GetScreening(int id)
    {
      ScreeningClass screening = null;

      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {
        command.Connection = connection;
        command.CommandText = "Select * from Screening where Screeningid = @Id";

        command.Parameters.AddWithValue("@Id", id);

        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {
          reader.Read();

          if (reader.HasRows)
          {
            screening = new ScreeningClass()
            {

            };

          }
          return screening;
        }
      }
    }
  }
}