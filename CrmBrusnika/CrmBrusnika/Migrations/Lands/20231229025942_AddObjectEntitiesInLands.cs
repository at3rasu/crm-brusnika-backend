using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrmBrusnika.Migrations.Lands
{
    /// <inheritdoc />
    public partial class AddObjectEntitiesInLands : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LandId = table.Column<Guid>(type: "uuid", nullable: false),
                    JuridicalCost = table.Column<double>(type: "double precision", nullable: false),
                    PermissiveSide = table.Column<string>(type: "text", nullable: false),
                    GeotechnicalConditions = table.Column<string>(type: "text", nullable: false),
                    AvailabilityEngineeringNetworks = table.Column<string>(type: "text", nullable: false),
                    TransportationaAccessibility = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectEntity_Lands_LandId",
                        column: x => x.LandId,
                        principalTable: "Lands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectEntity_LandId",
                table: "ObjectEntity",
                column: "LandId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectEntity");
        }
    }
}
