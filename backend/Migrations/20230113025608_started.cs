using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class started : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    birthDate = table.Column<string>(type: "TEXT", nullable: false),
                    salaryAmount = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    registrationNumber = table.Column<string>(type: "TEXT", nullable: false),
                    birthDate = table.Column<string>(type: "TEXT", nullable: true),
                    courseId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                    table.ForeignKey(
                        name: "FK_students_courses_courseId",
                        column: x => x.courseId,
                        principalTable: "courses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "disciplines",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    teacherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplines", x => x.id);
                    table.ForeignKey(
                        name: "FK_disciplines_teachers_teacherId",
                        column: x => x.teacherId,
                        principalTable: "teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseDiscipline",
                columns: table => new
                {
                    courseId = table.Column<int>(type: "INTEGER", nullable: false),
                    disciplineId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDiscipline", x => new { x.courseId, x.disciplineId });
                    table.ForeignKey(
                        name: "FK_CourseDiscipline_courses_courseId",
                        column: x => x.courseId,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDiscipline_disciplines_disciplineId",
                        column: x => x.disciplineId,
                        principalTable: "disciplines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "grades",
                columns: table => new
                {
                    disciplineId = table.Column<int>(type: "INTEGER", nullable: false),
                    studentId = table.Column<int>(type: "INTEGER", nullable: false),
                    score = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grades", x => new { x.disciplineId, x.studentId });
                    table.ForeignKey(
                        name: "FK_grades_disciplines_disciplineId",
                        column: x => x.disciplineId,
                        principalTable: "disciplines",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grades_students_studentId",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "Ciencia da Computação" });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "name" },
                values: new object[] { 2, "Direito" });

            migrationBuilder.InsertData(
                table: "teachers",
                columns: new[] { "id", "birthDate", "name", "salaryAmount" },
                values: new object[] { 1, "14/12/1982", "Cleison Lima", 7000f });

            migrationBuilder.InsertData(
                table: "teachers",
                columns: new[] { "id", "birthDate", "name", "salaryAmount" },
                values: new object[] { 2, "14/12/1982", "Marcelo Pires", 7200f });

            migrationBuilder.InsertData(
                table: "teachers",
                columns: new[] { "id", "birthDate", "name", "salaryAmount" },
                values: new object[] { 3, "14/12/1982", "Cristiao Ronaldo", 2000f });

            migrationBuilder.InsertData(
                table: "disciplines",
                columns: new[] { "id", "name", "teacherId" },
                values: new object[] { 1, "Logica de Programacao", 1 });

            migrationBuilder.InsertData(
                table: "disciplines",
                columns: new[] { "id", "name", "teacherId" },
                values: new object[] { 2, "Matematica I", 2 });

            migrationBuilder.InsertData(
                table: "disciplines",
                columns: new[] { "id", "name", "teacherId" },
                values: new object[] { 3, "Propabilidade I", 3 });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "birthDate", "courseId", "name", "registrationNumber" },
                values: new object[] { 1, "14/12/1982", 1, "Cleison Estudante", "XAXA1234" });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "id", "birthDate", "courseId", "name", "registrationNumber" },
                values: new object[] { 2, "14/12/1982", 2, "Marcelo Pires", "XAXA2333" });

            migrationBuilder.InsertData(
                table: "CourseDiscipline",
                columns: new[] { "courseId", "disciplineId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "CourseDiscipline",
                columns: new[] { "courseId", "disciplineId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "CourseDiscipline",
                columns: new[] { "courseId", "disciplineId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "CourseDiscipline",
                columns: new[] { "courseId", "disciplineId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "CourseDiscipline",
                columns: new[] { "courseId", "disciplineId" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "grades",
                columns: new[] { "disciplineId", "studentId", "score" },
                values: new object[] { 1, 1, 8f });

            migrationBuilder.InsertData(
                table: "grades",
                columns: new[] { "disciplineId", "studentId", "score" },
                values: new object[] { 2, 1, 5f });

            migrationBuilder.InsertData(
                table: "grades",
                columns: new[] { "disciplineId", "studentId", "score" },
                values: new object[] { 2, 2, 10f });

            migrationBuilder.InsertData(
                table: "grades",
                columns: new[] { "disciplineId", "studentId", "score" },
                values: new object[] { 3, 1, 10f });

            migrationBuilder.InsertData(
                table: "grades",
                columns: new[] { "disciplineId", "studentId", "score" },
                values: new object[] { 3, 2, 10f });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDiscipline_disciplineId",
                table: "CourseDiscipline",
                column: "disciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_disciplines_teacherId",
                table: "disciplines",
                column: "teacherId");

            migrationBuilder.CreateIndex(
                name: "IX_grades_studentId",
                table: "grades",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_students_courseId",
                table: "students",
                column: "courseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDiscipline");

            migrationBuilder.DropTable(
                name: "grades");

            migrationBuilder.DropTable(
                name: "disciplines");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "courses");
        }
    }
}
