namespace BibliotecaAPI.DTOs
{
    public class LivroResponseDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string? Genero { get; set; }
        public bool Lido { get; set; }
    }
}
