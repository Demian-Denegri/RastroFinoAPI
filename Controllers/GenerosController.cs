using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RastroFinoAPI.Data;
using RastroFinoAPI.Models;

namespace RastroFinoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GenerosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/generos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> GetGeneros()
        {
            return await _context.Generos.ToListAsync();
        }
    }
}