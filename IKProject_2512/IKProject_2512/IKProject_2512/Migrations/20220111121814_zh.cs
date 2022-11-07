using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IKProject_2512.Migrations
{
    public partial class zh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyEmployeeModel",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommercialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    JokerValue = table.Column<int>(type: "int", nullable: false),
                    MainCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeMiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackagePeriod = table.Column<int>(type: "int", nullable: false),
                    PackageStartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEmployeeModel", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmanKodu = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DepartmanAdı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Notlar = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmanID);
                });

            migrationBuilder.CreateTable(
                name: "MainCompanies",
                columns: table => new
                {
                    AnaŞirketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnaŞirketAdı = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AnaŞirketTicariÜnvan = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCompanies", x => x.AnaŞirketID);
                });

            migrationBuilder.CreateTable(
                name: "MembershipPackages",
                columns: table => new
                {
                    PaketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaketAdı = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MaksKapasite = table.Column<int>(type: "int", nullable: false),
                    PaketAylıkFiyatı = table.Column<double>(type: "float", nullable: false),
                    FotoDosyaYolu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValue: "badgeDefaultRev0.png"),
                    PaketAktifMi = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipPackages", x => x.PaketID);
                });

            migrationBuilder.CreateTable(
                name: "PlatformManagers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    İkinciAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Soyadı = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MailAdresi = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Parola = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    YeniParola = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false, defaultValue: "user123"),
                    DoğumTarihi = table.Column<DateTime>(type: "date", nullable: true),
                    İşeGirişTarihi = table.Column<DateTime>(type: "date", nullable: false),
                    İştenÇıkışTarihi = table.Column<DateTime>(type: "date", nullable: true),
                    FotoDosyaYolu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValue: "userdefaultfotoRev0.png"),
                    AdresBilgileri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ZamanDamgası = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MailUzantısı = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValue: "@bilgeadamboost.com"),
                    HesapAktifMi = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    HesapAdminMi = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformManagers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SignUpModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LatestPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUpModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CompanyPackages",
                columns: table => new
                {
                    ŞirketPaketiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ÜyelikPaketID = table.Column<int>(type: "int", nullable: false),
                    ÜyelikSüresi = table.Column<int>(type: "int", nullable: false),
                    ÜyelikToplamÜcreti = table.Column<double>(type: "float", nullable: false),
                    ÜyelikBaşlangıçTarihi = table.Column<DateTime>(type: "date", nullable: false),
                    PaketinKalanSüresi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPackages", x => x.ŞirketPaketiID);
                    table.ForeignKey(
                        name: "FK_CompanyPackages_MembershipPackages_ÜyelikPaketID",
                        column: x => x.ÜyelikPaketID,
                        principalTable: "MembershipPackages",
                        principalColumn: "PaketID");
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ŞirketAdı = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ŞirketÜnvanı = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ÇalışanSayısı = table.Column<int>(type: "int", nullable: true),
                    ŞirketTelefonu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ŞirketAdresi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AnaŞirketID = table.Column<int>(type: "int", nullable: true),
                    PlatformYöneticisiID = table.Column<int>(type: "int", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValue: "defaultCompanyRev0.jfif"),
                    MailUzantısı = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyPackageID = table.Column<int>(type: "int", nullable: true),
                    ŞirketAktifMi = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PaketKayıtNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_Companies_CompanyPackages_CompanyPackageID",
                        column: x => x.CompanyPackageID,
                        principalTable: "CompanyPackages",
                        principalColumn: "ŞirketPaketiID");
                    table.ForeignKey(
                        name: "FK_Companies_MainCompanies_AnaŞirketID",
                        column: x => x.AnaŞirketID,
                        principalTable: "MainCompanies",
                        principalColumn: "AnaŞirketID");
                    table.ForeignKey(
                        name: "FK_Companies_PlatformManagers_PlatformYöneticisiID",
                        column: x => x.PlatformYöneticisiID,
                        principalTable: "PlatformManagers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ÇalışanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoDosyaYolu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValue: "userdefaultfotoRev0.png"),
                    HesapYöneticisiMi = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HesapAktifMi = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    Adı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    İkinciAdı = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Soyadı = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DoğumTarihi = table.Column<DateTime>(type: "date", nullable: true),
                    İşeGirişTarihi = table.Column<DateTime>(type: "date", nullable: true),
                    İştenÇıkışTarihi = table.Column<DateTime>(type: "date", nullable: true),
                    Ünvanı = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MailAdresi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    İletişimNumarası = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    İletişimAdresi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Vardiya = table.Column<int>(type: "int", nullable: false),
                    ŞirketID = table.Column<int>(type: "int", nullable: false),
                    Parola = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    YeniParola = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false, defaultValue: "user123"),
                    ZamanDamgası = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MailUzantısı = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ÇalışanID);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_ŞirketID",
                        column: x => x.ŞirketID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID");
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmanID");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmanID", "DepartmanKodu", "DepartmanAdı", "Notlar" },
                values: new object[,]
                {
                    { 1, "IT", "Bilgi İşlem", null },
                    { 2, "Fin", "Finans", null },
                    { 3, "SP", "Satış Pazarlama", null },
                    { 4, "HR", "İnsan Kaynakları", null },
                    { 5, "Opr", "Operasyon", null },
                    { 6, "Exe", "Yönetim", null }
                });

            migrationBuilder.InsertData(
                table: "MembershipPackages",
                columns: new[] { "PaketID", "PaketAktifMi", "PaketAylıkFiyatı", "MaksKapasite", "PaketAdı", "FotoDosyaYolu" },
                values: new object[,]
                {
                    { 1, true, 1000.0, 150, "Başlangıç", "badgeBaslangicRev0.png" },
                    { 2, true, 3000.0, 300, "Silver", "badgeSilverRev0.jfif" },
                    { 3, true, 5000.0, 500, "Gold", "badgeGoldRev0.png" },
                    { 4, true, 8000.0, 2000, "Bronz", "badgeBronzeRev0.jpg" }
                });

            migrationBuilder.InsertData(
                table: "PlatformManagers",
                columns: new[] { "ID", "AdresBilgileri", "DoğumTarihi", "İşeGirişTarihi", "HesapAdminMi", "MailAdresi", "İkinciAdı", "Adı", "Parola", "Soyadı", "İştenÇıkışTarihi" },
                values: new object[] { 1, "Gayrettepe/Beşiktaş", new DateTime(1988, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "gizemyldz01@gmail.com", null, "Gizem", "Gizem123!", "Akalp", null });

            migrationBuilder.CreateIndex(
                name: "INDX_Company_Name",
                table: "Companies",
                column: "ŞirketAdı",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AnaŞirketID",
                table: "Companies",
                column: "AnaŞirketID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyPackageID",
                table: "Companies",
                column: "CompanyPackageID",
                unique: true,
                filter: "[CompanyPackageID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_PlatformYöneticisiID",
                table: "Companies",
                column: "PlatformYöneticisiID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPackages_ÜyelikPaketID",
                table: "CompanyPackages",
                column: "ÜyelikPaketID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employees",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ŞirketID",
                table: "Employees",
                column: "ŞirketID");

            migrationBuilder.CreateIndex(
                name: "INDX_PY_Mail",
                table: "PlatformManagers",
                column: "MailAdresi",
                unique: true,
                filter: "[MailAdresi] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyEmployeeModel");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "SignUpModel");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "CompanyPackages");

            migrationBuilder.DropTable(
                name: "MainCompanies");

            migrationBuilder.DropTable(
                name: "PlatformManagers");

            migrationBuilder.DropTable(
                name: "MembershipPackages");
        }
    }
}
