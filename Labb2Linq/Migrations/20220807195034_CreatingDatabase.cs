using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2Linq.Migrations
{
    public partial class CreatingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolClasses",
                columns: table => new
                {
                    SchoolClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolClassName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClasses", x => x.SchoolClassId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherFirstName = table.Column<string>(nullable: true),
                    TeacherLastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentFirstName = table.Column<string>(nullable: true),
                    StudentLastName = table.Column<string>(nullable: true),
                    SchoolClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_SchoolClasses_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "SchoolClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolClassCourses",
                columns: table => new
                {
                    SchoolClassCourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolClassId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClassCourses", x => x.SchoolClassCourseId);
                    table.ForeignKey(
                        name: "FK_SchoolClassCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolClassCourses_SchoolClasses_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "SchoolClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SchoolClasses",
                columns: new[] { "SchoolClassId", "SchoolClassName" },
                values: new object[,]
                {
                    { 1, "1a" },
                    { 2, "1b" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "TeacherId", "TeacherFirstName", "TeacherLastName" },
                values: new object[,]
                {
                    { 1, "Maja", "Lundström" },
                    { 2, "Anas", "Qlok" },
                    { 3, "Reidar", "Qlok" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "TeacherId" },
                values: new object[,]
                {
                    { 3, "Engelska", 1 },
                    { 4, "Matematik", 1 },
                    { 2, "Programmering 2", 2 },
                    { 1, "Programmering 1", 3 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "SchoolClassId", "StudentFirstName", "StudentLastName" },
                values: new object[,]
                {
                    { 1, 1, "Anders", "Pettersson" },
                    { 2, 1, "Peter", "Karlsson" },
                    { 3, 1, "Lisa", "Persson" },
                    { 4, 1, "Stina", "Alexandersson" },
                    { 5, 1, "Fredrik", "From" },
                    { 6, 2, "Anna", "Persson" },
                    { 7, 2, "Åke", "Stolt" },
                    { 8, 2, "Vera", "Strömberg" },
                    { 9, 2, "Kim", "Fredlund" },
                    { 10, 2, "Robin", "Andersson" }
                });

            migrationBuilder.InsertData(
                table: "SchoolClassCourses",
                columns: new[] { "SchoolClassCourseId", "CourseId", "SchoolClassId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "SchoolClassCourses",
                columns: new[] { "SchoolClassCourseId", "CourseId", "SchoolClassId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassCourses_CourseId",
                table: "SchoolClassCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClassCourses_SchoolClassId",
                table: "SchoolClassCourses",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolClassId",
                table: "Students",
                column: "SchoolClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolClassCourses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "SchoolClasses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
