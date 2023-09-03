using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BingeWatcher.Migrations
{
    /// <inheritdoc />
    public partial class CreateDbAndFillWithAnimesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    End_Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mean_Score = table.Column<double>(type: "float", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    Popularity = table.Column<int>(type: "int", nullable: true),
                    NSFW = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Media_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number_Of_Episodes = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "Id", "End_Date", "Mean_Score", "Media_Type", "NSFW", "Number_Of_Episodes", "Popularity", "Rank", "Rating", "Start_Date", "Status", "Synopsis", "Title" },
                values: new object[] { 1, null, null, "tv", null, 1, null, null, null, null, "currently_airing", null, "Dummy Title" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animes");
        }
    }
}
