using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoStore.Migrations
{
    public partial class _5migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videostore_movie_videostore_loan_loan_id",
                table: "videostore_movie");

            migrationBuilder.AlterColumn<int>(
                name: "loan_id",
                table: "videostore_movie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_videostore_movie_videostore_loan_loan_id",
                table: "videostore_movie",
                column: "loan_id",
                principalTable: "videostore_loan",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videostore_movie_videostore_loan_loan_id",
                table: "videostore_movie");

            migrationBuilder.AlterColumn<int>(
                name: "loan_id",
                table: "videostore_movie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_videostore_movie_videostore_loan_loan_id",
                table: "videostore_movie",
                column: "loan_id",
                principalTable: "videostore_loan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
