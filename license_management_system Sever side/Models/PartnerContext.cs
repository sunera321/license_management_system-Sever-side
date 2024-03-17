using Microsoft.EntityFrameworkCore;

namespace API.Model
{
    public class PartnerContext : DbContext
    {
        public PartnerContext(DbContextOptions<PartnerContext> options) : base(options)
    {

    }
    public DbSet<Partner> Partners { get; set; }
    
    }
}
