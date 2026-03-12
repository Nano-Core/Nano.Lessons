using Api.Data.MySql.Mappings.Data.Views;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.MySql.Views.Migrations
{
    /// <inheritdoc />
    public partial class AddedView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql(ExampleViewDefinition.SQL);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
