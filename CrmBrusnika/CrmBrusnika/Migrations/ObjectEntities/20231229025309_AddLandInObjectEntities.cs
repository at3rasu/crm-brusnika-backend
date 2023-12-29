using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrmBrusnika.Migrations.ObjectEntities
{
    /// <inheritdoc />
    public partial class AddLandInObjectEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LandId",
                table: "ObjectEntities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Lands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RegisterNumber = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    AreaInMeters = table.Column<string>(type: "text", nullable: false),
                    AboutHolder = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    WhoIsFound = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectEntities_LandId",
                table: "ObjectEntities",
                column: "LandId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectEntities_Lands_LandId",
                table: "ObjectEntities",
                column: "LandId",
                principalTable: "Lands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectEntities_Lands_LandId",
                table: "ObjectEntities");

            migrationBuilder.DropTable(
                name: "Lands");

            migrationBuilder.DropIndex(
                name: "IX_ObjectEntities_LandId",
                table: "ObjectEntities");

            migrationBuilder.DropColumn(
                name: "LandId",
                table: "ObjectEntities");
        }
    }
}
