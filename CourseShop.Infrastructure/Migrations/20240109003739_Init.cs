using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMainCategory = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategory);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_IdMainCategory",
                        column: x => x.IdMainCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory");
                });

            migrationBuilder.CreateTable(
                name: "DifficultyLevels",
                columns: table => new
                {
                    IdDifficultyLevel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Difficulty = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyLevels", x => x.IdDifficultyLevel);
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    IdReference = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainTittle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    PageTittle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.IdReference);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HighlightedCategories",
                columns: table => new
                {
                    IdHighlightedCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighlightedCategories", x => x.IdHighlightedCategory);
                    table.ForeignKey(
                        name: "FK_HighlightedCategories_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    IdCourse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    IdDifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CoursePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.IdCourse);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_DifficultyLevels_IdDifficultyLevel",
                        column: x => x.IdDifficultyLevel,
                        principalTable: "DifficultyLevels",
                        principalColumn: "IdDifficultyLevel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    IdPage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    IdReference = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.IdPage);
                    table.ForeignKey(
                        name: "FK_Pages_References_IdReference",
                        column: x => x.IdReference,
                        principalTable: "References",
                        principalColumn: "IdReference",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseSteps",
                columns: table => new
                {
                    IdCourseStep = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    IdCourse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSteps", x => x.IdCourseStep);
                    table.ForeignKey(
                        name: "FK_CourseSteps_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "IdCourse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteCourses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdCourse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteCourses", x => new { x.Id, x.IdCourse });
                    table.ForeignKey(
                        name: "FK_FavoriteCourses_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteCourses_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "IdCourse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    IdNews = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PhotoSmall = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IdCourse = table.Column<int>(type: "int", nullable: true),
                    IdMainCategory = table.Column<int>(type: "int", nullable: true),
                    IdCategory = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.IdNews);
                    table.CheckConstraint("CK_News_OneIdNotNull", "([IdCourse] IS NOT NULL AND [IdCategory] IS NULL AND [IdMainCategory] IS NULL) OR ([IdCourse] IS NULL AND [IdCategory] IS NOT NULL AND [IdMainCategory] IS NULL) OR ([IdCourse] IS NULL AND [IdCategory] IS NULL AND [IdMainCategory] IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_News_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory");
                    table.ForeignKey(
                        name: "FK_News_Categories_IdMainCategory",
                        column: x => x.IdMainCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory");
                    table.ForeignKey(
                        name: "FK_News_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "IdCourse");
                },
                comment: "Upewnij się, że tylko jedno z pól IdCourse, IdCategory, IdMainCategory ma wartość");

            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    IdOpinion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(2,1)", nullable: false),
                    IdCourse = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.IdOpinion);
                    table.ForeignKey(
                        name: "FK_Opinions_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "IdCourse");
                });

            migrationBuilder.CreateTable(
                name: "PromotedItems",
                columns: table => new
                {
                    IdPromotedItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategory = table.Column<int>(type: "int", nullable: true),
                    IdCourse = table.Column<int>(type: "int", nullable: true),
                    IdMainCategory = table.Column<int>(type: "int", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotedItems", x => x.IdPromotedItem);
                    table.CheckConstraint("CK_PromotedItems_OneIdNotNull", "([IdCourse] IS NOT NULL AND [IdCategory] IS NULL AND [IdMainCategory] IS NULL) OR ([IdCourse] IS NULL AND [IdCategory] IS NOT NULL AND [IdMainCategory] IS NULL) OR ([IdCourse] IS NULL AND [IdCategory] IS NULL AND [IdMainCategory] IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_PromotedItems_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory");
                    table.ForeignKey(
                        name: "FK_PromotedItems_Categories_IdMainCategory",
                        column: x => x.IdMainCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory");
                    table.ForeignKey(
                        name: "FK_PromotedItems_Courses_IdCourse",
                        column: x => x.IdCourse,
                        principalTable: "Courses",
                        principalColumn: "IdCourse");
                },
                comment: "Upewnij się, że tylko jedno z pól IdCourse, IdCategory, IdMainCategory ma wartość");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IdMainCategory",
                table: "Categories",
                column: "IdMainCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_IdCategory",
                table: "Courses",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_IdDifficultyLevel",
                table: "Courses",
                column: "IdDifficultyLevel");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSteps_IdCourse",
                table: "CourseSteps",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteCourses_IdCourse",
                table: "FavoriteCourses",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_HighlightedCategories_IdCategory",
                table: "HighlightedCategories",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_News_IdCategory",
                table: "News",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_News_IdCourse",
                table: "News",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_News_IdMainCategory",
                table: "News",
                column: "IdMainCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_IdCourse",
                table: "Opinions",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_IdReference",
                table: "Pages",
                column: "IdReference");

            migrationBuilder.CreateIndex(
                name: "IX_PromotedItems_IdCategory",
                table: "PromotedItems",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_PromotedItems_IdCourse",
                table: "PromotedItems",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_PromotedItems_IdMainCategory",
                table: "PromotedItems",
                column: "IdMainCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CourseSteps");

            migrationBuilder.DropTable(
                name: "FavoriteCourses");

            migrationBuilder.DropTable(
                name: "HighlightedCategories");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "PromotedItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "DifficultyLevels");
        }
    }
}
