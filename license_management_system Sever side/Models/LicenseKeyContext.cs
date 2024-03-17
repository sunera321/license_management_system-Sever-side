using Microsoft.EntityFrameworkCore;

namespace API.Model
{
    public class LicenseKeyContext : DbContext
    {
        public LicenseKeyContext(DbContextOptions<LicenseKeyContext> options) : base(options)
        {

        }
        public DbSet<LicenseKey> LicenseKeys { get; set; }
    }
}
