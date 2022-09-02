using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Migrations
{
    public partial class update_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCategoryNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCategoryNews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppContact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    CateLevel = table.Column<int>(type: "int", maxLength: 5, nullable: false, defaultValue: 1),
                    HasChild = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StampPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCateId = table.Column<int>(type: "int", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppProductCategory_AppProductCategory_ParentCateId",
                        column: x => x.ParentCateId,
                        principalTable: "AppProductCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MstPermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Table = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstPermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysEnv",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysEnv", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(200)", maxLength: 200, nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(200)", maxLength: 200, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber1 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    PhoneNumber2 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BlockedTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BlockedBy = table.Column<int>(type: "int", nullable: true),
                    AppRoleId = table.Column<int>(type: "int", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUser_AppRole_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "AppRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppRolePermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppRoleId = table.Column<int>(type: "int", nullable: false),
                    MstPermissionId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRolePermission_AppRole_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "AppRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRolePermission_MstPermission_MstPermissionId",
                        column: x => x.MstPermissionId,
                        principalTable: "MstPermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Views = table.Column<long>(type: "bigint", nullable: false, defaultValue: 0L),
                    Votes = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    Published = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoverImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImgThumbnailPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StampPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SEOTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SEODescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SEOKeyword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SEOImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppNews_AppCategoryNews_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AppCategoryNews",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppNews_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppPolicy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverImgThumbnailPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Like = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPolicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPolicy_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppVerifyCode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expired = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppVerifyCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppVerifyCode_AppUser_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AppUser",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "Desc", "DisplayOrder", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Quản trị toàn bộ hệ thống", null, "Quản trị hệ thống", null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "MstPermission",
                columns: new[] { "Id", "Code", "CreatedDate", "DeletedDate", "Desc", "DisplayOrder", "GroupName", "Table" },
                values: new object[,]
                {
                    { 1306, "UNPUBLIC", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gỡ bỏ bài viết", null, "Quản lý tin tức", "AppNews" },
                    { 1401, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xem danh sách thể loại tin", null, "Quản lý thể loại tin", "AppCategoryNews" },
                    { 1402, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Thêm thể loại bài viết", null, "Quản lý thể loại tin", "AppCategoryNews" },
                    { 1403, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cập nhật thể loại bài viết", null, "Quản lý thể loại tin", "AppCategoryNews" },
                    { 1404, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xóa thể loại bài viết", null, "Quản lý thể loại tin", "AppCategoryNews" },
                    { 1501, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xem danh sách các chính sách", null, "Quản lý chính sách", "AppPolicy" },
                    { 1502, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Thêm chính sách", null, "Quản lý chính sách", "AppPolicy" },
                    { 1504, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xóa chính sách", null, "Quản lý chính sách", "AppPolicy" },
                    { 1505, "DETAILS", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xem chi tiết chính sách", null, "Quản lý chính sách", "AppPolicy" },
                    { 1601, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xem danh sách các liên hệ", null, "Quản lý liên hệ", "AppContact" },
                    { 1602, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xóa liên hệ", null, "Quản lý liên hệ", "AppContact" },
                    { 1701, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xem danh sách danh mục sản phẩm", null, "Quản lý danh mục sản phẩm", "AppProductCategory" },
                    { 1702, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Thêm danh mục sản phẩm", null, "Quản lý danh mục sản phẩm", "AppProductCategory" },
                    { 1703, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cập nhật danh mục", null, "Quản lý danh mục sản phẩm", "AppProductCategory" },
                    { 1704, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xóa danh mục sản phẩm", null, "Quản lý danh mục sản phẩm", "AppProductCategory" },
                    { 1305, "PUBLIC", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Công khai bài viết", null, "Quản lý tin tức", "AppNews" },
                    { 1304, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xóa bài viết", null, "Quản lý tin tức", "AppNews" },
                    { 1503, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sửa chính sách", null, "Quản lý chính sách", "AppPolicy" },
                    { 1302, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Thêm bài viết", null, "Quản lý tin tức", "AppNews" },
                    { 1303, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cập nhật bài viết", null, "Quản lý tin tức", "AppNews" },
                    { 1103, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Thêm quyền", null, "Quản lý phân quyền", "AppRole" },
                    { 1105, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xóa quyền", null, "Quản lý phân quyền", "AppRole" },
                    { 1104, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sửa quyền", null, "Quản lý phân quyền", "AppRole" },
                    { 1102, "VIEW_DETAIL", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xem chi tiết quyền", null, "Quản lý phân quyền", "AppRole" },
                    { 1006, "BLOCK", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Khóa người dùng", null, "Quản lý người dùng", "AppUser" },
                    { 1003, "CREATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Thêm người dùng", null, "Quản lý người dùng", "AppUser" },
                    { 1008, "DELETE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xóa người dùng", null, "Quản lý người dùng", "AppUser" },
                    { 1101, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xem danh sách quyền", null, "Quản lý phân quyền", "AppRole" },
                    { 1007, "UNBLOCK", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mở khóa người dùng", null, "Quản lý người dùng", "AppUser" },
                    { 1004, "UPDATE", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Cập nhật người dùng", null, "Quản lý người dùng", "AppUser" },
                    { 1005, "UPDATE_PWD", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Đổi mật khẩu", null, "Quản lý người dùng", "AppUser" },
                    { 1002, "VIEW_DETAIL", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xem chi tiết người dùng", null, "Quản lý người dùng", "AppUser" },
                    { 1001, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xem danh sách người dùng", null, "Quản lý người dùng", "AppUser" },
                    { 1205, "MANAGER", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Quản lý file hệ thống", null, "Quản lý file", "FileManager" },
                    { 1301, "VIEW_LIST", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Xem danh sách bài viết", null, "Quản lý tin tức", "AppNews" }
                });

            migrationBuilder.InsertData(
                table: "SysEnv",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "KiotVietClientSecretKey", "" },
                    { "SEOTitle", "" },
                    { "VideoYoutube", "" },
                    { "SecondaryMail", "" },
                    { "PrimaryMail", "" },
                    { "Youtube", "" }
                });

            migrationBuilder.InsertData(
                table: "SysEnv",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "SEODescription", "" },
                    { "KiotVietClientId", "" },
                    { "Logo", "" },
                    { "EmbeddedMap", "" },
                    { "MessengerEmbeddedCode", "" },
                    { "Zalo", "" },
                    { "Facebook", "" },
                    { "BrandPhone", "" },
                    { "BrandAddress", "" },
                    { "BrandName", "" },
                    { "SEOKeyword", "" },
                    { "AdminReciverMail", "" },
                    { "SEOImagePath", "" }
                });

            migrationBuilder.InsertData(
                table: "AppRolePermission",
                columns: new[] { "Id", "AppRoleId", "CreatedBy", "CreatedDate", "DeletedDate", "DisplayOrder", "MstPermissionId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 3, 1, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1103, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1105, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1104, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1102, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1101, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 1, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1006, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1003, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 1, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1008, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 1, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1007, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1004, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1005, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1002, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1001, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 1, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1205, null, new DateTime(2021, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "Address", "AppRoleId", "Avatar", "BlockedBy", "BlockedTo", "CreatedBy", "CreatedDate", "DeletedDate", "DisplayOrder", "Email", "FullName", "PasswordHash", "PasswordSalt", "PhoneNumber1", "PhoneNumber2", "UpdatedBy", "UpdatedDate", "Username" },
                values: new object[,]
                {
                    { 1, "Thành phố Hồ Chí Minh", 1, null, null, null, -1, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "admin_test@gmail.com", "Obama", new byte[] { 188, 83, 213, 160, 196, 30, 244, 72, 238, 224, 3, 99, 77, 4, 48, 188, 108, 139, 130, 172, 93, 172, 251, 251, 16, 194, 105, 115, 1, 135, 121, 77, 112, 184, 222, 5, 210, 3, 211, 16, 148, 13, 218, 192, 150, 194, 228, 115, 211, 121, 25, 203, 70, 50, 161, 40, 130, 117, 116, 156, 40, 141, 208, 27 }, new byte[] { 163, 178, 185, 171, 121, 90, 141, 119, 58, 120, 184, 245, 111, 148, 19, 249, 195, 76, 152, 182, 226, 221, 180, 187, 157, 185, 243, 53, 37, 251, 38, 162, 101, 235, 113, 154, 11, 247, 71, 23, 171, 22, 202, 102, 129, 43, 1, 250, 221, 228, 85, 192, 88, 234, 218, 238, 124, 197, 229, 206, 25, 35, 164, 4, 67, 63, 173, 248, 177, 245, 145, 173, 126, 16, 96, 185, 159, 110, 109, 14, 113, 63, 39, 158, 175, 104, 157, 5, 96, 242, 142, 246, 182, 54, 67, 188, 198, 3, 215, 20, 22, 21, 34, 193, 23, 3, 123, 55, 142, 36, 170, 33, 44, 220, 37, 128, 99, 231, 188, 18, 80, 83, 115, 68, 152, 56, 158, 172 }, "0928666158", "0928666156", -1, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { 2, "Thành phố Hồ Chí Minh", 1, null, null, null, -1, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "thanhnguyendt2000@gmail.com", "Obama", new byte[] { 188, 83, 213, 160, 196, 30, 244, 72, 238, 224, 3, 99, 77, 4, 48, 188, 108, 139, 130, 172, 93, 172, 251, 251, 16, 194, 105, 115, 1, 135, 121, 77, 112, 184, 222, 5, 210, 3, 211, 16, 148, 13, 218, 192, 150, 194, 228, 115, 211, 121, 25, 203, 70, 50, 161, 40, 130, 117, 116, 156, 40, 141, 208, 27 }, new byte[] { 163, 178, 185, 171, 121, 90, 141, 119, 58, 120, 184, 245, 111, 148, 19, 249, 195, 76, 152, 182, 226, 221, 180, 187, 157, 185, 243, 53, 37, 251, 38, 162, 101, 235, 113, 154, 11, 247, 71, 23, 171, 22, 202, 102, 129, 43, 1, 250, 221, 228, 85, 192, 88, 234, 218, 238, 124, 197, 229, 206, 25, 35, 164, 4, 67, 63, 173, 248, 177, 245, 145, 173, 126, 16, 96, 185, 159, 110, 109, 14, 113, 63, 39, 158, 175, 104, 157, 5, 96, 242, 142, 246, 182, 54, 67, 188, 198, 3, 215, 20, 22, 21, 34, 193, 23, 3, 123, 55, 142, 36, 170, 33, 44, 220, 37, 128, 99, 231, 188, 18, 80, 83, 115, 68, 152, 56, 158, 172 }, "0928666157", "0928666158", -1, new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppNews_CategoryId",
                table: "AppNews",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AppNews_UserId",
                table: "AppNews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "uq_slug",
                table: "AppNews",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppPolicy_UserId",
                table: "AppPolicy",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProductCategory_ParentCateId",
                table: "AppProductCategory",
                column: "ParentCateId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_AppRoleId",
                table: "AppRolePermission",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_MstPermissionId",
                table: "AppRolePermission",
                column: "MstPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_AppRoleId",
                table: "AppUser",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_Username",
                table: "AppUser",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppVerifyCode_IdUser",
                table: "AppVerifyCode",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppContact");

            migrationBuilder.DropTable(
                name: "AppNews");

            migrationBuilder.DropTable(
                name: "AppPolicy");

            migrationBuilder.DropTable(
                name: "AppProductCategory");

            migrationBuilder.DropTable(
                name: "AppRolePermission");

            migrationBuilder.DropTable(
                name: "AppVerifyCode");

            migrationBuilder.DropTable(
                name: "SysEnv");

            migrationBuilder.DropTable(
                name: "AppCategoryNews");

            migrationBuilder.DropTable(
                name: "MstPermission");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "AppRole");
        }
    }
}
