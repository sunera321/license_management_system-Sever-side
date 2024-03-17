using Microsoft.EntityFrameworkCore;

namespace API.Model
{
    public class ActivateContext : DbContext
    {
        public ActivateContext(DbContextOptions<ActivateContext> options) : base(options)
        {

        }
        public DbSet<Activate> Activate { get; set; }
    }
}