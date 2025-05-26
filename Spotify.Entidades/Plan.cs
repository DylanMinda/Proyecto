public class Plan
{
    public int Id { get; set; }
    public string Nombre { get; set; } // Personal, Familiar, Empresarial
    public string Descripcion { get; set; }
    public int MaximoUsuarios { get; set; }
    public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
