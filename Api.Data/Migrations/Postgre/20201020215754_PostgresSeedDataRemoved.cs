using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Data.Migrations.Postgre
{
    public partial class PostgresSeedDataRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "movie_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "movie_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "movie_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "movie_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "movie_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "movie_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "movie_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "movie_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "movie_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "movies",
                keyColumn: "movie_id",
                keyValue: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "movie_id", "age_restriction", "price", "title", "year" },
                values: new object[,]
                {
                    { 1, 12, 10f, "Star Wars Episode IV: A New Hope", 1979 },
                    { 2, 12, 5.5f, "Ghostbusters", 1984 },
                    { 3, 15, 8.5f, "Terminator", 1984 },
                    { 4, 17, 5f, "Taxi Driver", 1976 },
                    { 5, 18, 5f, "Platoon", 1986 },
                    { 6, 15, 8.5f, "Frantic", 1988 },
                    { 7, 13, 9.5f, "Ronin", 1998 },
                    { 8, 16, 10.5f, "Analyze This", 1999 },
                    { 9, 16, 8.5f, "Leon: the Professional", 1994 },
                    { 10, 13, 8.5f, "Mission Impossible", 1996 }
                });
        }
    }
}
