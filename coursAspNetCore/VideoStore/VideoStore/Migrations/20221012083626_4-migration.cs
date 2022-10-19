using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoStore.Migrations
{
    public partial class _4migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddForeignKey(
                name: "FK_videostore_movie_videostore_loan_LoanId",
                table: "videostore_movie",
                column: "LoanId",
                principalTable: "videostore_loan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
