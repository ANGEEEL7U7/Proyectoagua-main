using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyectoagua.Migrations
{
    public partial class ProyectoEscolar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medidores",
                columns: table => new
                {
                    Id_Medidor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proveedor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medidores", x => x.Id_Medidor);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id_Empresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rfc = table.Column<int>(type: "int", nullable: false),
                    Nombre_E = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contasenia_E = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ubicacion_E = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_Regristro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Medidor_E = table.Column<int>(type: "int", nullable: false),
                    Correo_E = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedidoresId_Medidor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id_Empresa);
                    table.ForeignKey(
                        name: "FK_Empresas_Medidores_MedidoresId_Medidor",
                        column: x => x.MedidoresId_Medidor,
                        principalTable: "Medidores",
                        principalColumn: "Id_Medidor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id_us = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    domicilio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Medidor = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedidoresId_Medidor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id_us);
                    table.ForeignKey(
                        name: "FK_Usuarios_Medidores_MedidoresId_Medidor",
                        column: x => x.MedidoresId_Medidor,
                        principalTable: "Medidores",
                        principalColumn: "Id_Medidor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BlogEmpresas",
                columns: table => new
                {
                    Id_BlogEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlFoto_E = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uso_Agua_E = table.Column<double>(type: "float", nullable: false),
                    Ubicacion_E = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opinion_E = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_empresa = table.Column<int>(type: "int", nullable: false),
                    Id_Medidor_fk_E = table.Column<int>(type: "int", nullable: false),
                    MedidoresId_Medidor = table.Column<int>(type: "int", nullable: true),
                    EmpresasId_Empresa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogEmpresas", x => x.Id_BlogEmpresa);
                    table.ForeignKey(
                        name: "FK_BlogEmpresas_Empresas_EmpresasId_Empresa",
                        column: x => x.EmpresasId_Empresa,
                        principalTable: "Empresas",
                        principalColumn: "Id_Empresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlogEmpresas_Medidores_MedidoresId_Medidor",
                        column: x => x.MedidoresId_Medidor,
                        principalTable: "Medidores",
                        principalColumn: "Id_Medidor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id_Blog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlFoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uso_Agua = table.Column<double>(type: "float", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_usuario = table.Column<int>(type: "int", nullable: false),
                    Id_Medidor_fk = table.Column<int>(type: "int", nullable: false),
                    MedidoresId_Medidor = table.Column<int>(type: "int", nullable: true),
                    UsuariosId_us = table.Column<int>(type: "int", nullable: true),
                    EmpresasId_Empresa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id_Blog);
                    table.ForeignKey(
                        name: "FK_Blogs_Empresas_EmpresasId_Empresa",
                        column: x => x.EmpresasId_Empresa,
                        principalTable: "Empresas",
                        principalColumn: "Id_Empresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blogs_Medidores_MedidoresId_Medidor",
                        column: x => x.MedidoresId_Medidor,
                        principalTable: "Medidores",
                        principalColumn: "Id_Medidor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Blogs_Usuarios_UsuariosId_us",
                        column: x => x.UsuariosId_us,
                        principalTable: "Usuarios",
                        principalColumn: "Id_us",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogEmpresas_EmpresasId_Empresa",
                table: "BlogEmpresas",
                column: "EmpresasId_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_BlogEmpresas_MedidoresId_Medidor",
                table: "BlogEmpresas",
                column: "MedidoresId_Medidor");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_EmpresasId_Empresa",
                table: "Blogs",
                column: "EmpresasId_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_MedidoresId_Medidor",
                table: "Blogs",
                column: "MedidoresId_Medidor");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UsuariosId_us",
                table: "Blogs",
                column: "UsuariosId_us");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_MedidoresId_Medidor",
                table: "Empresas",
                column: "MedidoresId_Medidor");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_MedidoresId_Medidor",
                table: "Usuarios",
                column: "MedidoresId_Medidor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogEmpresas");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Medidores");
        }
    }
}
