using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientConnect.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Specialty = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    PostCode = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneNum = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    DoctorEmail = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    PostCode = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneNum = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Patient_Doctor_DoctorEmail",
                        column: x => x.DoctorEmail,
                        principalTable: "Doctor",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_DoctorEmail",
                table: "Patient",
                column: "DoctorEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Doctor");
        }
    }
}
