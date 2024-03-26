using Microsoft.EntityFrameworkCore;

namespace MagazinDeFlori.Models
{
    public class FloareContext : DbContext 
    {
        public DbSet<Floare> Floarea { get; set; }
        public FloareContext(DbContextOptions<FloareContext>options):base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
