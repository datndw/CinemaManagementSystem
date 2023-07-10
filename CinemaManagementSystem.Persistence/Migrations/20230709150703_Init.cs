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
                values: new object[] { new Guid("dbb49f8e-a8d0-4ecd-87aa-d4dee2e0241c"), new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(5400), "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(5790), "Xinh gai, code gioi :))", "Female", "", "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(5800), "Cao Quynh Anh" });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "UserId" },
                values: new object[] { new Guid("c5a362e7-2726-401d-bf1c-7c97d85173fd"), "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 516, DateTimeKind.Local).AddTicks(4010), "Founded in 1971, Lucasfilm is one of the world's leading entertainment companies and home to the legendary Star Wars and Indiana Jones franchises.", "/o86DbpburjxrqAzEDhXZcyE8pDb.png", "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(2280), "Lucasfilm Ltd.", null });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("40ea4241-7fff-40e5-b488-638dc98d5086"), "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(4920), "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(4920), "Phim Phiêu Lưu" },
                    { new Guid("e52ff8e0-4254-4d90-9f5f-75e7d4861f24"), "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(4900), "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(4900), "Phim Hành Động" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "AgeRequired", "BackDropUrl", "CreatedBy", "DateCreated", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "ReleaseDate", "Title" },
                values: new object[] { new Guid("9a3ff39f-cde5-4585-b097-6518556f011f"), 8, "/4XM8DUTQb3lhLemJC51Jx4a2EuA.jpg", "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(4600), "Dom Toretto và gia đình anh ta là mục tiêu của đứa con trai đầy thù hận của trùm ma túy Hernan Reyes.", "/brZzXXQ8GuzlAdu4TJxjhC8ebBL.jpg", "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(4600), new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(4460), "Fast & Furious X" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDate", "CompanyId", "CreatedBy", "DateCreated", "Firstname", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Lastname", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("00000001-0001-0001-0101-010101010101"), null, null, "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(3060), "System", null, "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(3060), "Administrator", null },
                    { new Guid("00000003-0003-0003-0303-030303030303"), null, null, "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(3670), "System", null, "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(3670), "User", null }
                });

            migrationBuilder.InsertData(
                table: "MovieActor",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[] { new Guid("dbb49f8e-a8d0-4ecd-87aa-d4dee2e0241c"), new Guid("9a3ff39f-cde5-4585-b097-6518556f011f") });

            migrationBuilder.InsertData(
                table: "MovieCompany",
                columns: new[] { "CompanyId", "MovieId" },
                values: new object[] { new Guid("c5a362e7-2726-401d-bf1c-7c97d85173fd"), new Guid("9a3ff39f-cde5-4585-b097-6518556f011f") });

            migrationBuilder.InsertData(
                table: "MovieGenre",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[] { new Guid("e52ff8e0-4254-4d90-9f5f-75e7d4861f24"), new Guid("9a3ff39f-cde5-4585-b097-6518556f011f") });

            migrationBuilder.InsertData(
                table: "Rate",
                columns: new[] { "Id", "Comment", "CreatedBy", "DateCreated", "LastModifiedBy", "LastModifiedDate", "MovieId", "Rating", "UserId" },
                values: new object[] { new Guid("454dccc4-d67c-487d-8d1d-f0341c0b7240"), "Web xịn, phim hay, toàn trai xinh gái đẹp, recommend nha mọi ngừi", "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(6730), "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(6730), new Guid("9a3ff39f-cde5-4585-b097-6518556f011f"), 9.5, new Guid("00000001-0001-0001-0101-010101010101") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BirthDate", "CompanyId", "CreatedBy", "DateCreated", "Firstname", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Lastname", "MiddleName" },
                values: new object[] { new Guid("00000002-0002-0002-0202-020202020202"), null, new Guid("c5a362e7-2726-401d-bf1c-7c97d85173fd"), "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(3670), "System", null, "Administrator", new DateTime(2023, 7, 9, 22, 7, 3, 525, DateTimeKind.Local).AddTicks(3670), "Publisher", null });

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
