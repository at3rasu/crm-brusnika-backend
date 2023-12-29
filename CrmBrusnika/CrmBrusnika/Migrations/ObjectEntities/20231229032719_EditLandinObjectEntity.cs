using System;
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
            migrationBuilder.CreateTable(
                name: "Land",
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
                    table.PrimaryKey("PK_Land", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectEntities",
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
                    table.PrimaryKey("PK_ObjectEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectEntities_Land_LandId",
                        column: x => x.LandId,
                        principalTable: "Land",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectEntities_LandId",
                table: "ObjectEntities",
                column: "LandId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectEntities");

            migrationBuilder.DropTable(
                name: "Land");
        }
    }
}
