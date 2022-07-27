using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AishwaryaProject.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "Age", "FirstName", "Gender", "LastName", "TeamName" },
                values: new object[,]
                {
                    { 1, 21, "Amara", "M", "Sriram", "A" },
                    { 2, 20, "Muskan", "F", "Muskan", "A" },
                    { 3, 21, "Rahul", "M", "Yadav", "A" },
                    { 4, 20, "Shraddha", "F", "Shraddha", "A" },
                    { 5, 20, "Aishwarya", "F", "Verma", "A" },
                    { 6, 20, "Shreya", "F", "", "B" },
                    { 7, 20, "Nandhita", "F", "", "B" },
                    { 8, 20, "Shashwat", "M", "", "B" },
                    { 9, 21, "Siddarth", "M", "", "B" },
                    { 10, 20, "Shriya", "F", "", "B" },
                    { 11, 21, "Sriram", "M", "", "C" },
                    { 12, 20, "Sneha", "F", "Sinha", "C" },
                    { 13, 20, "Simran", "F", "Singh", "C" },
                    { 14, 21, "Subhash", "M", "Gurjar", "C" },
                    { 15, 19, "Umeed", "F", "Chandel", "C" },
                    { 16, 22, "Vaibhav", "M", "Bhatnagar", "D" },
                    { 17, 20, "Pujitha", "F", "Vavilapalli", "D" },
                    { 18, 20, "Palak", "F", "Soni", "D" },
                    { 19, 21, "Saurabh", "M", "Kumar", "D" },
                    { 20, 20, "Tisha", "F", "Varshney", "D" },
                    { 21, 21, "Aman", "M", "Asati", "D" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
