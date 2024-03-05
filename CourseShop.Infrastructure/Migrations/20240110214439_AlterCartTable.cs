using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterCartTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                columns: new[] { "Id", "IdCourse" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");
        }
    }
}
