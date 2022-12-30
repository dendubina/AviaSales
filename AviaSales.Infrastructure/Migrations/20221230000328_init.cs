using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AviaSales.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plane",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plane", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Locations_FromId",
                        column: x => x.FromId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routes_Locations_ToId",
                        column: x => x.ToId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routes_Plane_PlaneId",
                        column: x => x.PlaneId,
                        principalTable: "Plane",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03c9f600-7b8a-832c-6b08-84e780aadc91"), "Carolside" },
                    { new Guid("052d17a6-8fb5-95fb-075e-d290f39d91fe"), "McGlynnmouth" },
                    { new Guid("09127902-7261-46ce-a6c1-063681635971"), "Heathmouth" },
                    { new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1"), "Mertzville" },
                    { new Guid("1a053781-6433-57af-f547-1ebfbd2bfe3e"), "New Leannehaven" },
                    { new Guid("1a487d75-635c-260c-048e-994bc7e3754b"), "Port Imafurt" },
                    { new Guid("1c685168-a6d6-10c7-3594-1264cfe88c5d"), "Funkton" },
                    { new Guid("204d66c2-5c30-436d-227a-136cc85cdbf1"), "East Rafaelafort" },
                    { new Guid("20a683ad-9e6c-cdac-5b20-17e29fff1684"), "Lubowitzmouth" },
                    { new Guid("213608f2-53eb-fa3c-064a-26cd5eaaa713"), "New Stevehaven" },
                    { new Guid("216c811c-3365-ec83-d9fe-9800686277b1"), "East Tomside" },
                    { new Guid("236db095-f9d4-dfb6-ee3b-935e5aca2f06"), "Kutchbury" },
                    { new Guid("24236ed8-e2af-45ff-95ce-c77cc793f831"), "Hadleyborough" },
                    { new Guid("26d9ff62-1887-9a43-cb94-740d541f22ce"), "Lake Darrel" },
                    { new Guid("289110d0-98b3-a713-2fdd-59bf53f22d95"), "South Velva" },
                    { new Guid("29daecd2-986e-d2ae-09e4-4f50b6bf3fcb"), "Myriamfurt" },
                    { new Guid("2bb1ab03-90f2-27ec-b0e6-7520e2248cde"), "East Jessborough" },
                    { new Guid("2cd53209-d75a-bb49-3d4e-b2bf9136ca6c"), "Schmitthaven" },
                    { new Guid("2f1fa003-a663-e904-080e-9cc152cfdd82"), "Kyliehaven" },
                    { new Guid("316cdda5-4b93-59ed-3196-5b81f60f65e8"), "Wizashire" },
                    { new Guid("32a0e9d6-4031-5a92-8580-8b7ff8f1dc29"), "Stewartport" },
                    { new Guid("36afde81-f203-8bb6-b502-73b908328efc"), "Port Maryamton" },
                    { new Guid("3a697dc0-d59e-9309-f165-e19bdb903e73"), "East Malikaton" },
                    { new Guid("3c52929b-3de6-7026-c31d-7e095c625b2e"), "Rodgerland" },
                    { new Guid("3f8ffa80-028a-08db-78b7-f1e6fe318ef7"), "Brownmouth" },
                    { new Guid("3fa7775f-d4c2-fe4f-29b4-2c90f262a20f"), "Kerlukeville" },
                    { new Guid("40ff80a5-a75c-5baf-5e89-1b06fb442667"), "West Emerson" },
                    { new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717"), "Port Nelson" },
                    { new Guid("49b6227d-c666-e240-0bfc-fb6cefe517c1"), "South Marianeview" },
                    { new Guid("49e7d14c-7d36-e1a7-60c3-2aa25a3093da"), "South Brionnafurt" },
                    { new Guid("49fc59bc-fc35-e2ff-5f0a-ceaf0939b700"), "South Efrainberg" },
                    { new Guid("4cabc058-9ade-47a4-dbf6-e4ed2c99c9c5"), "Dillanview" },
                    { new Guid("4fd05d6c-3951-3e49-377b-1830a850b833"), "Gleichnerland" },
                    { new Guid("5095c31c-f6e4-cda4-abe6-15d0575021c9"), "Lake Ferne" },
                    { new Guid("518ba440-01e9-8225-988e-f7ee72ef1b62"), "Kirlinside" },
                    { new Guid("51dbe856-886e-2eb6-9bc9-4106bac99bf9"), "Spencerside" },
                    { new Guid("534385db-ac40-34cc-aeb2-af5bed37729e"), "Bartontown" },
                    { new Guid("5352ba8c-9e8d-346f-bfff-a8842dc7947f"), "West Danial" },
                    { new Guid("57441913-142a-7fd8-71e3-2b9eefa50eda"), "Whitechester" },
                    { new Guid("58f66ccb-a3c8-a581-680e-7d1154310fc7"), "Baumbachbury" },
                    { new Guid("58fd3a9c-75dd-c357-b3e1-04749f29a7dc"), "West Willis" },
                    { new Guid("5b38d4bc-786e-02d7-9891-07e4e4f0413a"), "Martyville" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5b6aed0b-8d10-48b9-5510-68d91365661a"), "New Anselland" },
                    { new Guid("5f8063e9-390f-3ed6-f20f-028edf2b8e95"), "Port Isom" },
                    { new Guid("5ff50fdd-00de-77e3-9e84-8a017739d1dc"), "Port Adolphusshire" },
                    { new Guid("615db99a-1b12-507b-734f-e2229097f81c"), "Brannonton" },
                    { new Guid("62c15cd1-0fca-5dc0-9a06-55d394a2d898"), "East Julie" },
                    { new Guid("6316f77f-e1be-cacb-716d-8a30ace9436e"), "Adanfurt" },
                    { new Guid("66d4a404-deb4-6b10-633e-fb61165652b5"), "South Bryana" },
                    { new Guid("678d1793-bef0-c597-3e44-711d34d0f3e6"), "South Genoveva" },
                    { new Guid("67b047da-b652-fb14-9e88-e802b652a294"), "Lake Brennaberg" },
                    { new Guid("6ae094dd-0331-6682-b745-30deecc85579"), "New Fletchermouth" },
                    { new Guid("6d6c12e3-4e9a-a2d5-218b-52dda8a12ee0"), "West Adelia" },
                    { new Guid("6e0c5b5e-6e19-824d-7965-bacbc13b7e49"), "Jeramytown" },
                    { new Guid("7108d887-76ee-5bd3-e742-f4ec88a01684"), "West Raphaellefort" },
                    { new Guid("7c38b5dd-68f0-070b-571e-62f20214aac6"), "Lake Jerrellstad" },
                    { new Guid("810a14c6-b7bc-6697-3c28-e03b5092541c"), "Schmidtville" },
                    { new Guid("815becb2-4854-b3f6-1b77-213cc5eee7d2"), "North Amelie" },
                    { new Guid("83f8f41f-7a58-4370-c478-c687d2de44a8"), "Lockmanhaven" },
                    { new Guid("845dba0b-1c3b-15aa-d5db-fc85176ea91c"), "North Nelliechester" },
                    { new Guid("87eef81b-1b62-49b3-ca1f-2af45162dc18"), "Kadeville" },
                    { new Guid("8a4f5c9b-c14d-3923-110b-d614f8c180e7"), "North Garnetburgh" },
                    { new Guid("9056b5bc-f2fc-6ffa-f56a-f5701226825e"), "Erlingchester" },
                    { new Guid("92f94545-ce92-123d-9836-f7b9f4b948bb"), "East Elwin" },
                    { new Guid("963a11e6-b2b5-329f-59ed-b04bedd1bcc0"), "North Alexys" },
                    { new Guid("964de9f9-e59c-63d9-f92b-ecbe6651c609"), "Reingerton" },
                    { new Guid("98e8bef7-2979-89c1-ee55-19a9d64fa775"), "Gaylordview" },
                    { new Guid("9988c5b2-6ac4-b3cf-ee49-952691688933"), "Hyattmouth" },
                    { new Guid("a0c1a772-8d09-7a6a-6994-43e12599c587"), "Starkburgh" },
                    { new Guid("a1747828-9ca1-9463-627b-a071f0553fe6"), "South Xander" },
                    { new Guid("a41c736f-e312-be92-bab2-8b66ba608ea5"), "East Enrico" },
                    { new Guid("a46450b9-7d53-cbbc-b12a-5f40fe56fbf7"), "East Danialstad" },
                    { new Guid("ae29c1b6-3162-e02c-a235-a77369338165"), "Maximilianhaven" },
                    { new Guid("b05bfb04-a734-19d6-600d-b53a74a6a716"), "Bartellton" },
                    { new Guid("b52028ea-9cfd-bdaf-3f49-6b0b069d95c1"), "Schummberg" },
                    { new Guid("b805d93f-4168-a614-c8e2-a48401d53a6a"), "Buckridgefurt" },
                    { new Guid("b93332e1-21e1-85a9-ffd5-81afd50083cb"), "Raeganmouth" },
                    { new Guid("baab63ed-1251-efeb-3db7-7b7eb4163d7c"), "Lucasside" },
                    { new Guid("bc267cd5-ce98-812f-7dfc-e62f3bd1d180"), "Holdenfurt" },
                    { new Guid("be6ac0be-ceb2-8585-4048-9a914dc77d72"), "West Felipa" },
                    { new Guid("bec3b223-ab01-6d60-c952-23cef257312d"), "Grimesfurt" },
                    { new Guid("c60ae875-bcec-c6d2-b190-b11f93bce6e5"), "Dawnside" },
                    { new Guid("c7a466eb-7cc9-1f9e-2c0e-604caeaf9bab"), "Port Archibaldborough" },
                    { new Guid("cb721af5-b1f6-627b-1f02-5836a442b463"), "Emardshire" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d32fe062-0e6b-a9dd-2d43-e3195563abdd"), "Noblefort" },
                    { new Guid("d3eb5f43-d318-8d5d-13be-3d6c53b5c287"), "Greenfort" },
                    { new Guid("d574ecbb-e31b-fbba-f81b-123d28306a6f"), "New Amaliamouth" },
                    { new Guid("d6228bf9-3a5c-8357-ab65-3bdc7306fd24"), "South Fatimaberg" },
                    { new Guid("d7e2bb26-9245-41a8-2d82-b3be3e1b3432"), "Port Nelson" },
                    { new Guid("dab5a148-ee05-99a1-8972-f5f14c284465"), "Lake Selina" },
                    { new Guid("dd76a6ab-7b2e-419e-da37-05f3f12609c7"), "West Meganeport" },
                    { new Guid("df70e319-c4cd-9963-dde7-ad5496c66e77"), "Geraldton" },
                    { new Guid("e0824043-de98-9dfb-6d08-49bfd177c2cc"), "Nicoville" },
                    { new Guid("e1f4bf2b-5b92-2417-30c1-6366da03f928"), "West Margarita" },
                    { new Guid("e8a69852-6982-4bc2-d038-659d7459d2d2"), "East Cornell" },
                    { new Guid("e901d463-5eba-a201-1af6-d52ea3ed1eca"), "Edwinaside" },
                    { new Guid("ed22d346-e5cc-9759-1cce-2b19aa2f8e7e"), "Guillermoburgh" },
                    { new Guid("edc1402a-3370-f890-284b-e9c5ef2b12eb"), "South Fermin" },
                    { new Guid("efbff604-380c-8625-c308-218f15bcd476"), "Ardithfort" },
                    { new Guid("f83d95af-1eb3-3cb0-c3ab-016015fbd6a1"), "West Easton" }
                });

            migrationBuilder.InsertData(
                table: "Plane",
                columns: new[] { "Id", "Model", "SeatsCount" },
                values: new object[,]
                {
                    { new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), "Jaguar Camaro", 37 },
                    { new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), "Honda 911", 46 },
                    { new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), "BMW Colorado", 47 },
                    { new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), "Toyota Colorado", 15 },
                    { new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), "Bugatti 911", 15 },
                    { new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), "Audi ATS", 43 },
                    { new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), "Smart Fiesta", 48 },
                    { new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), "Volvo Focus", 12 },
                    { new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), "Chrysler Countach", 17 },
                    { new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), "Audi Camry", 14 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Apple" },
                    { 2, "Banana" },
                    { 3, "Orange" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Arrival", "Departure", "FromId", "PlaneId", "ToId" },
                values: new object[,]
                {
                    { new Guid("01b2e03e-ced7-fd96-d389-7d7d68eb44db"), new DateTime(2023, 1, 14, 18, 14, 17, 691, DateTimeKind.Local).AddTicks(4181), new DateTime(2023, 1, 14, 14, 53, 39, 419, DateTimeKind.Local).AddTicks(1511), new Guid("d6228bf9-3a5c-8357-ab65-3bdc7306fd24"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("49b6227d-c666-e240-0bfc-fb6cefe517c1") },
                    { new Guid("030e9991-b8ca-17b9-e6b7-2bd5fab54d6e"), new DateTime(2023, 1, 3, 14, 58, 9, 23, DateTimeKind.Local).AddTicks(940), new DateTime(2023, 1, 3, 11, 41, 17, 855, DateTimeKind.Local).AddTicks(4623), new Guid("58fd3a9c-75dd-c357-b3e1-04749f29a7dc"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("26d9ff62-1887-9a43-cb94-740d541f22ce") },
                    { new Guid("09d56cb0-cd9e-d462-2a10-d634125fc56a"), new DateTime(2023, 1, 17, 14, 23, 21, 21, DateTimeKind.Local).AddTicks(3850), new DateTime(2023, 1, 17, 11, 13, 32, 149, DateTimeKind.Local).AddTicks(9347), new Guid("5b6aed0b-8d10-48b9-5510-68d91365661a"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("62c15cd1-0fca-5dc0-9a06-55d394a2d898") },
                    { new Guid("09ed88ff-7adf-c6ac-ef97-6fc64e31c43d"), new DateTime(2023, 1, 20, 12, 27, 36, 339, DateTimeKind.Local).AddTicks(6008), new DateTime(2023, 1, 20, 9, 22, 19, 13, DateTimeKind.Local).AddTicks(5881), new Guid("f83d95af-1eb3-3cb0-c3ab-016015fbd6a1"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), new Guid("810a14c6-b7bc-6697-3c28-e03b5092541c") },
                    { new Guid("154a6e70-7c74-b7eb-6ec8-ad59c2cbc63a"), new DateTime(2023, 1, 11, 18, 17, 46, 870, DateTimeKind.Local).AddTicks(8558), new DateTime(2023, 1, 11, 14, 17, 16, 839, DateTimeKind.Local).AddTicks(259), new Guid("dd76a6ab-7b2e-419e-da37-05f3f12609c7"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), new Guid("678d1793-bef0-c597-3e44-711d34d0f3e6") },
                    { new Guid("15eab8bd-03ef-5d80-6def-e1c9ff88345d"), new DateTime(2023, 1, 22, 8, 53, 58, 125, DateTimeKind.Local).AddTicks(9302), new DateTime(2023, 1, 22, 5, 14, 23, 86, DateTimeKind.Local).AddTicks(4291), new Guid("e0824043-de98-9dfb-6d08-49bfd177c2cc"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1") },
                    { new Guid("1711ac0b-3dc4-a54c-0b78-6d034e215481"), new DateTime(2023, 1, 24, 19, 46, 38, 856, DateTimeKind.Local).AddTicks(8963), new DateTime(2023, 1, 24, 16, 40, 19, 506, DateTimeKind.Local).AddTicks(9429), new Guid("dd76a6ab-7b2e-419e-da37-05f3f12609c7"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("57441913-142a-7fd8-71e3-2b9eefa50eda") },
                    { new Guid("1d500299-1466-461a-188a-23472e134022"), new DateTime(2023, 1, 23, 15, 25, 33, 689, DateTimeKind.Local).AddTicks(8010), new DateTime(2023, 1, 23, 11, 53, 18, 97, DateTimeKind.Local).AddTicks(9166), new Guid("7c38b5dd-68f0-070b-571e-62f20214aac6"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("3a697dc0-d59e-9309-f165-e19bdb903e73") },
                    { new Guid("20252cb7-58ee-505e-c3f0-8a7d6711419c"), new DateTime(2023, 1, 14, 6, 54, 11, 826, DateTimeKind.Local).AddTicks(6890), new DateTime(2023, 1, 14, 2, 57, 54, 534, DateTimeKind.Local).AddTicks(2879), new Guid("edc1402a-3370-f890-284b-e9c5ef2b12eb"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("3fa7775f-d4c2-fe4f-29b4-2c90f262a20f") },
                    { new Guid("2b27d095-2635-e4d2-8930-6fc574e5e3a8"), new DateTime(2023, 1, 27, 0, 34, 4, 25, DateTimeKind.Local).AddTicks(2097), new DateTime(2023, 1, 26, 21, 9, 16, 710, DateTimeKind.Local).AddTicks(3825), new Guid("36afde81-f203-8bb6-b502-73b908328efc"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("40ff80a5-a75c-5baf-5e89-1b06fb442667") },
                    { new Guid("2ec98e27-1561-cef1-bb93-ce8e1ce75c7e"), new DateTime(2023, 1, 14, 14, 45, 59, 99, DateTimeKind.Local).AddTicks(2936), new DateTime(2023, 1, 14, 11, 7, 16, 271, DateTimeKind.Local).AddTicks(3933), new Guid("58fd3a9c-75dd-c357-b3e1-04749f29a7dc"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("213608f2-53eb-fa3c-064a-26cd5eaaa713") },
                    { new Guid("326902de-bede-1a27-7000-0ae6ba87f875"), new DateTime(2023, 1, 20, 3, 41, 32, 363, DateTimeKind.Local).AddTicks(4624), new DateTime(2023, 1, 19, 23, 44, 46, 693, DateTimeKind.Local).AddTicks(1784), new Guid("dab5a148-ee05-99a1-8972-f5f14c284465"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("26d9ff62-1887-9a43-cb94-740d541f22ce") },
                    { new Guid("35b56426-dcbd-341f-4aaf-07d751cd79bb"), new DateTime(2023, 1, 19, 16, 38, 9, 812, DateTimeKind.Local).AddTicks(4901), new DateTime(2023, 1, 19, 13, 32, 42, 172, DateTimeKind.Local).AddTicks(9232), new Guid("92f94545-ce92-123d-9836-f7b9f4b948bb"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("66d4a404-deb4-6b10-633e-fb61165652b5") },
                    { new Guid("35e1f137-925c-94b4-27a3-e4fd3b48e47e"), new DateTime(2023, 1, 4, 16, 24, 40, 898, DateTimeKind.Local).AddTicks(8996), new DateTime(2023, 1, 4, 12, 46, 23, 577, DateTimeKind.Local).AddTicks(9331), new Guid("bc267cd5-ce98-812f-7dfc-e62f3bd1d180"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("964de9f9-e59c-63d9-f92b-ecbe6651c609") },
                    { new Guid("37ca6cdd-34be-39b9-4506-e81d2d1e8613"), new DateTime(2023, 1, 2, 6, 15, 0, 764, DateTimeKind.Local).AddTicks(3111), new DateTime(2023, 1, 2, 2, 53, 30, 132, DateTimeKind.Local).AddTicks(4923), new Guid("2bb1ab03-90f2-27ec-b0e6-7520e2248cde"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), new Guid("efbff604-380c-8625-c308-218f15bcd476") },
                    { new Guid("3a680cfa-f0f5-fe73-a57a-be21b5356fc7"), new DateTime(2023, 1, 23, 8, 9, 50, 912, DateTimeKind.Local).AddTicks(5187), new DateTime(2023, 1, 23, 4, 9, 14, 285, DateTimeKind.Local).AddTicks(1319), new Guid("3fa7775f-d4c2-fe4f-29b4-2c90f262a20f"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), new Guid("5095c31c-f6e4-cda4-abe6-15d0575021c9") },
                    { new Guid("3eee6bf8-9143-9dfc-3fef-d87cecef6057"), new DateTime(2023, 1, 12, 16, 19, 59, 577, DateTimeKind.Local).AddTicks(3571), new DateTime(2023, 1, 12, 13, 1, 48, 976, DateTimeKind.Local).AddTicks(7231), new Guid("6316f77f-e1be-cacb-716d-8a30ace9436e"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1") },
                    { new Guid("401ef71c-5ee2-50e2-bf01-1079a59e47ae"), new DateTime(2023, 1, 28, 5, 10, 20, 130, DateTimeKind.Local).AddTicks(3870), new DateTime(2023, 1, 28, 1, 41, 21, 692, DateTimeKind.Local).AddTicks(1232), new Guid("67b047da-b652-fb14-9e88-e802b652a294"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1") },
                    { new Guid("43a29314-15f7-bae9-2bb9-d79f8f8d1cc0"), new DateTime(2023, 1, 5, 3, 49, 34, 910, DateTimeKind.Local).AddTicks(743), new DateTime(2023, 1, 4, 23, 46, 11, 543, DateTimeKind.Local).AddTicks(276), new Guid("e1f4bf2b-5b92-2417-30c1-6366da03f928"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), new Guid("dd76a6ab-7b2e-419e-da37-05f3f12609c7") },
                    { new Guid("445fc712-f4f3-5cc7-f834-82d43dcd8082"), new DateTime(2023, 1, 17, 14, 21, 28, 549, DateTimeKind.Local).AddTicks(9706), new DateTime(2023, 1, 17, 10, 48, 33, 336, DateTimeKind.Local).AddTicks(3871), new Guid("98e8bef7-2979-89c1-ee55-19a9d64fa775"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), new Guid("289110d0-98b3-a713-2fdd-59bf53f22d95") },
                    { new Guid("44bc790e-0d96-c6f2-7cf0-1ebb46bfbc83"), new DateTime(2022, 12, 31, 0, 17, 25, 776, DateTimeKind.Local).AddTicks(5363), new DateTime(2022, 12, 30, 20, 45, 12, 119, DateTimeKind.Local).AddTicks(9941), new Guid("213608f2-53eb-fa3c-064a-26cd5eaaa713"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("baab63ed-1251-efeb-3db7-7b7eb4163d7c") },
                    { new Guid("499494f1-fa0e-2b8e-473c-4b5a66457502"), new DateTime(2023, 1, 6, 20, 24, 23, 422, DateTimeKind.Local).AddTicks(785), new DateTime(2023, 1, 6, 16, 58, 46, 767, DateTimeKind.Local).AddTicks(5732), new Guid("3c52929b-3de6-7026-c31d-7e095c625b2e"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("b52028ea-9cfd-bdaf-3f49-6b0b069d95c1") },
                    { new Guid("49baac77-421d-3962-679a-73d07215c76a"), new DateTime(2023, 1, 1, 11, 21, 2, 176, DateTimeKind.Local).AddTicks(7408), new DateTime(2023, 1, 1, 8, 14, 47, 302, DateTimeKind.Local).AddTicks(8251), new Guid("cb721af5-b1f6-627b-1f02-5836a442b463"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717") },
                    { new Guid("4d3e96cd-a670-5d64-83eb-36d7e63bf188"), new DateTime(2023, 1, 1, 8, 18, 25, 166, DateTimeKind.Local).AddTicks(1259), new DateTime(2023, 1, 1, 4, 48, 16, 843, DateTimeKind.Local).AddTicks(5448), new Guid("5b6aed0b-8d10-48b9-5510-68d91365661a"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("3a697dc0-d59e-9309-f165-e19bdb903e73") },
                    { new Guid("4eed2d03-bf67-1ebe-c819-598c3362ee84"), new DateTime(2023, 1, 14, 22, 3, 33, 124, DateTimeKind.Local).AddTicks(7495), new DateTime(2023, 1, 14, 18, 3, 15, 483, DateTimeKind.Local).AddTicks(157), new Guid("9988c5b2-6ac4-b3cf-ee49-952691688933"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("92f94545-ce92-123d-9836-f7b9f4b948bb") },
                    { new Guid("50153d18-3bf2-3f74-a39f-26b2b2f42d08"), new DateTime(2023, 1, 18, 20, 47, 1, 897, DateTimeKind.Local).AddTicks(6902), new DateTime(2023, 1, 18, 16, 58, 31, 367, DateTimeKind.Local).AddTicks(5159), new Guid("a0c1a772-8d09-7a6a-6994-43e12599c587"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("b805d93f-4168-a614-c8e2-a48401d53a6a") },
                    { new Guid("584ca306-fa84-5be9-2676-c60e30a9b369"), new DateTime(2023, 1, 15, 2, 16, 20, 676, DateTimeKind.Local).AddTicks(2460), new DateTime(2023, 1, 14, 23, 11, 35, 978, DateTimeKind.Local).AddTicks(8134), new Guid("8a4f5c9b-c14d-3923-110b-d614f8c180e7"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("40ff80a5-a75c-5baf-5e89-1b06fb442667") },
                    { new Guid("58c8f276-ccd2-cd1b-8057-6de74413eaf5"), new DateTime(2023, 1, 11, 10, 23, 59, 510, DateTimeKind.Local).AddTicks(4131), new DateTime(2023, 1, 11, 6, 29, 51, 731, DateTimeKind.Local).AddTicks(1182), new Guid("6d6c12e3-4e9a-a2d5-218b-52dda8a12ee0"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("5095c31c-f6e4-cda4-abe6-15d0575021c9") },
                    { new Guid("59230ac9-f7cf-0db0-23d0-3d437656d72e"), new DateTime(2023, 1, 28, 19, 4, 20, 687, DateTimeKind.Local).AddTicks(5425), new DateTime(2023, 1, 28, 15, 52, 59, 42, DateTimeKind.Local).AddTicks(1151), new Guid("6ae094dd-0331-6682-b745-30deecc85579"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("24236ed8-e2af-45ff-95ce-c77cc793f831") },
                    { new Guid("5a74ae95-09e7-dd4b-8771-316c584dd183"), new DateTime(2023, 1, 18, 23, 26, 39, 224, DateTimeKind.Local).AddTicks(2774), new DateTime(2023, 1, 18, 20, 8, 51, 821, DateTimeKind.Local).AddTicks(266), new Guid("09127902-7261-46ce-a6c1-063681635971"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("a41c736f-e312-be92-bab2-8b66ba608ea5") },
                    { new Guid("61a9e977-a57e-c987-ca94-d7d5ec0c2af7"), new DateTime(2023, 1, 12, 6, 51, 51, 838, DateTimeKind.Local).AddTicks(1048), new DateTime(2023, 1, 12, 3, 33, 0, 516, DateTimeKind.Local).AddTicks(1854), new Guid("ae29c1b6-3162-e02c-a235-a77369338165"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("1c685168-a6d6-10c7-3594-1264cfe88c5d") },
                    { new Guid("626a8234-8d06-7de4-582c-1b4b41fd1ad0"), new DateTime(2023, 1, 14, 16, 29, 16, 373, DateTimeKind.Local).AddTicks(8690), new DateTime(2023, 1, 14, 12, 39, 57, 200, DateTimeKind.Local).AddTicks(4965), new Guid("ed22d346-e5cc-9759-1cce-2b19aa2f8e7e"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), new Guid("d6228bf9-3a5c-8357-ab65-3bdc7306fd24") },
                    { new Guid("69d70a92-28a1-db54-445e-8e512792a31f"), new DateTime(2023, 1, 15, 6, 43, 52, 818, DateTimeKind.Local).AddTicks(5243), new DateTime(2023, 1, 15, 3, 10, 48, 358, DateTimeKind.Local).AddTicks(3255), new Guid("58f66ccb-a3c8-a581-680e-7d1154310fc7"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("d7e2bb26-9245-41a8-2d82-b3be3e1b3432") },
                    { new Guid("6a0b7945-e313-7702-4ff8-04610e643e41"), new DateTime(2023, 1, 21, 3, 51, 33, 340, DateTimeKind.Local).AddTicks(2348), new DateTime(2023, 1, 21, 0, 36, 50, 468, DateTimeKind.Local).AddTicks(3025), new Guid("51dbe856-886e-2eb6-9bc9-4106bac99bf9"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("36afde81-f203-8bb6-b502-73b908328efc") },
                    { new Guid("6a99c2b9-734c-4a9b-11d8-5b9b69712b73"), new DateTime(2023, 1, 28, 11, 51, 58, 862, DateTimeKind.Local).AddTicks(5023), new DateTime(2023, 1, 28, 7, 58, 48, 496, DateTimeKind.Local).AddTicks(5711), new Guid("3c52929b-3de6-7026-c31d-7e095c625b2e"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("a46450b9-7d53-cbbc-b12a-5f40fe56fbf7") },
                    { new Guid("6b047afb-ee8d-0520-fc30-759a630c17af"), new DateTime(2023, 1, 28, 20, 58, 30, 423, DateTimeKind.Local).AddTicks(8916), new DateTime(2023, 1, 28, 17, 16, 47, 742, DateTimeKind.Local).AddTicks(6442), new Guid("ae29c1b6-3162-e02c-a235-a77369338165"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("c60ae875-bcec-c6d2-b190-b11f93bce6e5") },
                    { new Guid("6bb0d151-867a-7c09-a893-be77bc04b909"), new DateTime(2023, 1, 9, 21, 14, 54, 539, DateTimeKind.Local).AddTicks(3789), new DateTime(2023, 1, 9, 17, 18, 51, 186, DateTimeKind.Local).AddTicks(79), new Guid("b05bfb04-a734-19d6-600d-b53a74a6a716"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), new Guid("83f8f41f-7a58-4370-c478-c687d2de44a8") },
                    { new Guid("6bc1671a-1ab2-6d1c-0c83-fab16a1a15ff"), new DateTime(2023, 1, 7, 20, 45, 11, 998, DateTimeKind.Local).AddTicks(1123), new DateTime(2023, 1, 7, 16, 50, 58, 358, DateTimeKind.Local).AddTicks(363), new Guid("09127902-7261-46ce-a6c1-063681635971"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("e1f4bf2b-5b92-2417-30c1-6366da03f928") },
                    { new Guid("6f95b226-4298-5bbe-62a5-ff4b16966a1c"), new DateTime(2023, 1, 16, 16, 31, 51, 676, DateTimeKind.Local).AddTicks(6630), new DateTime(2023, 1, 16, 12, 46, 55, 784, DateTimeKind.Local).AddTicks(5555), new Guid("e901d463-5eba-a201-1af6-d52ea3ed1eca"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("f83d95af-1eb3-3cb0-c3ab-016015fbd6a1") },
                    { new Guid("739bdafd-5a95-4db6-eadb-ea4d62eef73f"), new DateTime(2023, 1, 23, 14, 59, 37, 732, DateTimeKind.Local).AddTicks(8171), new DateTime(2023, 1, 23, 11, 8, 5, 844, DateTimeKind.Local).AddTicks(8872), new Guid("964de9f9-e59c-63d9-f92b-ecbe6651c609"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("49b6227d-c666-e240-0bfc-fb6cefe517c1") },
                    { new Guid("73a53dd8-629e-7eee-db91-8cdc60684b67"), new DateTime(2023, 1, 17, 1, 34, 27, 451, DateTimeKind.Local).AddTicks(5837), new DateTime(2023, 1, 16, 22, 2, 32, 251, DateTimeKind.Local).AddTicks(8107), new Guid("bec3b223-ab01-6d60-c952-23cef257312d"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("ae29c1b6-3162-e02c-a235-a77369338165") },
                    { new Guid("77883dbe-2043-98a1-ef26-c7132db5db84"), new DateTime(2023, 1, 3, 0, 47, 18, 984, DateTimeKind.Local).AddTicks(1560), new DateTime(2023, 1, 2, 20, 55, 38, 940, DateTimeKind.Local).AddTicks(1669), new Guid("a1747828-9ca1-9463-627b-a071f0553fe6"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("3fa7775f-d4c2-fe4f-29b4-2c90f262a20f") }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Arrival", "Departure", "FromId", "PlaneId", "ToId" },
                values: new object[,]
                {
                    { new Guid("798cc9aa-8376-c7e9-07f6-0f241c990120"), new DateTime(2023, 1, 1, 2, 34, 45, 327, DateTimeKind.Local).AddTicks(6353), new DateTime(2022, 12, 31, 23, 26, 7, 935, DateTimeKind.Local).AddTicks(8916), new Guid("f83d95af-1eb3-3cb0-c3ab-016015fbd6a1"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("03c9f600-7b8a-832c-6b08-84e780aadc91") },
                    { new Guid("7a13e967-f1b2-9e6e-b45f-a1204d7e9d4d"), new DateTime(2023, 1, 9, 1, 32, 8, 26, DateTimeKind.Local).AddTicks(9787), new DateTime(2023, 1, 8, 22, 13, 4, 536, DateTimeKind.Local).AddTicks(7595), new Guid("bc267cd5-ce98-812f-7dfc-e62f3bd1d180"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("32a0e9d6-4031-5a92-8580-8b7ff8f1dc29") },
                    { new Guid("7e187b92-5053-ebb7-5616-d2c36e163b6a"), new DateTime(2023, 1, 13, 8, 50, 50, 100, DateTimeKind.Local).AddTicks(8204), new DateTime(2023, 1, 13, 5, 31, 56, 690, DateTimeKind.Local).AddTicks(9275), new Guid("20a683ad-9e6c-cdac-5b20-17e29fff1684"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717") },
                    { new Guid("8257c4da-a58d-186a-c700-e9f0006fc948"), new DateTime(2023, 1, 25, 18, 0, 14, 9, DateTimeKind.Local).AddTicks(2920), new DateTime(2023, 1, 25, 14, 20, 50, 450, DateTimeKind.Local).AddTicks(1433), new Guid("bc267cd5-ce98-812f-7dfc-e62f3bd1d180"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("5352ba8c-9e8d-346f-bfff-a8842dc7947f") },
                    { new Guid("833c5595-d6da-91c2-903a-b93a70717b0e"), new DateTime(2023, 1, 27, 17, 31, 49, 924, DateTimeKind.Local).AddTicks(5799), new DateTime(2023, 1, 27, 14, 23, 41, 539, DateTimeKind.Local).AddTicks(8044), new Guid("845dba0b-1c3b-15aa-d5db-fc85176ea91c"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), new Guid("216c811c-3365-ec83-d9fe-9800686277b1") },
                    { new Guid("864a5955-0325-e16f-a132-6f0c512461dd"), new DateTime(2023, 1, 28, 18, 9, 12, 468, DateTimeKind.Local).AddTicks(4139), new DateTime(2023, 1, 28, 15, 1, 43, 412, DateTimeKind.Local).AddTicks(4149), new Guid("d3eb5f43-d318-8d5d-13be-3d6c53b5c287"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("964de9f9-e59c-63d9-f92b-ecbe6651c609") },
                    { new Guid("8709ee20-967e-7e00-914e-a87a607121ed"), new DateTime(2023, 1, 6, 14, 37, 53, 230, DateTimeKind.Local).AddTicks(8023), new DateTime(2023, 1, 6, 11, 31, 59, 252, DateTimeKind.Local).AddTicks(7610), new Guid("3a697dc0-d59e-9309-f165-e19bdb903e73"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("62c15cd1-0fca-5dc0-9a06-55d394a2d898") },
                    { new Guid("879589cc-3162-29f4-68cb-057f4d5e699e"), new DateTime(2023, 1, 21, 15, 8, 12, 675, DateTimeKind.Local).AddTicks(8493), new DateTime(2023, 1, 21, 11, 34, 14, 466, DateTimeKind.Local).AddTicks(7847), new Guid("09127902-7261-46ce-a6c1-063681635971"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("3c52929b-3de6-7026-c31d-7e095c625b2e") },
                    { new Guid("8953e056-98c6-0d4a-17e5-7a075907d5e2"), new DateTime(2023, 1, 13, 18, 57, 19, 781, DateTimeKind.Local).AddTicks(1376), new DateTime(2023, 1, 13, 15, 44, 58, 61, DateTimeKind.Local).AddTicks(7664), new Guid("f83d95af-1eb3-3cb0-c3ab-016015fbd6a1"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("58f66ccb-a3c8-a581-680e-7d1154310fc7") },
                    { new Guid("8d19ad76-2bfd-19d0-7226-71f018e7e661"), new DateTime(2023, 1, 19, 9, 10, 15, 758, DateTimeKind.Local).AddTicks(5356), new DateTime(2023, 1, 19, 6, 0, 27, 113, DateTimeKind.Local).AddTicks(1356), new Guid("d32fe062-0e6b-a9dd-2d43-e3195563abdd"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("bec3b223-ab01-6d60-c952-23cef257312d") },
                    { new Guid("8da07ed4-1d20-4912-15bf-167aef628b2f"), new DateTime(2023, 1, 4, 6, 0, 30, 942, DateTimeKind.Local).AddTicks(7722), new DateTime(2023, 1, 4, 2, 49, 39, 952, DateTimeKind.Local).AddTicks(800), new Guid("58f66ccb-a3c8-a581-680e-7d1154310fc7"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("edc1402a-3370-f890-284b-e9c5ef2b12eb") },
                    { new Guid("98a70476-b266-55b2-966e-dc91a9c240d2"), new DateTime(2023, 1, 18, 23, 34, 19, 473, DateTimeKind.Local).AddTicks(6872), new DateTime(2023, 1, 18, 20, 6, 32, 739, DateTimeKind.Local).AddTicks(1936), new Guid("5ff50fdd-00de-77e3-9e84-8a017739d1dc"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717") },
                    { new Guid("a05d13ea-a05e-f9dc-ef46-39631df28713"), new DateTime(2023, 1, 22, 3, 42, 53, 351, DateTimeKind.Local).AddTicks(1555), new DateTime(2023, 1, 22, 0, 37, 14, 601, DateTimeKind.Local).AddTicks(9677), new Guid("51dbe856-886e-2eb6-9bc9-4106bac99bf9"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("e8a69852-6982-4bc2-d038-659d7459d2d2") },
                    { new Guid("a1242af1-118c-5177-0898-f054dfca7ca5"), new DateTime(2023, 1, 17, 14, 12, 34, 801, DateTimeKind.Local).AddTicks(5972), new DateTime(2023, 1, 17, 10, 58, 32, 363, DateTimeKind.Local).AddTicks(6102), new Guid("213608f2-53eb-fa3c-064a-26cd5eaaa713"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("8a4f5c9b-c14d-3923-110b-d614f8c180e7") },
                    { new Guid("a3fb72ae-7134-5322-0823-629bee1603d8"), new DateTime(2023, 1, 4, 20, 48, 56, 927, DateTimeKind.Local).AddTicks(9638), new DateTime(2023, 1, 4, 17, 29, 29, 274, DateTimeKind.Local).AddTicks(5880), new Guid("26d9ff62-1887-9a43-cb94-740d541f22ce"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), new Guid("6ae094dd-0331-6682-b745-30deecc85579") },
                    { new Guid("a87108f9-6c51-854d-d608-9a1b91033e12"), new DateTime(2023, 1, 5, 23, 37, 17, 997, DateTimeKind.Local).AddTicks(1299), new DateTime(2023, 1, 5, 20, 29, 23, 468, DateTimeKind.Local).AddTicks(126), new Guid("b805d93f-4168-a614-c8e2-a48401d53a6a"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("7108d887-76ee-5bd3-e742-f4ec88a01684") },
                    { new Guid("a8fe1c1d-91fc-e3f0-8ad8-99bb3a76a597"), new DateTime(2023, 1, 21, 5, 11, 0, 473, DateTimeKind.Local).AddTicks(3785), new DateTime(2023, 1, 21, 1, 27, 45, 60, DateTimeKind.Local).AddTicks(546), new Guid("20a683ad-9e6c-cdac-5b20-17e29fff1684"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("316cdda5-4b93-59ed-3196-5b81f60f65e8") },
                    { new Guid("ac587955-1616-1a09-6538-01bcf0bfa2e1"), new DateTime(2023, 1, 25, 13, 14, 19, 479, DateTimeKind.Local).AddTicks(9553), new DateTime(2023, 1, 25, 9, 12, 42, 602, DateTimeKind.Local).AddTicks(3604), new Guid("815becb2-4854-b3f6-1b77-213cc5eee7d2"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("b05bfb04-a734-19d6-600d-b53a74a6a716") },
                    { new Guid("ae27c4d5-8e7c-4251-45cd-d3119898b013"), new DateTime(2023, 1, 2, 4, 43, 12, 697, DateTimeKind.Local).AddTicks(6976), new DateTime(2023, 1, 2, 1, 8, 27, 298, DateTimeKind.Local).AddTicks(6547), new Guid("2f1fa003-a663-e904-080e-9cc152cfdd82"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("d3eb5f43-d318-8d5d-13be-3d6c53b5c287") },
                    { new Guid("ae6592b8-a677-5e36-4760-17cb26a6367b"), new DateTime(2023, 1, 3, 2, 41, 19, 361, DateTimeKind.Local).AddTicks(2229), new DateTime(2023, 1, 2, 22, 50, 29, 399, DateTimeKind.Local).AddTicks(9875), new Guid("316cdda5-4b93-59ed-3196-5b81f60f65e8"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("49fc59bc-fc35-e2ff-5f0a-ceaf0939b700") },
                    { new Guid("b16729d6-48e1-8e33-56ae-69a5296a65fb"), new DateTime(2023, 1, 21, 18, 54, 48, 168, DateTimeKind.Local).AddTicks(2353), new DateTime(2023, 1, 21, 15, 1, 33, 471, DateTimeKind.Local).AddTicks(2616), new Guid("edc1402a-3370-f890-284b-e9c5ef2b12eb"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("49e7d14c-7d36-e1a7-60c3-2aa25a3093da") },
                    { new Guid("b295cc2e-2e75-487f-e4c8-2c8c448b1126"), new DateTime(2023, 1, 22, 9, 9, 15, 227, DateTimeKind.Local).AddTicks(4728), new DateTime(2023, 1, 22, 5, 54, 30, 628, DateTimeKind.Local).AddTicks(9776), new Guid("518ba440-01e9-8225-988e-f7ee72ef1b62"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1") },
                    { new Guid("ba4c5ec2-1ade-fbdb-6712-86c7939a1ba4"), new DateTime(2023, 1, 15, 3, 9, 3, 393, DateTimeKind.Local).AddTicks(882), new DateTime(2023, 1, 14, 23, 21, 31, 441, DateTimeKind.Local).AddTicks(343), new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1") },
                    { new Guid("bccf13a8-2248-2d82-d615-dfa16fb907d2"), new DateTime(2023, 1, 21, 17, 38, 29, 169, DateTimeKind.Local).AddTicks(4337), new DateTime(2023, 1, 21, 14, 23, 6, 264, DateTimeKind.Local).AddTicks(6654), new Guid("7c38b5dd-68f0-070b-571e-62f20214aac6"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("1a487d75-635c-260c-048e-994bc7e3754b") },
                    { new Guid("bdcf9798-87f4-1721-0a53-c54fdd60379f"), new DateTime(2023, 1, 18, 9, 22, 45, 233, DateTimeKind.Local).AddTicks(2037), new DateTime(2023, 1, 18, 5, 30, 17, 806, DateTimeKind.Local).AddTicks(4711), new Guid("ed22d346-e5cc-9759-1cce-2b19aa2f8e7e"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("a41c736f-e312-be92-bab2-8b66ba608ea5") },
                    { new Guid("bdfc56d6-57e5-067b-1c3a-1d82b6dd5bf8"), new DateTime(2023, 1, 25, 0, 11, 19, 273, DateTimeKind.Local).AddTicks(9406), new DateTime(2023, 1, 24, 20, 54, 59, 104, DateTimeKind.Local).AddTicks(3582), new Guid("d32fe062-0e6b-a9dd-2d43-e3195563abdd"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("289110d0-98b3-a713-2fdd-59bf53f22d95") },
                    { new Guid("c26b0047-5121-1885-3c62-696dd108d66f"), new DateTime(2023, 1, 8, 20, 5, 17, 759, DateTimeKind.Local).AddTicks(425), new DateTime(2023, 1, 8, 16, 10, 14, 892, DateTimeKind.Local).AddTicks(5134), new Guid("8a4f5c9b-c14d-3923-110b-d614f8c180e7"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("d32fe062-0e6b-a9dd-2d43-e3195563abdd") },
                    { new Guid("c2772a5b-d933-26b9-3f11-ca82d5cb2356"), new DateTime(2023, 1, 3, 3, 50, 20, 431, DateTimeKind.Local).AddTicks(3283), new DateTime(2023, 1, 3, 0, 7, 36, 293, DateTimeKind.Local).AddTicks(6090), new Guid("6d6c12e3-4e9a-a2d5-218b-52dda8a12ee0"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("49b6227d-c666-e240-0bfc-fb6cefe517c1") },
                    { new Guid("c4629660-07e2-f891-de89-ba4c99e8528a"), new DateTime(2023, 1, 23, 0, 35, 34, 230, DateTimeKind.Local).AddTicks(174), new DateTime(2023, 1, 22, 20, 55, 5, 39, DateTimeKind.Local).AddTicks(6024), new Guid("e1f4bf2b-5b92-2417-30c1-6366da03f928"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("49fc59bc-fc35-e2ff-5f0a-ceaf0939b700") },
                    { new Guid("c6cf4fee-ffb1-a153-7866-d8eb315ffc0d"), new DateTime(2023, 1, 16, 9, 20, 21, 442, DateTimeKind.Local).AddTicks(8034), new DateTime(2023, 1, 16, 6, 13, 7, 603, DateTimeKind.Local).AddTicks(6993), new Guid("236db095-f9d4-dfb6-ee3b-935e5aca2f06"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("3a697dc0-d59e-9309-f165-e19bdb903e73") },
                    { new Guid("c6e9611c-a9f2-a61a-9de6-ac60f8c66c64"), new DateTime(2023, 1, 15, 20, 1, 21, 71, DateTimeKind.Local).AddTicks(4593), new DateTime(2023, 1, 15, 16, 33, 24, 763, DateTimeKind.Local).AddTicks(3827), new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717") },
                    { new Guid("c71dbfb0-b4e0-84d7-b8a4-2f6eb0a524df"), new DateTime(2023, 1, 1, 11, 20, 27, 953, DateTimeKind.Local).AddTicks(6990), new DateTime(2023, 1, 1, 8, 10, 9, 336, DateTimeKind.Local).AddTicks(6680), new Guid("e901d463-5eba-a201-1af6-d52ea3ed1eca"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("92f94545-ce92-123d-9836-f7b9f4b948bb") },
                    { new Guid("c9216123-d766-5465-5a3e-74f302ac8f9b"), new DateTime(2023, 1, 11, 5, 20, 26, 930, DateTimeKind.Local).AddTicks(2037), new DateTime(2023, 1, 11, 2, 10, 37, 941, DateTimeKind.Local).AddTicks(243), new Guid("1c685168-a6d6-10c7-3594-1264cfe88c5d"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("49fc59bc-fc35-e2ff-5f0a-ceaf0939b700") },
                    { new Guid("cb37ba62-4922-d800-719c-ef1da917e438"), new DateTime(2023, 1, 2, 23, 56, 39, 851, DateTimeKind.Local).AddTicks(2117), new DateTime(2023, 1, 2, 20, 8, 21, 60, DateTimeKind.Local).AddTicks(4766), new Guid("b52028ea-9cfd-bdaf-3f49-6b0b069d95c1"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("58fd3a9c-75dd-c357-b3e1-04749f29a7dc") },
                    { new Guid("cda818ed-8326-a6dc-bd30-361e0a605254"), new DateTime(2023, 1, 6, 15, 58, 1, 18, DateTimeKind.Local).AddTicks(4415), new DateTime(2023, 1, 6, 12, 33, 11, 486, DateTimeKind.Local).AddTicks(3639), new Guid("6e0c5b5e-6e19-824d-7965-bacbc13b7e49"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("a0c1a772-8d09-7a6a-6994-43e12599c587") },
                    { new Guid("d28254dc-008e-72ae-7ca8-29f4a253f9ce"), new DateTime(2023, 1, 16, 21, 10, 44, 15, DateTimeKind.Local).AddTicks(4082), new DateTime(2023, 1, 16, 17, 13, 44, 693, DateTimeKind.Local).AddTicks(4617), new Guid("6d6c12e3-4e9a-a2d5-218b-52dda8a12ee0"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("4fd05d6c-3951-3e49-377b-1830a850b833") },
                    { new Guid("d2b783c9-8fea-0da5-f546-deeace9954c2"), new DateTime(2023, 1, 2, 14, 15, 34, 909, DateTimeKind.Local).AddTicks(3188), new DateTime(2023, 1, 2, 10, 25, 47, 824, DateTimeKind.Local).AddTicks(7453), new Guid("6ae094dd-0331-6682-b745-30deecc85579"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("4fd05d6c-3951-3e49-377b-1830a850b833") },
                    { new Guid("d54ef8f0-6b6e-358a-f603-e928ed4f0850"), new DateTime(2023, 1, 17, 18, 32, 1, 642, DateTimeKind.Local).AddTicks(3888), new DateTime(2023, 1, 17, 15, 7, 4, 4, DateTimeKind.Local).AddTicks(461), new Guid("7c38b5dd-68f0-070b-571e-62f20214aac6"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("3f8ffa80-028a-08db-78b7-f1e6fe318ef7") },
                    { new Guid("d6262411-3f4c-1672-11d2-c1e42024512b"), new DateTime(2023, 1, 8, 23, 19, 52, 39, DateTimeKind.Local).AddTicks(6077), new DateTime(2023, 1, 8, 19, 48, 25, 871, DateTimeKind.Local).AddTicks(4642), new Guid("615db99a-1b12-507b-734f-e2229097f81c"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("213608f2-53eb-fa3c-064a-26cd5eaaa713") },
                    { new Guid("d7812b07-7a91-ab51-6d95-b24c8e3478e2"), new DateTime(2023, 1, 11, 15, 43, 20, 260, DateTimeKind.Local).AddTicks(5923), new DateTime(2023, 1, 11, 11, 44, 46, 310, DateTimeKind.Local).AddTicks(7188), new Guid("e8a69852-6982-4bc2-d038-659d7459d2d2"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("df70e319-c4cd-9963-dde7-ad5496c66e77") },
                    { new Guid("d9b2cc4e-c032-090d-6a08-7c8e0bf346fb"), new DateTime(2023, 1, 1, 19, 17, 57, 223, DateTimeKind.Local).AddTicks(9753), new DateTime(2023, 1, 1, 15, 35, 29, 86, DateTimeKind.Local).AddTicks(7996), new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("9988c5b2-6ac4-b3cf-ee49-952691688933") },
                    { new Guid("dac49789-df84-7623-73dd-8f286137e7c9"), new DateTime(2023, 1, 24, 4, 2, 37, 421, DateTimeKind.Local).AddTicks(4992), new DateTime(2023, 1, 24, 0, 46, 37, 66, DateTimeKind.Local).AddTicks(5915), new Guid("b93332e1-21e1-85a9-ffd5-81afd50083cb"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("36afde81-f203-8bb6-b502-73b908328efc") }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "Arrival", "Departure", "FromId", "PlaneId", "ToId" },
                values: new object[,]
                {
                    { new Guid("de452a89-5a71-151e-d90d-931a82191cbe"), new DateTime(2023, 1, 13, 8, 49, 48, 680, DateTimeKind.Local).AddTicks(4140), new DateTime(2023, 1, 13, 5, 29, 48, 487, DateTimeKind.Local).AddTicks(5496), new Guid("efbff604-380c-8625-c308-218f15bcd476"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("1a053781-6433-57af-f547-1ebfbd2bfe3e") },
                    { new Guid("dfad176a-f7d4-16b3-d535-2ea47d3dea71"), new DateTime(2023, 1, 13, 7, 26, 49, 710, DateTimeKind.Local).AddTicks(5520), new DateTime(2023, 1, 13, 3, 40, 56, 252, DateTimeKind.Local).AddTicks(6981), new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("e1f4bf2b-5b92-2417-30c1-6366da03f928") },
                    { new Guid("e05b1e7e-270e-07af-845c-a0dd170a0597"), new DateTime(2023, 1, 16, 10, 59, 30, 487, DateTimeKind.Local).AddTicks(1340), new DateTime(2023, 1, 16, 7, 39, 29, 61, DateTimeKind.Local).AddTicks(3797), new Guid("83f8f41f-7a58-4370-c478-c687d2de44a8"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), new Guid("b93332e1-21e1-85a9-ffd5-81afd50083cb") },
                    { new Guid("e400bdd4-1982-50ca-4607-f575f4bda7ba"), new DateTime(2023, 1, 2, 12, 23, 33, 781, DateTimeKind.Local).AddTicks(2234), new DateTime(2023, 1, 2, 9, 3, 55, 399, DateTimeKind.Local).AddTicks(7142), new Guid("bec3b223-ab01-6d60-c952-23cef257312d"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("d574ecbb-e31b-fbba-f81b-123d28306a6f") },
                    { new Guid("e480d992-3d80-d59f-a808-1d0b89095725"), new DateTime(2023, 1, 17, 3, 50, 28, 411, DateTimeKind.Local).AddTicks(3407), new DateTime(2023, 1, 17, 0, 30, 11, 72, DateTimeKind.Local).AddTicks(8584), new Guid("24236ed8-e2af-45ff-95ce-c77cc793f831"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("5352ba8c-9e8d-346f-bfff-a8842dc7947f") },
                    { new Guid("e6d88563-890c-9438-4012-5dd3eb6a0e78"), new DateTime(2023, 1, 14, 0, 2, 41, 301, DateTimeKind.Local).AddTicks(6936), new DateTime(2023, 1, 13, 20, 39, 46, 148, DateTimeKind.Local).AddTicks(1016), new Guid("edc1402a-3370-f890-284b-e9c5ef2b12eb"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("4cabc058-9ade-47a4-dbf6-e4ed2c99c9c5") },
                    { new Guid("e87ecc4a-d11c-b5b9-7b94-c53a981fba2b"), new DateTime(2023, 1, 10, 12, 27, 1, 447, DateTimeKind.Local).AddTicks(6415), new DateTime(2023, 1, 10, 8, 40, 22, 378, DateTimeKind.Local).AddTicks(2268), new Guid("b805d93f-4168-a614-c8e2-a48401d53a6a"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("58f66ccb-a3c8-a581-680e-7d1154310fc7") },
                    { new Guid("e9175281-bb5e-ccbb-5dab-af95d9642499"), new DateTime(2023, 1, 11, 20, 5, 1, 285, DateTimeKind.Local).AddTicks(3674), new DateTime(2023, 1, 11, 16, 46, 6, 578, DateTimeKind.Local).AddTicks(3198), new Guid("58fd3a9c-75dd-c357-b3e1-04749f29a7dc"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("df70e319-c4cd-9963-dde7-ad5496c66e77") },
                    { new Guid("ea4a618b-7a83-f547-baae-edd5415c7caf"), new DateTime(2023, 1, 24, 4, 2, 5, 418, DateTimeKind.Local).AddTicks(5680), new DateTime(2023, 1, 24, 0, 3, 5, 537, DateTimeKind.Local).AddTicks(1918), new Guid("5f8063e9-390f-3ed6-f20f-028edf2b8e95"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("5b6aed0b-8d10-48b9-5510-68d91365661a") },
                    { new Guid("f0f445ef-56e3-44ee-dd55-f13862e447f5"), new DateTime(2023, 1, 13, 23, 36, 0, 603, DateTimeKind.Local).AddTicks(6922), new DateTime(2023, 1, 13, 19, 43, 10, 256, DateTimeKind.Local).AddTicks(7617), new Guid("dd76a6ab-7b2e-419e-da37-05f3f12609c7"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("9056b5bc-f2fc-6ffa-f56a-f5701226825e") },
                    { new Guid("f140cc85-1b0d-251a-9ace-1454a488ecff"), new DateTime(2023, 1, 28, 21, 39, 17, 220, DateTimeKind.Local).AddTicks(398), new DateTime(2023, 1, 28, 18, 22, 39, 203, DateTimeKind.Local).AddTicks(5074), new Guid("d3eb5f43-d318-8d5d-13be-3d6c53b5c287"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("a46450b9-7d53-cbbc-b12a-5f40fe56fbf7") },
                    { new Guid("f1807687-275c-2739-c33c-52deeed89c94"), new DateTime(2022, 12, 31, 21, 5, 45, 301, DateTimeKind.Local).AddTicks(7286), new DateTime(2022, 12, 31, 17, 58, 46, 122, DateTimeKind.Local).AddTicks(514), new Guid("9056b5bc-f2fc-6ffa-f56a-f5701226825e"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("7108d887-76ee-5bd3-e742-f4ec88a01684") },
                    { new Guid("f25a5a81-e599-36cd-6b98-89dce5921121"), new DateTime(2023, 1, 23, 20, 1, 41, 600, DateTimeKind.Local).AddTicks(2715), new DateTime(2023, 1, 23, 16, 9, 58, 532, DateTimeKind.Local).AddTicks(4706), new Guid("3a697dc0-d59e-9309-f165-e19bdb903e73"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("32a0e9d6-4031-5a92-8580-8b7ff8f1dc29") },
                    { new Guid("f521ffa9-17b9-2d2f-2df5-cb5e49e1bce5"), new DateTime(2022, 12, 31, 2, 5, 24, 538, DateTimeKind.Local).AddTicks(6134), new DateTime(2022, 12, 30, 22, 22, 52, 618, DateTimeKind.Local).AddTicks(488), new Guid("92f94545-ce92-123d-9836-f7b9f4b948bb"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), new Guid("6d6c12e3-4e9a-a2d5-218b-52dda8a12ee0") },
                    { new Guid("fb9e77d0-7ed3-effa-106b-3a25f59de688"), new DateTime(2023, 1, 23, 7, 45, 14, 972, DateTimeKind.Local).AddTicks(9586), new DateTime(2023, 1, 23, 3, 52, 50, 789, DateTimeKind.Local).AddTicks(214), new Guid("678d1793-bef0-c597-3e44-711d34d0f3e6"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("9056b5bc-f2fc-6ffa-f56a-f5701226825e") },
                    { new Guid("ff4c0ff5-6287-3af1-333f-89d8392abfb7"), new DateTime(2023, 1, 17, 3, 13, 40, 534, DateTimeKind.Local).AddTicks(8832), new DateTime(2023, 1, 16, 23, 41, 17, 71, DateTimeKind.Local).AddTicks(9306), new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("6ae094dd-0331-6682-b745-30deecc85579") }
                });

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
                name: "IX_Locations_Name",
                table: "Locations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_FromId",
                table: "Routes",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_PlaneId",
                table: "Routes",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_ToId",
                table: "Routes",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_OwnerId",
                table: "Tickets",
                column: "OwnerId");
        }

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
                name: "Products");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Plane");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
