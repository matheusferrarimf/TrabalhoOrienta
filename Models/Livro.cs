namespace BibliotecaVirtual.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public bool Disponivel { get; set; } = true;

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
