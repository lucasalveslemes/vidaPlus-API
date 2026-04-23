using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidaPlus.Migrations
{
    /// <inheritdoc />
    public partial class AddEnderecoColumnToPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Pacientes");
        }
    }
}
