using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Models;

namespace BibliotecaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Livro> Livros { get; set; } = null!;
    }
}
