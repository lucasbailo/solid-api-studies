using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> GetAllAsync();
        Task<Livro?> GetByIdAsync(int id);
        Task<Livro> AddAsync(Livro livro);
        Task UpdateAsync(Livro livro);
        Task DeleteAsync(Livro livro);
    }
}
