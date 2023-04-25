using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectGroup2.Migrations.Music
{
    /// <inheritdoc />
    public partial class AddMusicTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musicc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    artist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    musicGenre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    releaseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    musicAlbum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicc", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Musicc",
                columns: new[] { "Id", "artist", "musicAlbum", "musicGenre", "releaseDate", "title" },
                values: new object[] { 1234, "Example", "Example", "Example", "01/22/2019", "Example" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musicc");
        }
    }
}
