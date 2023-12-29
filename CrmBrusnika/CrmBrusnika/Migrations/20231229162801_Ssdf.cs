using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrmBrusnika.Migrations
{
    /// <inheritdoc />
    public partial class Ssdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Entities",
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
                    table.PrimaryKey("PK_Entities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entities_Lands_LandId",
                        column: x => x.LandId,
                        principalTable: "Lands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LandId = table.Column<Guid>(type: "uuid", nullable: false),
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Stage = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_Lands_LandId",
                        column: x => x.LandId,
                        principalTable: "Lands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entities_LandId",
                table: "Entities",
                column: "LandId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_transactions_EntityId",
                table: "transactions",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_LandId",
                table: "transactions",
                column: "LandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "Lands");
        }
    }
}
