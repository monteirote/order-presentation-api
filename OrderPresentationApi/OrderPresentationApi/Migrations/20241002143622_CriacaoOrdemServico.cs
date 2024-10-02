using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderPresentationApi.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoOrdemServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdensServico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    DsCodigoOs = table.Column<string>(type: "TEXT", nullable: false),
                    DtCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DtEntrega = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IcCancel = table.Column<bool>(type: "INTEGER", nullable: false),
                    DsObservacao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdensServico", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdensServico");
        }
    }
}
