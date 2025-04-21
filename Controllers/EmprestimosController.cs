using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaVirtual.Data;
using BibliotecaVirtual.Models;

namespace BibliotecaVirtual.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmprestimosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emprestimo>>> GetEmprestimos()
        {
            return await _context.Emprestimos
                .Include(e => e.Usuario)
                .Include(e => e.Livro)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Emprestimo>> GetEmprestimo(int id)
        {
            var emprestimo = await _context.Emprestimos
                .Include(e => e.Usuario)
                .Include(e => e.Livro)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (emprestimo == null)
                return NotFound();

            return emprestimo;
        }

        [HttpPost]
        public async Task<ActionResult<Emprestimo>> PostEmprestimo(Emprestimo emprestimo)
        {
            var livro = await _context.Livros.FindAsync(emprestimo.LivroId);
            if (livro == null || !livro.Disponivel)
                return BadRequest("Livro indisponível.");

            livro.Disponivel = false;
            _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmprestimo), new { id = emprestimo.Id }, emprestimo);
        }

        [HttpPut("{id}/devolver")]
        public async Task<IActionResult> RegistrarDevolucao(int id)
        {
            var emprestimo = await _context.Emprestimos
                .Include(e => e.Livro)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (emprestimo == null)
                return NotFound();

            if (emprestimo.Livro == null)
                return BadRequest("Livro não encontrado para este empréstimo.");

            emprestimo.DataDevolucao = DateTime.Now;
            emprestimo.Livro.Disponivel = true;

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
