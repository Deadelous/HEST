using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfacesRepoProject;
using Microsoft.AspNetCore.Identity;
using ModelLibary.Models;
using MSSQLContextclasses;


namespace RepositoriesProject
{
  public class AccountRepo
  {
    private IAccountContext _context;

    public AccountRepo(IAccountContext context)
    {
      this._context = context;

    }

    public AccountClass Authenticate(string email, string password)
    {
      if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        return null;

      var user = _context.GetAccount(email);

      if (user == null)
        return null;


      var loggedUser = _context.GetAccount(email);
      

      //loggedAccount.Valid = (loggedUser != null && _context.Authenticate(loggedUser, password));


      return user;
    }

    public AccountClass CreateAccount(AccountClass account, string password)
    {
     
     return _context.CreateAccount(account, password);
     
    }

    public AccountClass GetAccountID(int id)
    {
      return _context.GetAccountID(id);
    }

    public AccountClass GetAccount(string email)
    {
      return _context.GetAccount(email);
    }

    public IReadOnlyCollection<AccountClass> GetAllAccounts()
    {
      return _context.GetAllAccounts();
    }

    public AccountClass PayCredits(AccountClass account, decimal credit)
    {
      return _context.PayCredits(account, credit);
    }

    public AccountClass UpdateAccount(AccountClass account)
    {

      return _context.UpdateAccount(account);
    }

    public void DeleteAccount(int userid)
    {
      _context.DeleteAccount(userid);
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      if (password == null) throw new ArgumentNullException("password");
      if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }

    private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
      if (password == null) throw new ArgumentNullException("password");
      if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
      if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
      if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

      using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
      {
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computedHash.Length; i++)
        {
          if (computedHash[i] != storedHash[i]) return false;
        }
      }

      return true;
    }
  }
}

