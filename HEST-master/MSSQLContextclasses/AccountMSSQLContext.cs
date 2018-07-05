using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using InterfacesRepoProject;
using ModelLibary.Models;
using System.Data.SqlClient;


namespace MSSQLContextclasses
{
  public class AccountMSSQLContext : IAccountContext
  {

    public bool Authenticate(AccountClass account, string password)
    {
      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {
        command.Connection = connection;
        command.CommandText = @"SELECT * FROM [Account] WHERE [Account].[Email] = @email";
        command.Parameters.AddWithValue("@email", account.Email);


        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {
          reader.Read();
          return reader.HasRows && password == (string)reader["Password"];
        }
      }
    }

    public AccountClass CreateAccount(AccountClass account, string password)
    {
      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {
        command.Connection = connection;
        command.CommandText = @"EXEC SP_Account_Insert @firstname, @lastname, @email, @adress, @city, @postalcode, @phonenumber, @username, @password";


        command.Parameters.AddWithValue("@firstname", account.FirstName);
        command.Parameters.AddWithValue("@lastname", account.LastName);
        command.Parameters.AddWithValue("@email", account.Email);
        command.Parameters.AddWithValue("@adress", account.Adress);
        command.Parameters.AddWithValue("@city", account.City);
        command.Parameters.AddWithValue("@postalcode", account.Postalcode);
        command.Parameters.AddWithValue("@phonenumber", account.Phonenumber);
        command.Parameters.AddWithValue("@username", account.Username);
        command.Parameters.AddWithValue("@password", account.Password);


        connection.Open();
        command.ExecuteNonQuery();

        return account;

      }
    }

    public void DeleteAccount(int id)
    {

      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {
        command.Connection = connection;
        command.CommandText = @"DELETE FROM [dbo].[Account]
                              WHERE ID = @Id";

        command.Parameters.AddWithValue("@Id", id);

        connection.Open();

        int affectedRows = command.ExecuteNonQuery();

        if (affectedRows == 0)
        {
          throw new DatabaseException("Kon de gegevens niet in de database schrijven.");
        }
      }
    }

    public AccountClass GetAccountID(int id)
    {
      AccountClass account = null;

      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {
        command.Connection = connection;
        command.CommandText = "Select * from [Account] Where [Account].AccountID = @AccountID;";
        command.Parameters.AddWithValue("@AccountID", id);

        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {
          reader.Read();

          if (reader.HasRows)
          {
            account = new AccountClass()
            {
              Id = id,
              FirstName = reader["FirstName"].ToString(),
              LastName = reader["LastName"].ToString(),
              Email = reader["Email"].ToString(),
              Adress = reader["Adress"].ToString(),
              Postalcode = reader["Postalcode"].ToString(),
              City = reader["City"].ToString(),
              Phonenumber = reader["Phonenumber"].ToString(),
              Username = reader["UserName"].ToString(),
              Credit = Convert.ToDecimal(reader["Credit"])
            };
          }
        }
      }

      return account;
    }


    public AccountClass GetAccount(string email)
    {
      AccountClass account = null;

      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {
        command.Connection = connection;
        command.CommandText = "Select * from [Account] Where [Account].Email = @email;";
        command.Parameters.AddWithValue("@email", email);

        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {
          reader.Read();

          if (reader.HasRows)
          {
            account = new AccountClass()
            {
              Id = Convert.ToInt32(reader["AccountID"]),
              FirstName = reader["FirstName"].ToString(),
              LastName = reader["LastName"].ToString(),
              Email = email,
              Adress = reader["Adress"].ToString(),
              Postalcode = reader["Postalcode"].ToString(),
              City = reader["City"].ToString(),
              Phonenumber = reader["Phonenumber"].ToString(),
              Username = reader["UserName"].ToString(),
              Credit = Convert.ToDecimal(reader["Credit"])
            };
          }
        }
      }
      return account;
    }


    public IReadOnlyCollection<AccountClass> GetAllAccounts()
    {
      var accounts = new List<AccountClass>();
      using (SqlConnection connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (SqlCommand command = new SqlCommand())
      {
        command.Connection = connection;
        command.CommandText = @"Select * from [Account]";


        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            accounts.Add(new AccountClass()
            {
              Id = Convert.ToInt32(reader["AccountID"]),
              FirstName = reader["FirstName"].ToString(),
              LastName = reader["LastName"].ToString(),
              Email = reader["Email"].ToString(),
              Username = reader["UserName"].ToString(),
              Adress = reader["Adress"].ToString(),
              Credit = Convert.ToDecimal(reader["Credit"]),
              PictureUrl = reader["Picture"].ToString()
            });
          }
        }

      }
      return accounts;
    }


    public AccountClass PayCredits(AccountClass account, decimal credit)
    {
      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {
        command.Connection = connection;
        command.CommandText = @"EXEC SP_Account_Credit @accountID, @credit";

        command.Parameters.AddWithValue("AccountID", account.Id);
        command.Parameters.AddWithValue("@credit", account.Credit);

        connection.Open();
        command.ExecuteNonQuery();

        return account;

      }
    }


    public AccountClass UpdateAccount(AccountClass account)
    {
      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {
        command.Connection = connection;
        command.CommandText = @"UPDATE [dbo].[Account]
                             SET [FirstName] = @firstname
                                ,[LastName] = @lastname
                                ,[UserName] = @username
                                ,[Adress] = @adress
                
                           WHERE ID = @Id";

        command.Parameters.AddWithValue("@firstname", account.FirstName);
        command.Parameters.AddWithValue("@lastname", account.LastName);
        command.Parameters.AddWithValue("@username", account.Username);
        command.Parameters.AddWithValue("@adress", account.Adress);
        command.Parameters.AddWithValue("@Id", account.Id);

        connection.Open();

        int affectedRows = command.ExecuteNonQuery();

        if (affectedRows == 0)
        {
          throw new DatabaseException("Kon de gegevens niet in de database schrijven.");
        }
      }
      return account;
    }

    public void UpdateAccount(AccountClass account, string password)
    {
      using (var connection = new SqlConnection(DatabaseClass.ConnectionString))
      using (var command = new SqlCommand())
      {
        command.Connection = connection;
        command.CommandText = @"UPDATE [dbo].[Account]
                             SET [FirstName] = @firstname
                                ,[LastName] = @lastname
                                ,[Email] = @mail
                                ,[UserName] = @username
                                ,[Adress] = @adress
                                ,[Credit] = @credit
                                ,[Password] = @password
                           WHERE ID = @Id";

        command.Parameters.AddWithValue("@firstname", account.FirstName);
        command.Parameters.AddWithValue("@lastname", account.LastName);
        command.Parameters.AddWithValue("@mail", account.Email);
        command.Parameters.AddWithValue("@username", account.Username);
        command.Parameters.AddWithValue("@adress", account.Adress);
        command.Parameters.AddWithValue("@credit", account.Credit);
        command.Parameters.AddWithValue("@password", account.Password);
        command.Parameters.AddWithValue("@Id", account.Id);

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