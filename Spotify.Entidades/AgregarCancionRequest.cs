using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entidades
{
    public class AgregarCancionRequest
    {
        public int PlaylistId { get; set; }
        public int CancionId { get; set; }
    }

}
