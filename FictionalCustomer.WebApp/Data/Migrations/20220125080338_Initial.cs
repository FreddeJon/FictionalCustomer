using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FictionalCustomer.WebApp.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackType = table.Column<int>(type: "int", nullable: false),
                    EmployeeStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDescription = table.Column<string>(type: "ntext", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjectStatus = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    ProjectMembersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.ProjectMembersId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employees_ProjectMembersId",
                        column: x => x.ProjectMembersId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectsId",
                table: "EmployeeProject",
                column: "ProjectsId");



            migrationBuilder.InsertData(
                 table: "Employees",
                 columns: new[] { "Id", "FirstName", "LastName", "Email", "PhoneNumber", "City", "Street", "StackType", "EmployeeStatus" },
                 values: new object[,]
                 {
                    { new Guid("B465E3DB-DDCE-7EBB-A474-451012B1D613"),"Xena","Harris","neque.sed.dictum@protonmail.net","(269) 526-0410","Acapulco","P.O. Box 965, 959 Vehicula Av.",1,1},
                    { new Guid("06F039E3-762D-00B3-24FB-AABC3A5B7815"),"Xandra","Castillo","vel.sapien@outlook.couk","(588) 675-1872","Galway","888 Risus. Street",3,1},
                    { new Guid("7E33E42D-DE9B-7B12-D33D-CCBE1126DA19"),"Upton","Avery","malesuada.vel@yahoo.com","(861) 615-1712","Belfast","Ap #376-1307 Ipsum Rd.",4,0},
                    { new Guid("3E1C6EEC-D79C-D6DA-D601-CE8636820E66"),"Velma","Boyd","duis@google.org","(708) 326-8348","Quesada","Ap #895-7852 Velit Street",0,2},
                    { new Guid("C172D8CF-9836-195D-6972-AA5C59162F1B"),"Melvin","Richardson","ante.iaculis.nec@yahoo.com","(879) 923-4578","Mödling","Ap #271-2820 Tincidunt, St.",1,0},
                    { new Guid("3CFA69AD-282D-50BD-CC67-54AA1D2A88C3"),"Malik","Brock","in.nec@hotmail.org","(652) 838-0467","Feira de Santana","224-9211 Dignissim. Rd.",1,1},
                    { new Guid("8C1A7946-A58D-34A5-4BEE-82336526C144"),"Jana","Decker","donec.tincidunt@icloud.net","1-216-268-8341","Oslo","Ap #339-8379 Curabitur Rd.",0,1},
                    { new Guid("9414D5CD-8256-2C2B-DCBE-DE39C3277CCB"),"Lynn","Marks","malesuada.integer@protonmail.org","1-282-315-1485","Banda Aceh","Ap #234-1211 Magna, St.",0,0},
                    { new Guid("152D9724-3E7B-16D1-D22A-7E59EB544C23"),"Jayme","Horton","non.lacinia@outlook.ca","(283) 338-1423","Townsville","Ap #699-2188 Nullam Rd.",3,1},
                    { new Guid("AEC526A5-8139-4B23-9629-A432C96ACB9B"),"Elton","Walsh","fames.ac@hotmail.ca","1-868-577-3523","Zaragoza","1608 Aliquet. Av.",1,0},
                    { new Guid("7896E807-993B-3C04-6294-8745BCB32A59"),"Ferris","Burch","hendrerit.consectetuer.cursus@yahoo.org","(661) 877-6146","Tokoroa","P.O. Box 617, 5206 Sed, Road",4,2},
                    { new Guid("B240A568-966E-8A68-A1A3-274AEE2FD3F9"),"Hammett","Armstrong","adipiscing.lobortis@aol.org","(211) 873-6880","Bhimber","6700 Et St.",4,1},
                    { new Guid("3A48265D-6CA4-E94D-C78C-42944B9B43A6"),"Jordan","Becker","libero.proin@icloud.org","1-794-273-4672","Tver","570-1042 Sapien St.",1,2},
                    { new Guid("A4536A91-FEDE-625E-B4AB-7855575F8C9E"),"Rajah","Moore","quis.tristique@outlook.ca","(580) 684-9208","Recco","285-6729 Purus Road",2,2},
                    { new Guid("38F42ECC-4465-D8FC-4474-BE7AEDE3CB35"),"Clio","Petersen","vivamus.nibh.dolor@protonmail.com","1-818-808-1956","Bauchi","275-8931 Mattis St.",3,0},
                    { new Guid("D5E0B5DA-48C3-6D48-95A3-B38A39CE8565"),"Ainsley","Mcmillan","in.consectetuer@aol.ca","(410) 318-1622","Puntarenas","Ap #747-7283 Est. Avenue",3,1},
                    { new Guid("9DDB54C9-5CEE-F61A-B110-3FE2A51E476E"),"Hedda","Larson","fermentum.convallis@yahoo.ca","(518) 311-7085","Port Lincoln","491-2577 A Av.",3,1},
                    { new Guid("73CB48D9-9D7E-25A8-1843-7C657BBA5E04"),"Alec","Morse","posuere.at.velit@hotmail.edu","1-875-811-2257","Campbellton","9069 Tortor Ave",1,1},
                    { new Guid("437BCFA5-8B00-ADD7-84B7-47C16D56B57E"),"Micah","Calderon","etiam.gravida@google.com","1-665-507-1172","Mainz","Ap #166-8893 Ac Rd.",0,2},
                    { new Guid("D1E101AE-E404-0AB6-DDA4-DC1BB59D5982"),"Orson","Washington","nascetur.ridiculus@protonmail.edu","(626) 821-1301","Gasteiz","556-5276 Fringilla, Rd.",1,2}
                 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
