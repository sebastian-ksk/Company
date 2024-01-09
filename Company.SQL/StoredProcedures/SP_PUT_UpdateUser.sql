CREATE PROCEDURE [dbo].[SP_PUT_UpdateUser]
    @Id INT,
    @Usuario NVARCHAR(100),
    @Clave NVARCHAR(100),
    @TipoUsr NVARCHAR(50),
    @Nombre NVARCHAR(100),
    @Img NVARCHAR(MAX),
    @Other NVARCHAR(MAX),
    @PermissionsChecks NVARCHAR(MAX)
AS
BEGIN
    UPDATE [dbo].[UsuariosTabla]
    SET 
        Usuario = @Usuario,
        Clave = @Clave,
        TipoUsr = @TipoUsr,
        Nombre = @Nombre,
        Img = @Img,
        Other = @Other,
        PermissionsChecks = @PermissionsChecks
    WHERE Id = @Id;
END
