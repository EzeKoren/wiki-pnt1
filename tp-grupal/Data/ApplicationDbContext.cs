using Microsoft.EntityFrameworkCore;
using tp_grupal.Models;

namespace tp_grupal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Articulo> Articulos { get; set; }
    }
}
