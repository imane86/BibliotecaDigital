using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaDigital.Data.Contexts.Migrations
{
    /// <inheritdoc />
    public partial class relacionar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolUsuario_Roles_RolesId",
                table: "RolUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_RolUsuario_Usuarios_UsuariosId",
                table: "RolUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolUsuario",
                table: "RolUsuario");

            migrationBuilder.RenameTable(
                name: "RolUsuario",
                newName: "UsuarioRoles");

            migrationBuilder.RenameIndex(
                name: "IX_RolUsuario_UsuariosId",
                table: "UsuarioRoles",
                newName: "IX_UsuarioRoles_UsuariosId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioRoles",
                table: "UsuarioRoles",
                columns: new[] { "RolesId", "UsuariosId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRoles_Roles_RolesId",
                table: "UsuarioRoles",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRoles_Usuarios_UsuariosId",
                table: "UsuarioRoles",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRoles_Roles_RolesId",
                table: "UsuarioRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRoles_Usuarios_UsuariosId",
                table: "UsuarioRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioRoles",
                table: "UsuarioRoles");

            migrationBuilder.RenameTable(
                name: "UsuarioRoles",
                newName: "RolUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioRoles_UsuariosId",
                table: "RolUsuario",
                newName: "IX_RolUsuario_UsuariosId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolUsuario",
                table: "RolUsuario",
                columns: new[] { "RolesId", "UsuariosId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RolUsuario_Roles_RolesId",
                table: "RolUsuario",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolUsuario_Usuarios_UsuariosId",
                table: "RolUsuario",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
