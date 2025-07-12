using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_venta.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Churrascos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCarne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Termino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamaño = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Porciones = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Churrascos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCombo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DulcesTipicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDulce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Empaque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadEnCaja = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DulcesTipicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guarniciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guarniciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreIngrediente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoIngrediente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComboChurrascos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComboId = table.Column<int>(type: "int", nullable: false),
                    ChurrascoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboChurrascos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComboChurrascos_Churrascos_ChurrascoId",
                        column: x => x.ChurrascoId,
                        principalTable: "Churrascos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboChurrascos_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComboDulces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComboId = table.Column<int>(type: "int", nullable: false),
                    DulceTipicoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboDulces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComboDulces_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboDulces_DulcesTipicos_DulceTipicoId",
                        column: x => x.DulceTipicoId,
                        principalTable: "DulcesTipicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChurrascoGuarniciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChurrascoId = table.Column<int>(type: "int", nullable: false),
                    GuarnicionId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChurrascoGuarniciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChurrascoGuarniciones_Churrascos_ChurrascoId",
                        column: x => x.ChurrascoId,
                        principalTable: "Churrascos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChurrascoGuarniciones_Guarniciones_GuarnicionId",
                        column: x => x.GuarnicionId,
                        principalTable: "Guarniciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChurrascoGuarniciones_ChurrascoId",
                table: "ChurrascoGuarniciones",
                column: "ChurrascoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChurrascoGuarniciones_GuarnicionId",
                table: "ChurrascoGuarniciones",
                column: "GuarnicionId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboChurrascos_ChurrascoId",
                table: "ComboChurrascos",
                column: "ChurrascoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboChurrascos_ComboId",
                table: "ComboChurrascos",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboDulces_ComboId",
                table: "ComboDulces",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboDulces_DulceTipicoId",
                table: "ComboDulces",
                column: "DulceTipicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChurrascoGuarniciones");

            migrationBuilder.DropTable(
                name: "ComboChurrascos");

            migrationBuilder.DropTable(
                name: "ComboDulces");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropTable(
                name: "Guarniciones");

            migrationBuilder.DropTable(
                name: "Churrascos");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "DulcesTipicos");
        }
    }
}
