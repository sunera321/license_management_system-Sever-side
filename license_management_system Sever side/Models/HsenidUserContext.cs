using Microsoft.EntityFrameworkCore;

namespace API.Model
{
    public class HsenidUserContext : DbContext
    {
        public HsenidUserContext(DbContextOptions<HsenidUserContext> options) : base(options)
        {

        }
        public DbSet<HsenidUser> HsenidUsers { get; set; }
    
    }
}
