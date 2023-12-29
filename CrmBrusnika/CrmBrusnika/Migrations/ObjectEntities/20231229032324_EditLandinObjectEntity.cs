using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrmBrusnika.Migrations.ObjectEntities
{
    /// <inheritdoc />
    public partial class EditLandinObjectEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectEntities_Lands_LandId",
                table: "ObjectEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lands",
                table: "Lands");

            migrationBuilder.RenameTable(
                name: "Lands",
                newName: "Land");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Land",
                table: "Land",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectEntities_Land_LandId",
                table: "ObjectEntities",
                column: "LandId",
                principalTable: "Land",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectEntities_Land_LandId",
                table: "ObjectEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Land",
                table: "Land");

            migrationBuilder.RenameTable(
                name: "Land",
                newName: "Lands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lands",
                table: "Lands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectEntities_Lands_LandId",
                table: "ObjectEntities",
                column: "LandId",
                principalTable: "Lands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
