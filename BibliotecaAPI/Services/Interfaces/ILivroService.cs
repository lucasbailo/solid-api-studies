using BibliotecaAPI.DTOs;

namespace BibliotecaAPI.Services.Interfaces
{
    public interface ILivroService
    {
        Task<IEnumerable<LivroResponseDto>> GetAllAsync();
        Task<LivroResponseDto?> GetByIdAsync(int id);
        Task<LivroResponseDto> CreateAsync(LivroCreateDto dto);
        Task<bool> UpdateAsync(int id, LivroUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
