using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Orders",
                table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: false),
                    CounterpartyName = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<byte[]>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Orders", x => x.Id); });

            migrationBuilder.CreateTable(
                "Products",
                table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    ProductNumber = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    OrderId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        "FK_Products_Orders_OrderId",
                        x => x.OrderId,
                        "Orders",
                        "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                "Subdivisions",
                table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ManagerId = table.Column<byte[]>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Subdivisions", x => x.Id); });

            migrationBuilder.CreateTable(
                "Employees",
                table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    SubdivisionId = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        "FK_Employees_Subdivisions_SubdivisionId",
                        x => x.SubdivisionId,
                        "Subdivisions",
                        "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                "IX_Employees_SubdivisionId",
                "Employees",
                "SubdivisionId");

            migrationBuilder.CreateIndex(
                "IX_Orders_AuthorId",
                "Orders",
                "AuthorId");

            migrationBuilder.CreateIndex(
                "IX_Products_OrderId",
                "Products",
                "OrderId");

            migrationBuilder.CreateIndex(
                "IX_Subdivisions_ManagerId",
                "Subdivisions",
                "ManagerId");

            migrationBuilder.AddForeignKey(
                "FK_Orders_Employees_AuthorId",
                "Orders",
                "AuthorId",
                "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                "FK_Subdivisions_Employees_ManagerId",
                "Subdivisions",
                "ManagerId",
                "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Employees_Subdivisions_SubdivisionId",
                "Employees");

            migrationBuilder.DropTable(
                "Products");

            migrationBuilder.DropTable(
                "Orders");

            migrationBuilder.DropTable(
                "Subdivisions");

            migrationBuilder.DropTable(
                "Employees");
        }
    }
}