using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Api.Data.SqlServer.Spatial.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__EFAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EntityKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntitySetName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EntityTypeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EntityState = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    RequestId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___EFAudit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "__EFDataProtectionKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendlyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xml = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___EFDataProtectionKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "__EFIdentityRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___EFIdentityRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "__EFIdentityUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___EFIdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Example",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Point = table.Column<Point>(type: "geography", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Example", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "__EFAuditProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    RelationName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___EFAuditProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK___EFAuditProperties___EFAudit_ParentId",
                        column: x => x.ParentId,
                        principalTable: "__EFAudit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "__EFIdentityRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___EFIdentityRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK___EFIdentityRoleClaim___EFIdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "__EFIdentityRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "__EFIdentityApiKey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentityUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    RevokedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___EFIdentityApiKey", x => x.Id);
                    table.ForeignKey(
                        name: "FK___EFIdentityApiKey___EFIdentityUser_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "__EFIdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "__EFIdentityUserChangeData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentityUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NewPhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___EFIdentityUserChangeData", x => x.Id);
                    table.ForeignKey(
                        name: "FK___EFIdentityUserChangeData___EFIdentityUser_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "__EFIdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "__EFIdentityUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___EFIdentityUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK___EFIdentityUserClaim___EFIdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "__EFIdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "__EFIdentityUserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___EFIdentityUserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK___EFIdentityUserLogin___EFIdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "__EFIdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "__EFIdentityUserRefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentityUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ExpireAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___EFIdentityUserRefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK___EFIdentityUserRefreshToken___EFIdentityUser_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "__EFIdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "__EFIdentityUserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___EFIdentityUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK___EFIdentityUserRole___EFIdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "__EFIdentityRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK___EFIdentityUserRole___EFIdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "__EFIdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "__EFIdentityUserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___EFIdentityUserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK___EFIdentityUserToken___EFIdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "__EFIdentityUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX___EFAudit_CreatedBy",
                table: "__EFAudit",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX___EFAudit_EntityState",
                table: "__EFAudit",
                column: "EntityState");

            migrationBuilder.CreateIndex(
                name: "IX___EFAudit_EntityTypeName",
                table: "__EFAudit",
                column: "EntityTypeName");

            migrationBuilder.CreateIndex(
                name: "IX___EFAudit_RequestId",
                table: "__EFAudit",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX___EFAuditProperties_ParentId",
                table: "__EFAuditProperties",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX___EFAuditProperties_PropertyName",
                table: "__EFAuditProperties",
                column: "PropertyName");

            migrationBuilder.CreateIndex(
                name: "IX___EFIdentityApiKey_IdentityUserId",
                table: "__EFIdentityApiKey",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX___EFIdentityApiKey_RevokedAt",
                table: "__EFIdentityApiKey",
                column: "RevokedAt");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "__EFIdentityRole",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX___EFIdentityRoleClaim_RoleId",
                table: "__EFIdentityRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "__EFIdentityUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX___EFIdentityUser_Email",
                table: "__EFIdentityUser",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX___EFIdentityUser_IsActive",
                table: "__EFIdentityUser",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX___EFIdentityUser_PhoneNumber",
                table: "__EFIdentityUser",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "__EFIdentityUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UX___EFIdentityUserChangeData_IdentityUserId",
                table: "__EFIdentityUserChangeData",
                column: "IdentityUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX___EFIdentityUserClaim_UserId",
                table: "__EFIdentityUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX___EFIdentityUserLogin_UserId",
                table: "__EFIdentityUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX___EFIdentityUserRefreshToken_ExpireAt",
                table: "__EFIdentityUserRefreshToken",
                column: "ExpireAt");

            migrationBuilder.CreateIndex(
                name: "UX___EFIdentityUserRefreshToken_IdentityUserId",
                table: "__EFIdentityUserRefreshToken",
                column: "IdentityUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX___EFIdentityUserRefreshToken_IdentityUserId_AppId",
                table: "__EFIdentityUserRefreshToken",
                columns: new[] { "IdentityUserId", "AppId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX___EFIdentityUserRole_RoleId",
                table: "__EFIdentityUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Example_CreatedAt",
                table: "Example",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Example_IsDeleted",
                table: "Example",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Example_Name",
                table: "Example",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__EFAuditProperties");

            migrationBuilder.DropTable(
                name: "__EFDataProtectionKeys");

            migrationBuilder.DropTable(
                name: "__EFIdentityApiKey");

            migrationBuilder.DropTable(
                name: "__EFIdentityRoleClaim");

            migrationBuilder.DropTable(
                name: "__EFIdentityUserChangeData");

            migrationBuilder.DropTable(
                name: "__EFIdentityUserClaim");

            migrationBuilder.DropTable(
                name: "__EFIdentityUserLogin");

            migrationBuilder.DropTable(
                name: "__EFIdentityUserRefreshToken");

            migrationBuilder.DropTable(
                name: "__EFIdentityUserRole");

            migrationBuilder.DropTable(
                name: "__EFIdentityUserToken");

            migrationBuilder.DropTable(
                name: "Example");

            migrationBuilder.DropTable(
                name: "__EFAudit");

            migrationBuilder.DropTable(
                name: "__EFIdentityRole");

            migrationBuilder.DropTable(
                name: "__EFIdentityUser");
        }
    }
}
