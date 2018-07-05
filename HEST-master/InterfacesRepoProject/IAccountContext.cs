using System;
using System.Collections.Generic;
using System.Text;
using ModelLibary.Models;

namespace InterfacesRepoProject
{
  public interface IAccountContext
  {
    AccountClass GetAccount(string email);

    AccountClass GetAccountID(int id);

    AccountClass CreateAccount(AccountClass account, string password);

    AccountClass UpdateAccount(AccountClass account);

    void UpdateAccount(AccountClass account, string password);

    IReadOnlyCollection<AccountClass> GetAllAccounts();

    AccountClass PayCredits(AccountClass account, decimal credit);

    bool Authenticate(AccountClass account, string password);

    void DeleteAccount(int id);
  }
}
