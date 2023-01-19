using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrencystamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetroles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedusername = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedemail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    emailconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    passwordhash = table.Column<string>(type: "text", nullable: true),
                    securitystamp = table.Column<string>(type: "text", nullable: true),
                    concurrencystamp = table.Column<string>(type: "text", nullable: true),
                    phonenumber = table.Column<string>(type: "text", nullable: true),
                    phonenumberconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    twofactorenabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockoutend = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockoutenabled = table.Column<bool>(type: "boolean", nullable: false),
                    accessfailedcount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetusers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "planes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    seatscount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_planes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleid = table.Column<Guid>(type: "uuid", nullable: false),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetroleclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_aspnetroleclaims_aspnetroles_roleid",
                        column: x => x.roleid,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    claimtype = table.Column<string>(type: "text", nullable: true),
                    claimvalue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_aspnetuserclaims_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    loginprovider = table.Column<string>(type: "text", nullable: false),
                    providerkey = table.Column<string>(type: "text", nullable: false),
                    providerdisplayname = table.Column<string>(type: "text", nullable: true),
                    userid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserlogins", x => new { x.loginprovider, x.providerkey });
                    table.ForeignKey(
                        name: "fk_aspnetuserlogins_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    roleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserroles", x => new { x.userid, x.roleid });
                    table.ForeignKey(
                        name: "fk_aspnetuserroles_aspnetroles_roleid",
                        column: x => x.roleid,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_aspnetuserroles_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    loginprovider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetusertokens", x => new { x.userid, x.loginprovider, x.name });
                    table.ForeignKey(
                        name: "fk_aspnetusertokens_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "routes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    arrival = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    departure = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    fromid = table.Column<Guid>(type: "uuid", nullable: false),
                    toid = table.Column<Guid>(type: "uuid", nullable: false),
                    planeid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_routes", x => x.id);
                    table.ForeignKey(
                        name: "fk_routes_locations_fromid",
                        column: x => x.fromid,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_routes_locations_toid",
                        column: x => x.toid,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_routes_plane_planeid",
                        column: x => x.planeid,
                        principalTable: "planes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    seatnumber = table.Column<int>(type: "integer", nullable: false),
                    ownerid = table.Column<Guid>(type: "uuid", nullable: false),
                    routeid = table.Column<Guid>(type: "uuid", nullable: false),
                    ticketstatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tickets", x => x.id);
                    table.ForeignKey(
                        name: "fk_tickets_routes_routeid",
                        column: x => x.routeid,
                        principalTable: "routes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tickets_users_ownerid",
                        column: x => x.ownerid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "id", "accessfailedcount", "concurrencystamp", "email", "emailconfirmed", "lockoutenabled", "lockoutend", "normalizedemail", "normalizedusername", "passwordhash", "phonenumber", "phonenumberconfirmed", "securitystamp", "twofactorenabled", "username" },
                values: new object[] { new Guid("557710e6-1b91-4344-8bc4-a75c68a5a165"), 0, "74dcaa9f-9087-4672-b3a0-efca7ffda610", "awestruck31@mail.ru", true, false, null, "AWESTRUCK31@MAIL.RU", "ADMIN", "AQAAAAEAACcQAAAAEInHKhu/LFFZaUOi0JwxLD0ZjL/7Txo3xyE29pm/gzQJxCEykZCpYfrDzr4yXd3Jew==", null, false, "鲧�齾嬖葀왲侞離ꏗ", false, "admin" });

            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "id", "name" },
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
                    { new Guid("5b38d4bc-786e-02d7-9891-07e4e4f0413a"), "Martyville" },
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
                    { new Guid("cb721af5-b1f6-627b-1f02-5836a442b463"), "Emardshire" },
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
                table: "planes",
                columns: new[] { "id", "model", "seatscount" },
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
                table: "routes",
                columns: new[] { "id", "arrival", "departure", "fromid", "planeid", "price", "toid" },
                values: new object[,]
                {
                    { new Guid("031366d1-ed2d-674e-bfbe-1ec819598c33"), new DateTime(2023, 1, 6, 14, 8, 2, 82, DateTimeKind.Utc).AddTicks(230), new DateTime(2023, 1, 6, 14, 0, 28, 565, DateTimeKind.Utc).AddTicks(3), new Guid("bc267cd5-ce98-812f-7dfc-e62f3bd1d180"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), 26.35m, new Guid("dab5a148-ee05-99a1-8972-f5f14c284465") },
                    { new Guid("0759077a-e2d5-6d44-e39b-2867e9137ab2"), new DateTime(2023, 1, 6, 6, 50, 35, 340, DateTimeKind.Utc).AddTicks(7061), new DateTime(2023, 1, 6, 6, 16, 4, 885, DateTimeKind.Utc).AddTicks(748), new Guid("8a4f5c9b-c14d-3923-110b-d614f8c180e7"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), 43.32m, new Guid("a46450b9-7d53-cbbc-b12a-5f40fe56fbf7") },
                    { new Guid("07780e6a-961d-51b8-c983-b7d2ea8fa50d"), new DateTime(2023, 1, 18, 15, 47, 36, 710, DateTimeKind.Utc).AddTicks(7181), new DateTime(2023, 1, 18, 15, 5, 16, 328, DateTimeKind.Utc).AddTicks(869), new Guid("518ba440-01e9-8225-988e-f7ee72ef1b62"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), 52.02m, new Guid("be6ac0be-ceb2-8585-4048-9a914dc77d72") },
                    { new Guid("08a8d59f-0b1d-0989-5725-104eff89203e"), new DateTime(2023, 1, 8, 9, 46, 29, 653, DateTimeKind.Utc).AddTicks(6985), new DateTime(2023, 1, 8, 9, 42, 12, 146, DateTimeKind.Utc).AddTicks(3320), new Guid("a41c736f-e312-be92-bab2-8b66ba608ea5"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), 10.93m, new Guid("5095c31c-f6e4-cda4-abe6-15d0575021c9") },
                    { new Guid("08d16d69-6fd6-11ec-1209-6b557958ac16"), new DateTime(2023, 1, 8, 19, 56, 57, 407, DateTimeKind.Utc).AddTicks(1582), new DateTime(2023, 1, 8, 19, 49, 10, 178, DateTimeKind.Utc).AddTicks(936), new Guid("316cdda5-4b93-59ed-3196-5b81f60f65e8"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), 70.43m, new Guid("58f66ccb-a3c8-a581-680e-7d1154310fc7") },
                    { new Guid("0b794507-136a-02e3-774f-f804610e643e"), new DateTime(2023, 1, 27, 18, 16, 43, 748, DateTimeKind.Utc).AddTicks(264), new DateTime(2023, 1, 26, 18, 19, 25, 672, DateTimeKind.Utc).AddTicks(1982), new Guid("51dbe856-886e-2eb6-9bc9-4106bac99bf9"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), 75.29m, new Guid("36afde81-f203-8bb6-b502-73b908328efc") },
                    { new Guid("0bfb656a-75b7-212c-76f2-c858d2cc1bcd"), new DateTime(2023, 2, 1, 20, 37, 29, 958, DateTimeKind.Utc).AddTicks(2963), new DateTime(2023, 2, 1, 20, 23, 35, 132, DateTimeKind.Utc).AddTicks(9840), new Guid("3a697dc0-d59e-9309-f165-e19bdb903e73"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), 12.08m, new Guid("92f94545-ce92-123d-9836-f7b9f4b948bb") },
                    { new Guid("1001bf50-a579-479e-ae32-518ef0be183d"), new DateTime(2023, 1, 8, 1, 12, 7, 419, DateTimeKind.Utc).AddTicks(4869), new DateTime(2023, 1, 7, 1, 14, 34, 300, DateTimeKind.Utc).AddTicks(6859), new Guid("26d9ff62-1887-9a43-cb94-740d541f22ce"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), 15.28m, new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1") },
                    { new Guid("118ca124-5177-9808-f054-dfca7ca57968"), new DateTime(2023, 1, 17, 14, 35, 40, 467, DateTimeKind.Utc).AddTicks(1539), new DateTime(2023, 1, 17, 14, 5, 17, 412, DateTimeKind.Utc).AddTicks(1618), new Guid("963a11e6-b2b5-329f-59ed-b04bedd1bcc0"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), 60.04m, new Guid("b52028ea-9cfd-bdaf-3f49-6b0b069d95c1") },
                    { new Guid("1192e5dc-f921-3deb-0c51-f620bc0eac83"), new DateTime(2023, 1, 18, 14, 17, 34, 530, DateTimeKind.Utc).AddTicks(8358), new DateTime(2023, 1, 18, 14, 5, 20, 270, DateTimeKind.Utc).AddTicks(4313), new Guid("cb721af5-b1f6-627b-1f02-5836a442b463"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), 48.65m, new Guid("1a053781-6433-57af-f547-1ebfbd2bfe3e") },
                    { new Guid("11a5300f-18ed-cda8-2683-dca6bd30361e"), new DateTime(2023, 1, 12, 20, 8, 16, 561, DateTimeKind.Utc).AddTicks(4823), new DateTime(2023, 1, 11, 20, 8, 20, 98, DateTimeKind.Utc).AddTicks(6110), new Guid("20a683ad-9e6c-cdac-5b20-17e29fff1684"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), 70.13m, new Guid("6d6c12e3-4e9a-a2d5-218b-52dda8a12ee0") },
                    { new Guid("122fb25a-618b-ea4a-837a-47f5baaeedd5"), new DateTime(2023, 1, 18, 6, 49, 12, 954, DateTimeKind.Utc).AddTicks(1802), new DateTime(2023, 1, 18, 6, 36, 18, 516, DateTimeKind.Utc).AddTicks(6581), new Guid("678d1793-bef0-c597-3e44-711d34d0f3e6"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), 45.11m, new Guid("c7a466eb-7cc9-1f9e-2c0e-604caeaf9bab") },
                    { new Guid("1387f21d-0b15-7c3b-fed6-2967b1e14833"), new DateTime(2023, 1, 18, 4, 23, 3, 636, DateTimeKind.Utc).AddTicks(1365), new DateTime(2023, 1, 18, 3, 43, 34, 968, DateTimeKind.Utc).AddTicks(6776), new Guid("236db095-f9d4-dfb6-ee3b-935e5aca2f06"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), 72.58m, new Guid("7108d887-76ee-5bd3-e742-f4ec88a01684") },
                    { new Guid("21612380-66c9-65d7-545a-3e74f302ac8f"), new DateTime(2023, 1, 17, 19, 45, 37, 338, DateTimeKind.Utc).AddTicks(1159), new DateTime(2023, 1, 16, 19, 53, 13, 144, DateTimeKind.Utc).AddTicks(9803), new Guid("1c685168-a6d6-10c7-3594-1264cfe88c5d"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), 1.53m, new Guid("49fc59bc-fc35-e2ff-5f0a-ceaf0939b700") },
                    { new Guid("227134a3-0853-6223-9bee-1603d8aedefc"), new DateTime(2023, 1, 16, 13, 2, 40, 484, DateTimeKind.Utc).AddTicks(2868), new DateTime(2023, 1, 16, 12, 44, 5, 151, DateTimeKind.Utc).AddTicks(8031), new Guid("a41c736f-e312-be92-bab2-8b66ba608ea5"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), 51.97m, new Guid("24236ed8-e2af-45ff-95ce-c77cc793f831") },
                    { new Guid("235760ef-b331-5927-9902-501d66141a46"), new DateTime(2023, 2, 1, 0, 24, 19, 89, DateTimeKind.Utc).AddTicks(9475), new DateTime(2023, 2, 1, 0, 13, 22, 431, DateTimeKind.Utc).AddTicks(8645), new Guid("204d66c2-5c30-436d-227a-136cc85cdbf1"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), 94.98m, new Guid("baab63ed-1251-efeb-3db7-7b7eb4163d7c") },
                    { new Guid("26e30496-b01c-1dbf-c7e0-b4d784b8a42f"), new DateTime(2023, 1, 25, 0, 29, 38, 747, DateTimeKind.Utc).AddTicks(3706), new DateTime(2023, 1, 25, 0, 28, 38, 902, DateTimeKind.Utc).AddTicks(215), new Guid("58fd3a9c-75dd-c357-b3e1-04749f29a7dc"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), 6.23m, new Guid("518ba440-01e9-8225-988e-f7ee72ef1b62") },
                    { new Guid("2739275c-3cc3-de52-eed8-9c946181a6fc"), new DateTime(2023, 1, 21, 22, 22, 55, 604, DateTimeKind.Utc).AddTicks(3046), new DateTime(2023, 1, 21, 21, 51, 29, 317, DateTimeKind.Utc).AddTicks(5329), new Guid("e901d463-5eba-a201-1af6-d52ea3ed1eca"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), 73.08m, new Guid("a1747828-9ca1-9463-627b-a071f0553fe6") },
                    { new Guid("2ad462cd-d610-1234-5fc5-6a7e8473192d"), new DateTime(2023, 1, 15, 15, 34, 1, 622, DateTimeKind.Utc).AddTicks(6052), new DateTime(2023, 1, 15, 15, 11, 22, 378, DateTimeKind.Utc).AddTicks(5607), new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), 60.88m, new Guid("49b6227d-c666-e240-0bfc-fb6cefe517c1") },
                    { new Guid("300ec676-b3a9-db69-584b-6c8947006bc2"), new DateTime(2023, 2, 2, 2, 15, 39, 719, DateTimeKind.Utc).AddTicks(8300), new DateTime(2023, 2, 1, 2, 20, 35, 355, DateTimeKind.Utc).AddTicks(389), new Guid("4fd05d6c-3951-3e49-377b-1830a850b833"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), 27.00m, new Guid("83f8f41f-7a58-4370-c478-c687d2de44a8") },
                    { new Guid("314ec66f-3dc4-14b7-6122-e3815a5af299"), new DateTime(2023, 1, 25, 5, 59, 48, 455, DateTimeKind.Utc).AddTicks(5549), new DateTime(2023, 1, 25, 5, 48, 29, 718, DateTimeKind.Utc).AddTicks(74), new Guid("5095c31c-f6e4-cda4-abe6-15d0575021c9"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), 48.24m, new Guid("6ae094dd-0331-6682-b745-30deecc85579") },
                    { new Guid("34f85cc7-d482-cd3d-8082-d0254cff6c77"), new DateTime(2023, 1, 24, 15, 46, 54, 416, DateTimeKind.Utc).AddTicks(1603), new DateTime(2023, 1, 24, 15, 1, 12, 798, DateTimeKind.Utc).AddTicks(5140), new Guid("d574ecbb-e31b-fbba-f81b-123d28306a6f"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), 16.36m, new Guid("df70e319-c4cd-9963-dde7-ad5496c66e77") },
                    { new Guid("352b27d0-d226-89e4-306f-c574e5e3a8a5"), new DateTime(2023, 2, 1, 5, 10, 20, 434, DateTimeKind.Utc).AddTicks(1300), new DateTime(2023, 2, 1, 4, 50, 37, 341, DateTimeKind.Utc).AddTicks(774), new Guid("49b6227d-c666-e240-0bfc-fb6cefe517c1"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), 36.20m, new Guid("6316f77f-e1be-cacb-716d-8a30ace9436e") },
                    { new Guid("3844cd49-c4da-8257-8da5-6a18c700e9f0"), new DateTime(2023, 1, 20, 15, 33, 54, 428, DateTimeKind.Utc).AddTicks(9771), new DateTime(2023, 1, 20, 15, 31, 4, 563, DateTimeKind.Utc).AddTicks(9873), new Guid("5b6aed0b-8d10-48b9-5510-68d91365661a"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), 86.46m, new Guid("1c685168-a6d6-10c7-3594-1264cfe88c5d") },
                    { new Guid("3af16287-3f33-d889-392a-bfb79fd24598"), new DateTime(2023, 1, 22, 2, 47, 39, 593, DateTimeKind.Utc).AddTicks(3893), new DateTime(2023, 1, 22, 2, 16, 32, 643, DateTimeKind.Utc).AddTicks(5626), new Guid("dab5a148-ee05-99a1-8972-f5f14c284465"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), 99.18m, new Guid("213608f2-53eb-fa3c-064a-26cd5eaaa713") },
                    { new Guid("3dd8aed5-73a5-629e-ee7e-db918cdc6068"), new DateTime(2023, 1, 6, 11, 43, 27, 243, DateTimeKind.Utc).AddTicks(1506), new DateTime(2023, 1, 6, 11, 21, 49, 641, DateTimeKind.Utc).AddTicks(3063), new Guid("83f8f41f-7a58-4370-c478-c687d2de44a8"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), 27.14m, new Guid("bec3b223-ab01-6d60-c952-23cef257312d") },
                    { new Guid("3ff7ee62-130e-dca6-6e63-85d8e60c8938"), new DateTime(2023, 1, 9, 14, 57, 17, 111, DateTimeKind.Utc).AddTicks(3392), new DateTime(2023, 1, 9, 14, 17, 56, 203, DateTimeKind.Utc).AddTicks(5969), new Guid("518ba440-01e9-8225-988e-f7ee72ef1b62"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), 72.16m, new Guid("ed22d346-e5cc-9759-1cce-2b19aa2f8e7e") },
                    { new Guid("4424d621-d4e4-1914-01a3-4ec8f3f3f332"), new DateTime(2023, 1, 16, 2, 34, 43, 484, DateTimeKind.Utc).AddTicks(1538), new DateTime(2023, 1, 16, 2, 9, 48, 65, DateTimeKind.Utc).AddTicks(7101), new Guid("678d1793-bef0-c597-3e44-711d34d0f3e6"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), 99.05m, new Guid("7c38b5dd-68f0-070b-571e-62f20214aac6") },
                    { new Guid("4d38e417-d85c-91c4-c90a-2359cff7b00d"), new DateTime(2023, 1, 5, 15, 45, 35, 202, DateTimeKind.Utc).AddTicks(9881), new DateTime(2023, 1, 5, 15, 36, 43, 25, DateTimeKind.Utc).AddTicks(231), new Guid("36afde81-f203-8bb6-b502-73b908328efc"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), 67.69m, new Guid("289110d0-98b3-a713-2fdd-59bf53f22d95") },
                    { new Guid("4ef8f093-6ed5-8a6b-35f6-03e928ed4f08"), new DateTime(2023, 1, 23, 8, 57, 12, 50, DateTimeKind.Utc).AddTicks(2997), new DateTime(2023, 1, 23, 8, 49, 39, 208, DateTimeKind.Utc).AddTicks(15), new Guid("7c38b5dd-68f0-070b-571e-62f20214aac6"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), 84.56m, new Guid("3f8ffa80-028a-08db-78b7-f1e6fe318ef7") },
                    { new Guid("50ca1982-0746-75f5-f4bd-a7ba3e858493"), new DateTime(2023, 1, 7, 23, 6, 42, 591, DateTimeKind.Utc).AddTicks(3200), new DateTime(2023, 1, 7, 23, 0, 36, 564, DateTimeKind.Utc).AddTicks(8678), new Guid("e8a69852-6982-4bc2-d038-659d7459d2d2"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), 20.45m, new Guid("57441913-142a-7fd8-71e3-2b9eefa50eda") },
                    { new Guid("52537213-cb4f-cc4e-b2d9-32c00d096a08"), new DateTime(2023, 1, 24, 20, 26, 32, 786, DateTimeKind.Utc).AddTicks(2259), new DateTime(2023, 1, 24, 20, 6, 46, 695, DateTimeKind.Utc).AddTicks(2230), new Guid("d3eb5f43-d318-8d5d-13be-3d6c53b5c287"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), 34.52m, new Guid("2bb1ab03-90f2-27ec-b0e6-7520e2248cde") },
                    { new Guid("54e22ed7-355c-d585-c427-ae7c8e514245"), new DateTime(2023, 1, 25, 8, 30, 56, 481, DateTimeKind.Utc).AddTicks(7166), new DateTime(2023, 1, 24, 8, 34, 14, 665, DateTimeKind.Utc).AddTicks(9046), new Guid("3f8ffa80-028a-08db-78b7-f1e6fe318ef7"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), 5.16m, new Guid("052d17a6-8fb5-95fb-075e-d290f39d91fe") },
                    { new Guid("5c35e1f1-b492-2794-a3e4-fd3b48e47e18"), new DateTime(2023, 1, 20, 17, 1, 12, 90, DateTimeKind.Utc).AddTicks(7957), new DateTime(2023, 1, 20, 16, 40, 7, 153, DateTimeKind.Utc).AddTicks(5211), new Guid("4fd05d6c-3951-3e49-377b-1830a850b833"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), 58.47m, new Guid("58fd3a9c-75dd-c357-b3e1-04749f29a7dc") },
                    { new Guid("5ee91752-bbbb-5dcc-abaf-95d964249952"), new DateTime(2023, 1, 18, 18, 3, 49, 864, DateTimeKind.Utc).AddTicks(4477), new DateTime(2023, 1, 18, 17, 48, 36, 715, DateTimeKind.Utc).AddTicks(4513), new Guid("bc267cd5-ce98-812f-7dfc-e62f3bd1d180"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), 26.50m, new Guid("518ba440-01e9-8225-988e-f7ee72ef1b62") },
                    { new Guid("5f6852ab-deca-6902-32de-be271a70000a"), new DateTime(2023, 1, 5, 21, 4, 30, 544, DateTimeKind.Utc).AddTicks(5072), new DateTime(2023, 1, 5, 20, 50, 55, 125, DateTimeKind.Utc).AddTicks(5642), new Guid("1a487d75-635c-260c-048e-994bc7e3754b"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), 18.90m, new Guid("49b6227d-c666-e240-0bfc-fb6cefe517c1") },
                    { new Guid("6a99c2b9-734c-4a9b-11d8-5b9b69712b73"), new DateTime(2023, 1, 29, 18, 0, 13, 772, DateTimeKind.Utc).AddTicks(3840), new DateTime(2023, 1, 29, 17, 20, 45, 57, DateTimeKind.Utc).AddTicks(2581), new Guid("a46450b9-7d53-cbbc-b12a-5f40fe56fbf7"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), 97.38m, new Guid("8a4f5c9b-c14d-3923-110b-d614f8c180e7") },
                    { new Guid("6d1c1ab2-830c-b1fa-6a1a-15ff8e4f787b"), new DateTime(2023, 1, 7, 0, 46, 34, 262, DateTimeKind.Utc).AddTicks(1817), new DateTime(2023, 1, 7, 0, 41, 59, 777, DateTimeKind.Utc).AddTicks(8660), new Guid("d574ecbb-e31b-fbba-f81b-123d28306a6f"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), 17.47m, new Guid("7c38b5dd-68f0-070b-571e-62f20214aac6") },
                    { new Guid("6f032586-a1e1-6f32-0c51-2461dd15c1aa"), new DateTime(2023, 2, 1, 5, 4, 18, 846, DateTimeKind.Utc).AddTicks(7205), new DateTime(2023, 1, 31, 5, 12, 8, 175, DateTimeKind.Utc).AddTicks(6532), new Guid("6316f77f-e1be-cacb-716d-8a30ace9436e"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), 59.29m, new Guid("b805d93f-4168-a614-c8e2-a48401d53a6a") },
                    { new Guid("6f35b521-a4c7-dc87-eed6-0bac1117c43d"), new DateTime(2023, 1, 8, 1, 17, 40, 663, DateTimeKind.Utc).AddTicks(2793), new DateTime(2023, 1, 8, 0, 43, 34, 198, DateTimeKind.Utc).AddTicks(2552), new Guid("58fd3a9c-75dd-c357-b3e1-04749f29a7dc"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), 73.35m, new Guid("3c52929b-3de6-7026-c31d-7e095c625b2e") },
                    { new Guid("7187dd4b-6c31-4d58-d183-1e4273b81089"), new DateTime(2023, 1, 24, 18, 13, 14, 511, DateTimeKind.Utc).AddTicks(7050), new DateTime(2023, 1, 24, 18, 3, 18, 404, DateTimeKind.Utc).AddTicks(6568), new Guid("e1f4bf2b-5b92-2417-30c1-6366da03f928"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), 52.60m, new Guid("d574ecbb-e31b-fbba-f81b-123d28306a6f") },
                    { new Guid("739a6739-72d0-c715-6aea-6e212a71c25e"), new DateTime(2023, 1, 30, 8, 33, 31, 970, DateTimeKind.Utc).AddTicks(1049), new DateTime(2023, 1, 30, 7, 55, 28, 370, DateTimeKind.Utc).AddTicks(5011), new Guid("92f94545-ce92-123d-9836-f7b9f4b948bb"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), 56.93m, new Guid("c7a466eb-7cc9-1f9e-2c0e-604caeaf9bab") },
                    { new Guid("77883dbe-2043-98a1-ef26-c7132db5db84"), new DateTime(2023, 1, 28, 23, 26, 59, 736, DateTimeKind.Utc).AddTicks(8860), new DateTime(2023, 1, 28, 23, 16, 52, 645, DateTimeKind.Utc).AddTicks(6371), new Guid("3fa7775f-d4c2-fe4f-29b4-2c90f262a20f"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), 13.36m, new Guid("6d6c12e3-4e9a-a2d5-218b-52dda8a12ee0") },
                    { new Guid("7a91d781-ab51-956d-b24c-8e3478e2539a"), new DateTime(2023, 1, 19, 11, 33, 41, 718, DateTimeKind.Utc).AddTicks(5420), new DateTime(2023, 1, 19, 11, 17, 36, 304, DateTimeKind.Utc).AddTicks(1553), new Guid("5f8063e9-390f-3ed6-f20f-028edf2b8e95"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), 2.29m, new Guid("67b047da-b652-fb14-9e88-e802b652a294") },
                    { new Guid("7b0e589f-c018-56d6-fcbd-e5577b061c3a"), new DateTime(2023, 1, 27, 19, 33, 39, 664, DateTimeKind.Utc).AddTicks(5971), new DateTime(2023, 1, 27, 19, 4, 15, 907, DateTimeKind.Utc).AddTicks(3456), new Guid("bc267cd5-ce98-812f-7dfc-e62f3bd1d180"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), 46.57m, new Guid("92f94545-ce92-123d-9836-f7b9f4b948bb") },
                    { new Guid("7b36a626-2992-d5ac-2962-ba37cb224900"), new DateTime(2023, 1, 30, 22, 57, 6, 142, DateTimeKind.Utc).AddTicks(4098), new DateTime(2023, 1, 30, 22, 53, 39, 2, DateTimeKind.Utc).AddTicks(5304), new Guid("f83d95af-1eb3-3cb0-c3ab-016015fbd6a1"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), 96.16m, new Guid("5ff50fdd-00de-77e3-9e84-8a017739d1dc") },
                    { new Guid("7c74154a-b7eb-c86e-ad59-c2cbc63a99ac"), new DateTime(2023, 2, 1, 3, 18, 11, 191, DateTimeKind.Utc).AddTicks(4403), new DateTime(2023, 1, 31, 3, 26, 29, 719, DateTimeKind.Utc).AddTicks(9856), new Guid("d6228bf9-3a5c-8357-ab65-3bdc7306fd24"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), 93.47m, new Guid("9988c5b2-6ac4-b3cf-ee49-952691688933") },
                    { new Guid("7cdc209e-57e1-6426-b535-bddc1f344aaf"), new DateTime(2023, 1, 8, 15, 16, 24, 635, DateTimeKind.Utc).AddTicks(3230), new DateTime(2023, 1, 8, 14, 46, 38, 162, DateTimeKind.Utc).AddTicks(9095), new Guid("98e8bef7-2979-89c1-ee55-19a9d64fa775"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), 22.09m, new Guid("f83d95af-1eb3-3cb0-c3ab-016015fbd6a1") },
                    { new Guid("7ceff5ea-a958-986a-97cf-bdf48721170a"), new DateTime(2023, 1, 19, 20, 38, 43, 902, DateTimeKind.Utc).AddTicks(7501), new DateTime(2023, 1, 19, 20, 0, 36, 75, DateTimeKind.Utc).AddTicks(9349), new Guid("963a11e6-b2b5-329f-59ed-b04bedd1bcc0"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), 21.46m, new Guid("be6ac0be-ceb2-8585-4048-9a914dc77d72") },
                    { new Guid("7d89d3fd-687d-44eb-dbfb-8ee90f31dc54"), new DateTime(2023, 1, 9, 23, 44, 49, 55, DateTimeKind.Utc).AddTicks(2460), new DateTime(2023, 1, 8, 23, 57, 46, 936, DateTimeKind.Utc).AddTicks(1111), new Guid("845dba0b-1c3b-15aa-d5db-fc85176ea91c"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), 73.41m, new Guid("29daecd2-986e-d2ae-09e4-4f50b6bf3fcb") },
                    { new Guid("8154214e-fd8b-a7b8-a7f8-6bee3e4391fc"), new DateTime(2023, 1, 27, 9, 23, 35, 515, DateTimeKind.Utc).AddTicks(6009), new DateTime(2023, 1, 27, 9, 10, 13, 156, DateTimeKind.Utc).AddTicks(5808), new Guid("d6228bf9-3a5c-8357-ab65-3bdc7306fd24"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), 22.57m, new Guid("58f66ccb-a3c8-a581-680e-7d1154310fc7") },
                    { new Guid("81d82240-4fac-cc07-8995-876231f42968"), new DateTime(2023, 1, 20, 3, 12, 23, 487, DateTimeKind.Utc).AddTicks(8328), new DateTime(2023, 1, 20, 2, 28, 16, 647, DateTimeKind.Utc).AddTicks(2356), new Guid("b05bfb04-a734-19d6-600d-b53a74a6a716"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), 80.44m, new Guid("6ae094dd-0331-6682-b745-30deecc85579") },
                    { new Guid("835d64a6-36eb-e6d7-3bf1-881b72e95273"), new DateTime(2023, 1, 30, 14, 4, 26, 920, DateTimeKind.Utc).AddTicks(4457), new DateTime(2023, 1, 30, 13, 41, 9, 341, DateTimeKind.Utc).AddTicks(6219), new Guid("5095c31c-f6e4-cda4-abe6-15d0575021c9"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), 36.32m, new Guid("2bb1ab03-90f2-27ec-b0e6-7520e2248cde") },
                    { new Guid("8407af27-a05c-17dd-0a05-978df7297ec3"), new DateTime(2023, 2, 3, 17, 39, 52, 542, DateTimeKind.Utc).AddTicks(8442), new DateTime(2023, 2, 3, 17, 35, 5, 883, DateTimeKind.Utc).AddTicks(7319), new Guid("3c52929b-3de6-7026-c31d-7e095c625b2e"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), 75.67m, new Guid("4cabc058-9ade-47a4-dbf6-e4ed2c99c9c5") },
                    { new Guid("85b0c9a4-40cc-0df1-1b1a-259ace1454a4"), new DateTime(2023, 1, 20, 0, 51, 0, 100, DateTimeKind.Utc).AddTicks(2237), new DateTime(2023, 1, 20, 0, 9, 20, 672, DateTimeKind.Utc).AddTicks(1297), new Guid("62c15cd1-0fca-5dc0-9a06-55d394a2d898"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), 43.62m, new Guid("7c38b5dd-68f0-070b-571e-62f20214aac6") },
                    { new Guid("888cc254-7dd1-aab8-c98c-797683e9c707"), new DateTime(2023, 1, 31, 10, 34, 53, 640, DateTimeKind.Utc).AddTicks(6187), new DateTime(2023, 1, 31, 10, 1, 43, 292, DateTimeKind.Utc).AddTicks(2482), new Guid("ed22d346-e5cc-9759-1cce-2b19aa2f8e7e"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), 48.21m, new Guid("ed22d346-e5cc-9759-1cce-2b19aa2f8e7e") },
                    { new Guid("8adc7122-8dd0-82da-7ae8-cf1719c8bfa8"), new DateTime(2023, 1, 18, 20, 13, 29, 141, DateTimeKind.Utc).AddTicks(8342), new DateTime(2023, 1, 18, 19, 53, 5, 547, DateTimeKind.Utc).AddTicks(7438), new Guid("a1747828-9ca1-9463-627b-a071f0553fe6"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), 31.41m, new Guid("3fa7775f-d4c2-fe4f-29b4-2c90f262a20f") },
                    { new Guid("8af0c350-677d-4111-9c7d-f2b5964b0e79"), new DateTime(2023, 1, 23, 21, 45, 51, 973, DateTimeKind.Utc).AddTicks(2854), new DateTime(2023, 1, 22, 21, 54, 19, 109, DateTimeKind.Utc).AddTicks(8783), new Guid("29daecd2-986e-d2ae-09e4-4f50b6bf3fcb"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), 68.02m, new Guid("a1747828-9ca1-9463-627b-a071f0553fe6") },
                    { new Guid("8f9fd7b9-1c8d-6fc0-f6f0-027176ad198d"), new DateTime(2023, 1, 18, 22, 23, 50, 913, DateTimeKind.Utc).AddTicks(2387), new DateTime(2023, 1, 17, 22, 30, 49, 306, DateTimeKind.Utc).AddTicks(9112), new Guid("bc267cd5-ce98-812f-7dfc-e62f3bd1d180"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), 58.62m, new Guid("b52028ea-9cfd-bdaf-3f49-6b0b069d95c1") },
                    { new Guid("8fdd7376-6128-e737-c9f2-899c1880fb7a"), new DateTime(2023, 1, 10, 23, 0, 43, 147, DateTimeKind.Utc).AddTicks(7567), new DateTime(2023, 1, 10, 22, 44, 27, 240, DateTimeKind.Utc).AddTicks(4678), new Guid("964de9f9-e59c-63d9-f92b-ecbe6651c609"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), 36.37m, new Guid("236db095-f9d4-dfb6-ee3b-935e5aca2f06") },
                    { new Guid("91c2d6da-3a90-3ab9-7071-7b0ee34a24dd"), new DateTime(2023, 1, 13, 20, 11, 49, 559, DateTimeKind.Utc).AddTicks(4130), new DateTime(2023, 1, 13, 19, 53, 17, 731, DateTimeKind.Utc).AddTicks(1443), new Guid("20a683ad-9e6c-cdac-5b20-17e29fff1684"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), 33.48m, new Guid("5b38d4bc-786e-02d7-9891-07e4e4f0413a") },
                    { new Guid("922e7d5a-4516-de95-8f84-fee5e9689fb3"), new DateTime(2023, 2, 1, 13, 58, 0, 96, DateTimeKind.Utc).AddTicks(6966), new DateTime(2023, 1, 31, 13, 58, 23, 159, DateTimeKind.Utc).AddTicks(8010), new Guid("6316f77f-e1be-cacb-716d-8a30ace9436e"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), 7.55m, new Guid("dd76a6ab-7b2e-419e-da37-05f3f12609c7") },
                    { new Guid("92b04828-d70a-a169-2854-db445e8e5127"), new DateTime(2023, 1, 6, 20, 6, 16, 404, DateTimeKind.Utc).AddTicks(671), new DateTime(2023, 1, 6, 19, 43, 29, 712, DateTimeKind.Utc).AddTicks(259), new Guid("5ff50fdd-00de-77e3-9e84-8a017739d1dc"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), 77.63m, new Guid("316cdda5-4b93-59ed-3196-5b81f60f65e8") },
                    { new Guid("9494f1d7-0e49-8efa-2b47-3c4b5a664575"), new DateTime(2023, 1, 12, 10, 49, 33, 829, DateTimeKind.Utc).AddTicks(9391), new DateTime(2023, 1, 12, 10, 41, 21, 971, DateTimeKind.Utc).AddTicks(5034), new Guid("3c52929b-3de6-7026-c31d-7e095c625b2e"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), 39.22m, new Guid("b52028ea-9cfd-bdaf-3f49-6b0b069d95c1") },
                    { new Guid("94cac987-d5d7-0cec-2af7-a4697ba47bb7"), new DateTime(2023, 1, 27, 7, 38, 53, 714, DateTimeKind.Utc).AddTicks(6071), new DateTime(2023, 1, 26, 7, 45, 4, 668, DateTimeKind.Utc).AddTicks(1425), new Guid("67b047da-b652-fb14-9e88-e802b652a294"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), 76.82m, new Guid("8a4f5c9b-c14d-3923-110b-d614f8c180e7") },
                    { new Guid("967e8709-7e00-4e91-a87a-607121ed87ec"), new DateTime(2023, 2, 3, 10, 0, 50, 210, DateTimeKind.Utc).AddTicks(4537), new DateTime(2023, 2, 3, 9, 42, 18, 689, DateTimeKind.Utc).AddTicks(2831), new Guid("052d17a6-8fb5-95fb-075e-d290f39d91fe"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), 95.92m, new Guid("a41c736f-e312-be92-bab2-8b66ba608ea5") },
                    { new Guid("986f95b2-be42-625b-a5ff-4b16966a1c86"), new DateTime(2023, 1, 21, 3, 1, 18, 533, DateTimeKind.Utc).AddTicks(7451), new DateTime(2023, 1, 21, 2, 51, 46, 212, DateTimeKind.Utc).AddTicks(3119), new Guid("ed22d346-e5cc-9759-1cce-2b19aa2f8e7e"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), 69.43m, new Guid("9056b5bc-f2fc-6ffa-f56a-f5701226825e") },
                    { new Guid("9a7530fc-0c63-af17-7f62-2a28671493a2"), new DateTime(2023, 1, 16, 19, 15, 40, 258, DateTimeKind.Utc).AddTicks(2041), new DateTime(2023, 1, 16, 19, 10, 44, 428, DateTimeKind.Utc).AddTicks(4256), new Guid("09127902-7261-46ce-a6c1-063681635971"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), 53.67m, new Guid("5095c31c-f6e4-cda4-abe6-15d0575021c9") },
                    { new Guid("9d7e4d20-044d-855a-c73c-fdda9b73955a"), new DateTime(2023, 1, 15, 15, 23, 11, 139, DateTimeKind.Utc).AddTicks(4442), new DateTime(2023, 1, 15, 14, 56, 13, 69, DateTimeKind.Utc).AddTicks(3473), new Guid("b05bfb04-a734-19d6-600d-b53a74a6a716"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), 2.27m, new Guid("1a053781-6433-57af-f547-1ebfbd2bfe3e") },
                    { new Guid("a2bff0bc-95e1-a862-6342-ea135da05ea0"), new DateTime(2023, 1, 11, 7, 23, 12, 396, DateTimeKind.Utc).AddTicks(8507), new DateTime(2023, 1, 10, 7, 24, 34, 605, DateTimeKind.Utc).AddTicks(7127), new Guid("d7e2bb26-9245-41a8-2d82-b3be3e1b3432"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), 98.18m, new Guid("29daecd2-986e-d2ae-09e4-4f50b6bf3fcb") },
                    { new Guid("b2269fa3-f4b2-082d-956a-e18fc651d1b0"), new DateTime(2023, 1, 29, 8, 53, 5, 906, DateTimeKind.Utc).AddTicks(3976), new DateTime(2023, 1, 28, 9, 5, 19, 604, DateTimeKind.Utc).AddTicks(4679), new Guid("5f8063e9-390f-3ed6-f20f-028edf2b8e95"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), 52.56m, new Guid("d3eb5f43-d318-8d5d-13be-3d6c53b5c287") },
                    { new Guid("b750537e-56eb-d216-c36e-163b6a0989c4"), new DateTime(2023, 1, 12, 22, 38, 39, 365, DateTimeKind.Utc).AddTicks(6150), new DateTime(2023, 1, 12, 21, 57, 23, 610, DateTimeKind.Utc).AddTicks(2379), new Guid("1a053781-6433-57af-f547-1ebfbd2bfe3e"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), 83.58m, new Guid("d6228bf9-3a5c-8357-ab65-3bdc7306fd24") },
                    { new Guid("b8bdac0c-15ea-03ef-805d-6defe1c9ff88"), new DateTime(2023, 1, 23, 13, 5, 6, 813, DateTimeKind.Utc).AddTicks(9881), new DateTime(2023, 1, 23, 12, 32, 53, 224, DateTimeKind.Utc).AddTicks(8070), new Guid("2cd53209-d75a-bb49-3d4e-b2bf9136ca6c"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), 6.78m, new Guid("e0824043-de98-9dfb-6d08-49bfd177c2cc") },
                    { new Guid("b934be37-4539-e806-1d2d-1e86139807c8"), new DateTime(2023, 1, 14, 6, 7, 19, 996, DateTimeKind.Utc).AddTicks(3068), new DateTime(2023, 1, 14, 5, 57, 40, 281, DateTimeKind.Utc).AddTicks(7611), new Guid("6ae094dd-0331-6682-b745-30deecc85579"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), 58.05m, new Guid("815becb2-4854-b3f6-1b77-213cc5eee7d2") },
                    { new Guid("bb1ef07c-bf46-83bc-4190-4c287906a34c"), new DateTime(2023, 1, 11, 20, 4, 19, 571, DateTimeKind.Utc).AddTicks(6985), new DateTime(2023, 1, 11, 19, 43, 33, 588, DateTimeKind.Utc).AddTicks(8426), new Guid("2f1fa003-a663-e904-080e-9cc152cfdd82"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), 29.05m, new Guid("963a11e6-b2b5-329f-59ed-b04bedd1bcc0") },
                    { new Guid("bbcef115-ce93-1c8e-e75c-7e3837d2c7ff"), new DateTime(2023, 1, 11, 13, 58, 8, 689, DateTimeKind.Utc).AddTicks(3112), new DateTime(2023, 1, 10, 14, 1, 41, 110, DateTimeKind.Utc).AddTicks(2992), new Guid("bc267cd5-ce98-812f-7dfc-e62f3bd1d180"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), 38.72m, new Guid("c7a466eb-7cc9-1f9e-2c0e-604caeaf9bab") },
                    { new Guid("bc0b7359-ee45-cf4f-c6b1-ff53a17866d8"), new DateTime(2023, 1, 18, 4, 15, 10, 310, DateTimeKind.Utc).AddTicks(3642), new DateTime(2023, 1, 18, 3, 36, 12, 140, DateTimeKind.Utc).AddTicks(7450), new Guid("5b38d4bc-786e-02d7-9891-07e4e4f0413a"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), 44.65m, new Guid("d32fe062-0e6b-a9dd-2d43-e3195563abdd") },
                    { new Guid("bc77be93-b904-f009-ef22-6e111c61e9c6"), new DateTime(2023, 1, 25, 3, 1, 45, 44, DateTimeKind.Utc).AddTicks(5074), new DateTime(2023, 1, 25, 2, 24, 38, 595, DateTimeKind.Utc).AddTicks(881), new Guid("615db99a-1b12-507b-734f-e2229097f81c"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), 83.29m, new Guid("615db99a-1b12-507b-734f-e2229097f81c") },
                    { new Guid("bccf13a8-2248-2d82-d615-dfa16fb907d2"), new DateTime(2023, 1, 11, 19, 49, 59, 819, DateTimeKind.Utc).AddTicks(5749), new DateTime(2023, 1, 10, 19, 51, 12, 452, DateTimeKind.Utc).AddTicks(279), new Guid("1a487d75-635c-260c-048e-994bc7e3754b"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), 75.16m, new Guid("09127902-7261-46ce-a6c1-063681635971") },
                    { new Guid("c2772a5b-d933-26b9-3f11-ca82d5cb2356"), new DateTime(2023, 1, 24, 12, 6, 41, 712, DateTimeKind.Utc).AddTicks(6055), new DateTime(2023, 1, 24, 12, 6, 0, 62, DateTimeKind.Utc).AddTicks(4917), new Guid("49b6227d-c666-e240-0bfc-fb6cefe517c1"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), 13.80m, new Guid("1c685168-a6d6-10c7-3594-1264cfe88c5d") },
                    { new Guid("c4629660-07e2-f891-de89-ba4c99e8528a"), new DateTime(2023, 1, 23, 9, 23, 13, 898, DateTimeKind.Utc).AddTicks(5322), new DateTime(2023, 1, 23, 9, 6, 38, 161, DateTimeKind.Utc).AddTicks(9246), new Guid("49fc59bc-fc35-e2ff-5f0a-ceaf0939b700"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), 79.36m, new Guid("815becb2-4854-b3f6-1b77-213cc5eee7d2") },
                    { new Guid("c6f860ac-646c-77e4-b56a-c2fa0c683af5"), new DateTime(2023, 1, 29, 2, 18, 56, 524, DateTimeKind.Utc).AddTicks(4256), new DateTime(2023, 1, 29, 1, 49, 34, 902, DateTimeKind.Utc).AddTicks(2990), new Guid("7108d887-76ee-5bd3-e742-f4ec88a01684"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), 73.79m, new Guid("678d1793-bef0-c597-3e44-711d34d0f3e6") },
                    { new Guid("c7861267-9a93-a41b-fad6-b2642391990e"), new DateTime(2023, 1, 29, 23, 22, 28, 992, DateTimeKind.Utc).AddTicks(3346), new DateTime(2023, 1, 29, 22, 58, 52, 817, DateTimeKind.Utc).AddTicks(9007), new Guid("51dbe856-886e-2eb6-9bc9-4106bac99bf9"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), 14.87m, new Guid("3a697dc0-d59e-9309-f165-e19bdb903e73") },
                    { new Guid("cc2ea1e7-b295-2e75-7f48-e4c82c8c448b"), new DateTime(2023, 1, 23, 21, 57, 23, 638, DateTimeKind.Utc).AddTicks(8976), new DateTime(2023, 1, 23, 21, 25, 6, 706, DateTimeKind.Utc).AddTicks(1589), new Guid("66d4a404-deb4-6b10-633e-fb61165652b5"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), 25.09m, new Guid("518ba440-01e9-8225-988e-f7ee72ef1b62") },
                    { new Guid("d2111672-e4c1-2420-512b-dbe44c677b1c"), new DateTime(2023, 1, 20, 8, 38, 49, 652, DateTimeKind.Utc).AddTicks(2373), new DateTime(2023, 1, 20, 8, 27, 13, 313, DateTimeKind.Utc).AddTicks(7413), new Guid("1a053781-6433-57af-f547-1ebfbd2bfe3e"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), 24.23m, new Guid("bec3b223-ab01-6d60-c952-23cef257312d") },
                    { new Guid("d9151e5a-930d-821a-191c-be20599a60c2"), new DateTime(2023, 1, 8, 5, 5, 56, 203, DateTimeKind.Utc).AddTicks(23), new DateTime(2023, 1, 7, 5, 12, 56, 109, DateTimeKind.Utc).AddTicks(8440), new Guid("49e7d14c-7d36-e1a7-60c3-2aa25a3093da"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), 63.75m, new Guid("213608f2-53eb-fa3c-064a-26cd5eaaa713") },
                    { new Guid("e3f0f445-ee56-dd44-55f1-3862e447f5c0"), new DateTime(2023, 2, 2, 0, 42, 54, 429, DateTimeKind.Utc).AddTicks(5092), new DateTime(2023, 2, 2, 0, 23, 42, 38, DateTimeKind.Utc).AddTicks(3103), new Guid("c60ae875-bcec-c6d2-b190-b11f93bce6e5"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), 82.48m, new Guid("62c15cd1-0fca-5dc0-9a06-55d394a2d898") },
                    { new Guid("e48d0662-587d-1b2c-4b41-fd1ad04f5745"), new DateTime(2023, 1, 16, 0, 53, 54, 297, DateTimeKind.Utc).AddTicks(469), new DateTime(2023, 1, 16, 0, 30, 3, 151, DateTimeKind.Utc).AddTicks(4900), new Guid("e901d463-5eba-a201-1af6-d52ea3ed1eca"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), 72.42m, new Guid("4cabc058-9ade-47a4-dbf6-e4ed2c99c9c5") },
                    { new Guid("e49e3a8a-61ec-0545-936e-c2788b14e28e"), new DateTime(2023, 1, 31, 21, 2, 36, 187, DateTimeKind.Utc).AddTicks(4304), new DateTime(2023, 1, 31, 20, 30, 32, 755, DateTimeKind.Utc).AddTicks(7854), new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), 93.46m, new Guid("5352ba8c-9e8d-346f-bfff-a8842dc7947f") },
                    { new Guid("e69df525-b588-e9f9-19a0-b89265ae77a6"), new DateTime(2023, 1, 20, 15, 34, 59, 680, DateTimeKind.Utc).AddTicks(7198), new DateTime(2023, 1, 20, 15, 17, 28, 190, DateTimeKind.Utc).AddTicks(6025), new Guid("3c52929b-3de6-7026-c31d-7e095c625b2e"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), 2.52m, new Guid("e0824043-de98-9dfb-6d08-49bfd177c2cc") },
                    { new Guid("e718f071-61e6-9627-d937-4ad0779efbd3"), new DateTime(2023, 1, 19, 4, 41, 41, 66, DateTimeKind.Utc).AddTicks(7582), new DateTime(2023, 1, 19, 4, 16, 30, 151, DateTimeKind.Utc).AddTicks(2935), new Guid("24236ed8-e2af-45ff-95ce-c77cc793f831"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), 93.78m, new Guid("49fc59bc-fc35-e2ff-5f0a-ceaf0939b700") },
                    { new Guid("ef7a16bf-8b62-2f2f-49cd-e88a56e05389"), new DateTime(2023, 1, 5, 7, 16, 55, 321, DateTimeKind.Utc).AddTicks(3297), new DateTime(2023, 1, 5, 6, 38, 56, 8, DateTimeKind.Utc).AddTicks(8773), new Guid("4cabc058-9ade-47a4-dbf6-e4ed2c99c9c5"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), 61.20m, new Guid("dd76a6ab-7b2e-419e-da37-05f3f12609c7") },
                    { new Guid("f429a87c-53a2-cef9-e3a8-6f08d7d47ea0"), new DateTime(2023, 1, 30, 22, 6, 43, 898, DateTimeKind.Utc).AddTicks(5701), new DateTime(2023, 1, 30, 21, 48, 23, 686, DateTimeKind.Utc).AddTicks(5664), new Guid("e901d463-5eba-a201-1af6-d52ea3ed1eca"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), 65.69m, new Guid("3a697dc0-d59e-9309-f165-e19bdb903e73") },
                    { new Guid("f4d554a5-1c1d-a8fe-fc91-f0e38ad899bb"), new DateTime(2023, 1, 12, 14, 3, 50, 683, DateTimeKind.Utc).AddTicks(9246), new DateTime(2023, 1, 12, 13, 50, 54, 130, DateTimeKind.Utc).AddTicks(4373), new Guid("a1747828-9ca1-9463-627b-a071f0553fe6"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), 80.44m, new Guid("534385db-ac40-34cc-aeb2-af5bed37729e") },
                    { new Guid("f7d4dfad-16b3-35d5-2ea4-7d3dea718ee5"), new DateTime(2023, 1, 20, 3, 12, 51, 657, DateTimeKind.Utc).AddTicks(1702), new DateTime(2023, 1, 20, 2, 37, 18, 887, DateTimeKind.Utc).AddTicks(1191), new Guid("51dbe856-886e-2eb6-9bc9-4106bac99bf9"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), 83.77m, new Guid("6e0c5b5e-6e19-824d-7965-bacbc13b7e49") },
                    { new Guid("f9221420-8792-cc4a-7ee8-1cd1b9b57b94"), new DateTime(2023, 1, 11, 17, 44, 3, 590, DateTimeKind.Utc).AddTicks(2641), new DateTime(2023, 1, 11, 17, 9, 27, 268, DateTimeKind.Utc).AddTicks(5294), new Guid("7c38b5dd-68f0-070b-571e-62f20214aac6"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), 19.86m, new Guid("edc1402a-3370-f890-284b-e9c5ef2b12eb") },
                    { new Guid("f945de9a-76b6-a704-9866-b2b255966edc"), new DateTime(2023, 1, 24, 14, 18, 53, 888, DateTimeKind.Utc).AddTicks(6489), new DateTime(2023, 1, 24, 14, 6, 42, 731, DateTimeKind.Utc).AddTicks(6353), new Guid("615db99a-1b12-507b-734f-e2229097f81c"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), 26.10m, new Guid("b805d93f-4168-a614-c8e2-a48401d53a6a") },
                    { new Guid("f9efe502-7108-51a8-6c4d-85d6089a1b91"), new DateTime(2023, 1, 21, 14, 45, 35, 266, DateTimeKind.Utc).AddTicks(4065), new DateTime(2023, 1, 21, 14, 34, 22, 128, DateTimeKind.Utc).AddTicks(3292), new Guid("e0824043-de98-9dfb-6d08-49bfd177c2cc"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), 80.73m, new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1") },
                    { new Guid("fad52bb7-4db5-8f6e-3e28-873dff88ed09"), new DateTime(2023, 1, 24, 22, 7, 56, 836, DateTimeKind.Utc).AddTicks(200), new DateTime(2023, 1, 24, 21, 50, 23, 868, DateTimeKind.Utc).AddTicks(7538), new Guid("963a11e6-b2b5-329f-59ed-b04bedd1bcc0"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), 4.18m, new Guid("e901d463-5eba-a201-1af6-d52ea3ed1eca") },
                    { new Guid("ffa902bd-f521-17b9-2f2d-2df5cb5e49e1"), new DateTime(2023, 1, 16, 16, 35, 41, 968, DateTimeKind.Utc).AddTicks(6060), new DateTime(2023, 1, 15, 16, 48, 2, 671, DateTimeKind.Utc).AddTicks(9163), new Guid("5b38d4bc-786e-02d7-9891-07e4e4f0413a"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), 42.61m, new Guid("92f94545-ce92-123d-9836-f7b9f4b948bb") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_aspnetroleclaims_roleid",
                table: "AspNetRoleClaims",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalizedname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_aspnetuserclaims_userid",
                table: "AspNetUserClaims",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_aspnetuserlogins_userid",
                table: "AspNetUserLogins",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_aspnetuserroles_roleid",
                table: "AspNetUserRoles",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalizedemail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalizedusername",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_routes_fromid",
                table: "routes",
                column: "fromid");

            migrationBuilder.CreateIndex(
                name: "ix_routes_planeid",
                table: "routes",
                column: "planeid");

            migrationBuilder.CreateIndex(
                name: "ix_routes_toid",
                table: "routes",
                column: "toid");

            migrationBuilder.CreateIndex(
                name: "ix_tickets_ownerid",
                table: "tickets",
                column: "ownerid");

            migrationBuilder.CreateIndex(
                name: "ix_tickets_routeid",
                table: "tickets",
                column: "routeid");
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
                name: "tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "routes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "planes");
        }
    }
}
