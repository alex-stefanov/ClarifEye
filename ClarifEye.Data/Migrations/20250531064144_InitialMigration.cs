using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClarifEye.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Enum = table.Column<int>(type: "int", nullable: true),
                    IsFilled = table.Column<bool>(type: "bit", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceQuestions",
                columns: table => new
                {
                    MultipleChoiceQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionString = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceQuestions", x => x.MultipleChoiceQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "ScaleQuestions",
                columns: table => new
                {
                    ScaleQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScaleQuestions", x => x.ScaleQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "YesNoQuestions",
                columns: table => new
                {
                    YesNoQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YesNoQuestions", x => x.YesNoQuestionId);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    ChoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MultipleChoiceQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.ChoiceId);
                    table.ForeignKey(
                        name: "FK_Choices_MultipleChoiceQuestions_MultipleChoiceQuestionId",
                        column: x => x.MultipleChoiceQuestionId,
                        principalTable: "MultipleChoiceQuestions",
                        principalColumn: "MultipleChoiceQuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScaleAnswers",
                columns: table => new
                {
                    ScaleAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectedOption = table.Column<int>(type: "int", nullable: false),
                    ScaleQuestionId = table.Column<int>(type: "int", nullable: false),
                    ClarUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScaleAnswers", x => x.ScaleAnswerId);
                    table.ForeignKey(
                        name: "FK_ScaleAnswers_AspNetUsers_ClarUserId",
                        column: x => x.ClarUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScaleAnswers_ScaleQuestions_ScaleQuestionId",
                        column: x => x.ScaleQuestionId,
                        principalTable: "ScaleQuestions",
                        principalColumn: "ScaleQuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YesNoAnswers",
                columns: table => new
                {
                    YesNoAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectedOption = table.Column<int>(type: "int", nullable: false),
                    YesNoQuestionId = table.Column<int>(type: "int", nullable: false),
                    ClarUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YesNoAnswers", x => x.YesNoAnswerId);
                    table.ForeignKey(
                        name: "FK_YesNoAnswers_AspNetUsers_ClarUserId",
                        column: x => x.ClarUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YesNoAnswers_YesNoQuestions_YesNoQuestionId",
                        column: x => x.YesNoQuestionId,
                        principalTable: "YesNoQuestions",
                        principalColumn: "YesNoQuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChoiceAnswers",
                columns: table => new
                {
                    ChoiceAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChoiceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceAnswers", x => x.ChoiceAnswerId);
                    table.ForeignKey(
                        name: "FK_ChoiceAnswers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChoiceAnswers_Choices_ChoiceId",
                        column: x => x.ChoiceId,
                        principalTable: "Choices",
                        principalColumn: "ChoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "Enum", "FirstName", "IsFilled", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Occupation", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "user-1", 0, 34, "3f61ab8c-5f0d-4414-a890-eeb6321b704a", "ClarUser", null, false, 0, "Ivan", false, "Dimitrov", false, null, null, null, "Software Engineer", null, null, false, "6014c79c-a4c9-43f2-82d2-05dca97ab3b7", false, null },
                    { "user-2", 0, 28, "0462e7a2-d7d8-4a8e-a103-6f1845d3ae07", "ClarUser", null, false, 1, "Maria", false, "Petrova", false, null, null, null, "Graphic Designer", null, null, false, "59bc3649-4f5c-4fa5-b249-01b7ffd77d50", false, null },
                    { "user-3", 0, 45, "fab4b1e3-b22d-4e0c-a186-cf3c9f49179a", "ClarUser", null, false, 0, "Georgi", false, "Ivanov", false, null, null, null, "Teacher", null, null, false, "02b94d42-dd56-4148-9b59-094330601d14", false, null },
                    { "user-4", 0, 22, "cd6dc205-851c-45b6-80eb-142c13b5ee92", "ClarUser", null, false, 1, "Elena", false, "Koleva", false, null, null, null, "Student", null, null, false, "f8ba5564-63f8-45d2-be12-42fde21eefd4", false, null },
                    { "user-5", 0, 39, "ddaf7157-7e31-45e2-af56-bc1c254aceca", "ClarUser", null, false, 0, "Nikolay", false, "Stoyanov", false, null, null, null, "Mechanic", null, null, false, "4e46ecaa-fab7-4824-b129-11a96a620590", false, null }
                });

            migrationBuilder.InsertData(
                table: "MultipleChoiceQuestions",
                columns: new[] { "MultipleChoiceQuestionId", "QuestionString" },
                values: new object[,]
                {
                    { 1, "When was your last eye exam?" },
                    { 2, "How often do you use eye protection (e.g., sunglasses, safety goggles) when needed?" }
                });

            migrationBuilder.InsertData(
                table: "ScaleQuestions",
                columns: new[] { "ScaleQuestionId", "QuestionText" },
                values: new object[,]
                {
                    { 1, "Blurry vision" },
                    { 2, "Double vision" },
                    { 3, "Difficulty seeing at night" },
                    { 4, "Halos around lights" },
                    { 5, "Trouble focusing" },
                    { 6, "Dry or gritty eyes" },
                    { 7, "Watery eyes" },
                    { 8, "Red or bloodshot eyes" },
                    { 9, "Burning/itching" },
                    { 10, "Eye pain or pressure" },
                    { 11, "Headaches after screens" },
                    { 12, "Eye strain or tiredness" },
                    { 13, "Sensitivity to light" }
                });

            migrationBuilder.InsertData(
                table: "YesNoQuestions",
                columns: new[] { "YesNoQuestionId", "QuestionText" },
                values: new object[,]
                {
                    { 1, "Do you wear glasses or contact lenses?" },
                    { 2, "Do you have a family history of eye conditions?" },
                    { 3, "Have you had eye surgery or trauma before?" },
                    { 4, "Do you use digital screens for more than 4 hours per day?" },
                    { 5, "Do you take regular breaks while using screens?" },
                    { 6, "Are you currently experiencing any vision-related problems?" }
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "ChoiceId", "AnswerString", "MultipleChoiceQuestionId" },
                values: new object[,]
                {
                    { 1, "Less than 1 year ago", 1 },
                    { 2, "1–2 years ago", 1 },
                    { 3, "More than 2 years ago", 1 }
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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceAnswers_ChoiceId",
                table: "ChoiceAnswers",
                column: "ChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ChoiceAnswers_UserId",
                table: "ChoiceAnswers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_MultipleChoiceQuestionId",
                table: "Choices",
                column: "MultipleChoiceQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ScaleAnswers_ClarUserId",
                table: "ScaleAnswers",
                column: "ClarUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScaleAnswers_ScaleQuestionId",
                table: "ScaleAnswers",
                column: "ScaleQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_YesNoAnswers_ClarUserId",
                table: "YesNoAnswers",
                column: "ClarUserId");

            migrationBuilder.CreateIndex(
                name: "IX_YesNoAnswers_YesNoQuestionId",
                table: "YesNoAnswers",
                column: "YesNoQuestionId");
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
                name: "ChoiceAnswers");

            migrationBuilder.DropTable(
                name: "ScaleAnswers");

            migrationBuilder.DropTable(
                name: "YesNoAnswers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "ScaleQuestions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "YesNoQuestions");

            migrationBuilder.DropTable(
                name: "MultipleChoiceQuestions");
        }
    }
}
