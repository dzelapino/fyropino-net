using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace fyropinonet.Migrations
{
    /// <inheritdoc />
    public partial class RemoveHero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heroes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsForceUser = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "IsForceUser", "Name" },
                values: new object[,]
                {
                    { 1, true, "Darth Jar Jar" },
                    { 2, true, "Jedi Bob" },
                    { 3, false, "Gonk" }
                });
        }
    }
}
