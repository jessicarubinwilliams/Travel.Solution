using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
  public class Destination
  {
    public Destination()
    {
      this.DestinationReviewJoinEntity = new HashSet<DestinationReview>();
    }
    public int DestinationId { get; set; }
    [Required]
    [StringLength(85)]
    public string City { get; set; }
    [Required]
    [StringLength(50)]
    public string State { get; set; }
    [Required]
    [StringLength(56)]
    public string Country { get; set; }
    public virtual ICollection<DestinationReview> DestinationReviewJoinEntity { get; }
  }
}