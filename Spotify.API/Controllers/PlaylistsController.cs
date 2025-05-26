using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spotify.Entidades;

namespace Spotify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly SpotifyDbContext _context;

        public PlaylistsController(SpotifyDbContext context)
        {
            _context = context;
        }

        // GET: api/Playlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            return await _context.Playlists
                .Include(p => p.Usuario) // ← importante
                .Include(p => p.PlaylistCanciones)
                    .ThenInclude(pc => pc.Cancion)
                .ToListAsync();
        }


        // GET: api/Playlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylist(int id)
        {
            var playlist = await _context.Playlists.FindAsync(id);

            if (playlist == null)
            {
                return NotFound();
            }

            return playlist;
        }

        // PUT: api/Playlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylist(int id, Playlist playlist)
        {
            if (id != playlist.Id)
            {
                return BadRequest();
            }

            _context.Entry(playlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaylistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Playlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> CrearPlaylist([FromBody] CrearPlaylistRequest request)
        {
            var usuario = await _context.Usuarios.FindAsync(request.UsuarioId);
            if (usuario == null)
                return NotFound("Usuario no encontrado.");

            var playlist = new Playlist
            {
                Nombre = request.Nombre,
                UsuarioId = usuario.Id
            };

            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return Ok(playlist);
        }
        [HttpPost("agregar-cancion")]
        public async Task<IActionResult> AgregarCancionAPlaylist([FromBody] AgregarCancionRequest request)
        {
            var playlist = await _context.Playlists
                .Include(p => p.PlaylistCanciones)
                .FirstOrDefaultAsync(p => p.Id == request.PlaylistId);

            if (playlist == null)
                return NotFound("Playlist no encontrada.");

            var cancion = await _context.Canciones.FindAsync(request.CancionId);
            if (cancion == null)
                return NotFound("Canción no encontrada.");

            if (playlist.PlaylistCanciones.Any(pc => pc.CancionId == request.CancionId))
                return BadRequest("La canción ya está en la playlist.");

            var nuevaRelacion = new PlaylistCancion
            {
                PlaylistId = request.PlaylistId,
                CancionId = request.CancionId
            };

            _context.PlaylistCanciones.Add(nuevaRelacion);
            await _context.SaveChangesAsync();

            return Ok("Canción agregada a la playlist correctamente.");
        }


        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            var playlist = await _context.Playlists.FindAsync(id);
            if (playlist == null)
            {
                return NotFound();
            }

            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaylistExists(int id)
        {
            return _context.Playlists.Any(e => e.Id == id);
        }
    }
}
