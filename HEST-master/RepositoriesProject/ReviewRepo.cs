using System;
using System.Collections.Generic;
using System.Text;
using InterfacesRepoProject;
using ModelLibary.Models;
using MSSQLContextclasses;

namespace RepositoriesProject
{
  public class ReviewRepo
  {
    private IReviewContext _context;

    public ReviewRepo(IReviewContext context)
    {
      this._context = context;
    }

    public void AddReview(ReviewClass review)
    {
      _context.AddReview(review);
    }

    public IReadOnlyCollection<ReviewClass> GetReviews()
    {
      return _context.GetReviews();
    }

    public void ChangeReview(ReviewClass review)
    {
      _context.ChangeReview(review);
    }

    public void DeleteReview(int reviewId)
    {
      _context.DeleteReview(reviewId);
    }

    public ReviewClass GetReview(int reviewId)
    {
      return _context.GetReview(reviewId);
    }
  }
}
