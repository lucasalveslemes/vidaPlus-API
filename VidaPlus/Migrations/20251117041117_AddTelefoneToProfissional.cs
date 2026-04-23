using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidaPlus.Migrations
{
    public partial class AddTelefoneToProfissional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Profissionais",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Profissionais");
        }
    }
}
