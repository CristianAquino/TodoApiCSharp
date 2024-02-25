using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApiCSharp.Models;

namespace TodoApiCSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly ILogger<LibroController> _logger;
        // agregamos el context de la bd
        private readonly TodoContext _context;

        // creamos el constructor de clase
        public LibroController(ILogger<LibroController> logger, TodoContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "libros")]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
        {
            return await _context.Libros.ToListAsync();
        }
        // [HttpGet("{id}", Name = "prestamo")]
        // public async Task<ActionResult<Prestamo>> GetPrestamo(Guid id)
        // {
        //     var prestamo = await _context.prestamos.FindAsync(id);
        //     if (prestamo == null)
        //     {
        //         return NotFound();
        //     }
        //     return prestamo;
        // }
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro([FromBody] Libro libro)
        {
            libro.libroId = Guid.NewGuid();
            _context.Libros.Add(new Libro());
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("libro", new { id = libro.libroId }, libro);

        }
    }
}
