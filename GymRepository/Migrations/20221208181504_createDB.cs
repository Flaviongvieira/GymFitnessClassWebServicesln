using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymRepository.Migrations
{
    public partial class createDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FitnessInstructor",
                columns: table => new
                {
                    InstrId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstrDoB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessInstructor", x => x.InstrId);
                });

            migrationBuilder.CreateTable(
                name: "FitnessStudio",
                columns: table => new
                {
                    StudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudioName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessStudio", x => x.StudioId);
                });

            migrationBuilder.CreateTable(
                name: "FitnessClassSchedule",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassWeekDay = table.Column<int>(type: "int", nullable: false),
                    ClassStartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassDuration = table.Column<int>(type: "int", nullable: false),
                    ClassStudioId = table.Column<int>(type: "int", nullable: false),
                    ClassInstrId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessClassSchedule", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_FitnessClassSchedule_FitnessInstructor_ClassInstrId",
                        column: x => x.ClassInstrId,
                        principalTable: "FitnessInstructor",
                        principalColumn: "InstrId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FitnessClassSchedule_FitnessStudio_ClassStudioId",
                        column: x => x.ClassStudioId,
                        principalTable: "FitnessStudio",
                        principalColumn: "StudioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FitnessClassSchedule_ClassInstrId",
                table: "FitnessClassSchedule",
                column: "ClassInstrId");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessClassSchedule_ClassStudioId",
                table: "FitnessClassSchedule",
                column: "ClassStudioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FitnessClassSchedule");

            migrationBuilder.DropTable(
                name: "FitnessInstructor");

            migrationBuilder.DropTable(
                name: "FitnessStudio");
        }
    }
}
