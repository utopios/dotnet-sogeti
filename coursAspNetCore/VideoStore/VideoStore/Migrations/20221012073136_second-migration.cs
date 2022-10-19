using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoStore.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videostore_loan_videostore_customer_CustomerId",
                table: "videostore_loan");

            migrationBuilder.DropForeignKey(
                name: "FK_videostore_movie_videostore_loan_LoanId",
                table: "videostore_movie");

            migrationBuilder.RenameColumn(
                name: "LoanId",
                table: "videostore_movie",
                newName: "loan_id");

            migrationBuilder.RenameIndex(
                name: "IX_videostore_movie_LoanId",
                table: "videostore_movie",
                newName: "IX_videostore_movie_loan_id");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "videostore_loan",
                newName: "customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_videostore_loan_CustomerId",
                table: "videostore_loan",
                newName: "IX_videostore_loan_customer_id");

            migrationBuilder.AlterColumn<int>(
                name: "loan_id",
                table: "videostore_movie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "customer_id",
                table: "videostore_loan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_videostore_loan_videostore_customer_customer_id",
                table: "videostore_loan",
                column: "customer_id",
                principalTable: "videostore_customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_videostore_movie_videostore_loan_loan_id",
                table: "videostore_movie",
                column: "loan_id",
                principalTable: "videostore_loan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videostore_loan_videostore_customer_customer_id",
                table: "videostore_loan");

            migrationBuilder.DropForeignKey(
                name: "FK_videostore_movie_videostore_loan_loan_id",
                table: "videostore_movie");

            migrationBuilder.RenameColumn(
                name: "loan_id",
                table: "videostore_movie",
                newName: "LoanId");

            migrationBuilder.RenameIndex(
                name: "IX_videostore_movie_loan_id",
                table: "videostore_movie",
                newName: "IX_videostore_movie_LoanId");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "videostore_loan",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_videostore_loan_customer_id",
                table: "videostore_loan",
                newName: "IX_videostore_loan_CustomerId");

            migrationBuilder.AlterColumn<int>(
                name: "LoanId",
                table: "videostore_movie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "videostore_loan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_videostore_loan_videostore_customer_CustomerId",
                table: "videostore_loan",
                column: "CustomerId",
                principalTable: "videostore_customer",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_videostore_movie_videostore_loan_LoanId",
                table: "videostore_movie",
                column: "LoanId",
                principalTable: "videostore_loan",
                principalColumn: "Id");
        }
    }
}
