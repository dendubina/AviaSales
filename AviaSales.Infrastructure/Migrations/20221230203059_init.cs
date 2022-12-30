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
                name: "tickets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    seatnumber = table.Column<int>(type: "integer", nullable: false),
                    ownerid = table.Column<Guid>(type: "uuid", nullable: false),
                    ticketstatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tickets", x => x.id);
                    table.ForeignKey(
                        name: "fk_tickets_users_ownerid",
                        column: x => x.ownerid,
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "id", "accessfailedcount", "concurrencystamp", "email", "emailconfirmed", "lockoutenabled", "lockoutend", "normalizedemail", "normalizedusername", "passwordhash", "phonenumber", "phonenumberconfirmed", "securitystamp", "twofactorenabled", "username" },
                values: new object[] { new Guid("557710e6-1b91-4344-8bc4-a75c68a5a165"), 0, "7c25c8ba-4845-4b55-a3e6-2acc073cc7a0", "awestruck31@mail.ru", true, false, null, "AWESTRUCK31@MAIL.RU", "ADMIN", "AQAAAAEAACcQAAAAEIzXHLnPMjQ1Rv2kCuagxbqi8eUiOGW6Drjj8jAw9kXhwqpPKeV9iu9DXuz3bffdzA==", null, false, null, false, "admin" });

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
                columns: new[] { "id", "arrival", "departure", "fromid", "planeid", "toid" },
                values: new object[,]
                {
                    { new Guid("01b2e03e-ced7-fd96-d389-7d7d68eb44db"), new DateTime(2023, 1, 16, 8, 9, 21, 138, DateTimeKind.Utc).AddTicks(4050), new DateTime(2023, 1, 15, 8, 21, 11, 142, DateTimeKind.Utc).AddTicks(6445), new Guid("d6228bf9-3a5c-8357-ab65-3bdc7306fd24"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("49b6227d-c666-e240-0bfc-fb6cefe517c1") },
                    { new Guid("030e9991-b8ca-17b9-e6b7-2bd5fab54d6e"), new DateTime(2023, 1, 5, 4, 53, 12, 470, DateTimeKind.Utc).AddTicks(581), new DateTime(2023, 1, 4, 5, 8, 49, 578, DateTimeKind.Utc).AddTicks(9443), new Guid("58fd3a9c-75dd-c357-b3e1-04749f29a7dc"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("26d9ff62-1887-9a43-cb94-740d541f22ce") },
                    { new Guid("09d56cb0-cd9e-d462-2a10-d634125fc56a"), new DateTime(2023, 1, 19, 4, 18, 24, 468, DateTimeKind.Utc).AddTicks(5036), new DateTime(2023, 1, 18, 4, 41, 3, 873, DateTimeKind.Utc).AddTicks(4940), new Guid("5b6aed0b-8d10-48b9-5510-68d91365661a"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("62c15cd1-0fca-5dc0-9a06-55d394a2d898") },
                    { new Guid("09ed88ff-7adf-c6ac-ef97-6fc64e31c43d"), new DateTime(2023, 1, 22, 2, 22, 39, 786, DateTimeKind.Utc).AddTicks(5588), new DateTime(2023, 1, 21, 2, 49, 50, 737, DateTimeKind.Utc).AddTicks(671), new Guid("f83d95af-1eb3-3cb0-c3ab-016015fbd6a1"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), new Guid("810a14c6-b7bc-6697-3c28-e03b5092541c") },
                    { new Guid("154a6e70-7c74-b7eb-6ec8-ad59c2cbc63a"), new DateTime(2023, 1, 12, 8, 12, 50, 317, DateTimeKind.Utc).AddTicks(9487), new DateTime(2023, 1, 12, 7, 44, 48, 562, DateTimeKind.Utc).AddTicks(5723), new Guid("dd76a6ab-7b2e-419e-da37-05f3f12609c7"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), new Guid("678d1793-bef0-c597-3e44-711d34d0f3e6") },
                    { new Guid("15eab8bd-03ef-5d80-6def-e1c9ff88345d"), new DateTime(2023, 1, 22, 22, 49, 1, 572, DateTimeKind.Utc).AddTicks(9064), new DateTime(2023, 1, 22, 22, 41, 54, 809, DateTimeKind.Utc).AddTicks(9172), new Guid("e0824043-de98-9dfb-6d08-49bfd177c2cc"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1") },
                    { new Guid("1711ac0b-3dc4-a54c-0b78-6d034e215481"), new DateTime(2023, 1, 26, 9, 41, 42, 304, DateTimeKind.Utc).AddTicks(63), new DateTime(2023, 1, 25, 10, 7, 51, 230, DateTimeKind.Utc).AddTicks(4979), new Guid("dd76a6ab-7b2e-419e-da37-05f3f12609c7"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("57441913-142a-7fd8-71e3-2b9eefa50eda") },
                    { new Guid("1d500299-1466-461a-188a-23472e134022"), new DateTime(2023, 1, 25, 5, 20, 37, 136, DateTimeKind.Utc).AddTicks(9118), new DateTime(2023, 1, 24, 5, 20, 49, 821, DateTimeKind.Utc).AddTicks(4720), new Guid("7c38b5dd-68f0-070b-571e-62f20214aac6"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("3a697dc0-d59e-9309-f165-e19bdb903e73") },
                    { new Guid("20252cb7-58ee-505e-c3f0-8a7d6711419c"), new DateTime(2023, 1, 14, 20, 49, 15, 273, DateTimeKind.Utc).AddTicks(7698), new DateTime(2023, 1, 14, 20, 25, 26, 257, DateTimeKind.Utc).AddTicks(8283), new Guid("edc1402a-3370-f890-284b-e9c5ef2b12eb"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("3fa7775f-d4c2-fe4f-29b4-2c90f262a20f") },
                    { new Guid("2b27d095-2635-e4d2-8930-6fc574e5e3a8"), new DateTime(2023, 1, 28, 14, 29, 7, 472, DateTimeKind.Utc).AddTicks(3084), new DateTime(2023, 1, 27, 14, 36, 48, 433, DateTimeKind.Utc).AddTicks(9318), new Guid("36afde81-f203-8bb6-b502-73b908328efc"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("40ff80a5-a75c-5baf-5e89-1b06fb442667") },
                    { new Guid("2ec98e27-1561-cef1-bb93-ce8e1ce75c7e"), new DateTime(2023, 1, 15, 4, 41, 2, 546, DateTimeKind.Utc).AddTicks(2564), new DateTime(2023, 1, 15, 4, 34, 47, 994, DateTimeKind.Utc).AddTicks(8747), new Guid("58fd3a9c-75dd-c357-b3e1-04749f29a7dc"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("213608f2-53eb-fa3c-064a-26cd5eaaa713") },
                    { new Guid("326902de-bede-1a27-7000-0ae6ba87f875"), new DateTime(2023, 1, 20, 17, 36, 35, 810, DateTimeKind.Utc).AddTicks(5598), new DateTime(2023, 1, 20, 17, 12, 18, 416, DateTimeKind.Utc).AddTicks(7271), new Guid("dab5a148-ee05-99a1-8972-f5f14c284465"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("26d9ff62-1887-9a43-cb94-740d541f22ce") },
                    { new Guid("35b56426-dcbd-341f-4aaf-07d751cd79bb"), new DateTime(2023, 1, 21, 6, 33, 13, 259, DateTimeKind.Utc).AddTicks(5865), new DateTime(2023, 1, 20, 7, 0, 13, 896, DateTimeKind.Utc).AddTicks(4714), new Guid("92f94545-ce92-123d-9836-f7b9f4b948bb"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("66d4a404-deb4-6b10-633e-fb61165652b5") },
                    { new Guid("35e1f137-925c-94b4-27a3-e4fd3b48e47e"), new DateTime(2023, 1, 5, 6, 19, 44, 345, DateTimeKind.Utc).AddTicks(9854), new DateTime(2023, 1, 5, 6, 13, 55, 301, DateTimeKind.Utc).AddTicks(4760), new Guid("bc267cd5-ce98-812f-7dfc-e62f3bd1d180"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("964de9f9-e59c-63d9-f92b-ecbe6651c609") },
                    { new Guid("37ca6cdd-34be-39b9-4506-e81d2d1e8613"), new DateTime(2023, 1, 3, 20, 10, 4, 211, DateTimeKind.Utc).AddTicks(2747), new DateTime(2023, 1, 2, 20, 21, 1, 855, DateTimeKind.Utc).AddTicks(9741), new Guid("2bb1ab03-90f2-27ec-b0e6-7520e2248cde"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), new Guid("efbff604-380c-8625-c308-218f15bcd476") },
                    { new Guid("3a680cfa-f0f5-fe73-a57a-be21b5356fc7"), new DateTime(2023, 1, 23, 22, 4, 54, 359, DateTimeKind.Utc).AddTicks(6291), new DateTime(2023, 1, 23, 21, 36, 46, 8, DateTimeKind.Utc).AddTicks(6871), new Guid("3fa7775f-d4c2-fe4f-29b4-2c90f262a20f"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), new Guid("5095c31c-f6e4-cda4-abe6-15d0575021c9") },
                    { new Guid("3eee6bf8-9143-9dfc-3fef-d87cecef6057"), new DateTime(2023, 1, 14, 6, 15, 3, 24, DateTimeKind.Utc).AddTicks(4671), new DateTime(2023, 1, 13, 6, 29, 20, 700, DateTimeKind.Utc).AddTicks(2781), new Guid("6316f77f-e1be-cacb-716d-8a30ace9436e"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1") },
                    { new Guid("401ef71c-5ee2-50e2-bf01-1079a59e47ae"), new DateTime(2023, 1, 29, 19, 5, 23, 577, DateTimeKind.Utc).AddTicks(4998), new DateTime(2023, 1, 28, 19, 8, 53, 415, DateTimeKind.Utc).AddTicks(6796), new Guid("67b047da-b652-fb14-9e88-e802b652a294"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1") },
                    { new Guid("43a29314-15f7-bae9-2bb9-d79f8f8d1cc0"), new DateTime(2023, 1, 5, 17, 44, 38, 357, DateTimeKind.Utc).AddTicks(1787), new DateTime(2023, 1, 5, 17, 13, 43, 266, DateTimeKind.Utc).AddTicks(5798), new Guid("e1f4bf2b-5b92-2417-30c1-6366da03f928"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), new Guid("dd76a6ab-7b2e-419e-da37-05f3f12609c7") },
                    { new Guid("445fc712-f4f3-5cc7-f834-82d43dcd8082"), new DateTime(2023, 1, 18, 4, 16, 31, 996, DateTimeKind.Utc).AddTicks(9376), new DateTime(2023, 1, 18, 4, 16, 5, 59, DateTimeKind.Utc).AddTicks(8706), new Guid("98e8bef7-2979-89c1-ee55-19a9d64fa775"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), new Guid("289110d0-98b3-a713-2fdd-59bf53f22d95") },
                    { new Guid("44bc790e-0d96-c6f2-7cf0-1ebb46bfbc83"), new DateTime(2023, 1, 1, 14, 12, 29, 223, DateTimeKind.Utc).AddTicks(6049), new DateTime(2022, 12, 31, 14, 12, 43, 843, DateTimeKind.Utc).AddTicks(5284), new Guid("213608f2-53eb-fa3c-064a-26cd5eaaa713"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("baab63ed-1251-efeb-3db7-7b7eb4163d7c") },
                    { new Guid("499494f1-fa0e-2b8e-473c-4b5a66457502"), new DateTime(2023, 1, 8, 10, 19, 26, 869, DateTimeKind.Utc).AddTicks(483), new DateTime(2023, 1, 7, 10, 26, 18, 491, DateTimeKind.Utc).AddTicks(581), new Guid("3c52929b-3de6-7026-c31d-7e095c625b2e"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("b52028ea-9cfd-bdaf-3f49-6b0b069d95c1") },
                    { new Guid("49baac77-421d-3962-679a-73d07215c76a"), new DateTime(2023, 1, 3, 1, 16, 5, 623, DateTimeKind.Utc).AddTicks(7012), new DateTime(2023, 1, 2, 1, 42, 19, 26, DateTimeKind.Utc).AddTicks(3053), new Guid("cb721af5-b1f6-627b-1f02-5836a442b463"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717") },
                    { new Guid("4d3e96cd-a670-5d64-83eb-36d7e63bf188"), new DateTime(2023, 1, 2, 22, 13, 28, 613, DateTimeKind.Utc).AddTicks(2360), new DateTime(2023, 1, 1, 22, 15, 48, 567, DateTimeKind.Utc).AddTicks(998), new Guid("5b6aed0b-8d10-48b9-5510-68d91365661a"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("3a697dc0-d59e-9309-f165-e19bdb903e73") },
                    { new Guid("4eed2d03-bf67-1ebe-c819-598c3362ee84"), new DateTime(2023, 1, 15, 11, 58, 36, 571, DateTimeKind.Utc).AddTicks(7207), new DateTime(2023, 1, 15, 11, 30, 47, 206, DateTimeKind.Utc).AddTicks(5013), new Guid("9988c5b2-6ac4-b3cf-ee49-952691688933"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("92f94545-ce92-123d-9836-f7b9f4b948bb") },
                    { new Guid("50153d18-3bf2-3f74-a39f-26b2b2f42d08"), new DateTime(2023, 1, 19, 10, 42, 5, 344, DateTimeKind.Utc).AddTicks(8028), new DateTime(2023, 1, 19, 10, 26, 3, 91, DateTimeKind.Utc).AddTicks(722), new Guid("a0c1a772-8d09-7a6a-6994-43e12599c587"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("b805d93f-4168-a614-c8e2-a48401d53a6a") },
                    { new Guid("584ca306-fa84-5be9-2676-c60e30a9b369"), new DateTime(2023, 1, 16, 16, 11, 24, 123, DateTimeKind.Utc).AddTicks(3188), new DateTime(2023, 1, 15, 16, 39, 7, 702, DateTimeKind.Utc).AddTicks(3498), new Guid("8a4f5c9b-c14d-3923-110b-d614f8c180e7"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("40ff80a5-a75c-5baf-5e89-1b06fb442667") },
                    { new Guid("58c8f276-ccd2-cd1b-8057-6de74413eaf5"), new DateTime(2023, 1, 12, 0, 19, 2, 957, DateTimeKind.Utc).AddTicks(4825), new DateTime(2023, 1, 11, 23, 57, 23, 454, DateTimeKind.Utc).AddTicks(6529), new Guid("6d6c12e3-4e9a-a2d5-218b-52dda8a12ee0"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("5095c31c-f6e4-cda4-abe6-15d0575021c9") },
                    { new Guid("59230ac9-f7cf-0db0-23d0-3d437656d72e"), new DateTime(2023, 1, 30, 8, 59, 24, 134, DateTimeKind.Utc).AddTicks(6363), new DateTime(2023, 1, 29, 9, 20, 30, 765, DateTimeKind.Utc).AddTicks(6620), new Guid("6ae094dd-0331-6682-b745-30deecc85579"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("24236ed8-e2af-45ff-95ce-c77cc793f831") },
                    { new Guid("5a74ae95-09e7-dd4b-8771-316c584dd183"), new DateTime(2023, 1, 20, 13, 21, 42, 671, DateTimeKind.Utc).AddTicks(3770), new DateTime(2023, 1, 19, 13, 36, 23, 544, DateTimeKind.Utc).AddTicks(5764), new Guid("09127902-7261-46ce-a6c1-063681635971"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("a41c736f-e312-be92-bab2-8b66ba608ea5") },
                    { new Guid("61a9e977-a57e-c987-ca94-d7d5ec0c2af7"), new DateTime(2023, 1, 13, 20, 46, 55, 285, DateTimeKind.Utc).AddTicks(1859), new DateTime(2023, 1, 12, 21, 0, 32, 239, DateTimeKind.Utc).AddTicks(7259), new Guid("ae29c1b6-3162-e02c-a235-a77369338165"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("1c685168-a6d6-10c7-3594-1264cfe88c5d") },
                    { new Guid("626a8234-8d06-7de4-582c-1b4b41fd1ad0"), new DateTime(2023, 1, 15, 6, 24, 19, 821, DateTimeKind.Utc).AddTicks(57), new DateTime(2023, 1, 15, 6, 7, 28, 924, DateTimeKind.Utc).AddTicks(648), new Guid("ed22d346-e5cc-9759-1cce-2b19aa2f8e7e"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), new Guid("d6228bf9-3a5c-8357-ab65-3bdc7306fd24") },
                    { new Guid("69d70a92-28a1-db54-445e-8e512792a31f"), new DateTime(2023, 1, 15, 20, 38, 56, 265, DateTimeKind.Utc).AddTicks(6253), new DateTime(2023, 1, 15, 20, 38, 20, 81, DateTimeKind.Utc).AddTicks(8760), new Guid("58f66ccb-a3c8-a581-680e-7d1154310fc7"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("d7e2bb26-9245-41a8-2d82-b3be3e1b3432") },
                    { new Guid("6a0b7945-e313-7702-4ff8-04610e643e41"), new DateTime(2023, 1, 22, 17, 46, 36, 787, DateTimeKind.Utc).AddTicks(3284), new DateTime(2023, 1, 21, 18, 4, 22, 191, DateTimeKind.Utc).AddTicks(8493), new Guid("51dbe856-886e-2eb6-9bc9-4106bac99bf9"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("36afde81-f203-8bb6-b502-73b908328efc") },
                    { new Guid("6a99c2b9-734c-4a9b-11d8-5b9b69712b73"), new DateTime(2023, 1, 29, 1, 47, 2, 309, DateTimeKind.Utc).AddTicks(7898), new DateTime(2023, 1, 29, 1, 26, 20, 220, DateTimeKind.Utc).AddTicks(1851), new Guid("3c52929b-3de6-7026-c31d-7e095c625b2e"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("a46450b9-7d53-cbbc-b12a-5f40fe56fbf7") },
                    { new Guid("6b047afb-ee8d-0520-fc30-759a630c17af"), new DateTime(2023, 1, 29, 10, 53, 33, 870, DateTimeKind.Utc).AddTicks(9951), new DateTime(2023, 1, 29, 10, 44, 19, 466, DateTimeKind.Utc).AddTicks(1959), new Guid("ae29c1b6-3162-e02c-a235-a77369338165"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("c60ae875-bcec-c6d2-b190-b11f93bce6e5") },
                    { new Guid("6bb0d151-867a-7c09-a893-be77bc04b909"), new DateTime(2023, 1, 10, 11, 9, 57, 986, DateTimeKind.Utc).AddTicks(4905), new DateTime(2023, 1, 10, 10, 46, 22, 909, DateTimeKind.Utc).AddTicks(5637), new Guid("b05bfb04-a734-19d6-600d-b53a74a6a716"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), new Guid("83f8f41f-7a58-4370-c478-c687d2de44a8") },
                    { new Guid("6bc1671a-1ab2-6d1c-0c83-fab16a1a15ff"), new DateTime(2023, 1, 8, 10, 40, 15, 445, DateTimeKind.Utc).AddTicks(2227), new DateTime(2023, 1, 8, 10, 18, 30, 81, DateTimeKind.Utc).AddTicks(5915), new Guid("09127902-7261-46ce-a6c1-063681635971"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("e1f4bf2b-5b92-2417-30c1-6366da03f928") },
                    { new Guid("6f95b226-4298-5bbe-62a5-ff4b16966a1c"), new DateTime(2023, 1, 17, 6, 26, 55, 123, DateTimeKind.Utc).AddTicks(6321), new DateTime(2023, 1, 17, 6, 14, 27, 508, DateTimeKind.Utc).AddTicks(400), new Guid("e901d463-5eba-a201-1af6-d52ea3ed1eca"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("f83d95af-1eb3-3cb0-c3ab-016015fbd6a1") },
                    { new Guid("739bdafd-5a95-4db6-eadb-ea4d62eef73f"), new DateTime(2023, 1, 24, 4, 54, 41, 179, DateTimeKind.Utc).AddTicks(7999), new DateTime(2023, 1, 24, 4, 35, 37, 568, DateTimeKind.Utc).AddTicks(3786), new Guid("964de9f9-e59c-63d9-f92b-ecbe6651c609"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("49b6227d-c666-e240-0bfc-fb6cefe517c1") },
                    { new Guid("73a53dd8-629e-7eee-db91-8cdc60684b67"), new DateTime(2023, 1, 18, 15, 29, 30, 898, DateTimeKind.Utc).AddTicks(6378), new DateTime(2023, 1, 17, 15, 30, 3, 975, DateTimeKind.Utc).AddTicks(3377), new Guid("bec3b223-ab01-6d60-c952-23cef257312d"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("ae29c1b6-3162-e02c-a235-a77369338165") },
                    { new Guid("77883dbe-2043-98a1-ef26-c7132db5db84"), new DateTime(2023, 1, 3, 14, 42, 22, 431, DateTimeKind.Utc).AddTicks(2160), new DateTime(2023, 1, 3, 14, 23, 10, 663, DateTimeKind.Utc).AddTicks(6969), new Guid("a1747828-9ca1-9463-627b-a071f0553fe6"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("3fa7775f-d4c2-fe4f-29b4-2c90f262a20f") },
                    { new Guid("798cc9aa-8376-c7e9-07f6-0f241c990120"), new DateTime(2023, 1, 2, 16, 29, 48, 774, DateTimeKind.Utc).AddTicks(6115), new DateTime(2023, 1, 1, 16, 53, 39, 659, DateTimeKind.Utc).AddTicks(3797), new Guid("f83d95af-1eb3-3cb0-c3ab-016015fbd6a1"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("03c9f600-7b8a-832c-6b08-84e780aadc91") },
                    { new Guid("7a13e967-f1b2-9e6e-b45f-a1204d7e9d4d"), new DateTime(2023, 1, 10, 15, 27, 11, 473, DateTimeKind.Utc).AddTicks(9619), new DateTime(2023, 1, 9, 15, 40, 36, 260, DateTimeKind.Utc).AddTicks(2511), new Guid("bc267cd5-ce98-812f-7dfc-e62f3bd1d180"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("32a0e9d6-4031-5a92-8580-8b7ff8f1dc29") },
                    { new Guid("7e187b92-5053-ebb7-5616-d2c36e163b6a"), new DateTime(2023, 1, 14, 22, 45, 53, 547, DateTimeKind.Utc).AddTicks(8094), new DateTime(2023, 1, 13, 22, 59, 28, 414, DateTimeKind.Utc).AddTicks(4220), new Guid("20a683ad-9e6c-cdac-5b20-17e29fff1684"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717") },
                    { new Guid("8257c4da-a58d-186a-c700-e9f0006fc948"), new DateTime(2023, 1, 26, 7, 55, 17, 456, DateTimeKind.Utc).AddTicks(3820), new DateTime(2023, 1, 26, 7, 48, 22, 173, DateTimeKind.Utc).AddTicks(6883), new Guid("bc267cd5-ce98-812f-7dfc-e62f3bd1d180"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("5352ba8c-9e8d-346f-bfff-a8842dc7947f") },
                    { new Guid("833c5595-d6da-91c2-903a-b93a70717b0e"), new DateTime(2023, 1, 29, 7, 26, 53, 371, DateTimeKind.Utc).AddTicks(6561), new DateTime(2023, 1, 28, 7, 51, 13, 263, DateTimeKind.Utc).AddTicks(3425), new Guid("845dba0b-1c3b-15aa-d5db-fc85176ea91c"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), new Guid("216c811c-3365-ec83-d9fe-9800686277b1") },
                    { new Guid("864a5955-0325-e16f-a132-6f0c512461dd"), new DateTime(2023, 1, 30, 8, 4, 15, 915, DateTimeKind.Utc).AddTicks(5202), new DateTime(2023, 1, 29, 8, 29, 15, 135, DateTimeKind.Utc).AddTicks(9680), new Guid("d3eb5f43-d318-8d5d-13be-3d6c53b5c287"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("964de9f9-e59c-63d9-f92b-ecbe6651c609") },
                    { new Guid("8709ee20-967e-7e00-914e-a87a607121ed"), new DateTime(2023, 1, 8, 4, 32, 56, 677, DateTimeKind.Utc).AddTicks(8927), new DateTime(2023, 1, 7, 4, 59, 30, 976, DateTimeKind.Utc).AddTicks(3062), new Guid("3a697dc0-d59e-9309-f165-e19bdb903e73"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("62c15cd1-0fca-5dc0-9a06-55d394a2d898") },
                    { new Guid("879589cc-3162-29f4-68cb-057f4d5e699e"), new DateTime(2023, 1, 22, 5, 3, 16, 122, DateTimeKind.Utc).AddTicks(9594), new DateTime(2023, 1, 22, 5, 1, 46, 190, DateTimeKind.Utc).AddTicks(3398), new Guid("09127902-7261-46ce-a6c1-063681635971"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("3c52929b-3de6-7026-c31d-7e095c625b2e") },
                    { new Guid("8953e056-98c6-0d4a-17e5-7a075907d5e2"), new DateTime(2023, 1, 15, 8, 52, 23, 228, DateTimeKind.Utc).AddTicks(1164), new DateTime(2023, 1, 14, 9, 12, 29, 785, DateTimeKind.Utc).AddTicks(2558), new Guid("f83d95af-1eb3-3cb0-c3ab-016015fbd6a1"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("58f66ccb-a3c8-a581-680e-7d1154310fc7") },
                    { new Guid("8d19ad76-2bfd-19d0-7226-71f018e7e661"), new DateTime(2023, 1, 20, 23, 5, 19, 205, DateTimeKind.Utc).AddTicks(6334), new DateTime(2023, 1, 19, 23, 27, 58, 836, DateTimeKind.Utc).AddTicks(6845), new Guid("d32fe062-0e6b-a9dd-2d43-e3195563abdd"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("bec3b223-ab01-6d60-c952-23cef257312d") },
                    { new Guid("8da07ed4-1d20-4912-15bf-167aef628b2f"), new DateTime(2023, 1, 5, 19, 55, 34, 389, DateTimeKind.Utc).AddTicks(7520), new DateTime(2023, 1, 4, 20, 17, 11, 675, DateTimeKind.Utc).AddTicks(5699), new Guid("58f66ccb-a3c8-a581-680e-7d1154310fc7"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("edc1402a-3370-f890-284b-e9c5ef2b12eb") },
                    { new Guid("98a70476-b266-55b2-966e-dc91a9c240d2"), new DateTime(2023, 1, 20, 13, 29, 22, 920, DateTimeKind.Utc).AddTicks(7535), new DateTime(2023, 1, 19, 13, 34, 4, 462, DateTimeKind.Utc).AddTicks(7267), new Guid("5ff50fdd-00de-77e3-9e84-8a017739d1dc"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717") },
                    { new Guid("a05d13ea-a05e-f9dc-ef46-39631df28713"), new DateTime(2023, 1, 23, 17, 37, 56, 798, DateTimeKind.Utc).AddTicks(2209), new DateTime(2023, 1, 22, 18, 4, 46, 325, DateTimeKind.Utc).AddTicks(5004), new Guid("51dbe856-886e-2eb6-9bc9-4106bac99bf9"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("e8a69852-6982-4bc2-d038-659d7459d2d2") },
                    { new Guid("a1242af1-118c-5177-0898-f054dfca7ca5"), new DateTime(2023, 1, 19, 4, 7, 38, 248, DateTimeKind.Utc).AddTicks(7217), new DateTime(2023, 1, 18, 4, 26, 4, 87, DateTimeKind.Utc).AddTicks(1725), new Guid("213608f2-53eb-fa3c-064a-26cd5eaaa713"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("8a4f5c9b-c14d-3923-110b-d614f8c180e7") },
                    { new Guid("a3fb72ae-7134-5322-0823-629bee1603d8"), new DateTime(2023, 1, 6, 10, 44, 0, 375, DateTimeKind.Utc).AddTicks(536), new DateTime(2023, 1, 5, 10, 57, 0, 998, DateTimeKind.Utc).AddTicks(1329), new Guid("26d9ff62-1887-9a43-cb94-740d541f22ce"), new Guid("ccfcc9e2-5809-8aba-7fb8-87de374bd9ea"), new Guid("6ae094dd-0331-6682-b745-30deecc85579") },
                    { new Guid("a87108f9-6c51-854d-d608-9a1b91033e12"), new DateTime(2023, 1, 7, 13, 32, 21, 444, DateTimeKind.Utc).AddTicks(2193), new DateTime(2023, 1, 6, 13, 56, 55, 191, DateTimeKind.Utc).AddTicks(5573), new Guid("b805d93f-4168-a614-c8e2-a48401d53a6a"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("7108d887-76ee-5bd3-e742-f4ec88a01684") },
                    { new Guid("a8fe1c1d-91fc-e3f0-8ad8-99bb3a76a597"), new DateTime(2023, 1, 21, 19, 6, 3, 920, DateTimeKind.Utc).AddTicks(4801), new DateTime(2023, 1, 21, 18, 55, 16, 783, DateTimeKind.Utc).AddTicks(6054), new Guid("20a683ad-9e6c-cdac-5b20-17e29fff1684"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("316cdda5-4b93-59ed-3196-5b81f60f65e8") },
                    { new Guid("ac587955-1616-1a09-6538-01bcf0bfa2e1"), new DateTime(2023, 1, 26, 3, 9, 22, 927, DateTimeKind.Utc).AddTicks(214), new DateTime(2023, 1, 26, 2, 40, 14, 325, DateTimeKind.Utc).AddTicks(8934), new Guid("815becb2-4854-b3f6-1b77-213cc5eee7d2"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("b05bfb04-a734-19d6-600d-b53a74a6a716") },
                    { new Guid("ae27c4d5-8e7c-4251-45cd-d3119898b013"), new DateTime(2023, 1, 2, 18, 38, 16, 144, DateTimeKind.Utc).AddTicks(7907), new DateTime(2023, 1, 2, 18, 35, 59, 22, DateTimeKind.Utc).AddTicks(2013), new Guid("2f1fa003-a663-e904-080e-9cc152cfdd82"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("d3eb5f43-d318-8d5d-13be-3d6c53b5c287") },
                    { new Guid("ae6592b8-a677-5e36-4760-17cb26a6367b"), new DateTime(2023, 1, 3, 16, 36, 22, 808, DateTimeKind.Utc).AddTicks(3276), new DateTime(2023, 1, 3, 16, 18, 1, 123, DateTimeKind.Utc).AddTicks(5398), new Guid("316cdda5-4b93-59ed-3196-5b81f60f65e8"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("49fc59bc-fc35-e2ff-5f0a-ceaf0939b700") },
                    { new Guid("b16729d6-48e1-8e33-56ae-69a5296a65fb"), new DateTime(2023, 1, 22, 8, 49, 51, 615, DateTimeKind.Utc).AddTicks(3051), new DateTime(2023, 1, 22, 8, 29, 5, 194, DateTimeKind.Utc).AddTicks(7965), new Guid("edc1402a-3370-f890-284b-e9c5ef2b12eb"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("49e7d14c-7d36-e1a7-60c3-2aa25a3093da") },
                    { new Guid("b295cc2e-2e75-487f-e4c8-2c8c448b1126"), new DateTime(2023, 1, 23, 23, 4, 18, 674, DateTimeKind.Utc).AddTicks(5666), new DateTime(2023, 1, 22, 23, 22, 2, 352, DateTimeKind.Utc).AddTicks(5245), new Guid("518ba440-01e9-8225-988e-f7ee72ef1b62"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1") },
                    { new Guid("ba4c5ec2-1ade-fbdb-6712-86c7939a1ba4"), new DateTime(2023, 1, 15, 17, 4, 6, 840, DateTimeKind.Utc).AddTicks(483), new DateTime(2023, 1, 15, 16, 49, 3, 164, DateTimeKind.Utc).AddTicks(5143), new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1") },
                    { new Guid("bccf13a8-2248-2d82-d615-dfa16fb907d2"), new DateTime(2023, 1, 23, 7, 33, 32, 616, DateTimeKind.Utc).AddTicks(5203), new DateTime(2023, 1, 22, 7, 50, 37, 988, DateTimeKind.Utc).AddTicks(2087), new Guid("7c38b5dd-68f0-070b-571e-62f20214aac6"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("1a487d75-635c-260c-048e-994bc7e3754b") },
                    { new Guid("bdcf9798-87f4-1721-0a53-c54fdd60379f"), new DateTime(2023, 1, 18, 23, 17, 48, 680, DateTimeKind.Utc).AddTicks(2665), new DateTime(2023, 1, 18, 22, 57, 49, 530, DateTimeKind.Utc).AddTicks(25), new Guid("ed22d346-e5cc-9759-1cce-2b19aa2f8e7e"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("a41c736f-e312-be92-bab2-8b66ba608ea5") },
                    { new Guid("bdfc56d6-57e5-067b-1c3a-1d82b6dd5bf8"), new DateTime(2023, 1, 26, 14, 6, 22, 721, DateTimeKind.Utc).AddTicks(26), new DateTime(2023, 1, 25, 14, 22, 30, 827, DateTimeKind.Utc).AddTicks(8892), new Guid("d32fe062-0e6b-a9dd-2d43-e3195563abdd"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("289110d0-98b3-a713-2fdd-59bf53f22d95") },
                    { new Guid("c26b0047-5121-1885-3c62-696dd108d66f"), new DateTime(2023, 1, 9, 10, 0, 21, 206, DateTimeKind.Utc).AddTicks(1148), new DateTime(2023, 1, 9, 9, 37, 46, 616, DateTimeKind.Utc).AddTicks(496), new Guid("8a4f5c9b-c14d-3923-110b-d614f8c180e7"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("d32fe062-0e6b-a9dd-2d43-e3195563abdd") },
                    { new Guid("c2772a5b-d933-26b9-3f11-ca82d5cb2356"), new DateTime(2023, 1, 3, 17, 45, 23, 878, DateTimeKind.Utc).AddTicks(2977), new DateTime(2023, 1, 3, 17, 35, 8, 17, DateTimeKind.Utc).AddTicks(937), new Guid("6d6c12e3-4e9a-a2d5-218b-52dda8a12ee0"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("49b6227d-c666-e240-0bfc-fb6cefe517c1") },
                    { new Guid("c4629660-07e2-f891-de89-ba4c99e8528a"), new DateTime(2023, 1, 23, 14, 30, 37, 677, DateTimeKind.Utc).AddTicks(1165), new DateTime(2023, 1, 23, 14, 22, 36, 763, DateTimeKind.Utc).AddTicks(1519), new Guid("e1f4bf2b-5b92-2417-30c1-6366da03f928"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("49fc59bc-fc35-e2ff-5f0a-ceaf0939b700") },
                    { new Guid("c6cf4fee-ffb1-a153-7866-d8eb315ffc0d"), new DateTime(2023, 1, 17, 23, 15, 24, 889, DateTimeKind.Utc).AddTicks(7756), new DateTime(2023, 1, 16, 23, 40, 39, 327, DateTimeKind.Utc).AddTicks(1854), new Guid("236db095-f9d4-dfb6-ee3b-935e5aca2f06"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("3a697dc0-d59e-9309-f165-e19bdb903e73") },
                    { new Guid("c6e9611c-a9f2-a61a-9de6-ac60f8c66c64"), new DateTime(2023, 1, 17, 9, 56, 24, 518, DateTimeKind.Utc).AddTicks(5698), new DateTime(2023, 1, 16, 10, 0, 56, 486, DateTimeKind.Utc).AddTicks(9379), new Guid("0ecb763b-465f-daef-3c12-8d23c6a218c1"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717") },
                    { new Guid("c71dbfb0-b4e0-84d7-b8a4-2f6eb0a524df"), new DateTime(2023, 1, 3, 1, 15, 31, 400, DateTimeKind.Utc).AddTicks(7946), new DateTime(2023, 1, 2, 1, 37, 41, 60, DateTimeKind.Utc).AddTicks(2158), new Guid("e901d463-5eba-a201-1af6-d52ea3ed1eca"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("92f94545-ce92-123d-9836-f7b9f4b948bb") },
                    { new Guid("c9216123-d766-5465-5a3e-74f302ac8f9b"), new DateTime(2023, 1, 12, 19, 15, 30, 377, DateTimeKind.Utc).AddTicks(2641), new DateTime(2023, 1, 11, 19, 38, 9, 664, DateTimeKind.Utc).AddTicks(5545), new Guid("1c685168-a6d6-10c7-3594-1264cfe88c5d"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("49fc59bc-fc35-e2ff-5f0a-ceaf0939b700") },
                    { new Guid("cb37ba62-4922-d800-719c-ef1da917e438"), new DateTime(2023, 1, 3, 13, 51, 43, 298, DateTimeKind.Utc).AddTicks(3158), new DateTime(2023, 1, 3, 13, 35, 52, 784, DateTimeKind.Utc).AddTicks(286), new Guid("b52028ea-9cfd-bdaf-3f49-6b0b069d95c1"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("58fd3a9c-75dd-c357-b3e1-04749f29a7dc") },
                    { new Guid("cda818ed-8326-a6dc-bd30-361e0a605254"), new DateTime(2023, 1, 8, 5, 53, 4, 465, DateTimeKind.Utc).AddTicks(5026), new DateTime(2023, 1, 7, 6, 0, 43, 209, DateTimeKind.Utc).AddTicks(8945), new Guid("6e0c5b5e-6e19-824d-7965-bacbc13b7e49"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("a0c1a772-8d09-7a6a-6994-43e12599c587") },
                    { new Guid("d28254dc-008e-72ae-7ca8-29f4a253f9ce"), new DateTime(2023, 1, 17, 11, 5, 47, 462, DateTimeKind.Utc).AddTicks(3945), new DateTime(2023, 1, 17, 10, 41, 16, 416, DateTimeKind.Utc).AddTicks(9548), new Guid("6d6c12e3-4e9a-a2d5-218b-52dda8a12ee0"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("4fd05d6c-3951-3e49-377b-1830a850b833") },
                    { new Guid("d2b783c9-8fea-0da5-f546-deeace9954c2"), new DateTime(2023, 1, 3, 4, 10, 38, 356, DateTimeKind.Utc).AddTicks(2883), new DateTime(2023, 1, 3, 3, 53, 19, 548, DateTimeKind.Utc).AddTicks(2300), new Guid("6ae094dd-0331-6682-b745-30deecc85579"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("4fd05d6c-3951-3e49-377b-1830a850b833") },
                    { new Guid("d54ef8f0-6b6e-358a-f603-e928ed4f0850"), new DateTime(2023, 1, 19, 8, 27, 5, 89, DateTimeKind.Utc).AddTicks(4818), new DateTime(2023, 1, 18, 8, 34, 35, 727, DateTimeKind.Utc).AddTicks(5926), new Guid("7c38b5dd-68f0-070b-571e-62f20214aac6"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("3f8ffa80-028a-08db-78b7-f1e6fe318ef7") },
                    { new Guid("d6262411-3f4c-1672-11d2-c1e42024512b"), new DateTime(2023, 1, 10, 13, 14, 55, 486, DateTimeKind.Utc).AddTicks(7208), new DateTime(2023, 1, 9, 13, 15, 57, 595, DateTimeKind.Utc).AddTicks(207), new Guid("615db99a-1b12-507b-734f-e2229097f81c"), new Guid("5ea81455-0ff2-cf92-8e8d-954a8d558734"), new Guid("213608f2-53eb-fa3c-064a-26cd5eaaa713") },
                    { new Guid("d7812b07-7a91-ab51-6d95-b24c8e3478e2"), new DateTime(2023, 1, 12, 5, 38, 23, 707, DateTimeKind.Utc).AddTicks(5662), new DateTime(2023, 1, 12, 5, 12, 18, 34, DateTimeKind.Utc).AddTicks(2058), new Guid("e8a69852-6982-4bc2-d038-659d7459d2d2"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("df70e319-c4cd-9963-dde7-ad5496c66e77") },
                    { new Guid("d9b2cc4e-c032-090d-6a08-7c8e0bf346fb"), new DateTime(2023, 1, 2, 9, 13, 0, 671, DateTimeKind.Utc).AddTicks(730), new DateTime(2023, 1, 2, 9, 3, 0, 810, DateTimeKind.Utc).AddTicks(3484), new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("9988c5b2-6ac4-b3cf-ee49-952691688933") },
                    { new Guid("dac49789-df84-7623-73dd-8f286137e7c9"), new DateTime(2023, 1, 25, 17, 57, 40, 868, DateTimeKind.Utc).AddTicks(5982), new DateTime(2023, 1, 24, 18, 14, 8, 790, DateTimeKind.Utc).AddTicks(1410), new Guid("b93332e1-21e1-85a9-ffd5-81afd50083cb"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("36afde81-f203-8bb6-b502-73b908328efc") },
                    { new Guid("de452a89-5a71-151e-d90d-931a82191cbe"), new DateTime(2023, 1, 14, 22, 44, 52, 127, DateTimeKind.Utc).AddTicks(4952), new DateTime(2023, 1, 13, 22, 57, 20, 211, DateTimeKind.Utc).AddTicks(902), new Guid("efbff604-380c-8625-c308-218f15bcd476"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("1a053781-6433-57af-f547-1ebfbd2bfe3e") },
                    { new Guid("dfad176a-f7d4-16b3-d535-2ea47d3dea71"), new DateTime(2023, 1, 13, 21, 21, 53, 157, DateTimeKind.Utc).AddTicks(5365), new DateTime(2023, 1, 13, 21, 8, 27, 976, DateTimeKind.Utc).AddTicks(1903), new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("e1f4bf2b-5b92-2417-30c1-6366da03f928") },
                    { new Guid("e05b1e7e-270e-07af-845c-a0dd170a0597"), new DateTime(2023, 1, 18, 0, 54, 33, 934, DateTimeKind.Utc).AddTicks(1166), new DateTime(2023, 1, 17, 1, 7, 0, 784, DateTimeKind.Utc).AddTicks(8710), new Guid("83f8f41f-7a58-4370-c478-c687d2de44a8"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), new Guid("b93332e1-21e1-85a9-ffd5-81afd50083cb") },
                    { new Guid("e400bdd4-1982-50ca-4607-f575f4bda7ba"), new DateTime(2023, 1, 4, 2, 18, 37, 228, DateTimeKind.Utc).AddTicks(3429), new DateTime(2023, 1, 3, 2, 31, 27, 123, DateTimeKind.Utc).AddTicks(2740), new Guid("bec3b223-ab01-6d60-c952-23cef257312d"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("d574ecbb-e31b-fbba-f81b-123d28306a6f") },
                    { new Guid("e480d992-3d80-d59f-a808-1d0b89095725"), new DateTime(2023, 1, 18, 17, 45, 31, 858, DateTimeKind.Utc).AddTicks(3227), new DateTime(2023, 1, 17, 17, 57, 42, 796, DateTimeKind.Utc).AddTicks(3494), new Guid("24236ed8-e2af-45ff-95ce-c77cc793f831"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("5352ba8c-9e8d-346f-bfff-a8842dc7947f") },
                    { new Guid("e6d88563-890c-9438-4012-5dd3eb6a0e78"), new DateTime(2023, 1, 15, 13, 57, 44, 748, DateTimeKind.Utc).AddTicks(6641), new DateTime(2023, 1, 14, 14, 7, 17, 871, DateTimeKind.Utc).AddTicks(5869), new Guid("edc1402a-3370-f890-284b-e9c5ef2b12eb"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("4cabc058-9ade-47a4-dbf6-e4ed2c99c9c5") },
                    { new Guid("e87ecc4a-d11c-b5b9-7b94-c53a981fba2b"), new DateTime(2023, 1, 11, 2, 22, 4, 894, DateTimeKind.Utc).AddTicks(6240), new DateTime(2023, 1, 11, 2, 7, 54, 101, DateTimeKind.Utc).AddTicks(7180), new Guid("b805d93f-4168-a614-c8e2-a48401d53a6a"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("58f66ccb-a3c8-a581-680e-7d1154310fc7") },
                    { new Guid("e9175281-bb5e-ccbb-5dab-af95d9642499"), new DateTime(2023, 1, 13, 10, 0, 4, 732, DateTimeKind.Utc).AddTicks(3526), new DateTime(2023, 1, 12, 10, 13, 38, 301, DateTimeKind.Utc).AddTicks(8124), new Guid("58fd3a9c-75dd-c357-b3e1-04749f29a7dc"), new Guid("8538059f-1613-ae06-5eff-b46a68ce6415"), new Guid("df70e319-c4cd-9963-dde7-ad5496c66e77") },
                    { new Guid("ea4a618b-7a83-f547-baae-edd5415c7caf"), new DateTime(2023, 1, 24, 17, 57, 8, 865, DateTimeKind.Utc).AddTicks(5398), new DateTime(2023, 1, 24, 17, 30, 37, 260, DateTimeKind.Utc).AddTicks(6777), new Guid("5f8063e9-390f-3ed6-f20f-028edf2b8e95"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("5b6aed0b-8d10-48b9-5510-68d91365661a") },
                    { new Guid("f0f445ef-56e3-44ee-dd55-f13862e447f5"), new DateTime(2023, 1, 14, 13, 31, 4, 50, DateTimeKind.Utc).AddTicks(8365), new DateTime(2023, 1, 14, 13, 10, 41, 980, DateTimeKind.Utc).AddTicks(3336), new Guid("dd76a6ab-7b2e-419e-da37-05f3f12609c7"), new Guid("67b6c90e-8091-4640-01e1-660d1d554352"), new Guid("9056b5bc-f2fc-6ffa-f56a-f5701226825e") },
                    { new Guid("f140cc85-1b0d-251a-9ace-1454a488ecff"), new DateTime(2023, 1, 30, 11, 34, 20, 667, DateTimeKind.Utc).AddTicks(946), new DateTime(2023, 1, 29, 11, 50, 10, 927, DateTimeKind.Utc).AddTicks(348), new Guid("d3eb5f43-d318-8d5d-13be-3d6c53b5c287"), new Guid("b1fe57c4-b9b2-966c-d9b7-952174784d79"), new Guid("a46450b9-7d53-cbbc-b12a-5f40fe56fbf7") },
                    { new Guid("f1807687-275c-2739-c33c-52deeed89c94"), new DateTime(2023, 1, 2, 11, 0, 48, 748, DateTimeKind.Utc).AddTicks(7172), new DateTime(2023, 1, 1, 11, 26, 17, 845, DateTimeKind.Utc).AddTicks(5457), new Guid("9056b5bc-f2fc-6ffa-f56a-f5701226825e"), new Guid("0aac9aea-970d-4c24-2c52-10626a95e60f"), new Guid("7108d887-76ee-5bd3-e742-f4ec88a01684") },
                    { new Guid("f25a5a81-e599-36cd-6b98-89dce5921121"), new DateTime(2023, 1, 24, 9, 56, 45, 47, DateTimeKind.Utc).AddTicks(2287), new DateTime(2023, 1, 24, 9, 37, 30, 255, DateTimeKind.Utc).AddTicks(9492), new Guid("3a697dc0-d59e-9309-f165-e19bdb903e73"), new Guid("c29d1349-d2e0-96e9-1366-ead1db91d7c6"), new Guid("32a0e9d6-4031-5a92-8580-8b7ff8f1dc29") },
                    { new Guid("f521ffa9-17b9-2d2f-2df5-cb5e49e1bce5"), new DateTime(2022, 12, 31, 16, 0, 27, 985, DateTimeKind.Utc).AddTicks(7069), new DateTime(2022, 12, 31, 15, 50, 24, 341, DateTimeKind.Utc).AddTicks(5955), new Guid("92f94545-ce92-123d-9836-f7b9f4b948bb"), new Guid("4974a191-133c-3a0b-2097-9c0ecb31bea7"), new Guid("6d6c12e3-4e9a-a2d5-218b-52dda8a12ee0") },
                    { new Guid("fb9e77d0-7ed3-effa-106b-3a25f59de688"), new DateTime(2023, 1, 23, 21, 40, 18, 420, DateTimeKind.Utc).AddTicks(560), new DateTime(2023, 1, 23, 21, 20, 22, 512, DateTimeKind.Utc).AddTicks(5701), new Guid("678d1793-bef0-c597-3e44-711d34d0f3e6"), new Guid("7f29b357-48f2-2d74-d8d9-9108fe8a0ff9"), new Guid("9056b5bc-f2fc-6ffa-f56a-f5701226825e") },
                    { new Guid("ff4c0ff5-6287-3af1-333f-89d8392abfb7"), new DateTime(2023, 1, 18, 17, 8, 43, 981, DateTimeKind.Utc).AddTicks(8464), new DateTime(2023, 1, 17, 17, 8, 48, 795, DateTimeKind.Utc).AddTicks(4122), new Guid("413e5611-0f3b-4b29-918e-9e2b8daf0717"), new Guid("85bb2a8f-44bc-0303-7f3c-f582a2c42134"), new Guid("6ae094dd-0331-6682-b745-30deecc85579") }
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
                name: "routes");

            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "planes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
