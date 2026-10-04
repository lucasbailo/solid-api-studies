using BibliotecaAPI.DTOs;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;
using BibliotecaAPI.Services.Interfaces;

namespace BibliotecaAPI.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repository;

        public LivroService(ILivroRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LivroResponseDto>> GetAllAsync()
        {
            var livros = await _repository.GetAllAsync();
            return livros.Select(ParaResponseDto);
        }

        public async Task<LivroResponseDto?> GetByIdAsync(int id)
        {
            var livro = await _repository.GetByIdAsync(id);
            return livro is null ? null : ParaResponseDto(livro);
        }

        public async Task<LivroResponseDto> CreateAsync(LivroCreateDto dto)
        {
            ValidarAno(dto.Ano);

            var livro = new Livro
            {
                Titulo = dto.Titulo,
                Autor = dto.Autor,
                Ano = dto.Ano,
                Genero = dto.Genero
            };

            var criado = await _repository.AddAsync(livro);
            return ParaResponseDto(criado);
        }

        public async Task<bool> UpdateAsync(int id, LivroUpdateDto dto)
        {
            var livro = await _repository.GetByIdAsync(id);
            if (livro is null)
                return false;

            ValidarAno(dto.Ano);

            livro.Titulo = dto.Titulo;
            livro.Autor = dto.Autor;
            livro.Ano = dto.Ano;
            livro.Genero = dto.Genero;
            livro.Lido = dto.Lido;

            await _repository.UpdateAsync(livro);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var livro = await _repository.GetByIdAsync(id);
            if (livro is null)
                return false;

            await _repository.DeleteAsync(livro);
            return true;
        }

        private static void ValidarAno(int ano)
        {
            if (ano > DateTime.Now.Year)
                throw new ArgumentException("O ano de publicação não pode ser no futuro");
        }

        private static LivroResponseDto ParaResponseDto(Livro livro)
        {
            return new LivroResponseDto
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                Ano = livro.Ano,
                Genero = livro.Genero,
                Lido = livro.Lido
            };
        }
    };
}
