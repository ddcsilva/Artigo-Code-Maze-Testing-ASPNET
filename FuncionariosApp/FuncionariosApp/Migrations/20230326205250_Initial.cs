using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuncionariosApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    NumeroConta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "Id", "Idade", "Nome", "NumeroConta" },
                values: new object[] { new Guid("8e6c3570-7c7d-4534-b44f-954af822e0e2"), 28, "Evelin", "123-9384613085-55" });

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "Id", "Idade", "Nome", "NumeroConta" },
                values: new object[] { new Guid("b2eef0d0-7865-4834-a184-7d914d798440"), 30, "Mark", "123-3452134543-32" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
