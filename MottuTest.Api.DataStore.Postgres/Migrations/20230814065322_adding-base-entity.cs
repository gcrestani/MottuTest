using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MottuTest.Api.DataStore.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class addingbaseentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "url",
                table: "Urls",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "shortUrl",
                table: "Urls",
                newName: "ShortUrl");

            migrationBuilder.RenameColumn(
                name: "hits",
                table: "Urls",
                newName: "Hits");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Urls",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Urls",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Urls",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Urls",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Urls");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Urls");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Urls",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "ShortUrl",
                table: "Urls",
                newName: "shortUrl");

            migrationBuilder.RenameColumn(
                name: "Hits",
                table: "Urls",
                newName: "hits");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Urls",
                newName: "id");

            migrationBuilder.AlterColumn<double>(
                name: "id",
                table: "Urls",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
