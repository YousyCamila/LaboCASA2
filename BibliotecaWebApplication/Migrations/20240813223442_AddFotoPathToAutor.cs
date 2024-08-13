using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddFotoPathToAutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoPath",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPath",
                table: "Autores");
        }
    }
}
