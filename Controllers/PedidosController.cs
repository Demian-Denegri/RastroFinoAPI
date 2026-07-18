using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RastroFinoAPI.Data;
using RastroFinoAPI.Models;

namespace RastroFinoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase

    {
        private readonly AppDbContext _context;

        public PedidosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        // GET: api/Pedidos/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var Pedido = await _context.Pedidos.FindAsync(id);
            if (Pedido == null) return NotFound();
            return Pedido;
        }

        // POST: api/pedidos
        [HttpPost]
        public async Task<ActionResult<Pedido>> CrearPedido(Pedido pedido)
        {
            pedido.Fecha = DateTime.Now; //le da la fecha y hora actual
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPedidos), new { id = pedido.IdPedido }, pedido);
        }
    }
}
        