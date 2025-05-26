using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entidades
{
    public class Artista
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Cancion> Canciones { get; set; } = new List<Cancion>();
        public List<Album> Albums { get; set; } = new List<Album>();


    }
}
