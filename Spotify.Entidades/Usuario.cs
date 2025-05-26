using Spotify.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string TipoCuenta { get; set; } // Free o Premium
    public int? PlanId { get; set; }
    public Plan? Plan { get; set; }
}
