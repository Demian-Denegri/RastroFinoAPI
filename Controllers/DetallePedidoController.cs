using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RastroFinoAPI.Data;
using RastroFinoAPI.Models;

namespace RastroFinoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetallePedidoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DetallePedidoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/detallepedido/pedido/1
        [HttpGet("pedido/{idPedido}")]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetallesPorPedido(int idPedido)
        {
            return await _context.DetallesPedido
                .Where(d => d.IdPedido == idPedido)
                .ToListAsync();
        }

        // POST: api/detallepedido
        [HttpPost]
        public async Task<ActionResult<DetallePedido>> CrearDetalle(DetallePedido detalle)
        {
            _context.DetallesPedido.Add(detalle);
            await _context.SaveChangesAsync();
            return Ok(detalle);
        }
    }
}