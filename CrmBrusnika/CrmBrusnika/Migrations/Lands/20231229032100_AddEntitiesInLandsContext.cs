using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrmBrusnika.Migrations.Lands
{
    /// <inheritdoc />
    public partial class AddEntitiesInLandsContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectEntity_Lands_LandId",
                table: "ObjectEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ObjectEntity",
                table: "ObjectEntity");

            migrationBuilder.RenameTable(
                name: "ObjectEntity",
                newName: "Entities");

            migrationBuilder.RenameIndex(
                name: "IX_ObjectEntity_LandId",
                table: "Entities",
                newName: "IX_Entities_LandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entities",
                table: "Entities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_Lands_LandId",
                table: "Entities",
                column: "LandId",
                principalTable: "Lands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entities_Lands_LandId",
                table: "Entities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entities",
                table: "Entities");

            migrationBuilder.RenameTable(
                name: "Entities",
                newName: "ObjectEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Entities_LandId",
                table: "ObjectEntity",
                newName: "IX_ObjectEntity_LandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObjectEntity",
                table: "ObjectEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectEntity_Lands_LandId",
                table: "ObjectEntity",
                column: "LandId",
                principalTable: "Lands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
