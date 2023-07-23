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
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { new Guid("0ebcaf0a-db4c-4676-ae06-911073d8f16b"), new DateTime(1987, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9960), "Diễn viên không thể thiếu trong các tựa phim hành động, phiêu lưu có tính chất liều lĩnh, ngoan cường", "Male", "/z8IEEid4z63CBlJtxrTKEfsW7NA.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9960), "Ellen DeGeneres" },
                    { new Guid("1c80a4c5-a23f-40f4-8467-7529816914af"), new DateTime(1966, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9940), "Dave began his writing career in 1993 as one of the original writers on NBC's \"Late Night With Conan O'Brien.\" After more than 400 shows, Dave moved to Los Angeles in 1995 and landed a job at Walt Disney Feature Animation in the movie \"Tarzan.\"", "Male", "/5iKtATPbLpv2lT7q9DPX2v2qPS1.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9950), "David Reynolds" },
                    { new Guid("5b7e5eb5-77fb-4e5a-b964-ee8ae6ebabe9"), new DateTime(1982, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9920), "Nam diễn viên chuyên nghiệp góp mặt trong nhiều bộ phim đình đám của các hãng phim Châu Âu", "Male", "/mDLDvsx8PaZoEThkBdyaG1JxPdf.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9920), "Kane Karrtima" },
                    { new Guid("8275f9c0-7db0-404c-b415-0732cf157980"), new DateTime(1990, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9950), "Chàng diễn viên trẻ tuổi với những thành tựu lớn lao trong sự nghiệp mới chớm nở của anh tại WestKark", "Male", "/fe4mUSp0XotA6Ku4Bs69Q9o2lqU.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9950), "Alexander Gould" },
                    { new Guid("fea65258-7f2c-4b34-b883-901fdd639792"), new DateTime(1959, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9940), "Ông được cho là diễn viên điện ảnh tâm huyết nhất khi tính tới năm 2023, ông đã thro đuổi đam mê được 38 năm", "Male", "/2ZulC2Ccq1yv3pemusks6Zlfy2s.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9940), "John Makanno" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("b3c42f3f-01d7-4f1b-a240-2b9417281567"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(6210), "Cái công ty mà có cái đèn nhảy nhảy đè chứ I đúng không =))", "/1TjvGVDMYsj6JBxOAkUHpPEwLf7.png", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(6210), "Pixar", null },
                    { new Guid("bf653e49-0d80-4bdf-be0c-a91fa64af185"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(6190), "Kiểu như đường kẻ mới =)) Chứ còn gì nữa", "/78ilmDNTpdCfsakrsLqmAUkFTrO.png", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(6200), "New Line Cinema", null },
                    { new Guid("c42ae54b-6538-4c3c-a03d-86c33bf55253"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(6190), "Nhắc đến DreamWorks Pictures không thể không nghĩ tới hình ảnh cậu bé ngồi câu sao trên mặt trăng tượng trưng cho không biết, chắc là flex kiểu điện ảnh chuyên nghiệp =))", "/vru2SssLX3FPhnKZGtYw00pVIS9.png", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(6190), "DreamWorks Pictures", null },
                    { new Guid("e37843d8-b6e9-4d43-a80a-09369c215775"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(6200), "Cái này có phải Disney không nhỉ?", "/wdrCwmRnLFJhEoH8GSfymY85KHT.png", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(6200), "Walt Disney Pictures", null },
                    { new Guid("f31cf345-9bff-475c-9fba-02d9d8e6a7df"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 117, DateTimeKind.Local).AddTicks(290), "Founded in 1971, Lucasfilm is one of the world's leading entertainment companies and home to the legendary Star Wars and Indiana Jones franchises.", "/o86DbpburjxrqAzEDhXZcyE8pDb.png", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(5860), "Lucasfilm Ltd.", null },
                    { new Guid("f48e80d8-21e9-40f7-b9bb-6e66f0503503"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(6170), "Columbia Pictures Industries, Inc. (CPII) is an American film production and distribution company. Columbia Pictures now forms part of the Columbia TriStar Motion Picture Group, owned by Sony Pictures Entertainment, a subsidiary of the Japanese conglomerate Sony. It is one of the leading film companies in the world, a member of the so-called Big Six. It was one of the so-called Little Three among the eight major film studios of Hollywood's Golden Age.", "/71BqEFAF4V3qjjMPCpLuyJFB9A.png", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(6180), "Columbia Pictures", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("18b1f0d6-d08c-42b3-9924-1804da85f31f"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9020), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9030), "Phim Tài Liệu" },
                    { new Guid("23c66294-e39f-467b-8185-baf497ca6071"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9130), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9130), "Phim Miền Tây" },
                    { new Guid("2f2f4864-8d39-4d25-9a1a-73d5ba8cae93"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9100), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9100), "Phim Khoa Học Viễn Tưởng" },
                    { new Guid("308c20ec-54d2-4fb3-b248-284ba8af7de7"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9010), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9010), "Phim Hài" },
                    { new Guid("34a926c8-e2ba-4e64-99b5-5a9057aed2dc"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8990), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8990), "Phim Phiêu Lưu" },
                    { new Guid("390d8575-2988-4c59-bf0c-977d1270b532"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9030), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9030), "Phim Chính Kịch" },
                    { new Guid("44eab9b3-b90a-440b-b4e1-8520b0075f4e"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9020), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9020), "Phim Hình Sự" },
                    { new Guid("6362769f-640e-4368-a024-7b83dbb004f2"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9040), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9040), "Phim Gia Đình" },
                    { new Guid("64a8688a-297b-47d5-a1e2-ecdcd4afeb34"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9080), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9080), "Phim Bí Ẩn" },
                    { new Guid("7061aed7-be45-40ea-be63-6e5e460e5f0d"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9050), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9050), "Phim Giả Tượng" },
                    { new Guid("72f52a71-c10b-46b4-96a1-b9a49196dae3"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9060), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9070), "Phim Kinh Dị" },
                    { new Guid("8014baec-ea93-4e1d-b5b8-3b60cfd6ac2f"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8970), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8980), "Phim Hành Động" },
                    { new Guid("8474e072-713f-4e6c-b057-b23b813c5ded"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9070), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9070), "Phim Nhạc" },
                    { new Guid("ad42315e-e5bf-4b3f-9068-125c60caaeb1"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9060), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9060), "Phim Lịch Sử" },
                    { new Guid("b2a28cc2-c7e3-492d-801e-e1876a45b222"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9120), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9120), "Phim Chiến Tranh" },
                    { new Guid("b2eeea91-37e6-4675-84e9-d5e4456b3437"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9110), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9110), "Chương Trình Truyền Hình" },
                    { new Guid("cbca74a2-3528-497f-8c82-a673a9de6848"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9090), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9090), "Phim Lãng Mạn" },
                    { new Guid("e928e3fb-d6c9-4f2c-8ec3-dd1d3144f956"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9000), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9000), "Phim Hoạt Hình" },
                    { new Guid("f9f0c3e2-eea0-4f78-96a0-875922fc9ab0"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9110), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(9120), "Phim Gây Cấn" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRequired", "BackDropUrl", "CreatedBy", "DateCreated", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "ReleaseDate", "Status", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { new Guid("01c53c48-fde4-4099-9c4d-c2b632203428"), 14, "/wbNm4ShryprgwY9QIlEZU6JIcr1.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8680), "Based on the novels by Colombian writer Mario Mendoza and on the character of detective Frank Molina, the filming of Los Initiados took place in Bogotá. In the saga of Frank Molina, which uses the books Lady Massacre, La melancolia de los feos, El diario del fin del mundo and Akelarre, the story of an alcoholic private investigator who unmasks sinister plots within the underworld of Bogotá is told.", "/3FzWr7u7uFaLpolFQlUbibFDpQJ.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8680), new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "The Initiated", "/mJ8DsRHZRH8" },
                    { new Guid("06287564-c216-4bfb-b797-98a355342645"), 10, "/cSYLX73WskxCgvpN3MtRkYUSj1T.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8660), "Xứ Sở Các Nguyên Tố từ Disney và Pixar lấy bối cảnh tại thành phố các các nguyên tố, nơi lửa, nước, đất và không khí cùng chung sống với nhau. Câu chuyện xoay quanh nhân vật Ember, một cô nàng cá tính, thông minh, mạnh mẽ và đầy sức hút. Tuy nhiên, mối quan hệ của cô với Wade - một anh chàng hài hước, luôn thuận thế đẩy dòng - khiến Ember cảm thấy ngờ vực với thế giới này.", "/7GaeF6xeUbfXFZCtOCWs503CJUl.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8660), new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Xứ Sở Các Nguyên Tố", "/maq_YK88Xnw" },
                    { new Guid("067e170b-00ff-4066-8af9-f5f0c6f04166"), 12, "/3LzSMuatf6E6xw6i9F8LnvBZmAy.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8590), "Greg is a police lieutenant; he must collect informations on eco-activists, infiltrating them for months. Myriam, a young free woman, is fighting to save a forest from the building of a dam. They meet and fall in love on the Zone. A beautiful life, a joy that Greg discovers, despite the risks of being unmasked. For each of them, time is short: soon everything will disappear.", "/36wyM5ceCCIpu8lU88mxonYET71.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8590), new DateTime(2022, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "A Place to Fight For", "/g1mHBd5dM6Y" },
                    { new Guid("25a1d99a-c50b-4fcc-a0f8-d1642ee7ae82"), 14, "/628Dep6AxEtDxjZoGP78TsOxYbK.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8530), "Phần phim thứ 7 của loạt phim Nhiệm Vụ Bất Khả Thi", "/eoLBADTttXo4HJLLUK9amxE4RRM.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8530), new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Nhiệm Vụ: Bất Khả Thi - Nghiệp Báo Phần 1", "/o0We5hcYM7o" },
                    { new Guid("40dec6dd-977c-47a1-9553-564f8682c5ec"), 12, "/4HodYYKEIsGOdinkGi2Ucz6X9i0.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8580), "Miles Morales tái xuất trong phần tiếp theo của bom tấn hoạt hình từng đoạt giải Oscar - Spider-Man: Across the Spider-Verse. Sau khi gặp lại Gwen Stacy, chàng Spider-Man thân thiện đến từ Brooklyn phải du hành qua đa vũ trụ và gặp một nhóm Người Nhện chịu trách nhiệm bảo vệ các thế giới song song. Nhưng khi nhóm siêu anh hùng xung đột về cách xử lý một mối đe dọa mới, Miles buộc phải đọ sức với các Người Nhện khác và phải xác định lại ý nghĩa của việc trở thành một người hùng để có thể cứu những người cậu yêu thương nhất.", "/bX547n5W9ZIKCeAE44Vf2nfw4w.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8590), new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Người Nhện: Du Hành Vũ Trụ Nhện", "/sKYjLmtWbug" },
                    { new Guid("43fff982-fd01-48fa-80cf-0ca833974dcb"), 8, "/nHf61UzkfFno5X1ofIhugCPus2R.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8630), "Barbie and Ken are having the time of their lives in the colorful and seemingly perfect world of Barbie Land. However, when they get a chance to go to the real world, they soon discover the joys and perils of living among humans.", "/mqNkQhaXxsH8SLNmJnG5oGz4meR.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8630), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Barbie", "/pBk4NYhWNMM" },
                    { new Guid("555c5e31-7a5f-433b-a182-cd74437c13a5"), 16, "/4tdV5AeojEdbvn6VpeQrbuDlmzs.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8620), "Câu chuyện bắt đầu khi Suzume vô tình gặp chàng trai Souta đến thị trấn nơi cô sinh sống với mục đích tìm kiếm \"một cánh cửa\". Để bảo vệ Nhật Bản khỏi thảm họa, những cánh cửa rải rác khắp nơi phải được đóng lại, và bất ngờ thay Suzume cũng có khả năng đóng cửa đặc biệt này. Từ đó cả hai cùng nhau thực hiện sự mệnh \"khóa chặt cửa\"!", "/70f6AyM2U74up5MaPAZJ7AAnKKL.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8620), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Khóa Chặt Cửa Nào Suzume", "/xQ4_c8JfuzI" },
                    { new Guid("7047ea38-152a-43df-87a2-29d6fc455351"), 16, "/aO6hDsqTIAtQFUBoPWklmPFsSTW.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8540), "To put their demons to rest once and for all, Josh Lambert and a college-aged Dalton Lambert must go deeper into The Further than ever before, facing their family's dark past and a host of new and more horrifying terrors that lurk behind the red door.", "/faafq0NouR3wSemwc77slLEJHId.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8540), new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Quỷ Quyệt: Cửa Đỏ Vô Định", "/aGBOK2cnHSE" },
                    { new Guid("95caaff4-95a5-4c56-8e51-4e5468f1db7c"), 16, "/35z8hWuzfFUZQaYog8E9LsXW3iI.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8550), "Indiana Jones 5 sẽ pha trộn giữa thực tế, hư cấu khi lấy bối cảnh năm 1969, lần này Indiana Jones sẽ đối mặt với Đức quốc xã trong thời gian diễn ra cuộc chạy đua vào không gian.", "/gTAR51U4eAiCokNqtRy7FsprUar.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8550), new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Indiana Jones và Vòng Quay Định Mệnh", "/6u93f9fQ8yY" },
                    { new Guid("960cc025-cfe4-42ad-bf98-0a366c255725"), 8, "/4XM8DUTQb3lhLemJC51Jx4a2EuA.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8480), "Dom Toretto và gia đình anh ta là mục tiêu của đứa con trai đầy thù hận của trùm ma túy Hernan Reyes.", "/brZzXXQ8GuzlAdu4TJxjhC8ebBL.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8480), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Fast & Furious X", "/eoOaKN4qCKw" },
                    { new Guid("a526843e-5653-4c3f-a673-e4ea4ecfe340"), 12, "/wbNm4ShryprgwY9QIlEZU6JIcr1.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8670), "The story of Tim Ballard, a former US government agent, who quits his job in order to devote his life to rescuing children from global sex traffickers.", "/mx4O9OEvIB265VM3UATLslsSW5t.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8670), new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Sound of Freedom", "/Rt0kp4VW1cI" },
                    { new Guid("a745d153-7818-40b2-b383-c9c49d1d771a"), 14, "/fjWcAbHRxCSR4kLGvsPEhNjR2ts.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8520), "Khi ngân hàng mà Owen quản lý bị cướp chỉ vài ngày trước đám cưới của anh, mọi chứng cứ đều chỉ về một hướng cực kỳ khó xử: bố mẹ vợ tương lai của anh.", "/5dliMQ2ODbGNoq0hlefdnuXQxMw.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8520), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Khi Nhà Vợ Làm Tội Phạm", "/MvPaDziB-ac" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRequired", "BackDropUrl", "CreatedBy", "DateCreated", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "ReleaseDate", "Status", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { new Guid("b179d435-d056-4169-8b83-2fa9fc47f985"), 14, "/8rpDcsfLJypbO6vREc0547VKqEv.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8600), "Câu chuyện của “Avatar: Dòng Chảy Của Nước” lấy bối cảnh 10 năm sau những sự kiện xảy ra ở phần đầu tiên. Phim kể câu chuyện về gia đình mới của Jake Sully (Sam Worthington thủ vai) cùng những rắc rối theo sau và bi kịch họ phải chịu đựng khi phe loài người xâm lược hành tinh Pandora.", "/jGmC7aMqoLU0ALRKHkz3pQVV1pg.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8600), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Avatar:  Dòng Chảy Của Nước", "/gq2xKJXYZ80" },
                    { new Guid("b650d182-aa13-411f-aed2-c156da952014"), 14, "/7I6VUdPj6tQECNHdviJkUHD2u89.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8650), "Sát Thủ John Wick: Chương 4 là câu chuyện của John Wick (Keanu Reeves) đã khám phá ra con đường để đánh bại High Table. Nhưng trước khi có thể kiếm được tự do, Wick phải đối đầu với kẻ thù mới với những liên minh hùng mạnh trên toàn cầu và những lực lượng biến những người bạn cũ thành kẻ thù.", "/ksg3XSEezxpRVEB6BrKxmNOuhft.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8650), new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Sát Thủ John Wick: Phần 4", "/qEVUtrk8_B4" },
                    { new Guid("c6aa0bfd-9fb5-4d46-b301-fe36a8e67f89"), 12, "/oqP1qEZccq5AD9TVTIaO6IGUj7o.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8500), "Khi nữ thần chiến tranh Athena tái sinh trong cơ thể của một cô gái trẻ tên Sienna, chàng trai mồ côi Seiya phát hiện số phận của anh được định sẵn để bảo vệ cô và giải cứu thế giới. Nếu muốn sống sót, Seiya cần phải nắm lấy vận mệnh của mình và hy sinh mọi thứ để có được vị trí xứng đáng trong số các Hiệp sĩ Hoàng đạo.", "/7Hb59xDBe9fUPcR3VYFnLMCioLL.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8500), new DateTime(2023, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Knights of the Zodiac", "/Sko0o_KoBHY" },
                    { new Guid("d1318eda-0e22-49c5-a1cf-6fc16bd4f14b"), 14, "/vblTCXOWUQGSc837vgbhDRi4HSc.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8610), "Quái vật cơ bắp Seok-do (Ma Dong Seok) dẫn đầu đội hình sự truy lùng đường dây buôn chất cấm của thiếu gia Joo Seong Cheol. Cuộc truy đuổi càng thêm gay cấn khi cú đấm công lý \"chú Ma\" chạm trán thanh kiếm lừng lẫy chốn giang hồ Nhật Bản.", "/jeRp9uQSt4IkpGPqR2iWviRUEsE.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8610), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Vây Hãm: Không Lối Thoát", "/Efe7oVx27E4" },
                    { new Guid("ddc6b5e1-d9a2-4ec4-a0d5-d1df0ff879f1"), 12, "/5YZbUmjbMa3ClvSW1Wj3D6XGolb.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8510), "Cho dù vũ trụ này có bao la đến đâu, các Vệ Binh của chúng ta cũng không thể trốn chạy mãi mãi.", "/Ak5hAxorxMpxKoVw5e3kGfxs7sY.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8510), new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Vệ Binh Dải Ngân Hà 3", "/JqcncLPi9zw" },
                    { new Guid("edf6f009-4e1c-4aa0-b15d-e9a42680e181"), 14, "/wuwMLVIY0Zqfz6uToyDmb7TYRVN.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8570), "A group of Black friends reunite for a Juneteenth weekend getaway only to find themselves trapped in a remote cabin with a twisted killer.", "/n2aS9FE0C3VUHtSb3Ak41aU9K3y.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8570), new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "The Blackening", "/moiRCJR4ToY" },
                    { new Guid("f19ccbdb-6862-41fd-933c-9c4df0b984eb"), 8, "/9n2tJBplPbgR2ca05hS5CKXwP2c.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8560), "The Super Mario Bros. Movie xoay quanh cuộc phiêu lưu ở thế giới Vương quốc Nấm của anh em thợ sửa ống nước Mario và Luigi. Sau khi tình cờ bước tới vùng đất lạ từ một ống nước, Luigi đã bị chia tách với Mario và rơi vào tay quái vật rùa xấu xa Bowser, hắn đang âm mưu độc chiếm thế giới. Trong lúc cố gắng tìm kiếm người anh em của mình, Mario đã chạm mặt anh bạn nấm Toad và công chúa Peach. Từ đây họ sát cánh bên nhau trên hành trình ngăn chặn thế lực hắc ám.", "/gRlfFcpPdjREQ3lgeuAuB10gfbR.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8560), new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Anh Em Super Mario", "/QcinmCfoh8E" },
                    { new Guid("fad5c047-c827-4622-9ed5-760196264635"), 14, "/4QpKxH614YFIsmiIBVUbsnG2H8w.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8640), "Bị đổ oan tội ác bi thảm, hiệp sĩ nọ bắt tay với một thiếu nữ kiên cường, có khả năng thay đổi hình dạng để minh oan. Nhưng sẽ ra sao nếu cô là con quái vật anh thề sẽ tiêu diệt?", "/2NQljeavtfl22207D1kxLpa4LS3.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8640), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Nimona", "/f_fuHRyQbOc" },
                    { new Guid("fcd84d09-ccc8-401f-9ef1-c720e6af7aa5"), 14, "/k1gMjXi1vtwTDiGwfBw7L897zs3.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8580), "Quyết tâm tìm kiếm công bằng cũng như lợi nhuận từ công việc bạc bẽo, một công nhân nhà máy âm mưu tuồn nước hoa xa xỉ qua mặt sếp mình.", "/4x9u5HsxeSJu9SW9Pf6fVVDPwxv.jpg", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(8580), new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Mùi Hương Của Vàng", "/2lwzVZkuGKE" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CompanyId", "CreatedBy", "DateCreated", "Firstname", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Lastname", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("00000001-0001-0001-0101-010101010101"), null, null, "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(6690), "System", null, "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(6700), "Administrator", null },
                    { new Guid("00000003-0003-0003-0303-030303030303"), null, null, "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(7330), "System", null, "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(7330), "User", null }
                });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("1c80a4c5-a23f-40f4-8467-7529816914af"), new Guid("06287564-c216-4bfb-b797-98a355342645") },
                    { new Guid("1c80a4c5-a23f-40f4-8467-7529816914af"), new Guid("25a1d99a-c50b-4fcc-a0f8-d1642ee7ae82") },
                    { new Guid("1c80a4c5-a23f-40f4-8467-7529816914af"), new Guid("7047ea38-152a-43df-87a2-29d6fc455351") },
                    { new Guid("8275f9c0-7db0-404c-b415-0732cf157980"), new Guid("7047ea38-152a-43df-87a2-29d6fc455351") },
                    { new Guid("5b7e5eb5-77fb-4e5a-b964-ee8ae6ebabe9"), new Guid("960cc025-cfe4-42ad-bf98-0a366c255725") },
                    { new Guid("fea65258-7f2c-4b34-b883-901fdd639792"), new Guid("960cc025-cfe4-42ad-bf98-0a366c255725") },
                    { new Guid("0ebcaf0a-db4c-4676-ae06-911073d8f16b"), new Guid("a745d153-7818-40b2-b383-c9c49d1d771a") },
                    { new Guid("5b7e5eb5-77fb-4e5a-b964-ee8ae6ebabe9"), new Guid("a745d153-7818-40b2-b383-c9c49d1d771a") },
                    { new Guid("5b7e5eb5-77fb-4e5a-b964-ee8ae6ebabe9"), new Guid("c6aa0bfd-9fb5-4d46-b301-fe36a8e67f89") },
                    { new Guid("0ebcaf0a-db4c-4676-ae06-911073d8f16b"), new Guid("ddc6b5e1-d9a2-4ec4-a0d5-d1df0ff879f1") },
                    { new Guid("5b7e5eb5-77fb-4e5a-b964-ee8ae6ebabe9"), new Guid("ddc6b5e1-d9a2-4ec4-a0d5-d1df0ff879f1") },
                    { new Guid("fea65258-7f2c-4b34-b883-901fdd639792"), new Guid("ddc6b5e1-d9a2-4ec4-a0d5-d1df0ff879f1") },
                    { new Guid("8275f9c0-7db0-404c-b415-0732cf157980"), new Guid("f19ccbdb-6862-41fd-933c-9c4df0b984eb") }
                });

            migrationBuilder.InsertData(
                table: "MovieCompanies",
                columns: new[] { "CompanyId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("b3c42f3f-01d7-4f1b-a240-2b9417281567"), new Guid("067e170b-00ff-4066-8af9-f5f0c6f04166") },
                    { new Guid("c42ae54b-6538-4c3c-a03d-86c33bf55253"), new Guid("40dec6dd-977c-47a1-9553-564f8682c5ec") },
                    { new Guid("bf653e49-0d80-4bdf-be0c-a91fa64af185"), new Guid("555c5e31-7a5f-433b-a182-cd74437c13a5") },
                    { new Guid("f48e80d8-21e9-40f7-b9bb-6e66f0503503"), new Guid("7047ea38-152a-43df-87a2-29d6fc455351") },
                    { new Guid("f31cf345-9bff-475c-9fba-02d9d8e6a7df"), new Guid("960cc025-cfe4-42ad-bf98-0a366c255725") },
                    { new Guid("e37843d8-b6e9-4d43-a80a-09369c215775"), new Guid("a526843e-5653-4c3f-a673-e4ea4ecfe340") },
                    { new Guid("f31cf345-9bff-475c-9fba-02d9d8e6a7df"), new Guid("a745d153-7818-40b2-b383-c9c49d1d771a") },
                    { new Guid("f31cf345-9bff-475c-9fba-02d9d8e6a7df"), new Guid("ddc6b5e1-d9a2-4ec4-a0d5-d1df0ff879f1") },
                    { new Guid("c42ae54b-6538-4c3c-a03d-86c33bf55253"), new Guid("edf6f009-4e1c-4aa0-b15d-e9a42680e181") },
                    { new Guid("f48e80d8-21e9-40f7-b9bb-6e66f0503503"), new Guid("f19ccbdb-6862-41fd-933c-9c4df0b984eb") },
                    { new Guid("bf653e49-0d80-4bdf-be0c-a91fa64af185"), new Guid("fcd84d09-ccc8-401f-9ef1-c720e6af7aa5") }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("308c20ec-54d2-4fb3-b248-284ba8af7de7"), new Guid("067e170b-00ff-4066-8af9-f5f0c6f04166") },
                    { new Guid("e928e3fb-d6c9-4f2c-8ec3-dd1d3144f956"), new Guid("25a1d99a-c50b-4fcc-a0f8-d1642ee7ae82") },
                    { new Guid("44eab9b3-b90a-440b-b4e1-8520b0075f4e"), new Guid("40dec6dd-977c-47a1-9553-564f8682c5ec") },
                    { new Guid("72f52a71-c10b-46b4-96a1-b9a49196dae3"), new Guid("7047ea38-152a-43df-87a2-29d6fc455351") },
                    { new Guid("8474e072-713f-4e6c-b057-b23b813c5ded"), new Guid("7047ea38-152a-43df-87a2-29d6fc455351") },
                    { new Guid("7061aed7-be45-40ea-be63-6e5e460e5f0d"), new Guid("95caaff4-95a5-4c56-8e51-4e5468f1db7c") },
                    { new Guid("8014baec-ea93-4e1d-b5b8-3b60cfd6ac2f"), new Guid("960cc025-cfe4-42ad-bf98-0a366c255725") },
                    { new Guid("cbca74a2-3528-497f-8c82-a673a9de6848"), new Guid("960cc025-cfe4-42ad-bf98-0a366c255725") },
                    { new Guid("308c20ec-54d2-4fb3-b248-284ba8af7de7"), new Guid("a745d153-7818-40b2-b383-c9c49d1d771a") },
                    { new Guid("34a926c8-e2ba-4e64-99b5-5a9057aed2dc"), new Guid("b179d435-d056-4169-8b83-2fa9fc47f985") },
                    { new Guid("8014baec-ea93-4e1d-b5b8-3b60cfd6ac2f"), new Guid("c6aa0bfd-9fb5-4d46-b301-fe36a8e67f89") },
                    { new Guid("8474e072-713f-4e6c-b057-b23b813c5ded"), new Guid("c6aa0bfd-9fb5-4d46-b301-fe36a8e67f89") },
                    { new Guid("34a926c8-e2ba-4e64-99b5-5a9057aed2dc"), new Guid("d1318eda-0e22-49c5-a1cf-6fc16bd4f14b") },
                    { new Guid("8014baec-ea93-4e1d-b5b8-3b60cfd6ac2f"), new Guid("d1318eda-0e22-49c5-a1cf-6fc16bd4f14b") },
                    { new Guid("34a926c8-e2ba-4e64-99b5-5a9057aed2dc"), new Guid("ddc6b5e1-d9a2-4ec4-a0d5-d1df0ff879f1") },
                    { new Guid("8014baec-ea93-4e1d-b5b8-3b60cfd6ac2f"), new Guid("ddc6b5e1-d9a2-4ec4-a0d5-d1df0ff879f1") },
                    { new Guid("6362769f-640e-4368-a024-7b83dbb004f2"), new Guid("edf6f009-4e1c-4aa0-b15d-e9a42680e181") },
                    { new Guid("7061aed7-be45-40ea-be63-6e5e460e5f0d"), new Guid("f19ccbdb-6862-41fd-933c-9c4df0b984eb") }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("18b1f0d6-d08c-42b3-9924-1804da85f31f"), new Guid("fcd84d09-ccc8-401f-9ef1-c720e6af7aa5") },
                    { new Guid("e928e3fb-d6c9-4f2c-8ec3-dd1d3144f956"), new Guid("fcd84d09-ccc8-401f-9ef1-c720e6af7aa5") }
                });

            migrationBuilder.InsertData(
                table: "Rates",
                columns: new[] { "Id", "Comment", "CreatedBy", "DateCreated", "LastModifiedBy", "LastModifiedDate", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("2efc9938-25b5-4044-a420-8760c3e5d8fc"), "Web xịn, phim hay, toàn trai xinh gái đẹp, recommend nha mọi ngừi", "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 126, DateTimeKind.Local).AddTicks(940), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 126, DateTimeKind.Local).AddTicks(950), new Guid("960cc025-cfe4-42ad-bf98-0a366c255725"), 9.5, new Guid("00000001-0001-0001-0101-010101010101") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CompanyId", "CreatedBy", "DateCreated", "Firstname", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Lastname", "MiddleName" },
                values: new object[] { new Guid("00000002-0002-0002-0202-020202020202"), null, new Guid("f31cf345-9bff-475c-9fba-02d9d8e6a7df"), "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(7320), "System", null, "Administrator", new DateTime(2023, 7, 23, 10, 42, 15, 125, DateTimeKind.Local).AddTicks(7330), "Publisher", null });

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
