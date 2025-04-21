namespace BibliotecaVirtual.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }
}
