using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entidades
{
    public class PagoRequest
    {
        public int UsuarioId { get; set; }
        public decimal Monto { get; set; }
        public string Metodo { get; set; } = "Tarjeta"; // o “Transferencia”, “Efectivo”, etc.
    }


}
