using Microsoft.EntityFrameworkCore;
using P.Model;

namespace P.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }

    }
}
