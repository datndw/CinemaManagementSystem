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
                name: "Actor",
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
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
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
                    table.PrimaryKey("PK_Company", x => x.Id);
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
                name: "User",
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
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovieActor",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActor", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActor_Actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActor_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCompany",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCompany", x => new { x.MovieId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_MovieCompany_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCompany_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
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
                    table.PrimaryKey("PK_Rate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rate_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rate_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "BirthDate", "CreatedBy", "DateCreated", "Description", "Gender", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("003d472a-4bee-4143-9485-ecf821662cf4"), new DateTime(1987, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3870), "Diễn viên không thể thiếu trong các tựa phim hành động, phiêu lưu có tính chất liều lĩnh, ngoan cường", "Male", "/z8IEEid4z63CBlJtxrTKEfsW7NA.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3870), "Ellen DeGeneres" },
                    { new Guid("637ff759-43c8-4d51-999d-e9c427be8847"), new DateTime(1959, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3840), "Ông được cho là diễn viên điện ảnh tâm huyết nhất khi tính tới năm 2023, ông đã thro đuổi đam mê được 38 năm", "Male", "/2ZulC2Ccq1yv3pemusks6Zlfy2s.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3840), "John Makanno" },
                    { new Guid("945fc645-f58d-437a-b80b-9b4dbc799da1"), new DateTime(1990, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3860), "Chàng diễn viên trẻ tuổi với những thành tựu lớn lao trong sự nghiệp mới chớm nở của anh tại WestKark", "Male", "/fe4mUSp0XotA6Ku4Bs69Q9o2lqU.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3860), "Alexander Gould" },
                    { new Guid("b15c5173-4322-45cf-93d1-5218c0be7b99"), new DateTime(1982, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3820), "Nam diễn viên chuyên nghiệp góp mặt trong nhiều bộ phim đình đám của các hãng phim Châu Âu", "Male", "/mDLDvsx8PaZoEThkBdyaG1JxPdf.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3820), "Kane Karrtima" },
                    { new Guid("eba2220e-2775-49da-a210-50619d60712a"), new DateTime(1966, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3850), "Dave began his writing career in 1993 as one of the original writers on NBC's \"Late Night With Conan O'Brien.\" After more than 400 shows, Dave moved to Los Angeles in 1995 and landed a job at Walt Disney Feature Animation in the movie \"Tarzan.\"", "Male", "/5iKtATPbLpv2lT7q9DPX2v2qPS1.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3850), "David Reynolds" }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("17b74a2b-a8ac-45ae-95d0-ff6a4fa411bc"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(320), "Nhắc đến DreamWorks Pictures không thể không nghĩ tới hình ảnh cậu bé ngồi câu sao trên mặt trăng tượng trưng cho không biết, chắc là flex kiểu điện ảnh chuyên nghiệp =))", "/vru2SssLX3FPhnKZGtYw00pVIS9.png", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(320), "DreamWorks Pictures", null },
                    { new Guid("43d00425-9cd4-43f0-89ca-885f55eea75d"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(340), "Cái này có phải Disney không nhỉ?", "/wdrCwmRnLFJhEoH8GSfymY85KHT.png", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(340), "Walt Disney Pictures", null },
                    { new Guid("72068859-00bd-40a4-9136-6a0949916462"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(350), "Cái công ty mà có cái đèn nhảy nhảy đè chứ I đúng không =))", "/1TjvGVDMYsj6JBxOAkUHpPEwLf7.png", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(350), "Pixar", null },
                    { new Guid("b3c06f54-0bd3-4c26-843c-fc52144db47c"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(310), "Columbia Pictures Industries, Inc. (CPII) is an American film production and distribution company. Columbia Pictures now forms part of the Columbia TriStar Motion Picture Group, owned by Sony Pictures Entertainment, a subsidiary of the Japanese conglomerate Sony. It is one of the leading film companies in the world, a member of the so-called Big Six. It was one of the so-called Little Three among the eight major film studios of Hollywood's Golden Age.", "/71BqEFAF4V3qjjMPCpLuyJFB9A.png", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(310), "Columbia Pictures", null },
                    { new Guid("c0fdc44d-b615-4bc0-a111-07462034be2a"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 448, DateTimeKind.Local).AddTicks(2840), "Founded in 1971, Lucasfilm is one of the world's leading entertainment companies and home to the legendary Star Wars and Indiana Jones franchises.", "/o86DbpburjxrqAzEDhXZcyE8pDb.png", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local), "Lucasfilm Ltd.", null },
                    { new Guid("f789a234-3804-40c7-92c5-f9534eb908cc"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(330), "Kiểu như đường kẻ mới =)) Chứ còn gì nữa", "/78ilmDNTpdCfsakrsLqmAUkFTrO.png", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(330), "New Line Cinema", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("1f193728-f63e-4b5d-9cca-be1829521364"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2910), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2910), "Phim Hài" },
                    { new Guid("2b36683e-4502-475c-9b1a-8fe22460bdc2"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2930), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2930), "Phim Tài Liệu" },
                    { new Guid("422036ac-7dcf-42a5-bd75-4e148bff8f81"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2950), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2950), "Phim Giả Tượng" },
                    { new Guid("50df545a-ec3b-4b77-a611-9d9e95a67d70"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3010), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3010), "Chương Trình Truyền Hình" },
                    { new Guid("5470c820-6513-4c86-9ed4-f1e03b4ca7b5"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3030), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3030), "Phim Miền Tây" },
                    { new Guid("8025dd69-d39e-47ec-b20c-f8cf2a87e3c2"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2900), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2900), "Phim Hoạt Hình" },
                    { new Guid("83b18249-e52e-47d2-b201-4f670664708e"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2960), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2960), "Phim Lịch Sử" },
                    { new Guid("88f568ef-caa1-4d42-9002-075d85be97ee"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2890), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2890), "Phim Phiêu Lưu" },
                    { new Guid("8a2230b4-d8aa-4ecb-a409-b131dc7ae57f"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3000), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3000), "Phim Khoa Học Viễn Tưởng" },
                    { new Guid("967f809f-3607-45ca-9aa3-aa378dddcbd5"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2940), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2940), "Phim Chính Kịch" },
                    { new Guid("a1e38a6f-b772-4d9e-8518-34f591507d55"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2990), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2990), "Phim Lãng Mạn" },
                    { new Guid("a85e5ed9-c7c2-46e2-93bb-b63c53304261"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2980), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2990), "Phim Bí Ẩn" },
                    { new Guid("ad991237-24db-4f54-aabf-fe9205ac7665"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2880), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2880), "Phim Hành Động" },
                    { new Guid("b2f9cd1b-173f-4b76-9a7a-f9ee1b448bdf"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2940), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2940), "Phim Gia Đình" },
                    { new Guid("d4dd99a7-0a53-47a5-8d23-cfe19c77cb4c"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3020), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3030), "Phim Chiến Tranh" },
                    { new Guid("d9029914-61e0-4601-9948-2ba3b06c3c7b"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2920), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2920), "Phim Hình Sự" },
                    { new Guid("e5c5e1b6-3c8a-4ec9-a996-7ea9e4f298ff"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3020), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(3020), "Phim Gây Cấn" },
                    { new Guid("ee9a75af-3c14-4fe5-a29c-f6edeef2505d"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2980), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2980), "Phim Nhạc" },
                    { new Guid("f30c8ac3-92b8-43a9-8a12-1e63438e0f34"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2970), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2970), "Phim Kinh Dị" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRequired", "BackDropUrl", "CreatedBy", "DateCreated", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("023fab5e-e9cc-406f-92a9-2ad88c959ab9"), 14, "/vblTCXOWUQGSc837vgbhDRi4HSc.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2510), "Quái vật cơ bắp Seok-do (Ma Dong Seok) dẫn đầu đội hình sự truy lùng đường dây buôn chất cấm của thiếu gia Joo Seong Cheol. Cuộc truy đuổi càng thêm gay cấn khi cú đấm công lý \"chú Ma\" chạm trán thanh kiếm lừng lẫy chốn giang hồ Nhật Bản.", "/jeRp9uQSt4IkpGPqR2iWviRUEsE.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2510), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vây Hãm: Không Lối Thoát" },
                    { new Guid("28e9f371-d980-4f72-81bb-a1a82e5b1e0a"), 12, "/3LzSMuatf6E6xw6i9F8LnvBZmAy.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2500), "Greg is a police lieutenant; he must collect informations on eco-activists, infiltrating them for months. Myriam, a young free woman, is fighting to save a forest from the building of a dam. They meet and fall in love on the Zone. A beautiful life, a joy that Greg discovers, despite the risks of being unmasked. For each of them, time is short: soon everything will disappear.", "/36wyM5ceCCIpu8lU88mxonYET71.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2500), new DateTime(2022, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Place to Fight For" },
                    { new Guid("2b17a63e-4376-468a-a40f-471e8613e582"), 14, "/k1gMjXi1vtwTDiGwfBw7L897zs3.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2480), "Quyết tâm tìm kiếm công bằng cũng như lợi nhuận từ công việc bạc bẽo, một công nhân nhà máy âm mưu tuồn nước hoa xa xỉ qua mặt sếp mình.", "/4x9u5HsxeSJu9SW9Pf6fVVDPwxv.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2480), new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mùi Hương Của Vàng" },
                    { new Guid("3362c7b9-c2ba-4d8f-ada3-38e91a88d342"), 12, "/5YZbUmjbMa3ClvSW1Wj3D6XGolb.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2410), "Cho dù vũ trụ này có bao la đến đâu, các Vệ Binh của chúng ta cũng không thể trốn chạy mãi mãi.", "/Ak5hAxorxMpxKoVw5e3kGfxs7sY.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2420), new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vệ Binh Dải Ngân Hà 3" },
                    { new Guid("54ed49bd-1150-4a38-a020-f07b311b405f"), 16, "/35z8hWuzfFUZQaYog8E9LsXW3iI.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2450), "Indiana Jones 5 sẽ pha trộn giữa thực tế, hư cấu khi lấy bối cảnh năm 1969, lần này Indiana Jones sẽ đối mặt với Đức quốc xã trong thời gian diễn ra cuộc chạy đua vào không gian.", "/gTAR51U4eAiCokNqtRy7FsprUar.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2450), new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indiana Jones và Vòng Quay Định Mệnh" },
                    { new Guid("603656c3-e160-4963-bba0-0627f0f1242a"), 8, "/9n2tJBplPbgR2ca05hS5CKXwP2c.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2460), "The Super Mario Bros. Movie xoay quanh cuộc phiêu lưu ở thế giới Vương quốc Nấm của anh em thợ sửa ống nước Mario và Luigi. Sau khi tình cờ bước tới vùng đất lạ từ một ống nước, Luigi đã bị chia tách với Mario và rơi vào tay quái vật rùa xấu xa Bowser, hắn đang âm mưu độc chiếm thế giới. Trong lúc cố gắng tìm kiếm người anh em của mình, Mario đã chạm mặt anh bạn nấm Toad và công chúa Peach. Từ đây họ sát cánh bên nhau trên hành trình ngăn chặn thế lực hắc ám.", "/gRlfFcpPdjREQ3lgeuAuB10gfbR.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2460), new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anh Em Super Mario" },
                    { new Guid("661ede96-e799-41ec-9e04-babe0592e53c"), 12, "/4HodYYKEIsGOdinkGi2Ucz6X9i0.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2490), "Miles Morales tái xuất trong phần tiếp theo của bom tấn hoạt hình từng đoạt giải Oscar - Spider-Man: Across the Spider-Verse. Sau khi gặp lại Gwen Stacy, chàng Spider-Man thân thiện đến từ Brooklyn phải du hành qua đa vũ trụ và gặp một nhóm Người Nhện chịu trách nhiệm bảo vệ các thế giới song song. Nhưng khi nhóm siêu anh hùng xung đột về cách xử lý một mối đe dọa mới, Miles buộc phải đọ sức với các Người Nhện khác và phải xác định lại ý nghĩa của việc trở thành một người hùng để có thể cứu những người cậu yêu thương nhất.", "/bX547n5W9ZIKCeAE44Vf2nfw4w.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2490), new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Người Nhện: Du Hành Vũ Trụ Nhện" },
                    { new Guid("76a3681d-4bd7-45fe-94b8-4a866e1166a5"), 14, "/8rpDcsfLJypbO6vREc0547VKqEv.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2510), "Câu chuyện của “Avatar: Dòng Chảy Của Nước” lấy bối cảnh 10 năm sau những sự kiện xảy ra ở phần đầu tiên. Phim kể câu chuyện về gia đình mới của Jake Sully (Sam Worthington thủ vai) cùng những rắc rối theo sau và bi kịch họ phải chịu đựng khi phe loài người xâm lược hành tinh Pandora.", "/jGmC7aMqoLU0ALRKHkz3pQVV1pg.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2510), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar:  Dòng Chảy Của Nước" },
                    { new Guid("827bfd28-29ea-4e4c-9d4e-7287d7cb6716"), 14, "/7I6VUdPj6tQECNHdviJkUHD2u89.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2550), "Sát Thủ John Wick: Chương 4 là câu chuyện của John Wick (Keanu Reeves) đã khám phá ra con đường để đánh bại High Table. Nhưng trước khi có thể kiếm được tự do, Wick phải đối đầu với kẻ thù mới với những liên minh hùng mạnh trên toàn cầu và những lực lượng biến những người bạn cũ thành kẻ thù.", "/ksg3XSEezxpRVEB6BrKxmNOuhft.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2550), new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sát Thủ John Wick: Phần 4" },
                    { new Guid("86c6b21a-5073-462f-b13b-a08e8a86ac8a"), 8, "/nHf61UzkfFno5X1ofIhugCPus2R.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2530), "Barbie and Ken are having the time of their lives in the colorful and seemingly perfect world of Barbie Land. However, when they get a chance to go to the real world, they soon discover the joys and perils of living among humans.", "/mqNkQhaXxsH8SLNmJnG5oGz4meR.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2530), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barbie" },
                    { new Guid("8a8cf8b3-8874-4caa-ba35-3696243d611c"), 16, "/4tdV5AeojEdbvn6VpeQrbuDlmzs.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2520), "Câu chuyện bắt đầu khi Suzume vô tình gặp chàng trai Souta đến thị trấn nơi cô sinh sống với mục đích tìm kiếm \"một cánh cửa\". Để bảo vệ Nhật Bản khỏi thảm họa, những cánh cửa rải rác khắp nơi phải được đóng lại, và bất ngờ thay Suzume cũng có khả năng đóng cửa đặc biệt này. Từ đó cả hai cùng nhau thực hiện sự mệnh \"khóa chặt cửa\"!", "/70f6AyM2U74up5MaPAZJ7AAnKKL.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2520), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khóa Chặt Cửa Nào Suzume" },
                    { new Guid("9d0cc4f5-1ba0-4308-b237-9110f3a02ed6"), 14, "/wuwMLVIY0Zqfz6uToyDmb7TYRVN.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2470), "A group of Black friends reunite for a Juneteenth weekend getaway only to find themselves trapped in a remote cabin with a twisted killer.", "/n2aS9FE0C3VUHtSb3Ak41aU9K3y.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2470), new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Blackening" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRequired", "BackDropUrl", "CreatedBy", "DateCreated", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("9f9c9df5-568b-4a76-887b-a7afedea832b"), 14, "/fjWcAbHRxCSR4kLGvsPEhNjR2ts.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2420), "Khi ngân hàng mà Owen quản lý bị cướp chỉ vài ngày trước đám cưới của anh, mọi chứng cứ đều chỉ về một hướng cực kỳ khó xử: bố mẹ vợ tương lai của anh.", "/5dliMQ2ODbGNoq0hlefdnuXQxMw.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2420), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khi Nhà Vợ Làm Tội Phạm" },
                    { new Guid("a1c8900b-952a-4cbb-974c-b2be112aa92c"), 16, "/aO6hDsqTIAtQFUBoPWklmPFsSTW.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2440), "To put their demons to rest once and for all, Josh Lambert and a college-aged Dalton Lambert must go deeper into The Further than ever before, facing their family's dark past and a host of new and more horrifying terrors that lurk behind the red door.", "/faafq0NouR3wSemwc77slLEJHId.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2440), new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quỷ Quyệt: Cửa Đỏ Vô Định" },
                    { new Guid("a9df64b3-09a6-44bb-9056-8204552203cd"), 14, "/628Dep6AxEtDxjZoGP78TsOxYbK.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2430), "Phần phim thứ 7 của loạt phim Nhiệm Vụ Bất Khả Thi", "/eoLBADTttXo4HJLLUK9amxE4RRM.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2430), new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nhiệm Vụ: Bất Khả Thi - Nghiệp Báo Phần 1" },
                    { new Guid("b3e27137-8d16-4afd-96a2-144462758fe6"), 14, "/wbNm4ShryprgwY9QIlEZU6JIcr1.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2580), "Based on the novels by Colombian writer Mario Mendoza and on the character of detective Frank Molina, the filming of Los Initiados took place in Bogotá. In the saga of Frank Molina, which uses the books Lady Massacre, La melancolia de los feos, El diario del fin del mundo and Akelarre, the story of an alcoholic private investigator who unmasks sinister plots within the underworld of Bogotá is told.", "/3FzWr7u7uFaLpolFQlUbibFDpQJ.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2580), new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Initiated" },
                    { new Guid("cb12e8e0-e34d-4d31-85f9-455fe981e17d"), 12, "/oqP1qEZccq5AD9TVTIaO6IGUj7o.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2410), "Khi nữ thần chiến tranh Athena tái sinh trong cơ thể của một cô gái trẻ tên Sienna, chàng trai mồ côi Seiya phát hiện số phận của anh được định sẵn để bảo vệ cô và giải cứu thế giới. Nếu muốn sống sót, Seiya cần phải nắm lấy vận mệnh của mình và hy sinh mọi thứ để có được vị trí xứng đáng trong số các Hiệp sĩ Hoàng đạo.", "/7Hb59xDBe9fUPcR3VYFnLMCioLL.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2410), new DateTime(2023, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Knights of the Zodiac" },
                    { new Guid("e35b114f-b3bc-45c2-9355-3045719c2368"), 14, "/4QpKxH614YFIsmiIBVUbsnG2H8w.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2540), "Bị đổ oan tội ác bi thảm, hiệp sĩ nọ bắt tay với một thiếu nữ kiên cường, có khả năng thay đổi hình dạng để minh oan. Nhưng sẽ ra sao nếu cô là con quái vật anh thề sẽ tiêu diệt?", "/2NQljeavtfl22207D1kxLpa4LS3.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2540), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nimona" },
                    { new Guid("e559fe9f-8c69-45ac-a2dc-e3eda20796d5"), 10, "/cSYLX73WskxCgvpN3MtRkYUSj1T.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2560), "Xứ Sở Các Nguyên Tố từ Disney và Pixar lấy bối cảnh tại thành phố các các nguyên tố, nơi lửa, nước, đất và không khí cùng chung sống với nhau. Câu chuyện xoay quanh nhân vật Ember, một cô nàng cá tính, thông minh, mạnh mẽ và đầy sức hút. Tuy nhiên, mối quan hệ của cô với Wade - một anh chàng hài hước, luôn thuận thế đẩy dòng - khiến Ember cảm thấy ngờ vực với thế giới này.", "/7GaeF6xeUbfXFZCtOCWs503CJUl.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2560), new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xứ Sở Các Nguyên Tố" },
                    { new Guid("ed44ceda-4acf-4100-9c99-ed8989ce16d6"), 12, "/wbNm4ShryprgwY9QIlEZU6JIcr1.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2570), "The story of Tim Ballard, a former US government agent, who quits his job in order to devote his life to rescuing children from global sex traffickers.", "/mx4O9OEvIB265VM3UATLslsSW5t.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2570), new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sound of Freedom" },
                    { new Guid("ed73d6cd-b742-46e2-98d7-6786f86ce5ec"), 8, "/4XM8DUTQb3lhLemJC51Jx4a2EuA.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2390), "Dom Toretto và gia đình anh ta là mục tiêu của đứa con trai đầy thù hận của trùm ma túy Hernan Reyes.", "/brZzXXQ8GuzlAdu4TJxjhC8ebBL.jpg", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(2390), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fast & Furious X" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDate", "CompanyId", "CreatedBy", "DateCreated", "Firstname", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Lastname", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("00000001-0001-0001-0101-010101010101"), null, null, "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(830), "System", null, "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(830), "Administrator", null },
                    { new Guid("00000003-0003-0003-0303-030303030303"), null, null, "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(1460), "System", null, "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(1470), "User", null }
                });

            migrationBuilder.InsertData(
                table: "MovieActor",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("003d472a-4bee-4143-9485-ecf821662cf4"), new Guid("3362c7b9-c2ba-4d8f-ada3-38e91a88d342") },
                    { new Guid("637ff759-43c8-4d51-999d-e9c427be8847"), new Guid("3362c7b9-c2ba-4d8f-ada3-38e91a88d342") },
                    { new Guid("b15c5173-4322-45cf-93d1-5218c0be7b99"), new Guid("3362c7b9-c2ba-4d8f-ada3-38e91a88d342") },
                    { new Guid("945fc645-f58d-437a-b80b-9b4dbc799da1"), new Guid("603656c3-e160-4963-bba0-0627f0f1242a") },
                    { new Guid("003d472a-4bee-4143-9485-ecf821662cf4"), new Guid("9f9c9df5-568b-4a76-887b-a7afedea832b") },
                    { new Guid("b15c5173-4322-45cf-93d1-5218c0be7b99"), new Guid("9f9c9df5-568b-4a76-887b-a7afedea832b") },
                    { new Guid("945fc645-f58d-437a-b80b-9b4dbc799da1"), new Guid("a1c8900b-952a-4cbb-974c-b2be112aa92c") },
                    { new Guid("eba2220e-2775-49da-a210-50619d60712a"), new Guid("a1c8900b-952a-4cbb-974c-b2be112aa92c") },
                    { new Guid("eba2220e-2775-49da-a210-50619d60712a"), new Guid("a9df64b3-09a6-44bb-9056-8204552203cd") },
                    { new Guid("b15c5173-4322-45cf-93d1-5218c0be7b99"), new Guid("cb12e8e0-e34d-4d31-85f9-455fe981e17d") },
                    { new Guid("eba2220e-2775-49da-a210-50619d60712a"), new Guid("e559fe9f-8c69-45ac-a2dc-e3eda20796d5") },
                    { new Guid("637ff759-43c8-4d51-999d-e9c427be8847"), new Guid("ed73d6cd-b742-46e2-98d7-6786f86ce5ec") },
                    { new Guid("b15c5173-4322-45cf-93d1-5218c0be7b99"), new Guid("ed73d6cd-b742-46e2-98d7-6786f86ce5ec") }
                });

            migrationBuilder.InsertData(
                table: "MovieCompany",
                columns: new[] { "CompanyId", "MovieId" },
                values: new object[] { new Guid("c0fdc44d-b615-4bc0-a111-07462034be2a"), new Guid("ed73d6cd-b742-46e2-98d7-6786f86ce5ec") });

            migrationBuilder.InsertData(
                table: "MovieGenre",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[] { new Guid("ad991237-24db-4f54-aabf-fe9205ac7665"), new Guid("ed73d6cd-b742-46e2-98d7-6786f86ce5ec") });

            migrationBuilder.InsertData(
                table: "Rate",
                columns: new[] { "Id", "Comment", "CreatedBy", "DateCreated", "LastModifiedBy", "LastModifiedDate", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("638342ef-6e19-40f1-91b9-e101bcfd39fa"), "Web xịn, phim hay, toàn trai xinh gái đẹp, recommend nha mọi ngừi", "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(4760), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(4760), new Guid("ed73d6cd-b742-46e2-98d7-6786f86ce5ec"), 9.5, new Guid("00000001-0001-0001-0101-010101010101") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDate", "CompanyId", "CreatedBy", "DateCreated", "Firstname", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Lastname", "MiddleName" },
                values: new object[] { new Guid("00000002-0002-0002-0202-020202020202"), null, new Guid("c0fdc44d-b615-4bc0-a111-07462034be2a"), "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(1460), "System", null, "Administrator", new DateTime(2023, 7, 10, 14, 35, 10, 457, DateTimeKind.Local).AddTicks(1460), "Publisher", null });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_ActorId",
                table: "MovieActor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCompany_CompanyId",
                table: "MovieCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenreId",
                table: "MovieGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_MovieId",
                table: "Rate",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_UserId",
                table: "Rate",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId",
                table: "User",
                column: "CompanyId",
                unique: true,
                filter: "[CompanyId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActor");

            migrationBuilder.DropTable(
                name: "MovieCompany");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
