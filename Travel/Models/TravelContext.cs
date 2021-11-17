using Microsoft.EntityFrameworkCore;

namespace Travel.Models
{
  public class TravelContext: DbContext
  {
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<DestinationReview> DestinationReview { get; set; }
    public TravelContext(DbContextOptions<TravelContext> options)
      : base (options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}