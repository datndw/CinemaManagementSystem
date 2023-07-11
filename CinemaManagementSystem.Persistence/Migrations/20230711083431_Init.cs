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
                    { new Guid("3e7fe71d-cf5c-4711-bedc-a792eecdf9a0"), new DateTime(1959, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 246, DateTimeKind.Local).AddTicks(550), "Ông được cho là diễn viên điện ảnh tâm huyết nhất khi tính tới năm 2023, ông đã thro đuổi đam mê được 38 năm", "Male", "/2ZulC2Ccq1yv3pemusks6Zlfy2s.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 246, DateTimeKind.Local).AddTicks(560), "John Makanno" },
                    { new Guid("67e9f5d9-bf69-4914-9fbc-08b3806ef1a5"), new DateTime(1990, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 246, DateTimeKind.Local).AddTicks(570), "Chàng diễn viên trẻ tuổi với những thành tựu lớn lao trong sự nghiệp mới chớm nở của anh tại WestKark", "Male", "/fe4mUSp0XotA6Ku4Bs69Q9o2lqU.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 246, DateTimeKind.Local).AddTicks(570), "Alexander Gould" },
                    { new Guid("a4c84ad8-ec37-4504-8e59-7fa0143850cf"), new DateTime(1982, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 246, DateTimeKind.Local).AddTicks(530), "Nam diễn viên chuyên nghiệp góp mặt trong nhiều bộ phim đình đám của các hãng phim Châu Âu", "Male", "/mDLDvsx8PaZoEThkBdyaG1JxPdf.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 246, DateTimeKind.Local).AddTicks(540), "Kane Karrtima" },
                    { new Guid("e01c80f8-c1ea-4e4e-843e-1c285f88ec41"), new DateTime(1966, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 246, DateTimeKind.Local).AddTicks(560), "Dave began his writing career in 1993 as one of the original writers on NBC's \"Late Night With Conan O'Brien.\" After more than 400 shows, Dave moved to Los Angeles in 1995 and landed a job at Walt Disney Feature Animation in the movie \"Tarzan.\"", "Male", "/5iKtATPbLpv2lT7q9DPX2v2qPS1.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 246, DateTimeKind.Local).AddTicks(560), "David Reynolds" },
                    { new Guid("ff5d0dba-82c0-4474-8815-7ac85e89ba48"), new DateTime(1987, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 246, DateTimeKind.Local).AddTicks(580), "Diễn viên không thể thiếu trong các tựa phim hành động, phiêu lưu có tính chất liều lĩnh, ngoan cường", "Male", "/z8IEEid4z63CBlJtxrTKEfsW7NA.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 246, DateTimeKind.Local).AddTicks(580), "Ellen DeGeneres" }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("1e4854b9-8696-4c29-9374-290932f70f59"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(6470), "Columbia Pictures Industries, Inc. (CPII) is an American film production and distribution company. Columbia Pictures now forms part of the Columbia TriStar Motion Picture Group, owned by Sony Pictures Entertainment, a subsidiary of the Japanese conglomerate Sony. It is one of the leading film companies in the world, a member of the so-called Big Six. It was one of the so-called Little Three among the eight major film studios of Hollywood's Golden Age.", "/71BqEFAF4V3qjjMPCpLuyJFB9A.png", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(6470), "Columbia Pictures", null },
                    { new Guid("27b3143f-bb07-4a54-97e1-ab778425313a"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(6490), "Kiểu như đường kẻ mới =)) Chứ còn gì nữa", "/78ilmDNTpdCfsakrsLqmAUkFTrO.png", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(6490), "New Line Cinema", null },
                    { new Guid("b311441d-d5c7-4e8d-9d20-8aa54ea0e005"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 235, DateTimeKind.Local).AddTicks(4860), "Founded in 1971, Lucasfilm is one of the world's leading entertainment companies and home to the legendary Star Wars and Indiana Jones franchises.", "/o86DbpburjxrqAzEDhXZcyE8pDb.png", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(6090), "Lucasfilm Ltd.", null },
                    { new Guid("c791a36f-efb1-4b0c-bcdb-d589cfef5fa2"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(6510), "Cái công ty mà có cái đèn nhảy nhảy đè chứ I đúng không =))", "/1TjvGVDMYsj6JBxOAkUHpPEwLf7.png", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(6510), "Pixar", null },
                    { new Guid("dbe7eed6-9261-4e2b-b72c-0baa77a91023"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(6480), "Nhắc đến DreamWorks Pictures không thể không nghĩ tới hình ảnh cậu bé ngồi câu sao trên mặt trăng tượng trưng cho không biết, chắc là flex kiểu điện ảnh chuyên nghiệp =))", "/vru2SssLX3FPhnKZGtYw00pVIS9.png", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(6480), "DreamWorks Pictures", null },
                    { new Guid("e552ed3c-0c8a-4b16-8602-be040a990a3f"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(6500), "Cái này có phải Disney không nhỉ?", "/wdrCwmRnLFJhEoH8GSfymY85KHT.png", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(6500), "Walt Disney Pictures", null }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("055f8ca6-74df-43c3-9aad-4fc316d85296"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9630), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9630), "Phim Nhạc" },
                    { new Guid("06b57a6d-a169-4875-b3ae-11abcfee691c"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9610), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9620), "Phim Lịch Sử" },
                    { new Guid("08e2a99e-96b6-4f9a-8866-37fb7e2d1b59"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9570), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9570), "Phim Hình Sự" },
                    { new Guid("09c732e3-3e68-454c-8584-037c7bb5a6d9"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9560), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9560), "Phim Hài" },
                    { new Guid("180a399f-ad16-43a1-859f-97050f0f8ad1"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9670), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9680), "Phim Gây Cấn" },
                    { new Guid("28de40be-66ea-42ef-8cf1-181c3205cada"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9550), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9550), "Phim Hoạt Hình" },
                    { new Guid("29bb13f9-4cf0-4287-9308-2db1a1c8a7c6"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9690), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9690), "Phim Miền Tây" },
                    { new Guid("401a268e-1272-40bf-9175-1e8ea17a99f3"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9660), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9660), "Phim Khoa Học Viễn Tưởng" },
                    { new Guid("5d294dd2-08c9-4460-9962-3c5f5a3231cd"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9650), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9650), "Phim Lãng Mạn" },
                    { new Guid("7e6f037f-4f6e-4931-a79b-1bb68e3c5ea0"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9680), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9680), "Phim Chiến Tranh" },
                    { new Guid("a92224b1-4f02-4c52-af2f-8f3e26d1c9ec"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9620), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9620), "Phim Kinh Dị" },
                    { new Guid("b13c612c-c4f6-4322-8ab9-f1e37f11146a"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9540), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9540), "Phim Phiêu Lưu" },
                    { new Guid("b57b51ca-de9b-4579-8271-57e6ec5fa7e4"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9600), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9600), "Phim Gia Đình" },
                    { new Guid("c026c572-4918-4093-bf17-4653f1d292fe"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9670), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9670), "Chương Trình Truyền Hình" },
                    { new Guid("d4c61819-9098-461e-98f0-b93ef3c5b1af"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9520), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9530), "Phim Hành Động" },
                    { new Guid("d4f29d63-a05a-437a-b342-696f0e04b06a"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9580), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9580), "Phim Tài Liệu" },
                    { new Guid("d7a9aeb0-f63d-485c-a442-86c52cf9401c"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9640), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9640), "Phim Bí Ẩn" },
                    { new Guid("ecfeb11d-6453-4d45-ba03-d77cc3f2d0e6"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9610), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9610), "Phim Giả Tượng" },
                    { new Guid("ef1e3663-2349-477d-958b-b8b0a6a9a5ea"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9590), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9590), "Phim Chính Kịch" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRequired", "BackDropUrl", "CreatedBy", "DateCreated", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "ReleaseDate", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("02e364f8-d6f9-47f7-88ac-a636466a75d6"), 12, "/oqP1qEZccq5AD9TVTIaO6IGUj7o.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8910), "Khi nữ thần chiến tranh Athena tái sinh trong cơ thể của một cô gái trẻ tên Sienna, chàng trai mồ côi Seiya phát hiện số phận của anh được định sẵn để bảo vệ cô và giải cứu thế giới. Nếu muốn sống sót, Seiya cần phải nắm lấy vận mệnh của mình và hy sinh mọi thứ để có được vị trí xứng đáng trong số các Hiệp sĩ Hoàng đạo.", "/7Hb59xDBe9fUPcR3VYFnLMCioLL.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8920), new DateTime(2023, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Knights of the Zodiac" },
                    { new Guid("11d7437c-b44d-4966-bf36-fe73d569b21a"), 12, "/wbNm4ShryprgwY9QIlEZU6JIcr1.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9120), "The story of Tim Ballard, a former US government agent, who quits his job in order to devote his life to rescuing children from global sex traffickers.", "/mx4O9OEvIB265VM3UATLslsSW5t.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9120), new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Sound of Freedom" },
                    { new Guid("1924ff46-177a-4c0a-964a-5f1331deffa3"), 16, "/4tdV5AeojEdbvn6VpeQrbuDlmzs.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9070), "Câu chuyện bắt đầu khi Suzume vô tình gặp chàng trai Souta đến thị trấn nơi cô sinh sống với mục đích tìm kiếm \"một cánh cửa\". Để bảo vệ Nhật Bản khỏi thảm họa, những cánh cửa rải rác khắp nơi phải được đóng lại, và bất ngờ thay Suzume cũng có khả năng đóng cửa đặc biệt này. Từ đó cả hai cùng nhau thực hiện sự mệnh \"khóa chặt cửa\"!", "/70f6AyM2U74up5MaPAZJ7AAnKKL.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9070), new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Khóa Chặt Cửa Nào Suzume" },
                    { new Guid("1b3c422c-b757-41ac-a7b7-5291f5f188a1"), 8, "/4XM8DUTQb3lhLemJC51Jx4a2EuA.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8890), "Dom Toretto và gia đình anh ta là mục tiêu của đứa con trai đầy thù hận của trùm ma túy Hernan Reyes.", "/brZzXXQ8GuzlAdu4TJxjhC8ebBL.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8890), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Fast & Furious X" },
                    { new Guid("3ca87128-52f6-46b8-a129-2d69d9b7ad11"), 14, "/628Dep6AxEtDxjZoGP78TsOxYbK.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8940), "Phần phim thứ 7 của loạt phim Nhiệm Vụ Bất Khả Thi", "/eoLBADTttXo4HJLLUK9amxE4RRM.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8940), new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Nhiệm Vụ: Bất Khả Thi - Nghiệp Báo Phần 1" },
                    { new Guid("3ccf0380-6621-4cea-a5d3-b02ab91a2200"), 14, "/fjWcAbHRxCSR4kLGvsPEhNjR2ts.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8930), "Khi ngân hàng mà Owen quản lý bị cướp chỉ vài ngày trước đám cưới của anh, mọi chứng cứ đều chỉ về một hướng cực kỳ khó xử: bố mẹ vợ tương lai của anh.", "/5dliMQ2ODbGNoq0hlefdnuXQxMw.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8930), new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Khi Nhà Vợ Làm Tội Phạm" },
                    { new Guid("5ad3a0a7-272c-4679-897a-1770f0651f5f"), 16, "/35z8hWuzfFUZQaYog8E9LsXW3iI.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8960), "Indiana Jones 5 sẽ pha trộn giữa thực tế, hư cấu khi lấy bối cảnh năm 1969, lần này Indiana Jones sẽ đối mặt với Đức quốc xã trong thời gian diễn ra cuộc chạy đua vào không gian.", "/gTAR51U4eAiCokNqtRy7FsprUar.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8960), new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Indiana Jones và Vòng Quay Định Mệnh" },
                    { new Guid("5d92a2c7-dbdc-4640-8df8-81d9a8f82c0b"), 14, "/vblTCXOWUQGSc837vgbhDRi4HSc.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9060), "Quái vật cơ bắp Seok-do (Ma Dong Seok) dẫn đầu đội hình sự truy lùng đường dây buôn chất cấm của thiếu gia Joo Seong Cheol. Cuộc truy đuổi càng thêm gay cấn khi cú đấm công lý \"chú Ma\" chạm trán thanh kiếm lừng lẫy chốn giang hồ Nhật Bản.", "/jeRp9uQSt4IkpGPqR2iWviRUEsE.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9060), new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Vây Hãm: Không Lối Thoát" },
                    { new Guid("70fa9a7d-69b5-47f2-8eaf-cf093f950ae8"), 14, "/7I6VUdPj6tQECNHdviJkUHD2u89.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9100), "Sát Thủ John Wick: Chương 4 là câu chuyện của John Wick (Keanu Reeves) đã khám phá ra con đường để đánh bại High Table. Nhưng trước khi có thể kiếm được tự do, Wick phải đối đầu với kẻ thù mới với những liên minh hùng mạnh trên toàn cầu và những lực lượng biến những người bạn cũ thành kẻ thù.", "/ksg3XSEezxpRVEB6BrKxmNOuhft.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9100), new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Sát Thủ John Wick: Phần 4" },
                    { new Guid("7dde9b26-1cfa-4608-813e-e11687a9c68e"), 14, "/k1gMjXi1vtwTDiGwfBw7L897zs3.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8990), "Quyết tâm tìm kiếm công bằng cũng như lợi nhuận từ công việc bạc bẽo, một công nhân nhà máy âm mưu tuồn nước hoa xa xỉ qua mặt sếp mình.", "/4x9u5HsxeSJu9SW9Pf6fVVDPwxv.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8990), new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Mùi Hương Của Vàng" },
                    { new Guid("8f5ba224-1ca9-4a5c-8ede-68b52e1e7a93"), 8, "/nHf61UzkfFno5X1ofIhugCPus2R.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9080), "Barbie and Ken are having the time of their lives in the colorful and seemingly perfect world of Barbie Land. However, when they get a chance to go to the real world, they soon discover the joys and perils of living among humans.", "/mqNkQhaXxsH8SLNmJnG5oGz4meR.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9080), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Barbie" },
                    { new Guid("9a6e062e-2309-4bbd-8e5b-9482fef46ec7"), 10, "/cSYLX73WskxCgvpN3MtRkYUSj1T.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9110), "Xứ Sở Các Nguyên Tố từ Disney và Pixar lấy bối cảnh tại thành phố các các nguyên tố, nơi lửa, nước, đất và không khí cùng chung sống với nhau. Câu chuyện xoay quanh nhân vật Ember, một cô nàng cá tính, thông minh, mạnh mẽ và đầy sức hút. Tuy nhiên, mối quan hệ của cô với Wade - một anh chàng hài hước, luôn thuận thế đẩy dòng - khiến Ember cảm thấy ngờ vực với thế giới này.", "/7GaeF6xeUbfXFZCtOCWs503CJUl.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9110), new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Xứ Sở Các Nguyên Tố" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRequired", "BackDropUrl", "CreatedBy", "DateCreated", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "ReleaseDate", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("b1cf2efb-3972-4220-9c0e-89e1e5619062"), 14, "/wbNm4ShryprgwY9QIlEZU6JIcr1.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9130), "Based on the novels by Colombian writer Mario Mendoza and on the character of detective Frank Molina, the filming of Los Initiados took place in Bogotá. In the saga of Frank Molina, which uses the books Lady Massacre, La melancolia de los feos, El diario del fin del mundo and Akelarre, the story of an alcoholic private investigator who unmasks sinister plots within the underworld of Bogotá is told.", "/3FzWr7u7uFaLpolFQlUbibFDpQJ.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9130), new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "The Initiated" },
                    { new Guid("ba0f389e-1c6b-40d5-b236-085c572f73bf"), 14, "/8rpDcsfLJypbO6vREc0547VKqEv.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9020), "Câu chuyện của “Avatar: Dòng Chảy Của Nước” lấy bối cảnh 10 năm sau những sự kiện xảy ra ở phần đầu tiên. Phim kể câu chuyện về gia đình mới của Jake Sully (Sam Worthington thủ vai) cùng những rắc rối theo sau và bi kịch họ phải chịu đựng khi phe loài người xâm lược hành tinh Pandora.", "/jGmC7aMqoLU0ALRKHkz3pQVV1pg.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9020), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Avatar:  Dòng Chảy Của Nước" },
                    { new Guid("bea41c9f-6a15-4e7e-ab7f-a0723be76924"), 8, "/9n2tJBplPbgR2ca05hS5CKXwP2c.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8970), "The Super Mario Bros. Movie xoay quanh cuộc phiêu lưu ở thế giới Vương quốc Nấm của anh em thợ sửa ống nước Mario và Luigi. Sau khi tình cờ bước tới vùng đất lạ từ một ống nước, Luigi đã bị chia tách với Mario và rơi vào tay quái vật rùa xấu xa Bowser, hắn đang âm mưu độc chiếm thế giới. Trong lúc cố gắng tìm kiếm người anh em của mình, Mario đã chạm mặt anh bạn nấm Toad và công chúa Peach. Từ đây họ sát cánh bên nhau trên hành trình ngăn chặn thế lực hắc ám.", "/gRlfFcpPdjREQ3lgeuAuB10gfbR.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8970), new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Anh Em Super Mario" },
                    { new Guid("c5317ab1-07fd-45be-92d5-6b639b60321d"), 14, "/wuwMLVIY0Zqfz6uToyDmb7TYRVN.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8980), "A group of Black friends reunite for a Juneteenth weekend getaway only to find themselves trapped in a remote cabin with a twisted killer.", "/n2aS9FE0C3VUHtSb3Ak41aU9K3y.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8980), new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "The Blackening" },
                    { new Guid("c7b4aeb4-5e12-4b25-b49a-e81d9b881f38"), 14, "/4QpKxH614YFIsmiIBVUbsnG2H8w.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9090), "Bị đổ oan tội ác bi thảm, hiệp sĩ nọ bắt tay với một thiếu nữ kiên cường, có khả năng thay đổi hình dạng để minh oan. Nhưng sẽ ra sao nếu cô là con quái vật anh thề sẽ tiêu diệt?", "/2NQljeavtfl22207D1kxLpa4LS3.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9090), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Nimona" },
                    { new Guid("d3e584c5-0a2f-477d-808b-a78152155fda"), 16, "/aO6hDsqTIAtQFUBoPWklmPFsSTW.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8950), "To put their demons to rest once and for all, Josh Lambert and a college-aged Dalton Lambert must go deeper into The Further than ever before, facing their family's dark past and a host of new and more horrifying terrors that lurk behind the red door.", "/faafq0NouR3wSemwc77slLEJHId.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8960), new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Quỷ Quyệt: Cửa Đỏ Vô Định" },
                    { new Guid("ee9a8ba8-4313-4b5d-853f-dae43dd837c3"), 12, "/3LzSMuatf6E6xw6i9F8LnvBZmAy.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9010), "Greg is a police lieutenant; he must collect informations on eco-activists, infiltrating them for months. Myriam, a young free woman, is fighting to save a forest from the building of a dam. They meet and fall in love on the Zone. A beautiful life, a joy that Greg discovers, despite the risks of being unmasked. For each of them, time is short: soon everything will disappear.", "/36wyM5ceCCIpu8lU88mxonYET71.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9010), new DateTime(2022, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "A Place to Fight For" },
                    { new Guid("f8bcb61f-f531-418f-ac4e-2bee3e99fa12"), 12, "/5YZbUmjbMa3ClvSW1Wj3D6XGolb.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8920), "Cho dù vũ trụ này có bao la đến đâu, các Vệ Binh của chúng ta cũng không thể trốn chạy mãi mãi.", "/Ak5hAxorxMpxKoVw5e3kGfxs7sY.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(8930), new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Vệ Binh Dải Ngân Hà 3" },
                    { new Guid("ff4f2c3b-b6fc-4799-90df-69de1faa85b5"), 12, "/4HodYYKEIsGOdinkGi2Ucz6X9i0.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9000), "Miles Morales tái xuất trong phần tiếp theo của bom tấn hoạt hình từng đoạt giải Oscar - Spider-Man: Across the Spider-Verse. Sau khi gặp lại Gwen Stacy, chàng Spider-Man thân thiện đến từ Brooklyn phải du hành qua đa vũ trụ và gặp một nhóm Người Nhện chịu trách nhiệm bảo vệ các thế giới song song. Nhưng khi nhóm siêu anh hùng xung đột về cách xử lý một mối đe dọa mới, Miles buộc phải đọ sức với các Người Nhện khác và phải xác định lại ý nghĩa của việc trở thành một người hùng để có thể cứu những người cậu yêu thương nhất.", "/bX547n5W9ZIKCeAE44Vf2nfw4w.jpg", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(9000), new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Người Nhện: Du Hành Vũ Trụ Nhện" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDate", "CompanyId", "CreatedBy", "DateCreated", "Firstname", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Lastname", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("00000001-0001-0001-0101-010101010101"), null, null, "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(7080), "System", null, "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(7080), "Administrator", null },
                    { new Guid("00000003-0003-0003-0303-030303030303"), null, null, "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(7790), "System", null, "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(7800), "User", null }
                });

            migrationBuilder.InsertData(
                table: "MovieActor",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("a4c84ad8-ec37-4504-8e59-7fa0143850cf"), new Guid("02e364f8-d6f9-47f7-88ac-a636466a75d6") },
                    { new Guid("3e7fe71d-cf5c-4711-bedc-a792eecdf9a0"), new Guid("1b3c422c-b757-41ac-a7b7-5291f5f188a1") },
                    { new Guid("a4c84ad8-ec37-4504-8e59-7fa0143850cf"), new Guid("1b3c422c-b757-41ac-a7b7-5291f5f188a1") },
                    { new Guid("e01c80f8-c1ea-4e4e-843e-1c285f88ec41"), new Guid("3ca87128-52f6-46b8-a129-2d69d9b7ad11") },
                    { new Guid("a4c84ad8-ec37-4504-8e59-7fa0143850cf"), new Guid("3ccf0380-6621-4cea-a5d3-b02ab91a2200") },
                    { new Guid("ff5d0dba-82c0-4474-8815-7ac85e89ba48"), new Guid("3ccf0380-6621-4cea-a5d3-b02ab91a2200") },
                    { new Guid("e01c80f8-c1ea-4e4e-843e-1c285f88ec41"), new Guid("9a6e062e-2309-4bbd-8e5b-9482fef46ec7") },
                    { new Guid("67e9f5d9-bf69-4914-9fbc-08b3806ef1a5"), new Guid("bea41c9f-6a15-4e7e-ab7f-a0723be76924") },
                    { new Guid("67e9f5d9-bf69-4914-9fbc-08b3806ef1a5"), new Guid("d3e584c5-0a2f-477d-808b-a78152155fda") },
                    { new Guid("e01c80f8-c1ea-4e4e-843e-1c285f88ec41"), new Guid("d3e584c5-0a2f-477d-808b-a78152155fda") },
                    { new Guid("3e7fe71d-cf5c-4711-bedc-a792eecdf9a0"), new Guid("f8bcb61f-f531-418f-ac4e-2bee3e99fa12") },
                    { new Guid("a4c84ad8-ec37-4504-8e59-7fa0143850cf"), new Guid("f8bcb61f-f531-418f-ac4e-2bee3e99fa12") },
                    { new Guid("ff5d0dba-82c0-4474-8815-7ac85e89ba48"), new Guid("f8bcb61f-f531-418f-ac4e-2bee3e99fa12") }
                });

            migrationBuilder.InsertData(
                table: "MovieCompany",
                columns: new[] { "CompanyId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("e552ed3c-0c8a-4b16-8602-be040a990a3f"), new Guid("11d7437c-b44d-4966-bf36-fe73d569b21a") },
                    { new Guid("27b3143f-bb07-4a54-97e1-ab778425313a"), new Guid("1924ff46-177a-4c0a-964a-5f1331deffa3") },
                    { new Guid("b311441d-d5c7-4e8d-9d20-8aa54ea0e005"), new Guid("1b3c422c-b757-41ac-a7b7-5291f5f188a1") },
                    { new Guid("b311441d-d5c7-4e8d-9d20-8aa54ea0e005"), new Guid("3ccf0380-6621-4cea-a5d3-b02ab91a2200") },
                    { new Guid("27b3143f-bb07-4a54-97e1-ab778425313a"), new Guid("7dde9b26-1cfa-4608-813e-e11687a9c68e") },
                    { new Guid("1e4854b9-8696-4c29-9374-290932f70f59"), new Guid("bea41c9f-6a15-4e7e-ab7f-a0723be76924") },
                    { new Guid("dbe7eed6-9261-4e2b-b72c-0baa77a91023"), new Guid("c5317ab1-07fd-45be-92d5-6b639b60321d") },
                    { new Guid("1e4854b9-8696-4c29-9374-290932f70f59"), new Guid("d3e584c5-0a2f-477d-808b-a78152155fda") },
                    { new Guid("c791a36f-efb1-4b0c-bcdb-d589cfef5fa2"), new Guid("ee9a8ba8-4313-4b5d-853f-dae43dd837c3") },
                    { new Guid("b311441d-d5c7-4e8d-9d20-8aa54ea0e005"), new Guid("f8bcb61f-f531-418f-ac4e-2bee3e99fa12") },
                    { new Guid("dbe7eed6-9261-4e2b-b72c-0baa77a91023"), new Guid("ff4f2c3b-b6fc-4799-90df-69de1faa85b5") }
                });

            migrationBuilder.InsertData(
                table: "MovieGenre",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("055f8ca6-74df-43c3-9aad-4fc316d85296"), new Guid("02e364f8-d6f9-47f7-88ac-a636466a75d6") },
                    { new Guid("d4c61819-9098-461e-98f0-b93ef3c5b1af"), new Guid("02e364f8-d6f9-47f7-88ac-a636466a75d6") },
                    { new Guid("5d294dd2-08c9-4460-9962-3c5f5a3231cd"), new Guid("1b3c422c-b757-41ac-a7b7-5291f5f188a1") },
                    { new Guid("d4c61819-9098-461e-98f0-b93ef3c5b1af"), new Guid("1b3c422c-b757-41ac-a7b7-5291f5f188a1") },
                    { new Guid("28de40be-66ea-42ef-8cf1-181c3205cada"), new Guid("3ca87128-52f6-46b8-a129-2d69d9b7ad11") },
                    { new Guid("09c732e3-3e68-454c-8584-037c7bb5a6d9"), new Guid("3ccf0380-6621-4cea-a5d3-b02ab91a2200") },
                    { new Guid("ecfeb11d-6453-4d45-ba03-d77cc3f2d0e6"), new Guid("5ad3a0a7-272c-4679-897a-1770f0651f5f") },
                    { new Guid("b13c612c-c4f6-4322-8ab9-f1e37f11146a"), new Guid("5d92a2c7-dbdc-4640-8df8-81d9a8f82c0b") },
                    { new Guid("d4c61819-9098-461e-98f0-b93ef3c5b1af"), new Guid("5d92a2c7-dbdc-4640-8df8-81d9a8f82c0b") },
                    { new Guid("28de40be-66ea-42ef-8cf1-181c3205cada"), new Guid("7dde9b26-1cfa-4608-813e-e11687a9c68e") },
                    { new Guid("d4f29d63-a05a-437a-b342-696f0e04b06a"), new Guid("7dde9b26-1cfa-4608-813e-e11687a9c68e") },
                    { new Guid("b13c612c-c4f6-4322-8ab9-f1e37f11146a"), new Guid("ba0f389e-1c6b-40d5-b236-085c572f73bf") },
                    { new Guid("ecfeb11d-6453-4d45-ba03-d77cc3f2d0e6"), new Guid("bea41c9f-6a15-4e7e-ab7f-a0723be76924") },
                    { new Guid("b57b51ca-de9b-4579-8271-57e6ec5fa7e4"), new Guid("c5317ab1-07fd-45be-92d5-6b639b60321d") },
                    { new Guid("055f8ca6-74df-43c3-9aad-4fc316d85296"), new Guid("d3e584c5-0a2f-477d-808b-a78152155fda") },
                    { new Guid("a92224b1-4f02-4c52-af2f-8f3e26d1c9ec"), new Guid("d3e584c5-0a2f-477d-808b-a78152155fda") },
                    { new Guid("09c732e3-3e68-454c-8584-037c7bb5a6d9"), new Guid("ee9a8ba8-4313-4b5d-853f-dae43dd837c3") },
                    { new Guid("b13c612c-c4f6-4322-8ab9-f1e37f11146a"), new Guid("f8bcb61f-f531-418f-ac4e-2bee3e99fa12") }
                });

            migrationBuilder.InsertData(
                table: "MovieGenre",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { new Guid("d4c61819-9098-461e-98f0-b93ef3c5b1af"), new Guid("f8bcb61f-f531-418f-ac4e-2bee3e99fa12") },
                    { new Guid("08e2a99e-96b6-4f9a-8866-37fb7e2d1b59"), new Guid("ff4f2c3b-b6fc-4799-90df-69de1faa85b5") }
                });

            migrationBuilder.InsertData(
                table: "Rate",
                columns: new[] { "Id", "Comment", "CreatedBy", "DateCreated", "LastModifiedBy", "LastModifiedDate", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("b19cd956-7225-4c57-b82a-33b30ed5818f"), "Web xịn, phim hay, toàn trai xinh gái đẹp, recommend nha mọi ngừi", "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 246, DateTimeKind.Local).AddTicks(1550), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 246, DateTimeKind.Local).AddTicks(1560), new Guid("1b3c422c-b757-41ac-a7b7-5291f5f188a1"), 9.5, new Guid("00000001-0001-0001-0101-010101010101") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDate", "CompanyId", "CreatedBy", "DateCreated", "Firstname", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Lastname", "MiddleName" },
                values: new object[] { new Guid("00000002-0002-0002-0202-020202020202"), null, new Guid("b311441d-d5c7-4e8d-9d20-8aa54ea0e005"), "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(7790), "System", null, "Administrator", new DateTime(2023, 7, 11, 15, 34, 31, 245, DateTimeKind.Local).AddTicks(7790), "Publisher", null });

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
