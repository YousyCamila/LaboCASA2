using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class Libro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LibroId",
                table: "Autores",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Autores_LibroId",
                table: "Autores",
                column: "LibroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_Libros_LibroId",
                table: "Autores",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "LibroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autores_Libros_LibroId",
                table: "Autores");

            migrationBuilder.DropIndex(
                name: "IX_Autores_LibroId",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "LibroId",
                table: "Autores");
        }
    }
}
