using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spotify.API.Migrations
{
    /// <inheritdoc />
    public partial class RenameAndFixPlaylistCancion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistCancion_Canciones_CancionId",
                table: "PlaylistCancion");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistCancion_Playlists_PlaylistId",
                table: "PlaylistCancion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistCancion",
                table: "PlaylistCancion");

            migrationBuilder.RenameTable(
                name: "PlaylistCancion",
                newName: "PlaylistCanciones");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistCancion_CancionId",
                table: "PlaylistCanciones",
                newName: "IX_PlaylistCanciones_CancionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistCanciones",
                table: "PlaylistCanciones",
                columns: new[] { "PlaylistId", "CancionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistCanciones_Canciones_CancionId",
                table: "PlaylistCanciones",
                column: "CancionId",
                principalTable: "Canciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistCanciones_Playlists_PlaylistId",
                table: "PlaylistCanciones",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistCanciones_Canciones_CancionId",
                table: "PlaylistCanciones");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistCanciones_Playlists_PlaylistId",
                table: "PlaylistCanciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaylistCanciones",
                table: "PlaylistCanciones");

            migrationBuilder.RenameTable(
                name: "PlaylistCanciones",
                newName: "PlaylistCancion");

            migrationBuilder.RenameIndex(
                name: "IX_PlaylistCanciones_CancionId",
                table: "PlaylistCancion",
                newName: "IX_PlaylistCancion_CancionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaylistCancion",
                table: "PlaylistCancion",
                columns: new[] { "PlaylistId", "CancionId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistCancion_Canciones_CancionId",
                table: "PlaylistCancion",
                column: "CancionId",
                principalTable: "Canciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistCancion_Playlists_PlaylistId",
                table: "PlaylistCancion",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
