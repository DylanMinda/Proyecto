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
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } // Nombre de la playlist
        public DateTime FechaCreacion { get; set; } // Fecha de creación de la playlist
        public List<Cancion> Canciones { get; set; } = new List<Cancion>(); // Lista de canciones en la playlist

    }
}
