using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MottuTest.Api.DataStore.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class editingurltable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Urls",
                newName: "OriginalUrl");

            migrationBuilder.AlterColumn<int>(
                name: "Hits",
                table: "Urls",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OriginalUrl",
                table: "Urls",
                newName: "Url");

            migrationBuilder.AlterColumn<double>(
                name: "Hits",
                table: "Urls",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
