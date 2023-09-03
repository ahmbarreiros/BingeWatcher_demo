using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BingeWatcher.Migrations
{
    /// <inheritdoc />
    public partial class AddGenreAndAnimeGenreRelationshipTablesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mean_Score",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "NSFW",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "Popularity",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Animes");

            migrationBuilder.RenameColumn(
                name: "Media_Type",
                table: "Animes",
                newName: "Main_Picture");

            migrationBuilder.CreateTable(
                name: "AnimeGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AnimeGenres",
                columns: new[] { "Id", "AnimeId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Main_Picture", "Status", "Title" },
                values: new object[] { "mainpic1.jpg", "finished", "Anime 1" });

            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "Id", "End_Date", "Main_Picture", "Number_Of_Episodes", "Rating", "Start_Date", "Status", "Synopsis", "Title" },
                values: new object[,]
                {
                    { 2, null, "mainpic2.jpg", 1, null, null, "finished", null, "Anime 2" },
                    { 3, null, "mainpic3.jpg", 1, null, null, "finished", null, "Anime 3" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Terror" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeGenres");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Main_Picture",
                table: "Animes",
                newName: "Media_Type");

            migrationBuilder.AddColumn<double>(
                name: "Mean_Score",
                table: "Animes",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NSFW",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Popularity",
                table: "Animes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Animes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Mean_Score", "Media_Type", "NSFW", "Popularity", "Rank", "Status", "Title" },
                values: new object[] { null, "tv", null, null, null, "currently_airing", "Dummy Title" });
        }
    }
}
