using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using InterfacesRepoProject;
using ModelLibary.Models;
using System.Data.SqlClient;

namespace MSSQLContextclasses
{
  public class ReservationMSSQLContext : IReservationContext
  {
   
    public void AddReservation(ReservationClass reservation)
    {
      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {

        command.Connection = connection;
        command.CommandText = @"INSERT INTO [dbo].[Reservation]
                           (
                            [Title]
                           ,[Date]
                           ,[Price]
                           ,[Paid]
                          
                     VALUES
                           (
                            @Title 
                           ,@Date
                           ,@Price
                           ,@Paid)";


        command.Parameters.AddWithValue("@Title", reservation.Title);
        command.Parameters.AddWithValue("@Date", reservation.Date);
        command.Parameters.AddWithValue("@Price", reservation.Price);
        command.Parameters.AddWithValue("@Paid", reservation.Paid);


        connection.Open();

        int affectedRows = command.ExecuteNonQuery();

        if (affectedRows == 0)
        {
          throw new DatabaseException("Kon de gegevens niet in de database schrijven.");
        }
      }
    }

    public void DeleteReservation(int id)
    {
      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {       
        command.Connection = connection;
        command.CommandText = @"DELETE FROM [dbo].[Reservation]
                              WHERE ID = @Id";

        command.Parameters.AddWithValue("@Id", id);

        connection.Open();

        int affectedRows = command.ExecuteNonQuery();

        if (affectedRows == 0)
        {
          throw new DataException("Kon de gegevens niet in de database schrijven.");
        }
      }
    }

    public ReservationClass GetReservation(int id)
    {
      ReservationClass reservation = null;

      using (SqlConnection connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (SqlCommand command = new SqlCommand())
      {
        command.Connection = connection;
        command.CommandText = "";

        command.Parameters.AddWithValue("@Id", id);


        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {
          reader.Read();

          if (reader.HasRows)
          {
            reservation = new ReservationClass()
            {
            

            };
          }
        }
        return reservation;
      }

    }

    public void UpdateReservation(ReservationClass reservation)
    {
      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {

        command.Connection = connection;
        command.CommandText = @"UPDATE [dbo].[Reservation]
                             SET [Title] = @Title
                                ,[Date] = @Date
                                ,[Price] = @Price
                                ,[Paid] = @Paid
                           WHERE ID = @Id";

        command.Parameters.AddWithValue("@Title", reservation.Title);
        command.Parameters.AddWithValue("@Date", reservation.Date);
        command.Parameters.AddWithValue("@Price", reservation.Price);
        command.Parameters.AddWithValue("@Paid", reservation.Paid);
        command.Parameters.AddWithValue("@Id", reservation.Id);

        connection.Open();

        int affectedRows = command.ExecuteNonQuery();

        if (affectedRows == 0)
        {
          throw new DatabaseException("Kon de gegevens niet in de database schrijven.");
        }
      }
    }
  }
}
