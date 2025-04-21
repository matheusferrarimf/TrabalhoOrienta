using System.Text.Json.Serialization;

namespace BibliotecaVirtual.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; } = DateTime.UtcNow;
        public DateTime? DataDevolucao { get; set; }

        public int UsuarioId { get; set; }

        [JsonIgnore] // evita o ciclo na serialização
        public Usuario? Usuario { get; set; }

        public int LivroId { get; set; }

        [JsonIgnore] // evita o ciclo com Livro → Categoria → Livros...
        public Livro? Livro { get; set; }
    }
}
