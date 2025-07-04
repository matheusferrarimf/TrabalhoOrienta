namespace BibliotecaVirtual.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
    }
}
