using BibliotecaAPI.Data;
using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;
using BibliotecaAPI.Repositories.Interfaces;

namespace BibliotecaAPI.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;

        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Livro>> GetAllAsync()
        {
            return await _context.Livros.ToListAsync();
        }
        public async Task<Livro?> GetByIdAsync(int id)
        {
            return await _context.Livros.FindAsync(id);
        }
        public async Task<Livro> AddAsync(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
            return livro;
        }
        public async Task UpdateAsync(Livro livro)
        {
            _context.Entry(livro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Livro livro)
        {
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
        }
    }
}
