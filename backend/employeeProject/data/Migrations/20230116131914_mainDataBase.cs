using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace employeeProject.data.Migrations
{
    /// <inheritdoc />
    public partial class mainDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(name: "File_Name", type: "nvarchar(max)", nullable: false),
                    UploadedByid = table.Column<int>(name: "Uploaded_By_id", type: "int", nullable: false),
                    UploadedToFolder = table.Column<string>(name: "Uploaded_To_Folder", type: "nvarchar(max)", nullable: false),
                    UploadedPath = table.Column<string>(name: "Uploaded_Path", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForgotPassword = table.Column<string>(name: "Forgot_Password", type: "nvarchar(max)", nullable: false),
                    Role = table.Column<bool>(type: "bit", nullable: false),
                    Doj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastActive = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestName = table.Column<string>(name: "Request_Name", type: "nvarchar(max)", nullable: false),
                    RaisedBy = table.Column<int>(name: "Raised_By", type: "int", nullable: false),
                    RaisedByName = table.Column<string>(name: "Raised_By_Name", type: "nvarchar(max)", nullable: false),
                    RequestDateTime = table.Column<DateTime>(name: "Request_Date_Time", type: "datetime2", nullable: false),
                    RequestStatus = table.Column<bool>(name: "Request_Status", type: "bit", nullable: false),
                    RequestMessage = table.Column<string>(name: "Request_Message", type: "nvarchar(max)", nullable: true),
                    RequestComment = table.Column<string>(name: "Request_Comment", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
