using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Api.Data.MySql.Spatial.Migrations
{
    /// <inheritdoc />
    public partial class AddedSpatial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Point>(
                name: "Point",
                table: "Example",
                type: "point",
                nullable: false,
                defaultValue: (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (0 0)"))
                .Annotation("MySql:SpatialReferenceSystemId", 4326);

            migrationBuilder.CreateIndex(
                name: "IX_Example_Point",
                table: "Example",
                column: "Point")
                .Annotation("MySql:SpatialIndex", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Example_Point",
                table: "Example");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "Example");
        }
    }
}
