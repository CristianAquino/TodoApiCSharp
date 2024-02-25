using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApiCSharp.Models;

namespace TodoApiCSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamoController : ControllerBase
    {
        private readonly ILogger<PrestamoController> _logger;
        // agregamos el context de la bd
        private readonly TodoContext _context;

        // creamos el constructor de clase
        public PrestamoController(ILogger<PrestamoController> logger, TodoContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "prestamos")]
        public async Task<ActionResult<IEnumerable<Prestamo>>> GetPrestamos()
        {
            return await _context.Prestamos.ToListAsync();
        }
        [HttpGet("{id}", Name = "prestamo")]
        public async Task<ActionResult<Prestamo>> GetPrestamo(Guid id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            return prestamo;
        }
        [HttpPost]
        public async Task<ActionResult<Prestamo>> PostPrestamo([FromBody] Prestamo prestamo)
        {
            prestamo.prestamoId = Guid.NewGuid();
            _context.Prestamos.Add(new Prestamo());
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("prestamo", new { id = prestamo.prestamoId }, prestamo);

        }
    }
}
