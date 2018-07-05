using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLibary;
using MSSQLContextclasses;
using InterfacesRepoProject;
using ModelLibary.Models;
using RepositoriesProject;

namespace HEST_Cinema.Controllers
{
  [Produces("application/json")]
  [Route("api/review")]
  public class ReviewController : Controller
  {
    private readonly ReviewRepo _repo = new ReviewRepo(new ReviewMSSQLContext());

    [HttpPost("CreateReview")]
    public void AddReview([FromBody]ReviewClass review)
    {
      _repo.AddReview(review);
    }

    [HttpPost("ChangeReview")]
    public void ChangeReview([FromBody] ReviewClass review)
    {
      _repo.ChangeReview(review);
    }

    [HttpGet("GetReviews")]
    public ActionResult GetReviews()
    {
      return Ok(_repo.GetReviews());
    }

    [HttpDelete("Deletereview")]
    public void DeleteReview(int reviewId)
    {
      _repo.DeleteReview(reviewId);
    }

    [HttpGet("{id}")]
    public ReviewClass GetReview(int reviewid)
    {
      return _repo.GetReview(reviewid);
    }
  }
}
