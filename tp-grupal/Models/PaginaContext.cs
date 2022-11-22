using Microsoft.EntityFrameworkCore;

namespace tp_grupal.Models
{
    public class PaginaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer("Data Source=LAPTOP-5PT4EJH9\\SQLEXPRESS;Initial catalog=Wiki; Integrated Security=true");
        }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Repositorio> Repositorio { get; set; }


    }
}
