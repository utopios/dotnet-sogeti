using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoStore.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "videostore_customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videostore_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "videostore_loan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videostore_loan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_videostore_loan_videostore_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "videostore_customer",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "videostore_movie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videostore_movie", x => x.id);
                    table.ForeignKey(
                        name: "FK_videostore_movie_videostore_loan_LoanId",
                        column: x => x.LoanId,
                        principalTable: "videostore_loan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_videostore_loan_CustomerId",
                table: "videostore_loan",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_videostore_movie_LoanId",
                table: "videostore_movie",
                column: "LoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "videostore_movie");

            migrationBuilder.DropTable(
                name: "videostore_loan");

            migrationBuilder.DropTable(
                name: "videostore_customer");
        }
    }
}
