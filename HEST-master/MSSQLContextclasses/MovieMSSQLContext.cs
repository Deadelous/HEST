using System;
using System.Collections.Generic;
using System.Text;
using InterfacesRepoProject;
using ModelLibary.Models;
using System.Data.SqlClient;

namespace MSSQLContextclasses
{
  public class MovieMSSQLContext : IMovieContext
  {
    public void AddMovie(int id, string title, string director, DateTime releasedate)
    {
      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {

        command.Connection = connection;
        command.CommandText = "";

        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {

        }
      }
    }

    public void ChangeMovie(MovieClass movie)
    {
      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {

        command.Connection = connection;
        command.CommandText = "";

        connection.Open();

        int affectedRows = command.ExecuteNonQuery();

        if (affectedRows == 0)
        {
          throw new DatabaseException("Kon de gegevens niet in de database schrijven.");
        }
      }
    }

    public void DeleteMovie(int id)
    {
      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {

        command.Connection = connection;
        command.CommandText = @"DELETE FROM [dbo].[Movie]
                              WHERE ID = @Id";

        command.Parameters.AddWithValue("@Id", id);

        connection.Open();

        int affectedRows = command.ExecuteNonQuery();

        if (affectedRows == 0)
        {
          throw new Exception("Kon de gegevens niet in de database schrijven.");
        }
      }
    }

    public IReadOnlyCollection<MovieClass> GetAllMovies()
    {
      var movies = new List<MovieClass>();
      using (SqlConnection connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (SqlCommand command = new SqlCommand())
      {
        command.Connection = connection;
        command.CommandText = @"Select * from [Movie]";


        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            movies.Add(new MovieClass((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3],
            (string)reader[4], (DateTime)reader[5], (Decimal)reader[6], (string)reader[7], (string)reader[8],(int)reader[9]));

          }
        }

      }
      return movies;
    }



    public MovieClass GetMovie(int id)
    {
      MovieClass movie = null;

      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {

        command.Connection = connection;
        command.CommandText = "Select * from Movie WHERE MovieID = @Id";

        command.Parameters.AddWithValue("@Id", id);

        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            movie= new MovieClass((int)reader[0], (string)reader[1], (string)reader[2], (string)reader[3],
              (string)reader[4], (DateTime)reader[5], (Decimal)reader[6], (string)reader[7], (string)reader[8],(int)reader[9]);
          }
        }
      }
      return movie;
    }
  } 
}