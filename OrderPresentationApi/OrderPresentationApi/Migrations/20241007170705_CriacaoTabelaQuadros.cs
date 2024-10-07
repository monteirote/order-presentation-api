using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderPresentationApi.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaQuadros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quadros",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID_ORDEM_SERVICO = table.Column<int>(type: "INTEGER", nullable: false),
                    VL_ALTURA = table.Column<int>(type: "INTEGER", nullable: false),
                    VL_LARGURA = table.Column<int>(type: "INTEGER", nullable: false),
                    CD_MOLDURA = table.Column<int>(type: "INTEGER", nullable: false),
                    CD_IMPRESSAO = table.Column<int>(type: "INTEGER", nullable: false),
                    CD_VIDRO = table.Column<int>(type: "INTEGER", nullable: false),
                    CD_FUNDO = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quadros", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quadros");
        }
    }
}
