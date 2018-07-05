using System;
using System.Collections.Generic;
using System.Text;
using ModelLibary.Models;

namespace InterfacesRepoProject
{
  public interface IReviewContext 
  {
    ReviewClass GetReview(int reviewId);

    void AddReview(ReviewClass review);

    IReadOnlyCollection<ReviewClass> GetReviews();

    void ChangeReview(ReviewClass review);

    void DeleteReview(int reviewId);
  }
}
;