using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Survey.Api.Cloud.Core.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Survey");

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "Survey",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InputType",
                schema: "Survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "Survey",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "Survey",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "varchar(255)", nullable: false),
                    InputTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsMandatory = table.Column<bool>(type: "boolean", nullable: false),
                    Formula = table.Column<string>(type: "varchar(255)", nullable: true),
                    QuestionGroupId = table.Column<long>(type: "bigint", nullable: true),
                    ProjectId = table.Column<long>(type: "bigint", nullable: false),
                    OrderSequence = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "[Fk_Question_InputTypeId]",
                        column: x => x.InputTypeId,
                        principalSchema: "Survey",
                        principalTable: "InputType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "[Fk_Question_ProjectId]",
                        column: x => x.ProjectId,
                        principalSchema: "Survey",
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "[Fk_Question_QuestionGroupId]",
                        column: x => x.QuestionGroupId,
                        principalSchema: "Survey",
                        principalTable: "Group",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Option",
                schema: "Survey",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "varchar(255)", nullable: false),
                    Key = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.Id);
                    table.ForeignKey(
                        name: "[Fk_Option_QuestionId]",
                        column: x => x.QuestionId,
                        principalSchema: "Survey",
                        principalTable: "Question",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "Survey",
                table: "InputType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "TextField" },
                    { 2, "Numeric" },
                    { 3, "Dropdown" },
                    { 4, "Radio" },
                    { 5, "Checkbox" },
                    { 6, "Toggle/Digital" },
                    { 7, "TextArea" },
                    { 8, "Date" },
                    { 9, "Autocomplete" },
                    { 10, "Attachment" },
                    { 11, "MultiSelect Dropdown" },
                    { 12, "MultiSelect Checkbox" },
                    { 13, "Complex" }
                });

            migrationBuilder.InsertData(
                schema: "Survey",
                table: "Project",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Defualt" });

            migrationBuilder.InsertData(
                schema: "Survey",
                table: "Question",
                columns: new[] { "Id", "Formula", "InputTypeId", "IsMandatory", "OrderSequence", "ProjectId", "QuestionGroupId", "Title" },
                values: new object[,]
                {
                    { 1L, null, 5, false, null, 1L, null, "Types of Establishment" },
                    { 2L, null, 5, true, null, 1L, null, "Gender" }
                });

            migrationBuilder.InsertData(
                schema: "Survey",
                table: "Option",
                columns: new[] { "Id", "Key", "QuestionId", "Value" },
                values: new object[,]
                {
                    { 1L, 0, 1L, "Residential" },
                    { 2L, 1, 1L, "Commercial" },
                    { 3L, 0, 2L, "Male" },
                    { 4L, 1, 2L, "Female" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Option_QuestionId",
                schema: "Survey",
                table: "Option",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_InputTypeId",
                schema: "Survey",
                table: "Question",
                column: "InputTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ProjectId",
                schema: "Survey",
                table: "Question",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionGroupId",
                schema: "Survey",
                table: "Question",
                column: "QuestionGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Option",
                schema: "Survey");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "Survey");

            migrationBuilder.DropTable(
                name: "InputType",
                schema: "Survey");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "Survey");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "Survey");
        }
    }
}
