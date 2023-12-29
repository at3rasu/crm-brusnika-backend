using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrmBrusnika.Migrations.ObjectEntities
{
    /// <inheritdoc />
    public partial class AddObjectEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JuridicalCost = table.Column<double>(type: "double precision", nullable: false),
                    PermissiveSide = table.Column<string>(type: "text", nullable: false),
                    GeotechnicalConditions = table.Column<string>(type: "text", nullable: false),
                    AvailabilityEngineeringNetworks = table.Column<string>(type: "text", nullable: false),
                    TransportationaAccessibility = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectEntities", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectEntities");
        }
    }
}
