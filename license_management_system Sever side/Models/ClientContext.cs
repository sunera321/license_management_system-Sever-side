using Microsoft.EntityFrameworkCore;

namespace API.Model
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
    }
}