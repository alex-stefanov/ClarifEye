using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClarifEye.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAnswerSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChoiceAnswers",
                keyColumn: "ChoiceAnswerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ChoiceAnswers",
                keyColumn: "ChoiceAnswerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ChoiceAnswers",
                keyColumn: "ChoiceAnswerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ChoiceAnswers",
                keyColumn: "ChoiceAnswerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ScaleAnswers",
                keyColumn: "ScaleAnswerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ScaleAnswers",
                keyColumn: "ScaleAnswerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ScaleAnswers",
                keyColumn: "ScaleAnswerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ScaleAnswers",
                keyColumn: "ScaleAnswerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ScaleAnswers",
                keyColumn: "ScaleAnswerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ScaleAnswers",
                keyColumn: "ScaleAnswerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ScaleAnswers",
                keyColumn: "ScaleAnswerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ScaleAnswers",
                keyColumn: "ScaleAnswerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ScaleAnswers",
                keyColumn: "ScaleAnswerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ScaleAnswers",
                keyColumn: "ScaleAnswerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ScaleAnswers",
                keyColumn: "ScaleAnswerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ScaleAnswers",
                keyColumn: "ScaleAnswerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ScaleAnswers",
                keyColumn: "ScaleAnswerId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "YesNoAnswers",
                keyColumn: "YesNoAnswerId",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fdbb90bb-9096-4610-9614-f533c1eeedce", "4af4dce4-93f5-4eb3-8309-c0df60c11044" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "425795df-47a2-42f7-8557-113fa2383bc5", "5eb1a3b8-6c55-4935-b05f-feab1be5bb6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1a17cea4-3d03-490b-b9fd-dfc0cfaf6ec5", "ddb6e3a2-f01b-4616-ac06-c8d549fec20f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aec14a14-cbc6-4a15-bc87-1b85a185fdbf", "631873a8-01b0-4e26-9b9c-6389d4a18677" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2d114365-3296-4b8c-8e78-3ab1cd9968cd", "cdf5ddf6-2906-42f5-81fc-ac487041c494" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5584aefc-d21d-437a-91b6-e3c348e7d728", "bfc728ea-fccc-4389-8a47-adc3df0645af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1ca89c78-8dd7-4924-9acf-c15c1fe83d0a", "c3345452-d7dd-43f6-8a3e-0a7e87d1f702" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a2f7b33b-876d-4213-aaa7-bbc1306b920e", "3c963507-2ee9-4e2f-aa64-f96028bc5154" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e573410e-00d0-4f62-b54e-9245ddee15d0", "244dcb3f-8881-4937-9340-991b5c643137" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c5a73f57-661b-49f4-9f34-1d1d540388fa", "73b75d83-9267-443d-8d88-7a233d9b7e49" });

            migrationBuilder.InsertData(
                table: "ChoiceAnswers",
                columns: new[] { "ChoiceAnswerId", "ChoiceId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "user-1" },
                    { 2, 2, "user-2" },
                    { 3, 3, "user-3" },
                    { 4, 2, "user-5" }
                });

            migrationBuilder.InsertData(
                table: "ScaleAnswers",
                columns: new[] { "ScaleAnswerId", "ClarUserId", "ScaleQuestionId", "SelectedOption" },
                values: new object[,]
                {
                    { 1, "user-1", 1, 0 },
                    { 2, "user-1", 2, 0 },
                    { 3, "user-1", 3, 0 },
                    { 4, "user-1", 4, 0 },
                    { 5, "user-1", 5, 0 },
                    { 6, "user-1", 6, 0 },
                    { 7, "user-1", 7, 0 },
                    { 8, "user-1", 8, 0 },
                    { 9, "user-1", 9, 0 },
                    { 10, "user-1", 10, 0 },
                    { 11, "user-1", 11, 0 },
                    { 12, "user-1", 12, 0 },
                    { 13, "user-1", 13, 0 }
                });

            migrationBuilder.InsertData(
                table: "YesNoAnswers",
                columns: new[] { "YesNoAnswerId", "ClarUserId", "SelectedOption", "YesNoQuestionId" },
                values: new object[,]
                {
                    { 1, "user-1", 1, 1 },
                    { 2, "user-1", 1, 2 },
                    { 3, "user-1", 0, 3 },
                    { 4, "user-1", 1, 4 },
                    { 5, "user-1", 0, 5 },
                    { 6, "user-1", 1, 6 },
                    { 7, "user-2", 1, 1 },
                    { 8, "user-2", 0, 2 },
                    { 9, "user-2", 0, 3 },
                    { 10, "user-2", 1, 4 },
                    { 11, "user-2", 1, 5 },
                    { 12, "user-2", 0, 6 },
                    { 13, "user-3", 0, 1 },
                    { 14, "user-3", 1, 2 },
                    { 15, "user-3", 1, 3 },
                    { 16, "user-3", 1, 4 },
                    { 17, "user-3", 0, 5 },
                    { 18, "user-3", 1, 6 },
                    { 19, "user-4", 2, 1 },
                    { 20, "user-4", 0, 2 },
                    { 21, "user-4", 0, 3 },
                    { 22, "user-4", 1, 4 },
                    { 23, "user-4", 1, 5 },
                    { 24, "user-4", 0, 6 },
                    { 25, "user-5", 1, 1 },
                    { 26, "user-5", 0, 2 },
                    { 27, "user-5", 0, 3 },
                    { 28, "user-5", 1, 4 },
                    { 29, "user-5", 1, 5 },
                    { 30, "user-5", 1, 6 }
                });
        }
    }
}
