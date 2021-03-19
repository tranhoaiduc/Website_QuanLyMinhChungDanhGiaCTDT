using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyMinhChungDanhGiaCTDT.EntityFramework.Migrations
{
    public partial class InitialEFDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IDENTITYROLE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDENTITYROLE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IDENTITYROLECLAIMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDENTITYROLECLAIMS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IDENTITYUSER",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    Gender = table.Column<bool>(type: "BIT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DATE", nullable: true),
                    Address = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_IDENTITYUSER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IDENTITYUSERCLAIMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDENTITYUSERCLAIMS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IDENTITYUSERLOGIN",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDENTITYUSERLOGIN", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "IDENTITYUSERROLE",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDENTITYUSERROLE", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "IDENTITYUSERTOKEN",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDENTITYUSERTOKEN", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TIEUCHUAN",
                columns: table => new
                {
                    MaTieuChuan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenTieuChuan = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoHopMinhChung = table.Column<string>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIEUCHUAN", x => x.MaTieuChuan);
                });

            migrationBuilder.CreateTable(
                name: "TIEUCHI",
                columns: table => new
                {
                    MaTieuChi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenTieuChi = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    YeuCauCuaTieuChi = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    MocChuanThamChieuDeDanhGiaTieuChiDatMucBon = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    GoiYNguonMinhChung = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    MaTieuChuan = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIEUCHI", x => x.MaTieuChi);
                    table.ForeignKey(
                        name: "FK_TIEUCHI_TIEUCHUAN_MaTieuChuan",
                        column: x => x.MaTieuChuan,
                        principalTable: "TIEUCHUAN",
                        principalColumn: "MaTieuChuan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MINHCHUNG",
                columns: table => new
                {
                    MaMinhChung = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoKyHieu = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    TrichYeu = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    CoQuanBanHanh = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    NoiNhanCacVanBan = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    NoiLuuBanChinh = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    MucDo = table.Column<int>(type: "INTEGER", nullable: false),
                    NguoiKyVanBan = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    SoPhatHanh = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    LinhVucVanBan = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    LoaiVanBan = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "DATE", nullable: false),
                    NgayLuu = table.Column<DateTime>(type: "DATE", nullable: false),
                    MaNguoiTao = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    MaTieuChi = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaTieuChuan = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MINHCHUNG", x => x.MaMinhChung);
                    table.ForeignKey(
                        name: "FK_MINHCHUNG_TIEUCHI_MaTieuChi",
                        column: x => x.MaTieuChi,
                        principalTable: "TIEUCHI",
                        principalColumn: "MaTieuChi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MINHCHUNG_TIEUCHUAN_MaTieuChuan",
                        column: x => x.MaTieuChuan,
                        principalTable: "TIEUCHUAN",
                        principalColumn: "MaTieuChuan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TEPTIN",
                columns: table => new
                {
                    MaTepTin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenTepTin = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    ThoiGianTao = table.Column<DateTime>(type: "DATE", nullable: false),
                    DuongDan = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    MaTieuChi = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaTieuChuan = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaMinhChung = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEPTIN", x => x.MaTepTin);
                    table.ForeignKey(
                        name: "FK_TEPTIN_MINHCHUNG_MaMinhChung",
                        column: x => x.MaMinhChung,
                        principalTable: "MINHCHUNG",
                        principalColumn: "MaMinhChung",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TEPTIN_TIEUCHI_MaTieuChi",
                        column: x => x.MaTieuChi,
                        principalTable: "TIEUCHI",
                        principalColumn: "MaTieuChi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TEPTIN_TIEUCHUAN_MaTieuChuan",
                        column: x => x.MaTieuChuan,
                        principalTable: "TIEUCHUAN",
                        principalColumn: "MaTieuChuan",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MINHCHUNG_MaTieuChi",
                table: "MINHCHUNG",
                column: "MaTieuChi");

            migrationBuilder.CreateIndex(
                name: "IX_MINHCHUNG_MaTieuChuan",
                table: "MINHCHUNG",
                column: "MaTieuChuan");

            migrationBuilder.CreateIndex(
                name: "IX_TEPTIN_MaMinhChung",
                table: "TEPTIN",
                column: "MaMinhChung");

            migrationBuilder.CreateIndex(
                name: "IX_TEPTIN_MaTieuChi",
                table: "TEPTIN",
                column: "MaTieuChi");

            migrationBuilder.CreateIndex(
                name: "IX_TEPTIN_MaTieuChuan",
                table: "TEPTIN",
                column: "MaTieuChuan");

            migrationBuilder.CreateIndex(
                name: "IX_TIEUCHI_MaTieuChuan",
                table: "TIEUCHI",
                column: "MaTieuChuan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IDENTITYROLE");

            migrationBuilder.DropTable(
                name: "IDENTITYROLECLAIMS");

            migrationBuilder.DropTable(
                name: "IDENTITYUSER");

            migrationBuilder.DropTable(
                name: "IDENTITYUSERCLAIMS");

            migrationBuilder.DropTable(
                name: "IDENTITYUSERLOGIN");

            migrationBuilder.DropTable(
                name: "IDENTITYUSERROLE");

            migrationBuilder.DropTable(
                name: "IDENTITYUSERTOKEN");

            migrationBuilder.DropTable(
                name: "TEPTIN");

            migrationBuilder.DropTable(
                name: "MINHCHUNG");

            migrationBuilder.DropTable(
                name: "TIEUCHI");

            migrationBuilder.DropTable(
                name: "TIEUCHUAN");
        }
    }
}
