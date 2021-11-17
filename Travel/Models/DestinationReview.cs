using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
  public class DestinationReview
  {
    public int DestinationReviewId { get; set; }
    public int DestinationId { get; set; }
    public int ReviewId { get; set; }
    public virtual Destination Destination { get; set; }
    public virtual Review Review { get; set; }
  }
}