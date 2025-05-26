using Microsoft.EntityFrameworkCore;
using Spotify.Entidades;

public class SpotifyDbContext : DbContext
{
    public SpotifyDbContext(DbContextOptions<SpotifyDbContext> options)
        : base(options)
    {
    }

    // Tablas (DbSet)
    public DbSet<Usuario> Usuarios { get; set; } = default!;
    public DbSet<Plan> Planes { get; set; } = default!;
    public DbSet<Pago> Pagos { get; set; } = default!;
    public DbSet<Cancion> Canciones { get; set; } = default!;
    public DbSet<Playlist> Playlists { get; set; } = default!;
    public DbSet<PlaylistCancion> PlaylistCanciones { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de clave compuesta para PlaylistCancion
        modelBuilder.Entity<PlaylistCancion>()
            .HasKey(pc => new { pc.PlaylistId, pc.CancionId });

        modelBuilder.Entity<PlaylistCancion>()
            .HasOne(pc => pc.Playlist)
            .WithMany(p => p.PlaylistCanciones)
            .HasForeignKey(pc => pc.PlaylistId);

        modelBuilder.Entity<PlaylistCancion>()
            .HasOne(pc => pc.Cancion)
            .WithMany(c => c.PlaylistCanciones)
            .HasForeignKey(pc => pc.CancionId);
    }
}
