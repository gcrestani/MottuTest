using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MottuTest.Api.DataStore.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Urls",
                columns: table => new
                {
                    id = table.Column<double>(type: "double precision", nullable: false),
                    hits = table.Column<double>(type: "double precision", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false),
                    shortUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urls", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Urls");
        }
    }
}
