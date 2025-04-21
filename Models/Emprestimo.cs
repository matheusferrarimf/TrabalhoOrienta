namespace BibliotecaVirtual.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; } = DateTime.Now;
        public DateTime? DataDevolucao { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public int LivroId { get; set; }
        public Livro? Livro { get; set; }
    }
}
