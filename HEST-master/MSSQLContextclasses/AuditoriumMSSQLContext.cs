using System;
using System.Collections.Generic;
using System.Text;
using InterfacesRepoProject;
using ModelLibary.Models;
using System.Data.SqlClient;


namespace MSSQLContextclasses
{
  public class AuditoriumMSSQLContext : IAuditoriumContext
  {

    public IReadOnlyCollection<AuditoriumClass> GetallAuditorium()
    {
      List<AuditoriumClass> auditorium = new List<AuditoriumClass>();
      using (SqlConnection connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (SqlCommand command = new SqlCommand())
      {
        command.Connection = connection;
        command.CommandText = "select * from Auditorium";


        connection.Open();
        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            auditorium.Add(new AuditoriumClass((int)reader[0], (string)reader[1], (string)reader[2], (int)reader[3]));

          }
        }
      }
      return auditorium;
    }


    public AuditoriumClass GetAuditorium(int id)
    {
      AuditoriumClass auditorium = null;

      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {

        command.Connection = connection;
        command.CommandText = "Select * from Auditorium  WHERE AuditoriumID = @Id";


        command.Parameters.AddWithValue("@Id", id);

        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            auditorium = new AuditoriumClass((int)reader[0], (string)reader[1], (string)reader[2], (int)reader[3]);
          }
        }
      }      
      return auditorium;
    }
  }
}
