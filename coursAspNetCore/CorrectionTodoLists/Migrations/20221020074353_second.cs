using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorrectionTodoLists.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todo_item_todo_list_ToDoListId",
                table: "todo_item");

            migrationBuilder.DropIndex(
                name: "IX_todo_item_ToDoListId",
                table: "todo_item");

            migrationBuilder.DropColumn(
                name: "ToDoListId",
                table: "todo_item");

            migrationBuilder.CreateIndex(
                name: "IX_todo_item_todolist_id",
                table: "todo_item",
                column: "todolist_id");

            migrationBuilder.AddForeignKey(
                name: "FK_todo_item_todo_list_todolist_id",
                table: "todo_item",
                column: "todolist_id",
                principalTable: "todo_list",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todo_item_todo_list_todolist_id",
                table: "todo_item");

            migrationBuilder.DropIndex(
                name: "IX_todo_item_todolist_id",
                table: "todo_item");

            migrationBuilder.AddColumn<int>(
                name: "ToDoListId",
                table: "todo_item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_todo_item_ToDoListId",
                table: "todo_item",
                column: "ToDoListId");

            migrationBuilder.AddForeignKey(
                name: "FK_todo_item_todo_list_ToDoListId",
                table: "todo_item",
                column: "ToDoListId",
                principalTable: "todo_list",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
