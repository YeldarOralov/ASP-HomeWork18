using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HW18.Data.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicanCertificates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PatientId = table.Column<Guid>(nullable: false),
                    PatientId1 = table.Column<string>(nullable: true),
                    DoctorId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DateOfIssue = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicanCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicanCertificates_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicanCertificates_AspNetUsers_PatientId1",
                        column: x => x.PatientId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "FullName" },
                values: new object[] { new Guid("3bc77a25-90d3-45e2-84c6-3c99f2ff3f43"), "Alex M." });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "FullName" },
                values: new object[] { new Guid("07b11ad7-91d2-4793-a581-2d5b607d7c4e"), "Mark A." });

            migrationBuilder.CreateIndex(
                name: "IX_MedicanCertificates_DoctorId",
                table: "MedicanCertificates",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicanCertificates_PatientId1",
                table: "MedicanCertificates",
                column: "PatientId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicanCertificates");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
