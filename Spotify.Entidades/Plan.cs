using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entidades
{
    public class Plan
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; }// Ejemplo: "Premium", "Free"
        public decimal PrecioMensual { get; set; } // Precio mensual del plan
        public int NumeroCanciones { get; set; } // Número de canciones que el usuario puede escuchar
        public int NumeroDispositivos { get; set; } // Número de dispositivos en los que se puede usar el plan
        public bool Descargas { get; set; } // Indica si el plan permite descargas de canciones
        public bool Anuncios { get; set; } // Indica si el plan tiene anuncios o no



    }
}
