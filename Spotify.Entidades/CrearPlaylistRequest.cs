using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entidades
{
    public class CrearPlaylistRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
    }

}
