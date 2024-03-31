using license_management_system_Sever_side.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace license_management_system_Sever_side.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
       
 
       
        public DbSet<Key> Keys { get; set; }
        public DbSet<ClientST> ClientSTs { get; set; }
       
        }


    }

