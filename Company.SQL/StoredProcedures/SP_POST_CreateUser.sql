CREATE PROCEDURE [dbo].[SP_POST_CreateUser]
    @Usuario NVARCHAR(100),
    @Clave NVARCHAR(100),
    @TipoUsr NVARCHAR(50),
    @Active BIT,
    @Nombre NVARCHAR(100),
    @Img NVARCHAR(MAX),
    @Other NVARCHAR(MAX),
    @PermissionsChecks NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO [dbo].[UsuariosTabla] 
        (Usuario, Clave, TipoUsr, Active, Nombre, Img, Other, PermissionsChecks)
    VALUES 
        (@Usuario, @Clave, @TipoUsr, @Active, @Nombre, @Img, @Other, @PermissionsChecks);
END
