using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Spotify.Entidades
{
    public class Usuario
    {
        [Key]public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

    }

}
