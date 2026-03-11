using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.SqlServer.Spatial.Migrations
{
    /// <inheritdoc />
    public partial class AddedSpatialIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                                 CREATE SPATIAL INDEX IX_Example_Point
                                 ON Example(Point)
                                 USING GEOGRAPHY_GRID
                                 """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
