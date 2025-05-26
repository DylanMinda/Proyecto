using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entidades
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public List<PlaylistCancion> PlaylistCanciones { get; set; } = new();
    }

}
