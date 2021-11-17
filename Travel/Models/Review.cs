using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
  public class Review
  {
    public Review()
    {
      this.DestinationReviewJoinEntity = new HashSet<DestinationReview>();
    }
    
    public int ReviewId { get; set; }
    [Required]
    [StringLength(85)]
    public string VisitDate { get; set; }
    [Required]
    [Range(0,5, ErrorMessage = "Rating must be between 0 and 5.")]
    public string Rating { get; set; }
    [Required]
    [StringLength(200)]
    public string Comments { get; set; }
    public virtual ICollection<DestinationReview> DestinationReviewJoinEntity { get; }
  }
}