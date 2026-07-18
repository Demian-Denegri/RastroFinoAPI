using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RastroFinoAPI.Data;
using RastroFinoAPI.Models;

namespace RastroFinoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/clientes/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();
            return cliente;
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> CrearCliente(Cliente cliente)
        {
            if (cliente == null || string.IsNullOrEmpty(cliente.Nombre))
                return BadRequest("Cliente inválido");

            var clienteExistente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Email == cliente.Email);

            if (clienteExistente != null)
                return Ok(clienteExistente);

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.IdCliente }, cliente);
        }
    }
}