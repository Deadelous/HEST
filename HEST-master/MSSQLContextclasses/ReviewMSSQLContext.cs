using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using InterfacesRepoProject;
using ModelLibary.Models;
using System.Data.SqlClient;

namespace MSSQLContextclasses
{
  public class ReviewMSSQLContext : IReviewContext
  {

    public void AddReview(ReviewClass review)
    {
      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {

        command.Connection = connection;
        command.CommandText = @"INSERT INTO [dbo].[Review]
                           (
                            [Name]
                           ,[Description]
                           ,[Rating]
                           ,[Date]
                          
                     VALUES
                           (
                            @Name 
                           ,@Description
                           ,@Rating
                           ,@Date)";


        command.Parameters.AddWithValue("@Name", review.Name);
        command.Parameters.AddWithValue("@Description", review.Description);
        command.Parameters.AddWithValue("@Rating", review.Rating);
        command.Parameters.AddWithValue("@Date", review.Date);


        connection.Open();

        int affectedRows = command.ExecuteNonQuery();

        if (affectedRows == 0)
        {
          throw new DatabaseException("Kon de gegevens niet in de database schrijven.");
        }
      }
    }

    public void ChangeReview(ReviewClass review)
    {
      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {

        command.Connection = connection;
        command.CommandText = @"UPDATE [dbo].[Review]
                             SET [Name] = @Name
                                ,[Description] = @Description
                                ,[Rating] = @Rating
                                ,[Date] = @Date
                           WHERE ID = @Id";

        command.Parameters.AddWithValue("@Name", review.Name);
        command.Parameters.AddWithValue("@Description", review.Description);
        command.Parameters.AddWithValue("@Rating", review.Rating);
        command.Parameters.AddWithValue("@Date", review.Date);
        command.Parameters.AddWithValue("@Id", review.Id);

        connection.Open();

        int affectedRows = command.ExecuteNonQuery();

        if (affectedRows == 0)
        {
          throw new DatabaseException("Kon de gegevens niet in de database schrijven.");
        }
      }
    }

    public void DeleteReview(int reviewId)
    {
      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {

        command.Connection = connection;
        command.CommandText = @"DELETE FROM [dbo].[Review]
                              WHERE ID = @Id";

        command.Parameters.AddWithValue("@Id", reviewId);

        connection.Open();

        int affectedRows = command.ExecuteNonQuery();

        if (affectedRows == 0)
        {
          throw new DatabaseException("Kon de gegevens niet in de database schrijven.");
        }
      }
    }

    public ReviewClass GetReview(int reviewId)
    {
      ReviewClass review = null;

      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {

        command.Connection = connection;
        command.CommandText =
          "Select m.[Title] as [MovieName], CONCAT(a.[FirstName], ' ', a.[Lastname]) as [Accountname], r.[Name] as [ReviewName], r.[Description] as [ReviewDescription], r.[Rating] as [ReviewRating] "
          + "from Review r "
          + "join Account a on a.[AccountID] = r.[AccountID] "
          + " join Movie m on m.[MovieID] = r.[MovieID]"
          + " WHERE AuditoriumID = @ReviewId ";

        command.Parameters.AddWithValue("@Id", reviewId);


        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            review = new ReviewClass((int)reader[0], (string)reader[1], (string)reader[2], (decimal)reader[3], (DateTime)reader[4], (int)reader[5], (string)reader[6], (int)reader[7], (string)reader[8]);
          }
        }
      }
      return review ;
    }

    public IReadOnlyCollection<ReviewClass> GetReviews()
    {
      var reviews = new List<ReviewClass>();
      using (SqlConnection connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (SqlCommand command = new SqlCommand())
      {
        command.Connection = connection;
        command.CommandText = @"select * from Review";
        //a.title, r.reviewid, r.name, r.description, r.rating from Review r inner join Movie a on a.movieID = r.Movieid
        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {

            reviews.Add(new ReviewClass((int)reader[0], (string)reader[1], (string)reader[2], (decimal)reader[3], (DateTime)reader[4], (int)reader[5], (string)reader[6], (int)reader[7],(string)reader[8]));
          }
          return reviews;
        }
      }
    }
  }
}