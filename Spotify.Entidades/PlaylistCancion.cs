using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entidades
{
    public class PlaylistCancion
    {
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; } = null!;

        public int CancionId { get; set; }
        public Cancion Cancion { get; set; } = null!;
    }

}
