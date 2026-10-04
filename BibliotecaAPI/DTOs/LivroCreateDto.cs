using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTOs
{
    public class LivroCreateDto
    {
        [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O valor máximo de caracteres é 50")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Autor é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O valor máximo de caracteres é 50")]
        public string Autor { get; set; } = string.Empty;

        [Range(1, 2150, ErrorMessage = "O ano deve estar entre 1 e 2150.")]
        public int Ano { get; set; }

        [MaxLength(50, ErrorMessage = "O valor máximo de caracteres é 50")]
        public string? Genero { get; set; }
    }
}
