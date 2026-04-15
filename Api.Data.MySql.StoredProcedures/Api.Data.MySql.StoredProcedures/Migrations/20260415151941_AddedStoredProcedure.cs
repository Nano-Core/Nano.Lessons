using Api.Data.MySql.StoredProcedures.Data.StoredProcedures;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.MySql.StoredProcedures.Migrations
{
    /// <inheritdoc />
    public partial class AddedStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql(ExampleStoredProcedureDefinition.SQL);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
