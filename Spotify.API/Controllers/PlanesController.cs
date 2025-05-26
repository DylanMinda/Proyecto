using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spotify.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spotify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanesController : ControllerBase
    {
        private readonly SpotifyDbContext _context;

        public PlanesController(SpotifyDbContext context)
        {
            _context = context;
        }

        // GET: api/Planes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plan>>> GetPlan()
        {
            return await _context.Planes.ToListAsync();
        }

        // GET: api/Planes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plan>> GetPlan(int id)
        {
            var plan = await _context.Planes.FindAsync(id);

            if (plan == null)
                return NotFound();

            return plan;
        }

        // POST: api/Planes?usuarioId=1
        [HttpPost]
        public async Task<IActionResult> CrearPlan([FromBody] Plan plan, [FromQuery] int usuarioId)
        {
            var usuario = await _context.Usuarios.FindAsync(usuarioId);

            if (usuario == null)
                return NotFound("Usuario no encontrado.");

            if (usuario.TipoCuenta != "Admin")
                return Forbid("Acceso restringido solo para administradores.");

            _context.Planes.Add(plan);
            await _context.SaveChangesAsync();

            return Ok(plan);
        }

        // PUT: api/Planes/5?usuarioId=1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlan(int id, [FromBody] Plan plan, [FromQuery] int usuarioId)
        {
            if (id != plan.Id)
                return BadRequest();

            var usuario = await _context.Usuarios.FindAsync(usuarioId);

            if (usuario == null)
                return NotFound("Usuario no encontrado.");

            if (usuario.TipoCuenta != "Admin")
                return Forbid("Acceso restringido solo para administradores.");

            _context.Entry(plan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Planes/5?usuarioId=1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan(int id, [FromQuery] int usuarioId)
        {
            var usuario = await _context.Usuarios.FindAsync(usuarioId);

            if (usuario == null)
                return NotFound("Usuario no encontrado.");

            if (usuario.TipoCuenta != "Admin")
                return Forbid("Acceso restringido solo para administradores.");

            var plan = await _context.Planes.FindAsync(id);
            if (plan == null)
                return NotFound();

            _context.Planes.Remove(plan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Planes/asignar-usuario
        [HttpPost("asignar-usuario")]
        public async Task<IActionResult> AsignarUsuarioAPlan([FromBody] AsignacionPlanRequest request)
        {
            var plan = await _context.Planes
                .Include(p => p.Usuarios)
                .FirstOrDefaultAsync(p => p.Id == request.PlanId);

            if (plan == null)
                return BadRequest("No hay ningún plan con ese ID. Crea un plan primero.");

            if (plan.Usuarios.Count >= plan.MaximoUsuarios)
                return BadRequest("Este plan ya alcanzó el número máximo de usuarios permitidos.");

            var usuario = await _context.Usuarios.FindAsync(request.UsuarioId);
            if (usuario == null)
                return NotFound("Usuario no encontrado.");

            usuario.PlanId = plan.Id;
            await _context.SaveChangesAsync();

            return Ok($"Usuario asignado al plan '{plan.Nombre}' correctamente.");
        }

        private bool PlanExists(int id)
        {
            return _context.Planes.Any(e => e.Id == id);
        }
    }
}
