


using datingapp.api.Models;
using Microsoft.EntityFrameworkCore;

namespace datingapp.api.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base (options){}
        
            public DbSet<Value> Values { get; set; }
            
            public DbSet<user> Users { get; set; }
            public DbSet<photo> Photos { get; set; }
            
    }
}