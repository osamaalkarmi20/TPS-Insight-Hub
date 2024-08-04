using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TPS_Insight_Hub.Migrations
{
    /// <inheritdoc />
    public partial class osama : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    LookUpDepartmentId = table.Column<int>(type: "int", nullable: true),
                    DepartmentPositionId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_LookUpDepartmentId",
                        column: x => x.LookUpDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Positions_DepartmentPositionId",
                        column: x => x.DepartmentPositionId,
                        principalTable: "Positions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin", "00000000-0000-0000-0000-000000000000", "admin", "ADMIN" },
                    { "user", "00000000-0000-0000-0000-000000000000", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DepartmentId", "DepartmentPositionId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "LookUpDepartmentId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PositionId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "admin-id", 0, "92c7e7ac-2f84-4275-9966-1b5fc40af365", 1, null, "admin@example.com", true, false, null, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEHh8o7tDK0PWZ5iiiFy0Uho5I9XJp8U2zRCLgfQxJTio2uHt0LnsU73o3zNLK50Pvg==", null, false, 1, "", false, "admin" },
                    { "user-1", 0, "18aa553f-c3ee-4c86-9509-e4b99f677068", 2, null, "user1@example.com", true, false, null, null, "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAEJHOBfCnA+idXap+osOkQu5pyjwKyOOOzkRhfOzyNP5z2IAoh04WynByVtejXar1Zw==", null, false, 2, "", false, "user1" },
                    { "user-10", 0, "75ba2dbf-0bf8-4d18-a907-d672294a8949", 1, null, "user10@example.com", true, false, null, null, "USER10@EXAMPLE.COM", "USER10", "AQAAAAIAAYagAAAAEHlWkGKnMVhnWsLzYrRvpPw4ulL+UpBvvIknP6+LmA+Qdb7YEQ9cl95inRAie/89Qw==", null, false, 1, "", false, "user10" },
                    { "user-11", 0, "ec1dc40d-1608-4808-a1de-cee234f8297e", 2, null, "user11@example.com", true, false, null, null, "USER11@EXAMPLE.COM", "USER11", "AQAAAAIAAYagAAAAEM9aJ6j0xVfaA/QCJRU5RLFbhe0K7UsypZvQ/5xg6vXJIjKZeQ/hsfA3oep8pbdqJA==", null, false, 2, "", false, "user11" },
                    { "user-12", 0, "bfb97fe4-fcb1-4b3a-ba5a-776c41a71c05", 3, null, "user12@example.com", true, false, null, null, "USER12@EXAMPLE.COM", "USER12", "AQAAAAIAAYagAAAAEGV1c2sffbVIu0lfIAnUkdLb55ByMbk18FQUj8+xmJeMVIY7gBwOqJPM8rEYZTb8Rg==", null, false, 3, "", false, "user12" },
                    { "user-2", 0, "fcaaccec-4001-49f9-a125-3b7a581427a8", 3, null, "user2@example.com", true, false, null, null, "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEMPG1A3kO7e8RzKA3lSIlJnjjRITdH5WSveyQ9fHbxqCvC1ChHtPZCquBtRKjBcFCw==", null, false, 3, "", false, "user2" },
                    { "user-3", 0, "65f79401-99a0-4366-8cfb-f7f4f1114e95", 4, null, "user3@example.com", true, false, null, null, "USER3@EXAMPLE.COM", "USER3", "AQAAAAIAAYagAAAAEK17mzvOXob6AFyrjailojK9Q4114/lfFexDAoZjQiV8+dw5/fvpYDCBWV0PaFFDog==", null, false, 4, "", false, "user3" },
                    { "user-4", 0, "d4d93093-13d3-4ccc-9874-fca600f48683", 5, null, "user4@example.com", true, false, null, null, "USER4@EXAMPLE.COM", "USER4", "AQAAAAIAAYagAAAAEIIBhigjPVMZROfjNwP3Wslb2P/HJ3L+oLw+wq/iioGkxZsNgZZaBWkzncM6VWxlkQ==", null, false, 5, "", false, "user4" },
                    { "user-5", 0, "054a3abb-b56e-4fa5-85fb-12cabd643204", 6, null, "user5@example.com", true, false, null, null, "USER5@EXAMPLE.COM", "USER5", "AQAAAAIAAYagAAAAEAvxQ4IuQwcG/OuRp307o5aU/yl8SXOUMCJcSkzZ5LGHraURGVDExSfKrHcUTQFK4Q==", null, false, 6, "", false, "user5" },
                    { "user-6", 0, "3ae63b12-9582-4e6e-a60c-3f120380a350", 7, null, "user6@example.com", true, false, null, null, "USER6@EXAMPLE.COM", "USER6", "AQAAAAIAAYagAAAAEIq57SU7mFYjb6gh9GgIgfdaRrlXdxwPdIV1UbsY+utroaR4miXVp2CJzPAsBGVvtQ==", null, false, 7, "", false, "user6" },
                    { "user-7", 0, "60e706c0-30bf-4299-8315-9f3e228848c9", 8, null, "user7@example.com", true, false, null, null, "USER7@EXAMPLE.COM", "USER7", "AQAAAAIAAYagAAAAEKcAva/ZKWiyMI/3q/lV0XpUKyvPYoPHw93fay5uBGW3MlAHtmwtre0ewAhdE6C45g==", null, false, 8, "", false, "user7" },
                    { "user-8", 0, "929f6788-e339-4aa3-a772-15fa61e85cbd", 9, null, "user8@example.com", true, false, null, null, "USER8@EXAMPLE.COM", "USER8", "AQAAAAIAAYagAAAAENMXSqAjBwXXbIIPiAarZjeU9nmUOo9iRbilWjapKMKK2une/47T4RPTphEIj1RKoA==", null, false, 9, "", false, "user8" },
                    { "user-9", 0, "4aef9526-9b9d-4ac2-ab0d-d898058a8ccb", 10, null, "user9@example.com", true, false, null, null, "USER9@EXAMPLE.COM", "USER9", "AQAAAAIAAYagAAAAEGHs8WjZQLLIXteRxZJKZilEWNnYtZ3IJC1gWxOHKJwm2tSjDXF2Q794YZ2awPxLqw==", null, false, 10, "", false, "user9" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "Sales" },
                    { 4, "Marketing" },
                    { 5, "Finance" },
                    { 6, "Admin" },
                    { 7, "Support" },
                    { 8, "Development" },
                    { 9, "Design" },
                    { 10, "Testing" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Position" },
                values: new object[,]
                {
                    { 1, "Manager" },
                    { 2, "Developer" },
                    { 3, "Designer" },
                    { 4, "Tester" },
                    { 5, "Support" },
                    { 6, "HR" },
                    { 7, "Sales" },
                    { 8, "Marketing" },
                    { 9, "Finance" },
                    { 10, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "admin", "admin-id" },
                    { "user", "user-1" },
                    { "user", "user-10" },
                    { "user", "user-11" },
                    { "user", "user-12" },
                    { "user", "user-2" },
                    { "user", "user-3" },
                    { "user", "user-4" },
                    { "user", "user-5" },
                    { "user", "user-6" },
                    { "user", "user-7" },
                    { "user", "user-8" },
                    { "user", "user-9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentPositionId",
                table: "AspNetUsers",
                column: "DepartmentPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LookUpDepartmentId",
                table: "AspNetUsers",
                column: "LookUpDepartmentId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
