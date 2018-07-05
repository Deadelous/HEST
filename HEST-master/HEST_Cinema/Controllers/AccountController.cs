using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibary;
using MSSQLContextclasses;
using InterfacesRepoProject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using ModelLibary.Models;
using RepositoriesProject;
using HEST_Cinema.Controllers.Helpers;
using Microsoft.Extensions.Options;

namespace HEST_Cinema.Controllers
{

  [Produces("application/json")]
  [Route("api/account")]

  public class AccountController : Controller
  {
    private readonly AccountRepo _repo = new AccountRepo(new AccountMSSQLContext());
    private readonly Appsettings _appSettings;


    public AccountController(
      
      IOptions<Appsettings> appSettings)
    {    
      _appSettings = appSettings.Value;
    }

    [HttpGet("{id}")]
    public ActionResult GetAccountID(int id)
    {
      var account = _repo.GetAccountID(id);
      return Ok(account);
    }

    [HttpGet("GetAccount")]
    public AccountClass GetAccount([FromBody] AccountClass account)
    {
      return _repo.GetAccount(account.Email);
    }

    [HttpPost("CreateAccount")]
    public AccountClass CreateAccount([FromBody] AccountClass account)
    {
      return _repo.CreateAccount(account, account.Password);
    }


    [HttpPost("UpdateAccount")]
    public void UpdateAccount([FromBody]  AccountClass account)
    {
      _repo.UpdateAccount(account);
    }

    [HttpGet("GetAllAccounts")]
    public IReadOnlyCollection<AccountClass> GetAllAccounts()
    {
      return _repo.GetAllAccounts();
    }

    [HttpPost("PayCredits")]
    public AccountClass PayCredits([FromBody] AccountClass account)
    {
      return _repo.PayCredits(account, account.Credit);
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] AccountClass user)
    {
      var account = _repo.Authenticate(user.Email, user.Password);

      if (account == null)
        return Unauthorized();

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, user.Id.ToString())
        }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      var tokenString = tokenHandler.WriteToken(token);

      // return basic user info (without password) and token to store client side
      return Ok(new 
      {
        Id = account.Id,
        FirstName = account.FirstName,
        LastName = account.LastName,
        Email = account.Email,
        Adress = account.Adress,
        Postalcode = account.Postalcode,
        City = account.City,
        Phonenumber = account.Phonenumber,
        Username = account.Username,
        Credit = account.Credit,
        Token = tokenString      
      });
    }
  }
}

