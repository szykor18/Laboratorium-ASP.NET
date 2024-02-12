using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Number = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Region = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Country = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    PESEL = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfEmployment = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOfDismissal = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_employees_branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e97b65d3-4e61-4d5d-871c-adc4cf4c21a5", "e97b65d3-4e61-4d5d-871c-adc4cf4c21a5", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea67219e-154f-4cd7-b4b9-017a4551f395", "ea67219e-154f-4cd7-b4b9-017a4551f395", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "be93e15f-e31a-4606-9483-0795771e6d0b", 0, "a76aa99e-c532-43a7-8279-1d13af49629a", "user@wsei.edu.pl", true, false, null, "USER@WSEI.EDU.PL", "USER", "AQAAAAEAACcQAAAAEDy63vjbgZ6fjFQt/R4tsqjOv7vCj3P3bmOOT+cODXaAX7MLOD1mL62yQVIiR/r++Q==", null, false, "7c186ae9-d67a-484f-8481-b6a2153bc41c", false, "user" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "efa14892-ce09-4c41-b787-87804119e174", 0, "bcb27465-b834-45ec-9fb1-f55491399a94", "admin@wsei.edu.pl", true, false, null, "ADMIN@WSEI.EDU.PL", "ADMIN", "AQAAAAEAACcQAAAAEOLJ4uGK671vdiT8mV/NJ4CLrn8rOzVSqvUlD3rmuvvBVIKer8qihwc6mCyYSLqdAg==", null, false, "ebb21189-c9e8-404e-a408-699727c4e2d6", false, "admin" });

            migrationBuilder.InsertData(
                table: "branches",
                columns: new[] { "BranchId", "Title", "Address_City", "Address_Country", "Address_Number", "Address_PostalCode", "Address_Region", "Address_Street" },
                values: new object[] { 1, "Firma X", "Kraków", "Polska", "123", "00-015", "mazowieckie", "Korona" });

            migrationBuilder.InsertData(
                table: "branches",
                columns: new[] { "BranchId", "Title", "Address_City", "Address_Country", "Address_Number", "Address_PostalCode", "Address_Region", "Address_Street" },
                values: new object[] { 2, "XYZ Spółka z o.o.", "Kraków", "Polska", "3", "33-212", "Małopolskie", "Rynek Główny" });

            migrationBuilder.InsertData(
                table: "branches",
                columns: new[] { "BranchId", "Title", "Address_City", "Address_Country", "Address_Number", "Address_PostalCode", "Address_Region", "Address_Street" },
                values: new object[] { 3, "XYZ Spółka Akcyjna", "Warszawa", "Polska", "13", "22-143", "Mazowieckie", "Praska" });

            migrationBuilder.InsertData(
                table: "branches",
                columns: new[] { "BranchId", "Title", "Address_City", "Address_Country", "Address_Number", "Address_PostalCode", "Address_Region", "Address_Street" },
                values: new object[] { 4, "XYZ Spółka komandytowa", "Poznań", "Polska", "15", "41-320", "Wielkopolskie", "Błotna" });

            migrationBuilder.InsertData(
                table: "branches",
                columns: new[] { "BranchId", "Title", "Address_City", "Address_Country", "Address_Number", "Address_PostalCode", "Address_Region", "Address_Street" },
                values: new object[] { 5, "Firma Y", "Kraków", "Polska", "10", "32-040", "Małopolskie", "Topolowa" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ea67219e-154f-4cd7-b4b9-017a4551f395", "be93e15f-e31a-4606-9483-0795771e6d0b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e97b65d3-4e61-4d5d-871c-adc4cf4c21a5", "efa14892-ce09-4c41-b787-87804119e174" });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "EmployeeId", "BranchId", "DateOfDismissal", "DateOfEmployment", "Email", "LastName", "Name", "PESEL", "Phone", "Position" },
                values: new object[] { 1, 1, null, new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ewa.maj@firmax.pl", "Maj", "Ewa", "76051112345", "500100200", 1 });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "EmployeeId", "BranchId", "DateOfDismissal", "DateOfEmployment", "Email", "LastName", "Name", "PESEL", "Phone", "Position" },
                values: new object[] { 2, 2, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "marcin.zawadzki@xyz.com", "Zawadzki", "Marcin", "85012223456", "600200300", 2 });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "EmployeeId", "BranchId", "DateOfDismissal", "DateOfEmployment", "Email", "LastName", "Name", "PESEL", "Phone", "Position" },
                values: new object[] { 3, 3, null, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "anna.kowalczyk@xyzsa.com", "Kowalczyk", "Anna", "94021567890", "700300400", 3 });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "EmployeeId", "BranchId", "DateOfDismissal", "DateOfEmployment", "Email", "LastName", "Name", "PESEL", "Phone", "Position" },
                values: new object[] { 4, 4, null, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "krzysztof.borowski@xyzsk.com", "Borowski", "Krzysztof", "87032145698", "800400500", 4 });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "EmployeeId", "BranchId", "DateOfDismissal", "DateOfEmployment", "Email", "LastName", "Name", "PESEL", "Phone", "Position" },
                values: new object[] { 5, 5, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "magdalena.sikorska@firmax.pl", "Sikorska", "Magdalena", "88040512345", "900500600", 5 });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "EmployeeId", "BranchId", "DateOfDismissal", "DateOfEmployment", "Email", "LastName", "Name", "PESEL", "Phone", "Position" },
                values: new object[] { 6, 1, null, new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "tomasz.nowak@xyz.com", "Nowak", "Tomasz", "92050867890", "910610710", 1 });

            migrationBuilder.InsertData(
                table: "employees",
                columns: new[] { "EmployeeId", "BranchId", "DateOfDismissal", "DateOfEmployment", "Email", "LastName", "Name", "PESEL", "Phone", "Position" },
                values: new object[] { 7, 2, null, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "julia.wojcik@xyzsa.com", "Wójcik", "Julia", "93061178901", "920720820", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_BranchId",
                table: "employees",
                column: "BranchId");
        }

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
                name: "employees");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "branches");
        }
    }
}
