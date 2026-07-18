using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RastroFinoAPI.Data;
using RastroFinoAPI.Models;

namespace RastroFinoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/productos (me dice que producto esta activo)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos
                .Where(p => p.Activo == true)
                .ToListAsync();
        }

        // GET: api/productos/1 devuelve un solo producto por id
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            return producto;
        }

        // GET: api/productos/categoria/1 Devuelve todos los productos de una categoría específica
        [HttpGet("categoria/{idCategoria}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetPorCategoria(int idCategoria)
        {
            return await _context.Productos
                .Where(p => p.IdCategoria == idCategoria && p.Activo == true)
                .ToListAsync();
        }

        // POST: api/productos (Crea un producto nuevo. desde el panel admin manda los datos y este método los guarda en la base de datos)
        [HttpPost]
        public async Task<ActionResult<Producto>> CrearProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProducto), new { id = producto.IdProducto }, producto);
        }

        // PUT: api/productos/1(Edita un producto existente)
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarProducto(int id, Producto producto)
        {
            if (id != producto.IdProducto) return BadRequest();
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE lógico: api/productos/1(no borra el producto, solo so desactiva)  pone Activo = false
        [HttpDelete("{id}")]
        public async Task<IActionResult> DesactivarProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            producto.Activo = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // GET: api/productos/todos (incluye inactivos, solo para admin)
        [HttpGet("todos")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetTodos()
        {
            return await _context.Productos.ToListAsync();
        }
        // PUT: api/productos/activar/1
        [HttpPut("activar/{id}")]
        public async Task<IActionResult> ActivarProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            producto.Activo = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}