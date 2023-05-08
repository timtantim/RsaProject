using Microsoft.EntityFrameworkCore.Migrations;

namespace RsaProject.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    MaterialId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ParentNode = table.Column<int>(nullable: false),
                    isHead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BomHead",
                columns: table => new
                {
                    BomCode = table.Column<string>(maxLength: 20, nullable: false),
                    Id = table.Column<int>(nullable: false),
                    MaterialCode = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BomHead", x => x.BomCode);
                });

            migrationBuilder.CreateTable(
                name: "BomDetail",
                columns: table => new
                {
                    BomCode = table.Column<string>(maxLength: 20, nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ChildMaterialCode = table.Column<string>(maxLength: 20, nullable: false),
                    MaterialNum = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BomDetail", x => x.BomCode);
                    table.ForeignKey(
                        name: "FK_BomDetail_BomHead_BomCode",
                        column: x => x.BomCode,
                        principalTable: "BomHead",
                        principalColumn: "BomCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BomHead_BomCode",
                table: "BomHead",
                column: "BomCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bom");

            migrationBuilder.DropTable(
                name: "BomDetail");

            migrationBuilder.DropTable(
                name: "BomHead");
        }
    }
}
