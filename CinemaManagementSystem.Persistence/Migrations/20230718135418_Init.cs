using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaManagementSystem.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackDropUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeRequired = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCompanies",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCompanies", x => new { x.MovieId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_MovieCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCompanies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieUsers",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieUsers", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MovieUsers_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rates_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "BirthDate", "CreatedBy", "DateCreated", "Description", "Gender", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("0017645e-ead5-4409-befc-3cbe6c680143"), new DateTime(1959, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(9270), "Ông được cho là diễn viên điện ảnh tâm huyết nhất khi tính tới năm 2023, ông đã thro đuổi đam mê được 38 năm", "Male", "/2ZulC2Ccq1yv3pemusks6Zlfy2s.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(9270), "John Makanno" },
                    { new Guid("8b5de660-3363-4450-8687-c778fd6f4de6"), new DateTime(1990, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(9280), "Chàng diễn viên trẻ tuổi với những thành tựu lớn lao trong sự nghiệp mới chớm nở của anh tại WestKark", "Male", "/fe4mUSp0XotA6Ku4Bs69Q9o2lqU.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(9280), "Alexander Gould" },
                    { new Guid("8eb62e64-9041-42d6-bbde-24574294a553"), new DateTime(1987, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(9290), "Diễn viên không thể thiếu trong các tựa phim hành động, phiêu lưu có tính chất liều lĩnh, ngoan cường", "Male", "/z8IEEid4z63CBlJtxrTKEfsW7NA.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(9290), "Ellen DeGeneres" },
                    { new Guid("a94cbbaf-9ae0-4a1a-af9c-b7e9c4632fdd"), new DateTime(1966, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(9270), "Dave began his writing career in 1993 as one of the original writers on NBC's \"Late Night With Conan O'Brien.\" After more than 400 shows, Dave moved to Los Angeles in 1995 and landed a job at Walt Disney Feature Animation in the movie \"Tarzan.\"", "Male", "/5iKtATPbLpv2lT7q9DPX2v2qPS1.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(9280), "David Reynolds" },
                    { new Guid("ae96d217-2104-45d8-b65d-6bbf71a46699"), new DateTime(1982, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(9250), "Nam diễn viên chuyên nghiệp góp mặt trong nhiều bộ phim đình đám của các hãng phim Châu Âu", "Male", "/mDLDvsx8PaZoEThkBdyaG1JxPdf.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(9250), "Kane Karrtima" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("09919982-d68a-4e27-955f-2f20bcf86f2f"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 588, DateTimeKind.Local).AddTicks(5870), "Founded in 1971, Lucasfilm is one of the world's leading entertainment companies and home to the legendary Star Wars and Indiana Jones franchises.", "/o86DbpburjxrqAzEDhXZcyE8pDb.png", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(5450), "Lucasfilm Ltd.", null },
                    { new Guid("17308103-5051-4df1-b616-a6bb30ab1b77"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(5760), "Columbia Pictures Industries, Inc. (CPII) is an American film production and distribution company. Columbia Pictures now forms part of the Columbia TriStar Motion Picture Group, owned by Sony Pictures Entertainment, a subsidiary of the Japanese conglomerate Sony. It is one of the leading film companies in the world, a member of the so-called Big Six. It was one of the so-called Little Three among the eight major film studios of Hollywood's Golden Age.", "/71BqEFAF4V3qjjMPCpLuyJFB9A.png", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(5770), "Columbia Pictures", null },
                    { new Guid("83615941-d685-45dc-a818-8873dc9822a6"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(5780), "Kiểu như đường kẻ mới =)) Chứ còn gì nữa", "/78ilmDNTpdCfsakrsLqmAUkFTrO.png", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(5780), "New Line Cinema", null },
                    { new Guid("bc527e23-0685-4c87-a229-f4bef010b103"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(5790), "Cái này có phải Disney không nhỉ?", "/wdrCwmRnLFJhEoH8GSfymY85KHT.png", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(5790), "Walt Disney Pictures", null },
                    { new Guid("c98f61ac-d455-4d3e-a27d-179b2005d0f0"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(5770), "Nhắc đến DreamWorks Pictures không thể không nghĩ tới hình ảnh cậu bé ngồi câu sao trên mặt trăng tượng trưng cho không biết, chắc là flex kiểu điện ảnh chuyên nghiệp =))", "/vru2SssLX3FPhnKZGtYw00pVIS9.png", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(5780), "DreamWorks Pictures", null },
                    { new Guid("cd3ea95d-af2f-4e63-b7f8-9fd9a49d1f97"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(5800), "Cái công ty mà có cái đèn nhảy nhảy đè chứ I đúng không =))", "/1TjvGVDMYsj6JBxOAkUHpPEwLf7.png", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(5800), "Pixar", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("0081e4c8-8e4e-4d29-8255-c31e81e8fb94"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8360), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8360), "Phim Hài" },
                    { new Guid("2ccbb760-be2e-4500-82e7-3d5fb5b3dcba"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8480), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8480), "Phim Chiến Tranh" },
                    { new Guid("36e49dce-a76a-4671-8519-36842ec580b9"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8490), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8490), "Phim Miền Tây" },
                    { new Guid("3e45a754-514f-4d18-bb64-820045c42f95"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8350), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8350), "Phim Phiêu Lưu" },
                    { new Guid("63e46c43-0af7-45db-9ffd-247eca989808"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8420), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8420), "Phim Lịch Sử" },
                    { new Guid("66480329-0928-4a53-a2be-06e9f85a75dc"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8400), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8400), "Phim Gia Đình" },
                    { new Guid("8fc2bdcd-4c1b-47d3-89c9-d5e5cb8214b7"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8330), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8330), "Phim Hành Động" },
                    { new Guid("95b12e40-7b7f-418d-8dd2-4572085e3a64"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8430), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8430), "Phim Nhạc" },
                    { new Guid("971187c3-bd45-4a48-b6c1-3d4be9172c24"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8390), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8390), "Phim Chính Kịch" },
                    { new Guid("aabb54c4-4be3-4715-9de4-64fd4201fce5"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8420), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8420), "Phim Kinh Dị" },
                    { new Guid("af3a9fee-a271-45c0-bc8d-b84a313624f7"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8370), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8370), "Phim Hình Sự" },
                    { new Guid("c164eb0c-ae6d-4871-b2bf-6cb5ddf0644a"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8440), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8440), "Phim Bí Ẩn" },
                    { new Guid("d0b0f0ba-4631-426f-b0cd-6440253c8a00"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8460), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8460), "Chương Trình Truyền Hình" },
                    { new Guid("d88648e3-943d-4813-860c-dfabf1dc9448"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8460), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8460), "Phim Khoa Học Viễn Tưởng" },
                    { new Guid("d8e71725-c56f-4942-ae52-2ecdabe88bcf"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8410), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8410), "Phim Giả Tượng" },
                    { new Guid("e1a6a88c-9918-470c-ac4a-045fa17075be"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8360), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8360), "Phim Hoạt Hình" },
                    { new Guid("ed3236c0-c283-480b-b7e1-f5b5b3528feb"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8380), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8380), "Phim Tài Liệu" },
                    { new Guid("f272f81e-62fc-4ec7-97fd-5f4508702336"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8450), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8450), "Phim Lãng Mạn" },
                    { new Guid("fbcb51b9-e5ab-4d36-85b5-ac5bfa91a366"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8470), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8470), "Phim Gây Cấn" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRequired", "BackDropUrl", "CreatedBy", "DateCreated", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "ReleaseDate", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("1d18ba26-6af1-40e6-8375-67885b5ebccc"), 12, "/3LzSMuatf6E6xw6i9F8LnvBZmAy.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7950), "Greg is a police lieutenant; he must collect informations on eco-activists, infiltrating them for months. Myriam, a young free woman, is fighting to save a forest from the building of a dam. They meet and fall in love on the Zone. A beautiful life, a joy that Greg discovers, despite the risks of being unmasked. For each of them, time is short: soon everything will disappear.", "/36wyM5ceCCIpu8lU88mxonYET71.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7950), new DateTime(2022, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "A Place to Fight For" },
                    { new Guid("24ea61fa-7c35-425c-b8e3-432e3df1c985"), 14, "/7I6VUdPj6tQECNHdviJkUHD2u89.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8010), "Sát Thủ John Wick: Chương 4 là câu chuyện của John Wick (Keanu Reeves) đã khám phá ra con đường để đánh bại High Table. Nhưng trước khi có thể kiếm được tự do, Wick phải đối đầu với kẻ thù mới với những liên minh hùng mạnh trên toàn cầu và những lực lượng biến những người bạn cũ thành kẻ thù.", "/ksg3XSEezxpRVEB6BrKxmNOuhft.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8010), new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Sát Thủ John Wick: Phần 4" },
                    { new Guid("421f4e63-fcc8-40d3-a7c5-c43150678896"), 12, "/5YZbUmjbMa3ClvSW1Wj3D6XGolb.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7850), "Cho dù vũ trụ này có bao la đến đâu, các Vệ Binh của chúng ta cũng không thể trốn chạy mãi mãi.", "/Ak5hAxorxMpxKoVw5e3kGfxs7sY.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7850), new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Vệ Binh Dải Ngân Hà 3" },
                    { new Guid("524ac7e6-fe80-44b0-913a-5cf0ba158186"), 14, "/fjWcAbHRxCSR4kLGvsPEhNjR2ts.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7860), "Khi ngân hàng mà Owen quản lý bị cướp chỉ vài ngày trước đám cưới của anh, mọi chứng cứ đều chỉ về một hướng cực kỳ khó xử: bố mẹ vợ tương lai của anh.", "/5dliMQ2ODbGNoq0hlefdnuXQxMw.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7860), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Khi Nhà Vợ Làm Tội Phạm" },
                    { new Guid("551d7d2b-6c00-46b1-a869-6a87666bea80"), 8, "/nHf61UzkfFno5X1ofIhugCPus2R.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7990), "Barbie and Ken are having the time of their lives in the colorful and seemingly perfect world of Barbie Land. However, when they get a chance to go to the real world, they soon discover the joys and perils of living among humans.", "/mqNkQhaXxsH8SLNmJnG5oGz4meR.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7990), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Barbie" },
                    { new Guid("6847ef13-b8d8-4019-9ef0-bccc1099d94d"), 14, "/4QpKxH614YFIsmiIBVUbsnG2H8w.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8000), "Bị đổ oan tội ác bi thảm, hiệp sĩ nọ bắt tay với một thiếu nữ kiên cường, có khả năng thay đổi hình dạng để minh oan. Nhưng sẽ ra sao nếu cô là con quái vật anh thề sẽ tiêu diệt?", "/2NQljeavtfl22207D1kxLpa4LS3.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8000), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Nimona" },
                    { new Guid("6a1f8665-fa64-40ab-aee3-edc6a3cedcc5"), 14, "/8rpDcsfLJypbO6vREc0547VKqEv.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7960), "Câu chuyện của “Avatar: Dòng Chảy Của Nước” lấy bối cảnh 10 năm sau những sự kiện xảy ra ở phần đầu tiên. Phim kể câu chuyện về gia đình mới của Jake Sully (Sam Worthington thủ vai) cùng những rắc rối theo sau và bi kịch họ phải chịu đựng khi phe loài người xâm lược hành tinh Pandora.", "/jGmC7aMqoLU0ALRKHkz3pQVV1pg.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7960), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Avatar:  Dòng Chảy Của Nước" },
                    { new Guid("837ad15e-16fb-4f6b-9a01-e3995d691fe5"), 12, "/oqP1qEZccq5AD9TVTIaO6IGUj7o.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7840), "Khi nữ thần chiến tranh Athena tái sinh trong cơ thể của một cô gái trẻ tên Sienna, chàng trai mồ côi Seiya phát hiện số phận của anh được định sẵn để bảo vệ cô và giải cứu thế giới. Nếu muốn sống sót, Seiya cần phải nắm lấy vận mệnh của mình và hy sinh mọi thứ để có được vị trí xứng đáng trong số các Hiệp sĩ Hoàng đạo.", "/7Hb59xDBe9fUPcR3VYFnLMCioLL.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7840), new DateTime(2023, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Knights of the Zodiac" },
                    { new Guid("85087659-9e67-47b8-b0c2-e26316c1d564"), 16, "/aO6hDsqTIAtQFUBoPWklmPFsSTW.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7880), "To put their demons to rest once and for all, Josh Lambert and a college-aged Dalton Lambert must go deeper into The Further than ever before, facing their family's dark past and a host of new and more horrifying terrors that lurk behind the red door.", "/faafq0NouR3wSemwc77slLEJHId.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7880), new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Quỷ Quyệt: Cửa Đỏ Vô Định" },
                    { new Guid("900bf760-5952-4385-beea-b3e85d1da20a"), 10, "/cSYLX73WskxCgvpN3MtRkYUSj1T.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8010), "Xứ Sở Các Nguyên Tố từ Disney và Pixar lấy bối cảnh tại thành phố các các nguyên tố, nơi lửa, nước, đất và không khí cùng chung sống với nhau. Câu chuyện xoay quanh nhân vật Ember, một cô nàng cá tính, thông minh, mạnh mẽ và đầy sức hút. Tuy nhiên, mối quan hệ của cô với Wade - một anh chàng hài hước, luôn thuận thế đẩy dòng - khiến Ember cảm thấy ngờ vực với thế giới này.", "/7GaeF6xeUbfXFZCtOCWs503CJUl.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8010), new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Xứ Sở Các Nguyên Tố" },
                    { new Guid("a97e1be6-d15e-45ac-a18d-f50f8ae2678a"), 8, "/9n2tJBplPbgR2ca05hS5CKXwP2c.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7890), "The Super Mario Bros. Movie xoay quanh cuộc phiêu lưu ở thế giới Vương quốc Nấm của anh em thợ sửa ống nước Mario và Luigi. Sau khi tình cờ bước tới vùng đất lạ từ một ống nước, Luigi đã bị chia tách với Mario và rơi vào tay quái vật rùa xấu xa Bowser, hắn đang âm mưu độc chiếm thế giới. Trong lúc cố gắng tìm kiếm người anh em của mình, Mario đã chạm mặt anh bạn nấm Toad và công chúa Peach. Từ đây họ sát cánh bên nhau trên hành trình ngăn chặn thế lực hắc ám.", "/gRlfFcpPdjREQ3lgeuAuB10gfbR.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7890), new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Anh Em Super Mario" },
                    { new Guid("abbb5d76-f709-4911-863e-eeda82118978"), 14, "/vblTCXOWUQGSc837vgbhDRi4HSc.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7970), "Quái vật cơ bắp Seok-do (Ma Dong Seok) dẫn đầu đội hình sự truy lùng đường dây buôn chất cấm của thiếu gia Joo Seong Cheol. Cuộc truy đuổi càng thêm gay cấn khi cú đấm công lý \"chú Ma\" chạm trán thanh kiếm lừng lẫy chốn giang hồ Nhật Bản.", "/jeRp9uQSt4IkpGPqR2iWviRUEsE.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7970), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Vây Hãm: Không Lối Thoát" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRequired", "BackDropUrl", "CreatedBy", "DateCreated", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "ReleaseDate", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("b8800b30-7638-4842-bdf2-d0c9b816a6d8"), 12, "/wbNm4ShryprgwY9QIlEZU6JIcr1.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8020), "The story of Tim Ballard, a former US government agent, who quits his job in order to devote his life to rescuing children from global sex traffickers.", "/mx4O9OEvIB265VM3UATLslsSW5t.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8020), new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Sound of Freedom" },
                    { new Guid("bccbbce7-6946-45c8-bf37-5fdfa4ea0bd1"), 14, "/wbNm4ShryprgwY9QIlEZU6JIcr1.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8030), "Based on the novels by Colombian writer Mario Mendoza and on the character of detective Frank Molina, the filming of Los Initiados took place in Bogotá. In the saga of Frank Molina, which uses the books Lady Massacre, La melancolia de los feos, El diario del fin del mundo and Akelarre, the story of an alcoholic private investigator who unmasks sinister plots within the underworld of Bogotá is told.", "/3FzWr7u7uFaLpolFQlUbibFDpQJ.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(8030), new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "The Initiated" },
                    { new Guid("c8937670-1d07-4c2b-8e4b-9e3c417ded7e"), 8, "/4XM8DUTQb3lhLemJC51Jx4a2EuA.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7820), "Dom Toretto và gia đình anh ta là mục tiêu của đứa con trai đầy thù hận của trùm ma túy Hernan Reyes.", "/brZzXXQ8GuzlAdu4TJxjhC8ebBL.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7820), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Fast & Furious X" },
                    { new Guid("ccda1415-3cd7-45c8-b367-ad0762dfd62d"), 14, "/628Dep6AxEtDxjZoGP78TsOxYbK.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7870), "Phần phim thứ 7 của loạt phim Nhiệm Vụ Bất Khả Thi", "/eoLBADTttXo4HJLLUK9amxE4RRM.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7870), new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Nhiệm Vụ: Bất Khả Thi - Nghiệp Báo Phần 1" },
                    { new Guid("cdf2a4b3-b5b5-4a8f-9751-25f0e0b8a120"), 16, "/4tdV5AeojEdbvn6VpeQrbuDlmzs.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7980), "Câu chuyện bắt đầu khi Suzume vô tình gặp chàng trai Souta đến thị trấn nơi cô sinh sống với mục đích tìm kiếm \"một cánh cửa\". Để bảo vệ Nhật Bản khỏi thảm họa, những cánh cửa rải rác khắp nơi phải được đóng lại, và bất ngờ thay Suzume cũng có khả năng đóng cửa đặc biệt này. Từ đó cả hai cùng nhau thực hiện sự mệnh \"khóa chặt cửa\"!", "/70f6AyM2U74up5MaPAZJ7AAnKKL.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7980), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Khóa Chặt Cửa Nào Suzume" },
                    { new Guid("dd70197d-5459-4245-af6a-9a6cca834bfb"), 14, "/wuwMLVIY0Zqfz6uToyDmb7TYRVN.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7930), "A group of Black friends reunite for a Juneteenth weekend getaway only to find themselves trapped in a remote cabin with a twisted killer.", "/n2aS9FE0C3VUHtSb3Ak41aU9K3y.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7930), new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "The Blackening" },
                    { new Guid("e042a4aa-6aed-4dfd-aa0f-8cd056fbdca3"), 14, "/k1gMjXi1vtwTDiGwfBw7L897zs3.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7940), "Quyết tâm tìm kiếm công bằng cũng như lợi nhuận từ công việc bạc bẽo, một công nhân nhà máy âm mưu tuồn nước hoa xa xỉ qua mặt sếp mình.", "/4x9u5HsxeSJu9SW9Pf6fVVDPwxv.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7940), new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Mùi Hương Của Vàng" },
                    { new Guid("f35e1043-0c4d-4856-b8ab-d2e2872859db"), 16, "/35z8hWuzfFUZQaYog8E9LsXW3iI.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7880), "Indiana Jones 5 sẽ pha trộn giữa thực tế, hư cấu khi lấy bối cảnh năm 1969, lần này Indiana Jones sẽ đối mặt với Đức quốc xã trong thời gian diễn ra cuộc chạy đua vào không gian.", "/gTAR51U4eAiCokNqtRy7FsprUar.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7880), new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Indiana Jones và Vòng Quay Định Mệnh" },
                    { new Guid("f5da4be8-89fd-44ea-a024-550b7897945d"), 12, "/4HodYYKEIsGOdinkGi2Ucz6X9i0.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7940), "Miles Morales tái xuất trong phần tiếp theo của bom tấn hoạt hình từng đoạt giải Oscar - Spider-Man: Across the Spider-Verse. Sau khi gặp lại Gwen Stacy, chàng Spider-Man thân thiện đến từ Brooklyn phải du hành qua đa vũ trụ và gặp một nhóm Người Nhện chịu trách nhiệm bảo vệ các thế giới song song. Nhưng khi nhóm siêu anh hùng xung đột về cách xử lý một mối đe dọa mới, Miles buộc phải đọ sức với các Người Nhện khác và phải xác định lại ý nghĩa của việc trở thành một người hùng để có thể cứu những người cậu yêu thương nhất.", "/bX547n5W9ZIKCeAE44Vf2nfw4w.jpg", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(7950), new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Người Nhện: Du Hành Vũ Trụ Nhện" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CompanyId", "CreatedBy", "DateCreated", "Firstname", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Lastname", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("00000001-0001-0001-0101-010101010101"), null, null, "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(6260), "System", null, "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(6270), "Administrator", null },
                    { new Guid("00000003-0003-0003-0303-030303030303"), null, null, "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(6820), "System", null, "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(6820), "User", null }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("0017645e-ead5-4409-befc-3cbe6c680143"), new Guid("421f4e63-fcc8-40d3-a7c5-c43150678896") },
                    { new Guid("8eb62e64-9041-42d6-bbde-24574294a553"), new Guid("421f4e63-fcc8-40d3-a7c5-c43150678896") },
                    { new Guid("ae96d217-2104-45d8-b65d-6bbf71a46699"), new Guid("421f4e63-fcc8-40d3-a7c5-c43150678896") },
                    { new Guid("8eb62e64-9041-42d6-bbde-24574294a553"), new Guid("524ac7e6-fe80-44b0-913a-5cf0ba158186") },
                    { new Guid("ae96d217-2104-45d8-b65d-6bbf71a46699"), new Guid("524ac7e6-fe80-44b0-913a-5cf0ba158186") },
                    { new Guid("ae96d217-2104-45d8-b65d-6bbf71a46699"), new Guid("837ad15e-16fb-4f6b-9a01-e3995d691fe5") },
                    { new Guid("8b5de660-3363-4450-8687-c778fd6f4de6"), new Guid("85087659-9e67-47b8-b0c2-e26316c1d564") },
                    { new Guid("a94cbbaf-9ae0-4a1a-af9c-b7e9c4632fdd"), new Guid("85087659-9e67-47b8-b0c2-e26316c1d564") },
                    { new Guid("a94cbbaf-9ae0-4a1a-af9c-b7e9c4632fdd"), new Guid("900bf760-5952-4385-beea-b3e85d1da20a") },
                    { new Guid("8b5de660-3363-4450-8687-c778fd6f4de6"), new Guid("a97e1be6-d15e-45ac-a18d-f50f8ae2678a") },
                    { new Guid("0017645e-ead5-4409-befc-3cbe6c680143"), new Guid("c8937670-1d07-4c2b-8e4b-9e3c417ded7e") },
                    { new Guid("ae96d217-2104-45d8-b65d-6bbf71a46699"), new Guid("c8937670-1d07-4c2b-8e4b-9e3c417ded7e") },
                    { new Guid("a94cbbaf-9ae0-4a1a-af9c-b7e9c4632fdd"), new Guid("ccda1415-3cd7-45c8-b367-ad0762dfd62d") }
                });

            migrationBuilder.InsertData(
                table: "MovieCompanies",
                columns: new[] { "CompanyId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("cd3ea95d-af2f-4e63-b7f8-9fd9a49d1f97"), new Guid("1d18ba26-6af1-40e6-8375-67885b5ebccc") },
                    { new Guid("09919982-d68a-4e27-955f-2f20bcf86f2f"), new Guid("421f4e63-fcc8-40d3-a7c5-c43150678896") },
                    { new Guid("09919982-d68a-4e27-955f-2f20bcf86f2f"), new Guid("524ac7e6-fe80-44b0-913a-5cf0ba158186") },
                    { new Guid("17308103-5051-4df1-b616-a6bb30ab1b77"), new Guid("85087659-9e67-47b8-b0c2-e26316c1d564") },
                    { new Guid("17308103-5051-4df1-b616-a6bb30ab1b77"), new Guid("a97e1be6-d15e-45ac-a18d-f50f8ae2678a") },
                    { new Guid("bc527e23-0685-4c87-a229-f4bef010b103"), new Guid("b8800b30-7638-4842-bdf2-d0c9b816a6d8") },
                    { new Guid("09919982-d68a-4e27-955f-2f20bcf86f2f"), new Guid("c8937670-1d07-4c2b-8e4b-9e3c417ded7e") },
                    { new Guid("83615941-d685-45dc-a818-8873dc9822a6"), new Guid("cdf2a4b3-b5b5-4a8f-9751-25f0e0b8a120") },
                    { new Guid("c98f61ac-d455-4d3e-a27d-179b2005d0f0"), new Guid("dd70197d-5459-4245-af6a-9a6cca834bfb") },
                    { new Guid("83615941-d685-45dc-a818-8873dc9822a6"), new Guid("e042a4aa-6aed-4dfd-aa0f-8cd056fbdca3") },
                    { new Guid("c98f61ac-d455-4d3e-a27d-179b2005d0f0"), new Guid("f5da4be8-89fd-44ea-a024-550b7897945d") }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("0081e4c8-8e4e-4d29-8255-c31e81e8fb94"), new Guid("1d18ba26-6af1-40e6-8375-67885b5ebccc") },
                    { new Guid("3e45a754-514f-4d18-bb64-820045c42f95"), new Guid("421f4e63-fcc8-40d3-a7c5-c43150678896") },
                    { new Guid("8fc2bdcd-4c1b-47d3-89c9-d5e5cb8214b7"), new Guid("421f4e63-fcc8-40d3-a7c5-c43150678896") },
                    { new Guid("0081e4c8-8e4e-4d29-8255-c31e81e8fb94"), new Guid("524ac7e6-fe80-44b0-913a-5cf0ba158186") },
                    { new Guid("3e45a754-514f-4d18-bb64-820045c42f95"), new Guid("6a1f8665-fa64-40ab-aee3-edc6a3cedcc5") },
                    { new Guid("8fc2bdcd-4c1b-47d3-89c9-d5e5cb8214b7"), new Guid("837ad15e-16fb-4f6b-9a01-e3995d691fe5") },
                    { new Guid("95b12e40-7b7f-418d-8dd2-4572085e3a64"), new Guid("837ad15e-16fb-4f6b-9a01-e3995d691fe5") },
                    { new Guid("95b12e40-7b7f-418d-8dd2-4572085e3a64"), new Guid("85087659-9e67-47b8-b0c2-e26316c1d564") },
                    { new Guid("aabb54c4-4be3-4715-9de4-64fd4201fce5"), new Guid("85087659-9e67-47b8-b0c2-e26316c1d564") },
                    { new Guid("d8e71725-c56f-4942-ae52-2ecdabe88bcf"), new Guid("a97e1be6-d15e-45ac-a18d-f50f8ae2678a") },
                    { new Guid("3e45a754-514f-4d18-bb64-820045c42f95"), new Guid("abbb5d76-f709-4911-863e-eeda82118978") },
                    { new Guid("8fc2bdcd-4c1b-47d3-89c9-d5e5cb8214b7"), new Guid("abbb5d76-f709-4911-863e-eeda82118978") },
                    { new Guid("8fc2bdcd-4c1b-47d3-89c9-d5e5cb8214b7"), new Guid("c8937670-1d07-4c2b-8e4b-9e3c417ded7e") },
                    { new Guid("f272f81e-62fc-4ec7-97fd-5f4508702336"), new Guid("c8937670-1d07-4c2b-8e4b-9e3c417ded7e") },
                    { new Guid("e1a6a88c-9918-470c-ac4a-045fa17075be"), new Guid("ccda1415-3cd7-45c8-b367-ad0762dfd62d") },
                    { new Guid("66480329-0928-4a53-a2be-06e9f85a75dc"), new Guid("dd70197d-5459-4245-af6a-9a6cca834bfb") },
                    { new Guid("e1a6a88c-9918-470c-ac4a-045fa17075be"), new Guid("e042a4aa-6aed-4dfd-aa0f-8cd056fbdca3") },
                    { new Guid("ed3236c0-c283-480b-b7e1-f5b5b3528feb"), new Guid("e042a4aa-6aed-4dfd-aa0f-8cd056fbdca3") }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("d8e71725-c56f-4942-ae52-2ecdabe88bcf"), new Guid("f35e1043-0c4d-4856-b8ab-d2e2872859db") },
                    { new Guid("af3a9fee-a271-45c0-bc8d-b84a313624f7"), new Guid("f5da4be8-89fd-44ea-a024-550b7897945d") }
                });

            migrationBuilder.InsertData(
                table: "Rates",
                columns: new[] { "Id", "Comment", "CreatedBy", "DateCreated", "LastModifiedBy", "LastModifiedDate", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("f32c9b5a-51fe-43a3-b17d-5f5a52531979"), "Web xịn, phim hay, toàn trai xinh gái đẹp, recommend nha mọi ngừi", "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 611, DateTimeKind.Local).AddTicks(190), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 611, DateTimeKind.Local).AddTicks(190), new Guid("c8937670-1d07-4c2b-8e4b-9e3c417ded7e"), 9.5, new Guid("00000001-0001-0001-0101-010101010101") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CompanyId", "CreatedBy", "DateCreated", "Firstname", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Lastname", "MiddleName" },
                values: new object[] { new Guid("00000002-0002-0002-0202-020202020202"), null, new Guid("09919982-d68a-4e27-955f-2f20bcf86f2f"), "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(6810), "System", null, "Administrator", new DateTime(2023, 7, 18, 20, 54, 18, 610, DateTimeKind.Local).AddTicks(6810), "Publisher", null });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorId",
                table: "MovieActors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCompanies_CompanyId",
                table: "MovieCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_GenreId",
                table: "MovieGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieUsers_UserId",
                table: "MovieUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_MovieId",
                table: "Rates",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_UserId",
                table: "Rates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId",
                unique: true,
                filter: "[CompanyId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieCompanies");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "MovieUsers");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
