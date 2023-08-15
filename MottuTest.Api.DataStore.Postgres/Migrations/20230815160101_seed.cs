using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MottuTest.Api.DataStore.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "Id", "CreatedAt", "Hits", "OriginalUrl", "ShortUrl", "UpdatedAt" },
                values: new object[,]
                {
                    { 10743, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "http://uol.com.br", "http://chr.dc/y81xc", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "http://chaordic.com.br", "http://chr.dc/qy5k9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21220, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "http://diariocatarinense.com.br", "http://chr.dc/87itr", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23094, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "http://globo.com", "http://chr.dc/9dtr4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55324, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "http://youtube.com", "http://chr.dc/1w5tg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66761, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "http://terra.com.br", "http://chr.dc/u9jh3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70001, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "http://facebook.com", "http://chr.dc/qy61p", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70931, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "http://twitter.com", "http://chr.dc/7tmv1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76291, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "http://google.com", "http://chr.dc/aUx71", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "http://bing.com", "http://chr.dc/9opw2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 10743);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 19122);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 21220);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 23094);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 55324);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 66761);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 70001);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 70931);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 76291);

            migrationBuilder.DeleteData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 87112);
        }
    }
}
