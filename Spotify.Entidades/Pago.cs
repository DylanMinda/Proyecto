using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entidades
{
    public class Pago
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public decimal Monto { get; set; }
        public string Metodo { get; set; } 
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
    }

}
