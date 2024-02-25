using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApiCSharp.Models;

namespace TodoApiCSharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroPrestadoController : ControllerBase
    {
        private readonly ILogger<LibroPrestadoController> _logger;
        // agregamos el context de la bd
        private readonly TodoContext _context;

        // creamos el constructor de clase
        public LibroPrestadoController(ILogger<LibroPrestadoController> logger, TodoContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "librosPrestados")]
        public async Task<ActionResult<IEnumerable<LibroPrestado>>> GetLibrosPrestados()
        {
            return await _context.LibroPrestados.ToListAsync();
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
        public async Task<ActionResult<LibroPrestado>> PostLibroPrestado([FromBody] LibroPrestado libroPrestado)
        {
            _context.LibroPrestados.Add(new LibroPrestado());
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("libroPrestado", libroPrestado);

        }
    }
}
