using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormStructureEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormStructureEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InputEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DataType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Required = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormStructureInputEntity",
                columns: table => new
                {
                    FormStructureId = table.Column<string>(type: "text", nullable: false),
                    InputId = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormStructureInputEntity", x => new { x.FormStructureId, x.InputId });
                    table.ForeignKey(
                        name: "FK_FormStructureInputEntity_FormStructureEntity_FormStructureId",
                        column: x => x.FormStructureId,
                        principalTable: "FormStructureEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormStructureInputEntity_InputEntity_InputId",
                        column: x => x.InputId,
                        principalTable: "InputEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormStructureInputEntity_InputId",
                table: "FormStructureInputEntity",
                column: "InputId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormStructureInputEntity");

            migrationBuilder.DropTable(
                name: "FormStructureEntity");

            migrationBuilder.DropTable(
                name: "InputEntity");
        }
    }
}
