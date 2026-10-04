using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.DTOs
{
    public class LivroUpdateDto
    {
        [Required(ErrorMessage = "O título não pode ficar vazio.")]
        [MaxLength(50, ErrorMessage = "O valor máximo de caracteres é {1}")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O autor não pode ficar sem nome.")]
        [MaxLength(50, ErrorMessage = "O valor máximo de caracteres é {1}")]
        public string Autor { get; set; } = string.Empty;

        [Range(1, 2150, ErrorMessage = "O ano deve estar entre {1} e {2}.")]
        public int Ano { get; set; }

        [MaxLength(50, ErrorMessage = "O valor máximo de caracteres é {1}")]
        public string? Genero { get; set; }

        public bool Lido { get; set; }
    }
}
