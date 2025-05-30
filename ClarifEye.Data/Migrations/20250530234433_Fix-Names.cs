using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClarifEye.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YesNoQuestion_AspNetUsers_ClarUserId",
                table: "YesNoQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_YesNoQuestion_YesNoQuestions_YesNoQuestionId",
                table: "YesNoQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YesNoQuestion",
                table: "YesNoQuestion");

            migrationBuilder.RenameTable(
                name: "YesNoQuestion",
                newName: "YesNoAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_YesNoQuestion_YesNoQuestionId",
                table: "YesNoAnswers",
                newName: "IX_YesNoAnswers_YesNoQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_YesNoQuestion_ClarUserId",
                table: "YesNoAnswers",
                newName: "IX_YesNoAnswers_ClarUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Occupation",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Enum",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YesNoAnswers",
                table: "YesNoAnswers",
                column: "YesNoAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_YesNoAnswers_AspNetUsers_ClarUserId",
                table: "YesNoAnswers",
                column: "ClarUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_YesNoAnswers_YesNoQuestions_YesNoQuestionId",
                table: "YesNoAnswers",
                column: "YesNoQuestionId",
                principalTable: "YesNoQuestions",
                principalColumn: "YesNoQuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YesNoAnswers_AspNetUsers_ClarUserId",
                table: "YesNoAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_YesNoAnswers_YesNoQuestions_YesNoQuestionId",
                table: "YesNoAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YesNoAnswers",
                table: "YesNoAnswers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "YesNoAnswers",
                newName: "YesNoQuestion");

            migrationBuilder.RenameIndex(
                name: "IX_YesNoAnswers_YesNoQuestionId",
                table: "YesNoQuestion",
                newName: "IX_YesNoQuestion_YesNoQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_YesNoAnswers_ClarUserId",
                table: "YesNoQuestion",
                newName: "IX_YesNoQuestion_ClarUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Occupation",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Enum",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_YesNoQuestion",
                table: "YesNoQuestion",
                column: "YesNoAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_YesNoQuestion_AspNetUsers_ClarUserId",
                table: "YesNoQuestion",
                column: "ClarUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_YesNoQuestion_YesNoQuestions_YesNoQuestionId",
                table: "YesNoQuestion",
                column: "YesNoQuestionId",
                principalTable: "YesNoQuestions",
                principalColumn: "YesNoQuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
