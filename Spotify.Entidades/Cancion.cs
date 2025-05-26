using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entidades
{
    public class Cancion
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Artista { get; set; }
        public string? Album { get; set; }
        public string Genero { get; set; }
        public TimeSpan Duracion { get; set; }
        public string UrlArchivo { get; set; } // puede ser una URL local o pública

        public List<PlaylistCancion> PlaylistCanciones { get; set; } = new();
    }

}
